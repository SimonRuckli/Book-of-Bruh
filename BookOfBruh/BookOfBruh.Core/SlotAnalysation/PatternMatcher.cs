namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using System.Collections.Generic;
    
    public interface IPatternMatcher
    {
        public List<Pattern> FindMatches(List<Point> input);
    }

    public class PatternMatcher : IPatternMatcher
    {
        public List<Pattern> FindMatches(List<Point> input)
        {
            throw new System.NotImplementedException();
        }
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