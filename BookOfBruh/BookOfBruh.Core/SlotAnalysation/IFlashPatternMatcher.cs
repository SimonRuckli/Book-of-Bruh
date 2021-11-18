namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public interface IFlashPatternMatcher
    {
        List<Point> FindMatches(int direction, List<Point> sortedInput);
    }

    public class FlashPatternMatcher : IFlashPatternMatcher
    {
        private readonly ITrianglePatternMatcher trianglePatternMatcher;

        public FlashPatternMatcher(ITrianglePatternMatcher trianglePatternMatcher)
        {
            this.trianglePatternMatcher = trianglePatternMatcher;
        }

        public List<Point> FindMatches(int direction, List<Point> sortedInput)
        {
            List<Point> flashPattern = new List<Point>();

            flashPattern.AddRange(this.FindFirstTrianglePattern(sortedInput, direction));
            flashPattern.AddRange(this.FindSecondTrianglePattern(sortedInput, direction));

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

    }
}