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

            var allPatterns = new List<Pattern>();

            const int first = 0;

            for (int y = 0; y < slots.Rows; y++)
            {
                var firstPoint = new Point(first, y);

                List<ISymbol> symbols = CalculateSymbolsInFirstPosition(firstPoint, slots);

                foreach (ISymbol symbol in symbols)
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

        private static List<ISymbol> CalculateSymbolsInFirstPosition(Point firstPoint, Slots slots)
        {
            var symbols = new List<ISymbol>();

            ISymbol symbol = slots.Symbols[firstPoint.X, firstPoint.Y];

            if (symbol is WildSymbol)
            {
                symbols = CalculateWildDisguising(firstPoint, slots);
            }
            else
            {
                symbols.Add(symbol);
            }

            return symbols;
        }

        private static List<ISymbol> CalculateWildDisguising(Point firstPoint, Slots slots)
        {
            var disguises = new List<ISymbol> {new WildSymbol()};

            int nextColumn = firstPoint.X + 1;
            
            for (int y = -1; y <= +1; y++)
            {
                var nextPoint = new Point(nextColumn, firstPoint.Y + y);

                if (IsInRange(nextPoint, slots))
                {
                    ISymbol symbol = slots.Symbols[nextColumn, firstPoint.Y + y];

                    if (symbol is WildSymbol)
                    {
                        disguises.AddRange(CalculateWildDisguising(nextPoint, slots));
                    }
                    else
                    {
                        disguises.Add(symbol);
                    }
                }
            }

            return disguises.Distinct().ToList();
        }

        private static bool IsInRange(Point point, Slots slots)
        {
            if (0 > point.X || point.Y < 0)
            {
                return false;
            }

            if (slots.Columns <= point.X || point.Y >= slots.Rows)
            {
                return false;
            }

            return true;
        }

        private static List<Point> CalculateSameSymbolPoints(Slots slots, Point firstPoint, ISymbol template)
        {
            var points = new List<Point>() { firstPoint };
            
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
