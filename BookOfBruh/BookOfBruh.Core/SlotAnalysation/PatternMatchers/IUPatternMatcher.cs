namespace BookOfBruh.Core.SlotAnalysation.PatternMatchers
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public interface IUPatternMatcher
    {
        List<Point> FindMatches(int direction, List<Point> input);
    }

    public class UPatternMatcher : IUPatternMatcher
    {
        private readonly ILinePatternMatcher linePatternMatcher;

        public UPatternMatcher(ILinePatternMatcher linePatternMatcher)
        {
            this.linePatternMatcher = linePatternMatcher;
        }

        public List<Point> FindMatches(int direction, List<Point> input)
        {
            List<Point> uPattern = new List<Point>() { input.First() };

            uPattern.AddRange(this.FindShortedLinePattern(input, direction));

            IEnumerable<Point> lastPoint = input
                                           .Where(p => p.X == 4)
                                           .Where(p => p.Y == input.First().Y);
            uPattern.AddRange(lastPoint);

            return uPattern.Count == 5 ? uPattern : new List<Point>();
        }

        private List<Point> FindShortedLinePattern(IReadOnlyCollection<Point> input, int direction)
        {
            List<Point> firstPointInLinePattern = input
                                                  .Where(p => p.X == 1)
                                                  .Where(p => p.Y == input.First().Y + direction)
                                                  .ToList();

            List<Point> shortedInput = input.Where(p => p.X > 1).ToList();

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