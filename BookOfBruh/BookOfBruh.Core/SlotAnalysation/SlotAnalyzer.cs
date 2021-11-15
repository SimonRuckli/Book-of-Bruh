namespace BookOfBruh.Core.SlotAnalysation
{
    using BookOfBruh.Core.GameData;

    public class SlotAnalyzer
    {
        private readonly IPatternMatcher patternMatcher;

        public SlotAnalyzer(IPatternMatcher patternMatcher)
        {
            this.patternMatcher = patternMatcher;
        }

        public double Analyze(Slots slots)
        {
            return 0;
        }

    }
}
