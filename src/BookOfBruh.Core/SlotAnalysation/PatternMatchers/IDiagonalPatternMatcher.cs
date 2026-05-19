namespace BookOfBruh.Core.SlotAnalysation.PatternMatchers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public interface IDiagonalPatternMatcher
    {
        List<Point> FindMatches(List<Point> input);
    }

    public class DiagonalPatternMatcher : IDiagonalPatternMatcher
    {
        public List<Point> FindMatches(List<Point> input)
        {
            List<Point> diagonalPattern = FindOnlyDiagonalPattern(input, 0);

            if (diagonalPattern.Any())
            {
                diagonalPattern.AddRange(FindOnlyDiagonalPattern(input, 2));
            }

            List<Point> uniquePattern = diagonalPattern.Distinct().ToList();

            return uniquePattern.Count >= 3 ? uniquePattern : new List<Point>();
        }

        private static List<Point> FindOnlyDiagonalPattern(IReadOnlyList<Point> input, int start)
        {
            var diagonal = new List<Point>() { input[start] };

            for (int i = start + 1; i < input.Count; i++)
            {
                if (IsDiagonalPattern(input[i], diagonal))
                {
                    diagonal.Add(input[i]);
                }
            }

            return diagonal.Count >= 3 ? diagonal : new List<Point>();
        }

        private static bool IsDiagonalPattern(Point point, IReadOnlyCollection<Point> diagonal)
        {
            return IsOneColumnFartherThan(point, diagonal.Last()) &&
                   IsOneHigherOrOneLowerThan(point, diagonal.Last()) &&
                   !AnyPreviousPointsOnSameRow(point, diagonal);
        }

        private static bool IsOneColumnFartherThan(Point point, Point last)
        {
            return point.X == last.X + 1;
        }

        private static bool IsOneHigherOrOneLowerThan(Point point, Point last)
        {
            return point.Y == last.Y + 1 || point.Y == last.Y - 1;
        }

        private static bool AnyPreviousPointsOnSameRow(Point point, IEnumerable<Point> diagonal)
        {
            return diagonal.Any(p => p.Y == point.Y);
        }
    }
}