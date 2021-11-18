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

            List<Point> linePattern = new List<Point>() { firstPoint };

            Point lastPoint = firstPoint;

            foreach (Point point in input
                                    .Where(point => point.X == lastPoint.X + 1)
                                    .Where(point => point.Y == lastPoint.Y))
            {
                linePattern.Add(point);
                lastPoint = point;
            }

            return linePattern.Count >= 3 ? linePattern : new List<Point>();
        }
    }
}