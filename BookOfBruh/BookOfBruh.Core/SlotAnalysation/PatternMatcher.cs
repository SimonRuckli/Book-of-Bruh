namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using System.Collections.Generic;
    using System.Linq;

    public class PatternMatcher : IPatternMatcher
    {
        private readonly ILinePatternMatcher linePatternMatcher;
        private readonly ITrianglePatternMatcher trianglePatternMatcher;

        public PatternMatcher(ILinePatternMatcher linePatternMatcher, ITrianglePatternMatcher trianglePatternMatcher)
        {
            this.linePatternMatcher = linePatternMatcher;
            this.trianglePatternMatcher = trianglePatternMatcher;
        }

        public List<Pattern> FindMatches(List<Point> input)
        {
            List<Pattern> patterns = new List<Pattern>();

            List<Point> orderedInput = input.OrderBy(p => p.X).ToList();

            List<Point> linePattern = this.FindLinePattern(orderedInput);
            List<Point> trianglePatternUp = FindTrianglePatternUp(orderedInput);
            List<Point> trianglePatternDown = FindTrianglePatternDown(orderedInput);
            List<Point> diagonalPattern = FindDiagonalPattern(orderedInput);
            List<Point> uPatternUp = this.FindUPatternUp(orderedInput);
            List<Point> uPatternDown = this.FindUPatternDown(orderedInput);
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

        private List<Point> FindFlashPatternDown(List<Point> input)
        {
            return this.FindFlashPattern(input, -1);
        }

        private List<Point> FindFlashPatternUp(List<Point> input)
        {
            return this.FindFlashPattern(input, 1);
        }

        private List<Point> FindUPatternDown(List<Point> input)
        {
            return this.FindUPattern(input, -1);
        }

        private List<Point> FindUPatternUp(List<Point> input)
        {
            return this.FindUPattern(input, 1);
        }

        private List<Point> FindLinePattern(List<Point> input)
        {
            return this.linePatternMatcher.FindMatchesAt(0, input);
        }

        private List<Point> FindTrianglePatternDown(List<Point> input)
        {
            return this.FindTrianglePattern(input, -1);
        }

        private List<Point> FindTrianglePatternUp(List<Point> input)
        {
            return this.FindTrianglePattern(input, 1);
        }

        private List<Point> FindFlashPattern(List<Point> sortedInput, int direction)
        {
            List<Point> flashPattern = new List<Point>();
            
            flashPattern.AddRange(this.FindFirstTrianglePattern(sortedInput, direction));
            flashPattern.AddRange(FindSecondTrianglePattern(sortedInput, direction));

            flashPattern = flashPattern.Distinct().ToList();

            return flashPattern.Count == 5 ? flashPattern : new List<Point>();
        }

        private List<Point> FindFirstTrianglePattern(List<Point> sortedInput, int direction)
        {
            List<Point> firstTriangle = this.trianglePatternMatcher.FindMatchesAt(0, direction, sortedInput);

            if (firstTriangle.Count > 3)
            {
                firstTriangle = firstTriangle.GetRange(0, 3);
            }

            return firstTriangle;
        }

        private List<Point> FindSecondTrianglePattern(IReadOnlyCollection<Point> sortedInput, int direction)
        {
            IEnumerable<Point> firstPointInSecondTriangle = sortedInput.Where(p => p.X == 2).Where(p => p.Y == 1);

            List<Point> shortedInput = sortedInput.Where(p => p.X > 2).ToList();
            shortedInput.AddRange(firstPointInSecondTriangle);

            return this.trianglePatternMatcher.FindMatchesAt(2, direction * -1, shortedInput);
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

        private List<Point> FindUPattern(List<Point> sortedInput, int direction)
        {
            List<Point> uPattern = new List<Point>() { sortedInput.First() };
            
            uPattern.AddRange(this.FindShortedLinePattern(sortedInput, direction));

            IEnumerable<Point> lastPoint = sortedInput
                .Where(p=> p.X == 4)
                .Where(p => p.Y == sortedInput.First().Y);
            uPattern.AddRange(lastPoint);

            return uPattern.Count == 5 ? uPattern : new List<Point>();
        }

        private  List<Point> FindTrianglePattern(List<Point> input, int direction)
        {
            return this.trianglePatternMatcher.FindMatchesAt(0, direction, input);
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

        private List<Point> FindShortedLinePattern(IReadOnlyCollection<Point> sortedInput, int direction)
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

            List<Point> linePattern = this.linePatternMatcher.FindMatchesAt(1, shortedInput);

            if (linePattern.Count == 4)
            {
                linePattern.RemoveAt(linePattern.Count - 1);
            }

            return linePattern;
        }
    }
}