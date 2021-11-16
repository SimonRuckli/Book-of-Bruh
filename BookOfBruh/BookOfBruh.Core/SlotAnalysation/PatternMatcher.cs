namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using System.Collections.Generic;
    
    public interface IPatternMatcher
    {
        public List<Pattern> FindMatches(List<Point> input);
    }

    public class Pattern : IPatternMatcher
    {
        public List<Point> Value { get; }

        public Pattern(List<Point> value)
        {
            this.Value = value;
        }

        public List<Pattern> FindMatches(List<Point> input)
        {
            throw new System.NotImplementedException();
        }
    }
}