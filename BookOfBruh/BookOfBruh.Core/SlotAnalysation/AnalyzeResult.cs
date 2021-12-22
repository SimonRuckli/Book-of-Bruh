namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;

    public class AnalyzeResult
    {
        public AnalyzeResult(double multiplier, List<Pattern> patterns)
        {
            this.Multiplier = multiplier;
            this.Patterns = patterns;
        }

        public double Multiplier { get; }
        public List<Pattern> Patterns { get; }
    }
}
