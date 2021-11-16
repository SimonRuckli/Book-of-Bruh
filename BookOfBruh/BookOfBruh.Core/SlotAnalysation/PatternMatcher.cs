using System.Linq;

namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using System.Collections.Generic;
    
    public interface IPatternMatcher
    {
        public List<Pattern> FindMatches(List<Point> input);
    }

    public class PatternMatcher : IPatternMatcher
    {
        public List<Pattern> FindMatches(List<Point> input)
        {
            List<Pattern> patterns = new List<Pattern>();
            List<Point> linePattern = FindLinePattern(input);
            List<Point> trianglePattern = FindTrianglePattern(input);

            if (linePattern.Any())
            {
                patterns.Add(new Pattern(linePattern));
            }
            if (trianglePattern.Any())
            {
                patterns.Add(new Pattern(trianglePattern));
            }

            return patterns;
        }

        private static List<Point> FindTrianglePattern(List<Point> input)
        {
            Point firstPoint = input.First(point => point.X == 0);

            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();

            List<Point> trianglePattern = new List<Point>(){firstPoint};
            
            Point lastPoint = firstPoint;

            foreach (Point point in sortedPoints
                .Where(point => point.X == lastPoint.X + 1)
                .Where(point => point.Y == lastPoint.Y+1 || point.Y == lastPoint.Y - 1))
            {
                trianglePattern.Add(point);
                lastPoint = point;
            }

            return trianglePattern.Count >= 3 ? trianglePattern : new List<Point>();
        }

        private static List<Point> FindLinePattern(List<Point> input)
        {
            Point firstPoint = input.First(point => point.X == 0);

            List<Point> linePattern = input.Where(p => p.Y == firstPoint.Y).ToList();

            return linePattern.Count >= 3 ? linePattern : new List<Point>();
        }
    }
}