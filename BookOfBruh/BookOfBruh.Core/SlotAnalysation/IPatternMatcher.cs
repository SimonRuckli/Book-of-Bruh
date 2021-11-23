namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using System.Drawing;

    public interface IPatternMatcher
    {
        public List<Pattern> FindMatches(List<Point> input);
    }
}