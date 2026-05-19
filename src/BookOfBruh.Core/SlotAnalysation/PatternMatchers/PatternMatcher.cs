namespace BookOfBruh.Core.SlotAnalysation.PatternMatchers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
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
            var patterns = new List<Pattern>();

            List<Point> orderedInput = input.OrderBy(p => p.X).ToList();

            patterns.AddRange(this.FindLinePattern(orderedInput));
            patterns.AddRange(this.FindUPattern(orderedInput));
            patterns.AddRange(this.FindDiagonalPattern(orderedInput));
            patterns.AddRange(this.FindTriangleAndFlashPattern(orderedInput));
            
            return patterns.Where(p => p.Value.Any()).ToList();
        }

        private IEnumerable<Pattern> FindLinePattern(List<Point> input)
        {
            var patterns = new List<Pattern>();

            List<Point> linePattern = this.linePatternMatcher.FindMatchesAt(0, input);

            patterns.Add(new Pattern(linePattern));
            
            return patterns;
        }

        private IEnumerable<Pattern> FindUPattern(List<Point> input)
        {
            var patterns = new List<Pattern>();

            List<Point> uPatternUp = this.uPatternMatcher.FindMatches(1, input);
            List<Point> uPatternDown = this.uPatternMatcher.FindMatches(-1, input);

            patterns.Add(new Pattern(uPatternUp));
            patterns.Add(new Pattern(uPatternDown));

            return patterns;
        }

        private IEnumerable<Pattern> FindDiagonalPattern(List<Point> input)
        {
            var patterns = new List<Pattern>();

            List<Point> diagonalPattern = this.diagonalPatternMatcher.FindMatches(input);

            patterns.Add(new Pattern(diagonalPattern));

            return patterns;
        }

        private  IEnumerable<Pattern> FindTriangleAndFlashPattern(List<Point> input)
        {
            var patterns = new List<Pattern>();

            patterns.AddRange(this.FindTriangleAndFlashPatternInDirection(1, input));
            patterns.AddRange(this.FindTriangleAndFlashPatternInDirection(-1, input));

            return patterns;
        }

        private IEnumerable<Pattern> FindTriangleAndFlashPatternInDirection(int direction, List<Point> input)
        {
            var patterns = new List<Pattern>();

            List<Point> flashPattern = this.flashPatternMatcher.FindMatches(direction, input);
            List<Point> trianglePattern = this.trianglePatternMatcher.FindMatchesAt(0, direction, input);

            patterns.Add(new Pattern(flashPattern));
       
            if (!IsPartOfFlashPattern(trianglePattern, flashPattern))
            {
                patterns.Add(new Pattern(trianglePattern));
            }

            return patterns;
        }

        private static bool IsPartOfFlashPattern(ICollection trianglePattern, IEnumerable<Point> flashPattern)
        {
            return trianglePattern.Count == 3 && flashPattern.Any();
        }
    }
}