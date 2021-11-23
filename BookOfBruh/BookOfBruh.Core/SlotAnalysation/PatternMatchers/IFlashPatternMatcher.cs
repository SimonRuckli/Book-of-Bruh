namespace BookOfBruh.Core.SlotAnalysation.PatternMatchers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public interface IFlashPatternMatcher
    {
        List<Point> FindMatches(int direction, List<Point> input);
    }

    public class FlashPatternMatcher : IFlashPatternMatcher
    {
        private readonly ITrianglePatternMatcher trianglePatternMatcher;

        public FlashPatternMatcher(ITrianglePatternMatcher trianglePatternMatcher)
        {
            this.trianglePatternMatcher = trianglePatternMatcher;
        }

        public List<Point> FindMatches(int direction, List<Point> input)
        {
            List<Point> flashPattern = new List<Point>();

            flashPattern.AddRange(this.FindFirstTrianglePattern(input, direction));
            flashPattern.AddRange(this.FindSecondTrianglePattern(input, direction));

            flashPattern = flashPattern.Distinct().ToList();

            return flashPattern.Count == 5 ? flashPattern : new List<Point>();
        }

        private List<Point> FindFirstTrianglePattern(List<Point> input, int direction)
        {
            List<Point> firstTriangle = this.trianglePatternMatcher.FindMatchesAt(0, direction, input);

            if (firstTriangle.Count > 3)
            {
                firstTriangle = firstTriangle.GetRange(0, 3);
            }

            return firstTriangle;
        }

        private List<Point> FindSecondTrianglePattern(IReadOnlyCollection<Point> input, int direction)
        {
            IEnumerable<Point> firstPointInSecondTriangle = input.Where(p => p.X == 2).Where(p => p.Y == 1);

            List<Point> shortedInput = input.Where(p => p.X > 2).ToList();
            shortedInput.AddRange(firstPointInSecondTriangle);

            return this.trianglePatternMatcher.FindMatchesAt(2, direction * -1, shortedInput);
        }

    }
}