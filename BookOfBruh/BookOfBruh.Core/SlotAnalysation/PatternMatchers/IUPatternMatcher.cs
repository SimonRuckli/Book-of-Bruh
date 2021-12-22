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
            List<Point> uPattern = new() { input.First() };

            uPattern.AddRange(this.FindShortedLinePattern(input, direction));

            IEnumerable<Point> lastPoint = input
                                           .Where(IsInLastColumn)
                                           .Where(point => IsInSameRowAsFirstPoint(point, input.First())); // one or none
            uPattern.AddRange(lastPoint);

            return uPattern.Count == 5 ? uPattern : new List<Point>();
        }

        private IEnumerable<Point> FindShortedLinePattern(IReadOnlyCollection<Point> input, int direction)
        {
            List<Point> firstPointInLinePattern = input
                .Where(IsPointInSecondColumn)
                .Where(point => IsInRowInDirection(point, input.First(), direction))
                .ToList(); // one or none

            if (!firstPointInLinePattern.Any())
            {
                return new List<Point>();
            }

            List<Point> shortedInput = input.Where(IsInFrontOfSecondColumn).ToList();

            shortedInput.AddRange(firstPointInLinePattern);

            List<Point> linePattern = this.linePatternMatcher.FindMatchesAt(1, shortedInput);

            if (linePattern.Count == 4)
            {
                linePattern.RemoveAt(linePattern.Count - 1);
            }

            return linePattern;
        }

        private static bool IsInFrontOfSecondColumn(Point point)
        {
            return point.X > 1;
        }

        private static bool IsInRowInDirection(Point point, Point first, int direction)
        {
            return point.Y == first.Y + direction;
        }

        private static bool IsPointInSecondColumn(Point point)
        {
            return point.X == 1;
        }

        private static bool IsInSameRowAsFirstPoint(Point point, Point first)
        {
            return point.Y == first.Y;
        }

        private static bool IsInLastColumn(Point point)
        {
            return point.X == 4;
        }
    }
}