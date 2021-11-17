namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using System.Collections.Generic;
    using System.Linq;

    public class PatternMatcher : IPatternMatcher
    {
        public List<Pattern> FindMatches(List<Point> input)
        {
            List<Pattern> patterns = new List<Pattern>();

            List<Point> linePattern = FindLinePattern(input);
            List<Point> trianglePatternUp = FindTrianglePatternUp(input);
            List<Point> trianglePatternDown = FindTrianglePatternDown(input);
            List<Point> diagonalPattern = FindDiagonalPattern(input);
            List<Point> uPatternUp = FindUPatternUp(input);
            List<Point> uPatternDown = FindUPatternDown(input);
            List<Point> flashPatternUp = FindFlashPatternUp(input);
            List<Point> flashPatternDown = FindFlashPatternDown(input);

            if (linePattern.Any())
            {
                patterns.Add(new Pattern(linePattern));
            }
            if (trianglePatternUp.Any())
            {
                if ((trianglePatternUp.Count == 3 && flashPatternUp.Any()) == false)
                {
                    patterns.Add(new Pattern(trianglePatternUp));
                }
            }
            if (trianglePatternDown.Any())
            {
                if ((trianglePatternDown.Count == 3 && flashPatternDown.Any()) == false)
                {
                    patterns.Add(new Pattern(trianglePatternDown));
                }
            }
            if (diagonalPattern.Any())
            {
                patterns.Add(new Pattern(diagonalPattern));
            }
            if (uPatternUp.Any())
            {
                patterns.Add(new Pattern(uPatternUp));
            }
            if (uPatternDown.Any())
            {
                patterns.Add(new Pattern(uPatternDown));
            }
            if (flashPatternUp.Any())
            {
                patterns.Add(new Pattern(flashPatternUp));
            }
            if (flashPatternDown.Any())
            {
                patterns.Add(new Pattern(flashPatternDown));
            }

            return patterns;
        }

        private static List<Point> FindFlashPatternDown(IEnumerable<Point> input)
        {
            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();
            return FindFlashPattern(sortedPoints, -1);
        }

        private static List<Point> FindFlashPatternUp(IEnumerable<Point> input)
        {
            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();
            return FindFlashPattern(sortedPoints, 1);
        }

        private static List<Point> FindUPatternDown(IEnumerable<Point> input)
        {
            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();
            return FindUPattern(sortedPoints, -1);
        }

        private static List<Point> FindUPatternUp(IEnumerable<Point> input)
        {
            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();
            return FindUPattern(sortedPoints, 1);
        }

        private static List<Point> FindLinePattern(IEnumerable<Point> input)
        {
            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();
            return FindLinePatternAt(sortedPoints, 0);
        }

        private static List<Point> FindTrianglePatternDown(IEnumerable<Point> input)
        {
            return FindTrianglePattern(input, -1);
        }

        private static List<Point> FindTrianglePatternUp(IEnumerable<Point> input)
        {
            return FindTrianglePattern(input, 1);
        }

        private static List<Point> FindFlashPattern(IReadOnlyCollection<Point> sortedInput, int direction)
        {
            List<Point> flashPattern = new List<Point>();

            List<Point> firstTriangle = FindTrianglePatternAt(0, sortedInput, direction);
            List<Point> secondTriangle = FindTrianglePatternAt(2, sortedInput, direction * -1);

            if (firstTriangle.Count > 3)
            {
                firstTriangle = firstTriangle.GetRange(0, 3);
            }

            flashPattern.AddRange(firstTriangle);
            flashPattern.AddRange(secondTriangle);

            flashPattern = flashPattern.Distinct().ToList();

            return flashPattern.Count == 5 ? flashPattern : new List<Point>();
        }

        private static List<Point> FindDiagonalPattern(IEnumerable<Point> input)
        {
            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();

            List<Point> diagonalPattern = FindOnlyDiagonalPattern(sortedPoints, 0);

            if (diagonalPattern.Any())
            {
                diagonalPattern.AddRange(FindOnlyDiagonalPattern(sortedPoints, 2));
            }

            List<Point> uniquePattern = diagonalPattern.Distinct().ToList();

            return uniquePattern.Count >= 3 ? uniquePattern : new List<Point>();
        }

        private static List<Point> FindUPattern(IReadOnlyCollection<Point> sortedInput, int direction)
        {
            List<Point> uPattern = new List<Point>() { sortedInput.First() };
            
            uPattern.AddRange(FindShortedLinePattern(sortedInput, direction));

            IEnumerable<Point> lastPoint = sortedInput
                .Where(p=> p.X == 4)
                .Where(p => p.Y == sortedInput.First().Y);
            uPattern.AddRange(lastPoint);

            return uPattern.Count == 5 ? uPattern : new List<Point>();
        }

        private static List<Point> FindTrianglePattern(IEnumerable<Point> input, int direction)
        {
            List<Point> sortedPoints = input.OrderBy(p => p.X).ToList();
            return FindTrianglePatternAt(0, sortedPoints, direction);
        }

        private static List<Point> FindTrianglePatternAt(int position, IReadOnlyCollection<Point> sortedInput, int direction)
        {
            Point firstPoint = sortedInput.First(point => point.X == position);
            
            List<Point> trianglePattern = new List<Point>(){firstPoint};
            
            Point lastPoint = firstPoint;
            
            foreach (Point point in sortedInput
                .Where(point => point.X == lastPoint.X + 1)
                .Where(point => point.Y == firstPoint.Y || point.Y == firstPoint.Y + direction)
                .Where(point => point.Y == lastPoint.Y + 1 || point.Y == lastPoint.Y - 1))
            {
                trianglePattern.Add(point);
                lastPoint = point;
            }

            if (trianglePattern.Count == 4)
            {
                trianglePattern.RemoveAt(trianglePattern.Count-1);
            }

            return trianglePattern.Count >= 3 ? trianglePattern : new List<Point>();
        }

        private static List<Point> FindOnlyDiagonalPattern(IReadOnlyList<Point> input, int start)
        {
            List<Point> diagonal = new List<Point>() { input[start] };

            for (int i = start + 1; i < input.Count; i++)
            {
                if (input[i].X == diagonal.Last().X + 1)
                {
                    if (input[i].Y == diagonal.Last().Y + 1 || input[i].Y == diagonal.Last().Y - 1)
                    {
                        if (diagonal.All(p => p.Y != input[i].Y))
                        {
                            diagonal.Add(input[i]);
                        }
                    }
                }
            }

            return diagonal.Count >= 3 ? diagonal : new List<Point>();
        }

        private static List<Point> FindLinePatternAt(IReadOnlyCollection<Point> sortedInput, int position)
        {
            Point firstPoint = sortedInput.First(point => point.X == position);

            List<Point> linePattern = new List<Point>() { firstPoint };

            Point lastPoint = firstPoint;

            foreach (Point point in sortedInput
                .Where(point => point.X == lastPoint.X + 1)
                .Where(point => point.Y == lastPoint.Y))
            {
                linePattern.Add(point);
                lastPoint = point;
            }
            
            return linePattern.Count >= 3 ? linePattern : new List<Point>();
        }

        private static List<Point> FindShortedLinePattern(IReadOnlyCollection<Point> sortedInput, int direction)
        {
            List<Point> firstPointInLinePattern = sortedInput
                .Where(p => p.X == 1)
                .Where(p => p.Y == sortedInput.First().Y + direction)
                .ToList();

            List<Point> shortedInput = sortedInput.Where(p => p.X > 1).ToList();

            if (!firstPointInLinePattern.Any())
            {
                return new List<Point>();
            }

            shortedInput.AddRange(firstPointInLinePattern);

            List<Point> linePattern = FindLinePatternAt(shortedInput, 1);

            if (linePattern.Count == 4)
            {
                linePattern.RemoveAt(linePattern.Count - 1);
            }

            return linePattern;
        }
    }
}