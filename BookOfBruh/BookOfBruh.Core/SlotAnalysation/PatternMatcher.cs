namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using System.Collections.Generic;
    using System.Linq;

    public class PatternMatcher : IPatternMatcher
    {
        private readonly ILinePatternMatcher linePatternMatcher;
        private readonly ITrianglePatternMatcher trianglePatternMatcher;
        private readonly IDiagonalPatternMatcher diagonalPatternMatcher;
        private readonly IUPatternMatcher uPatternMatcher;

        public PatternMatcher(
            ILinePatternMatcher linePatternMatcher, 
            ITrianglePatternMatcher trianglePatternMatcher,
            IDiagonalPatternMatcher diagonalPatternMatcher,
            IUPatternMatcher uPatternMatcher)
        {
            this.linePatternMatcher = linePatternMatcher;
            this.trianglePatternMatcher = trianglePatternMatcher;
            this.diagonalPatternMatcher = diagonalPatternMatcher;
            this.uPatternMatcher = uPatternMatcher;
        }

        public List<Pattern> FindMatches(List<Point> input)
        {
            List<Pattern> patterns = new List<Pattern>();

            List<Point> orderedInput = input.OrderBy(p => p.X).ToList();

            List<Point> linePattern = this.FindLinePattern(orderedInput);
            List<Point> trianglePatternUp = this.FindTrianglePatternUp(orderedInput);
            List<Point> trianglePatternDown = this.FindTrianglePatternDown(orderedInput);
            List<Point> diagonalPattern = this.diagonalPatternMatcher.FindMatches(orderedInput);
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
            return this.uPatternMatcher.FindMatches(input, -1);
        }

        private List<Point> FindUPatternUp(List<Point> input)
        {
            return this.uPatternMatcher.FindMatches(input, 1);
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

        private  List<Point> FindTrianglePattern(List<Point> input, int direction)
        {
            return this.trianglePatternMatcher.FindMatchesAt(0, direction, input);
        }
    }
}