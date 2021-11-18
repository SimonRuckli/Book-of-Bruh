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
        private readonly IFlashPatternMatcher flashPatternMatcher;

        public PatternMatcher(
            ILinePatternMatcher linePatternMatcher, 
            ITrianglePatternMatcher trianglePatternMatcher,
            IDiagonalPatternMatcher diagonalPatternMatcher,
            IUPatternMatcher uPatternMatcher,
            IFlashPatternMatcher flashPatternMatcher)
        {
            this.linePatternMatcher = linePatternMatcher;
            this.trianglePatternMatcher = trianglePatternMatcher;
            this.diagonalPatternMatcher = diagonalPatternMatcher;
            this.uPatternMatcher = uPatternMatcher;
            this.flashPatternMatcher = flashPatternMatcher;
        }

        public List<Pattern> FindMatches(List<Point> input)
        {
            List<Pattern> patterns = new List<Pattern>();

            List<Point> orderedInput = input.OrderBy(p => p.X).ToList();

            List<Point> linePattern = this.FindLinePattern(orderedInput);
            List<Point> trianglePatternUp = this.FindTrianglePatternUp(orderedInput);
            List<Point> trianglePatternDown = this.FindTrianglePatternDown(orderedInput);
            List<Point> diagonalPattern = this.diagonalPatternMatcher.FindMatches(orderedInput);
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
            return this.flashPatternMatcher.FindMatches(-1, input);
        }

        private List<Point> FindFlashPatternUp(List<Point> input)
        {
            return this.flashPatternMatcher.FindMatches(1, input);
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

        private  List<Point> FindTrianglePattern(List<Point> input, int direction)
        {
            return this.trianglePatternMatcher.FindMatchesAt(0, direction, input);
        }
    }
}