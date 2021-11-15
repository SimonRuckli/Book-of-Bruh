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

            for (int y = 0; y < slots.Rows; y++)
            {
                multiplier += this.CalculateRowValue(slots, y);
            }

            return multiplier;
        }

        private double CalculateRowValue(Slots slots, int row)
        {
            const int first = 0;

            ISymbol firstSymbol = slots.Symbols[first, row];

            List<Pattern> patterns = this.CalculatePatterns(new Point(first, row), slots);

            List<int> patternCounts = patterns.Select(pattern => pattern.Value.Count).ToList();

            return CalculateRowMultiplier(firstSymbol, patternCounts);
        }

        private List<Pattern> CalculatePatterns(Point firstPoint, Slots slots)
        {
            List<Point> points = CalculateSameSymbolPoints(firstPoint, slots);

            return this.patternMatcher.FindMatches(points);
        }

        private static List<Point> CalculateSameSymbolPoints(Point firstPoint, Slots slots)
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

        private static double CalculateRowMultiplier(ISymbol firstSymbol, List<int> patternCounts)
        {
            int multiplier = 0;

            foreach (int patternCount in patternCounts)
            {
                if (patternCount == 5)
                {
                    multiplier += 24 * firstSymbol.Rarity;
                }
                if (patternCount == 4)
                {
                    multiplier += 6 * firstSymbol.Rarity;
                }
                if (patternCount == 3)
                {
                    multiplier += 3 * firstSymbol.Rarity;
                }
            }

            return multiplier;
        }
    }
}
