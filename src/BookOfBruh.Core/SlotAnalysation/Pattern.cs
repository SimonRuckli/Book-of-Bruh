namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using System.Drawing;
    public class Pattern
    {
        public List<Point> Value { get; }

        public Pattern(List<Point> value)
        {
            this.Value = value;
        }
    }
}