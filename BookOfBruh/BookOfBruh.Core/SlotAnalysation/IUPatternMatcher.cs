namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public interface IUPatternMatcher
    {
        List<Point> FindMatches(List<Point> sortedInput, int direction);
    }

    public class UPatternMatcher : IUPatternMatcher
    {
        private readonly ILinePatternMatcher linePatternMatcher;

        public UPatternMatcher(ILinePatternMatcher linePatternMatcher)
        {
            this.linePatternMatcher = linePatternMatcher;
        }

        public List<Point> FindMatches(List<Point> sortedInput, int direction)
        {
            List<Point> uPattern = new List<Point>() { sortedInput.First() };

            uPattern.AddRange(this.FindShortedLinePattern(sortedInput, direction));

            IEnumerable<Point> lastPoint = sortedInput
                                           .Where(p => p.X == 4)
                                           .Where(p => p.Y == sortedInput.First().Y);
            uPattern.AddRange(lastPoint);

            return uPattern.Count == 5 ? uPattern : new List<Point>();
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