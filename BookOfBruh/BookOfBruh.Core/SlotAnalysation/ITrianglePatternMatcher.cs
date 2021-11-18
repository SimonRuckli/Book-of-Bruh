namespace BookOfBruh.Core.SlotAnalysation
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
            List<Point> pointsAtPositon = input.Where(point => point.X == position).ToList();

            if (pointsAtPositon.Count == 0)
            {
                return new List<Point>();
            }

            Point firstPoint = pointsAtPositon.First();

            List<Point> trianglePattern = new List<Point>() { firstPoint };

            Point lastPoint = firstPoint;

            foreach (Point point in input
                                    .Where(point => point.X == lastPoint.X + 1)
                                    .Where(point => point.Y == firstPoint.Y || point.Y == firstPoint.Y + direction)
                                    .Where(point => point.Y == lastPoint.Y + 1 || point.Y == lastPoint.Y - 1))
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
    }
}