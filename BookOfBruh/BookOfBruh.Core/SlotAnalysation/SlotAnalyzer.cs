namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Symbols;
    using GameData;

    public interface ISlotAnalyzer
    {
        AnalyzeResult Analyze(Slots slots);
    }

    public class SlotAnalyzer : ISlotAnalyzer
    {
        private readonly IPatternMatcher patternMatcher;

        public SlotAnalyzer(IPatternMatcher patternMatcher)
        {
            this.patternMatcher = patternMatcher;
        }

        public AnalyzeResult Analyze(Slots slots)
        {
            double multiplier = 0;

            List<Pattern> allPatterns = new List<Pattern>();

            const int first = 0;

            for (int y = 0; y < slots.Rows; y++)
            {
                Point firstPoint = new Point(first, y);

                ISymbol type = slots.Symbols[firstPoint.X, firstPoint.Y];

                List<ISymbol> types = new List<ISymbol>();

                if (type is WildSymbol)
                {
                    types = CalculateWildDisguising(firstPoint, slots);
                }
                else
                {
                    types.Add(type);
                }

                foreach (ISymbol symbol in types)
                {
                    List<Point> points = CalculateSameSymbolPoints(slots, firstPoint, symbol);

                    List<Pattern> patterns = this.patternMatcher.FindMatches(points);

                    allPatterns.AddRange(patterns);

                    List<int> patternCounts = patterns.Select(pattern => pattern.Value.Count).ToList();

                    multiplier += CalculateRowMultiplier(patternCounts, symbol);
                }
            }
             
            return new AnalyzeResult(multiplier, allPatterns);
        }

        private static List<ISymbol> CalculateWildDisguising(Point firstPoint, Slots slots)
        {
            List<ISymbol> disguises = new List<ISymbol>();

            Point iterator = new Point(firstPoint.X +1, firstPoint.Y -1);

            if (iterator.Y < 0)
            {
                iterator.Y = 0;
            }

            while (iterator.Y < 3)
            {
                ISymbol currentSymbol = slots.Symbols[iterator.X, iterator.Y];

                if (disguises.All(s => s.GetType() != currentSymbol.GetType()))
                {

                    disguises.Add(currentSymbol);
                }

                iterator.Y++;
            }

            return disguises;
        }

        private static List<Point> CalculateSameSymbolPoints(Slots slots, Point firstPoint, ISymbol template)
        {
            List<Point> points = new List<Point>() { firstPoint };
            
            const int ignoreFirst = 1;
            
            for (int y = 0; y < slots.Rows; y++)
            {
                for (int x = ignoreFirst; x < slots.Columns; x++)
                {
                    ISymbol current = slots.Symbols[x, y];
                    if (current.GetType() == template.GetType() || current is WildSymbol)
                    {
                        points.Add(new Point(x, y));
                    }
                }
            }

            return points;
        }

        private static double CalculateRowMultiplier(List<int> patternCounts, ISymbol firstSymbol)
        {
            double multiplier = 0;

            foreach (int patternCount in patternCounts)
            {
                if (patternCount == 5)
                {
                    multiplier += firstSymbol.Value * 8;
                }
                if (patternCount == 4)
                {
                    multiplier += firstSymbol.Value * 3;
                }
                if (patternCount == 3)
                {
                    multiplier += firstSymbol.Value;
                }
            }

            return multiplier;
        }
    }
}
