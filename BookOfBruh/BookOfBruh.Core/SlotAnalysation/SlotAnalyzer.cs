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

                List<Point> points = CalculateSameSymbolPoints(slots, firstPoint);

                List<Pattern> patterns = this.patternMatcher.FindMatches(points); 

                List<int> patternCounts = patterns.Select(pattern => pattern.Value.Count).ToList();

                multiplier += CalculateRowMultiplier(patternCounts, slots.Symbols[first, y]);
            }

            return multiplier;
        }
        
        private static List<Point> CalculateSameSymbolPoints(Slots slots, Point firstPoint)
        {
            List<Point> points = new List<Point>() { firstPoint };

            const int ignoreFirst = 1;

            Type firstSymbol = slots.Symbols[firstPoint.X, firstPoint.Y].GetType();

            for (int y = 0; y < slots.Rows; y++)
            {
                for (int x = ignoreFirst; x < slots.Columns; x++)
                {
                    if (slots.Symbols[x, y].GetType() == firstSymbol)
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
