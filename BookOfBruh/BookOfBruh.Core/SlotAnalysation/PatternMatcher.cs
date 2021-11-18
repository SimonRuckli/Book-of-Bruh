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

            List<Point> orderedInput = input.OrderBy(p => p.X).ToList();

            List<Point> linePattern = FindLinePattern(orderedInput);
            List<Point> trianglePatternUp = FindTrianglePatternUp(orderedInput);
            List<Point> trianglePatternDown = FindTrianglePatternDown(orderedInput);
            List<Point> diagonalPattern = FindDiagonalPattern(orderedInput);
            List<Point> uPatternUp = FindUPatternUp(orderedInput);
            List<Point> uPatternDown = FindUPatternDown(orderedInput);
            List<Point> flashPatternUp = FindFlashPatternUp(orderedInput);
            List<Point> flashPatternDown = FindFlashPatternDown(orderedInput);

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

        private static List<Point> FindFlashPatternDown(IReadOnlyCollection<Point> input)
        {
            return FindFlashPattern(input, -1);
        }

        private static List<Point> FindFlashPatternUp(IReadOnlyCollection<Point> input)
        {
            return FindFlashPattern(input, 1);
        }

        private static List<Point> FindUPatternDown(IReadOnlyCollection<Point> input)
        {
            return FindUPattern(input, -1);
        }

        private static List<Point> FindUPatternUp(IReadOnlyCollection<Point> input)
        {
            return FindUPattern(input, 1);
        }

        private static List<Point> FindLinePattern(IReadOnlyCollection<Point> input)
        {
            return FindLinePatternAt(input, 0);
        }

        private static List<Point> FindTrianglePatternDown(IReadOnlyCollection<Point> input)
        {
            return FindTrianglePattern(input, -1);
        }

        private static List<Point> FindTrianglePatternUp(IReadOnlyCollection<Point> input)
        {
            return FindTrianglePattern(input, 1);
        }

        private static List<Point> FindFlashPattern(IReadOnlyCollection<Point> sortedInput, int direction)
        {
            List<Point> flashPattern = new List<Point>();
            
            flashPattern.AddRange(FindFirstTrianglePattern(sortedInput, direction));
            flashPattern.AddRange(FindSecondTrianglePattern(sortedInput, direction));

            flashPattern = flashPattern.Distinct().ToList();

            return flashPattern.Count == 5 ? flashPattern : new List<Point>();
        }

        private static List<Point> FindFirstTrianglePattern(IReadOnlyCollection<Point> sortedInput, int direction)
        {
            List<Point> firstTriangle = FindTrianglePatternAt(0, sortedInput, direction);

            if (firstTriangle.Count > 3)
            {
                firstTriangle = firstTriangle.GetRange(0, 3);
            }

            return firstTriangle;
        }

        private static List<Point> FindSecondTrianglePattern(IReadOnlyCollection<Point> sortedInput, int direction)
        {
            IEnumerable<Point> firstPointInSecondTriangle = sortedInput.Where(p => p.X == 2).Where(p => p.Y == 1);

            List<Point> shortedInput = sortedInput.Where(p => p.X > 2).ToList();
            shortedInput.AddRange(firstPointInSecondTriangle);

            return FindTrianglePatternAt(2, shortedInput, direction * -1);
        }

        private static List<Point> FindDiagonalPattern(IReadOnlyList<Point> input)
        {
            List<Point> diagonalPattern = FindOnlyDiagonalPattern(input, 0);

            if (diagonalPattern.Any())
            {
                diagonalPattern.AddRange(FindOnlyDiagonalPattern(input, 2));
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

        private static List<Point> FindTrianglePattern(IReadOnlyCollection<Point> input, int direction)
        {
            return FindTrianglePatternAt(0, input, direction);
        }

        private static List<Point> FindTrianglePatternAt(int position, IReadOnlyCollection<Point> sortedInput, int direction)
        {
            List<Point> pointsAtPositon = sortedInput.Where(point => point.X == position).ToList();

            if (pointsAtPositon.Count == 0)
            {
                return new List<Point>();
            }

            Point firstPoint = pointsAtPositon.First();

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