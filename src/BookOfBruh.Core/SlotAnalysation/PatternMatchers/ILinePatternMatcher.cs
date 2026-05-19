namespace BookOfBruh.Core.SlotAnalysation.PatternMatchers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public interface ILinePatternMatcher
    {
        List<Point> FindMatchesAt(int position, List<Point> input);
    }

    public class LinePatternMatcher : ILinePatternMatcher
    {
        public List<Point> FindMatchesAt(int position, List<Point> input)
        {
            Point firstPoint = input.First(point => point.X == position);

            List<Point> linePattern = new() { firstPoint };

            Point lastPoint = firstPoint;

            foreach (Point point in input
                                    .Where(point => IsOneColumnFarther(point, lastPoint))
                                    .Where(point => IsInSameRowAsFirstPoint(point, firstPoint)))
            {
                linePattern.Add(point);
                lastPoint = point;
            }

            return linePattern.Count >= 3 ? linePattern : new List<Point>();
        }

        private static bool IsOneColumnFarther(Point point, Point lastPoint)
        {
            return point.X == lastPoint.X + 1;
        }

        private static bool IsInSameRowAsFirstPoint(Point point, Point firstPoint)
        {
            return point.Y == firstPoint.Y;
        }
    }
}