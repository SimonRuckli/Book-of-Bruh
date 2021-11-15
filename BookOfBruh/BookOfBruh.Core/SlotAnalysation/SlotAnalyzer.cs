using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BookOfBruh.Core.Symbols;

namespace BookOfBruh.Core.SlotAnalysation
{
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
                const int first = 0;
                ISymbol firstSymbol = slots.Symbols[first, y];
                List<Point> points = GetSameSymbolPoints(firstSymbol, slots);
                points.Add(new Point(first,y));

                List<Pattern> patterns = this.patternMatcher.FindMatches(points);

                List<int> patternCounts = patterns.Select(pattern => pattern.Value.Count).ToList();

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
            }

            return multiplier;
        }

        private static List<Point> GetSameSymbolPoints(ISymbol slotsSymbol, Slots slots)
        {
            List<Point> points = new List<Point>();

            const int ignoreFirst = 1;
            
            for (int y = 0; y < slots.Rows; y++)
            {
                for (int x = ignoreFirst; x < slots.Columns; x++)
                {
                    if (slots.Symbols[x, y].GetType() == slotsSymbol.GetType())
                    {
                        points.Add(new Point(x, y));
                    }
                }
            }

            return points;
        }
    }
}
