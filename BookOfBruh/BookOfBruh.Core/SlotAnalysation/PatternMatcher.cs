using System.Drawing;

namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    public interface IPatternMatcher
    {
        public List<Pattern> FindMatches(List<Point> input);
    }

    public class Pattern
    {
        public List<Point> Value { get; }

        public Pattern(List<Point> value)
        {
            this.Value = value;
        }
    }
}