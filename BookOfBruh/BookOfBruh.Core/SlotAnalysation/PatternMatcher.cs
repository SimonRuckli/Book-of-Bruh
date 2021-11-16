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
            List<Point> trianglePatternUp = FindTrianglePattern(input, 1);
            List<Point> trianglePatternDown = FindTrianglePattern(input, -1);
            List<Point> diagonalPattern = FindDiagonalPattern(input);

            if (linePattern.Any())
            {
                patterns.Add(new Pattern(linePattern));
            }
            if (trianglePatternUp.Any())
            {
                patterns.Add(new Pattern(trianglePatternUp));
            }
            if (trianglePatternDown.Any())
            {
                patterns.Add(new Pattern(trianglePatternDown));
            }
            if (diagonalPattern.Any())
            {
                patterns.Add(new Pattern(diagonalPattern));
            }

            return patterns;
        }

        private static List<Point> FindDiagonalPattern(List<Point> input)
        {
            Point firstPoint = input.First(point => point.X == 0);

            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();

            List<Point> diagonalPattern = new List<Point>() { firstPoint };
            
            for (int i = 1; i < sortedPoints.Count; i++)
            {
                Point current = sortedPoints[i];
                if (current == new Point(1,1))
                {
                    diagonalPattern.Add(current);
                }
                if (current == new Point(2,2))
                {
                    diagonalPattern.Add(current);
                }
                if (current == new Point(3,1))
                {
                    diagonalPattern.Add(current);
                }
                if (current == new Point(4,0))
                {
                    diagonalPattern.Add(current);
                }
            }

            return diagonalPattern.Count >= 3 ? diagonalPattern : new List<Point>();
        }

        private static List<Point> FindTrianglePattern(List<Point> input, int direction)
        {
            Point firstPoint = input.First(point => point.X == 0);

            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();

            List<Point> trianglePattern = new List<Point>(){firstPoint};
            
            Point lastPoint = firstPoint;
            
            foreach (Point point in sortedPoints
                .Where(point => point.X == lastPoint.X + 1)
                .Where(point => point.Y == firstPoint.Y || point.Y == firstPoint.Y + direction)
                .Where(point => point.Y == lastPoint.Y + 1 || point.Y == lastPoint.Y - 1))
            {
                trianglePattern.Add(point);
                lastPoint = point;
            }

            return trianglePattern.Count >= 3 ? trianglePattern : new List<Point>();
        }

        private static List<Point> FindLinePattern(List<Point> input)
        {
            Point firstPoint = input.First(point => point.X == 0);

            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();

            List<Point> linePattern = new List<Point>() { firstPoint };

            Point lastPoint = firstPoint;

            foreach (Point point in sortedPoints
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