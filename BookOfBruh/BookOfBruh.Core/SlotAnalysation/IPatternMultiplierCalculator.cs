namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using Symbols;

    public interface IPatternMultiplierCalculator
    {
        double Calculate(List<int> pointsInPattern, ISymbol symbol);
    }

    public class PatternMultiplierCalculator : IPatternMultiplierCalculator
    {
        public double Calculate(List<int> pointsInPattern, ISymbol symbol)
        {
            double multiplier = 0;

            foreach (int patternCount in pointsInPattern)
            {
                if (patternCount == 5)
                {
                    multiplier += symbol.Value * 8;
                }
                if (patternCount == 4)
                {
                    multiplier += symbol.Value * 3;
                }
                if (patternCount == 3)
                {
                    multiplier += symbol.Value;
                }
            }

            return multiplier;
        }
    }
}