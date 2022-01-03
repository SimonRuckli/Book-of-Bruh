namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Symbols;
    using GameData;

    public interface ISlotAnalyzer
    {
        AnalyzeResult Analyze(Slots slots);
    }

    public class SlotAnalyzer : ISlotAnalyzer
    {
        private readonly IPatternMatcher patternMatcher;
        private readonly IWildDisguiseCalculator wildDisguiseCalculator;
        private readonly ISameSymbolCalculator sameSymbolCalculator;
        private readonly IPatternMultiplierCalculator patternMultiplierCalculator;

        public SlotAnalyzer(
            IPatternMatcher patternMatcher,
            IWildDisguiseCalculator wildDisguiseCalculator,
            ISameSymbolCalculator sameSymbolCalculator,
            IPatternMultiplierCalculator patternMultiplierCalculator)
        {
            this.patternMatcher = patternMatcher;
            this.wildDisguiseCalculator = wildDisguiseCalculator;
            this.sameSymbolCalculator = sameSymbolCalculator;
            this.patternMultiplierCalculator = patternMultiplierCalculator;
        }

        public AnalyzeResult Analyze(Slots slots)
        {
            double multiplier = 0;

            var allPatterns = new List<Pattern>();

            const int first = 0;

            for (int y = 0; y < slots.Rows; y++)
            {
                var startPoint = new Point(first, y);

                List<ISymbol> symbols = GetSymbolsInFirstPosition(startPoint, slots);

                foreach (ISymbol symbol in symbols)
                {
                    List<Point> points = this.sameSymbolCalculator.Calculate(startPoint, slots, symbol);

                    List<Pattern> patterns = this.patternMatcher.FindMatches(points);

                    allPatterns.AddRange(patterns);

                    List<int> patternCounts = patterns.Select(pattern => pattern.Value.Count).ToList();

                    multiplier += this.patternMultiplierCalculator.Calculate(patternCounts, symbol);
                }
            }

            return new AnalyzeResult(multiplier, allPatterns);
        }

        private List<ISymbol> GetSymbolsInFirstPosition(Point firstPoint, Slots slots)
        {
            var symbols = new List<ISymbol>();

            ISymbol symbol = slots.Symbols[firstPoint.X, firstPoint.Y];

            if (symbol is WildSymbol)
            {
                symbols = this.wildDisguiseCalculator.Calculate(firstPoint, slots);
            }
            else
            {
                symbols.Add(symbol);
            }

            return symbols;
        }
    }
}