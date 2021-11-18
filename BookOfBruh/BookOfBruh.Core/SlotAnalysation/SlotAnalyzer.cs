namespace BookOfBruh.Core.SlotAnalysation
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using BookOfBruh.Core.Symbols;
    using BookOfBruh.Core.GameData;

    public class SlotAnalyzer
    {
        private readonly IPatternMatcher patternMatcher;

        public SlotAnalyzer(IPatternMatcher patternMatcher)
        {
            this.patternMatcher = patternMatcher;
        }

        public double Analyze(Slots slots)
        {
            double multiplier = 0;

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

                    List<int> patternCounts = patterns.Select(pattern => pattern.Value.Count).ToList();

                    multiplier += CalculateRowMultiplier(patternCounts, symbol);
                }
            }

            return multiplier;
        }

        private static List<ISymbol> CalculateWildDisguising(Point firstPoint, Slots slots)
        {
            List<ISymbol> disguises = new List<ISymbol>();

            Point iterater = new Point(firstPoint.X +1, firstPoint.Y -1);

            if (iterater.Y > 0)
            {
                iterater.Y = 0;
            }

            while (iterater.Y < 3)
            {
                ISymbol currentSymbol = slots.Symbols[iterater.X, iterater.Y];

                if (disguises.All(s => s.GetType() != currentSymbol.GetType()))
                {

                    disguises.Add(currentSymbol);
                }

                iterater.Y++;
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
                    if (slots.Symbols[x, y].GetType() == template.GetType())
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
                    multiplier += firstSymbol.Rarity * 8;
                }
                if (patternCount == 4)
                {
                    multiplier += firstSymbol.Rarity * 3;
                }
                if (patternCount == 3)
                {
                    multiplier += firstSymbol.Rarity;
                }
            }

            return multiplier;
        }
    }
}
