namespace BookOfBruh.Core.SlotAnalysation.PatternMatchers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public interface ITrianglePatternMatcher
    {
        List<Point> FindMatchesAt(int position, int direction, List<Point> input);
    }

    public class TrianglePatternMatcher : ITrianglePatternMatcher
    {
        public List<Point> FindMatchesAt(int position, int direction, List<Point> input)
        {
            List<Point> pointsAtColumn = input.Where(point => point.X == position).ToList(); // one or none

            if (pointsAtColumn.Count == 0)
            {
                return new List<Point>();
            }

            Point firstPoint = pointsAtColumn.First();

            List<Point> trianglePattern = new() { firstPoint };

            Point lastPoint = firstPoint;

            foreach (Point point in input
                                    .Where(point => IsOneColumnFartherThan(point, lastPoint))
                                    .Where(point => IsPointInSameRowOrRowInDirectionOf(point, firstPoint, direction))
                                    .Where(point => IsPointInOtherRowThan(point, lastPoint)))
            {
                trianglePattern.Add(point);
                lastPoint = point;
            }

            if (trianglePattern.Count == 4)
            {
                trianglePattern.RemoveAt(trianglePattern.Count - 1);
            }

            return trianglePattern.Count >= 3 ? trianglePattern : new List<Point>();
        }

        private static bool IsOneColumnFartherThan(Point point, Point last)
        {
            return point.X == last.X + 1;
        }

        private static bool IsPointInSameRowOrRowInDirectionOf(Point point, Point firstPoint, int direction)
        {
            return point.Y == firstPoint.Y || point.Y == firstPoint.Y + direction;
        }

        private static bool IsPointInOtherRowThan(Point point, Point lastPoint)
        {
            return point.Y == lastPoint.Y + 1 || point.Y == lastPoint.Y - 1;
        }
    }
}