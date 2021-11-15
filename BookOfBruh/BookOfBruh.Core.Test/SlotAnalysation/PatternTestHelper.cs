using System.Drawing;

namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BookOfBruh.Core.SlotAnalysation;

    public class PatternTestHelper
    {
        public static List<Pattern> PatternsFromStringPatterns(string[] stringPatterns)
        {
            return stringPatterns.Select(PatternFromString).ToList();
        }

        private static Pattern PatternFromString(string pattern)
        {
            const char point = 'P';

            List<List<char>> enumerable = pattern.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(line => line.Select(c => c).ToList()).ToList();

            List<Point> validPoints = new List<Point>();

            for (int y = 0; y < enumerable.Count; y++)
            {
                for (int x = 0; x < enumerable[y].Count; x++)
                {
                    if (enumerable[y][x] == point)
                    {
                        validPoints.Add(new Point(x, y));
                    }
                }
            }

            return new Pattern(validPoints);
        }
    }
}