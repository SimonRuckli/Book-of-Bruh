namespace BookOfBruh.Core.SlotGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Reels;
    using Symbols;

    public class ReelsGenerator : IReelsGenerator
    {
        private readonly ISymbolListGenerator symbolListGenerator;
        private readonly ISpeedCalculator speedCalculator;

        public ReelsGenerator(ISymbolListGenerator symbolListGenerator, ISpeedCalculator speedCalculator)
        {
            this.symbolListGenerator = symbolListGenerator;
            this.speedCalculator = speedCalculator;
        }

        public List<IReel> Generate(int count)
        {
            var reels = new List<IReel>();
            List<ISymbol> generate = symbolListGenerator.Generate();

            for (int i = 0; i < count; i++)
            {
                generate = generate.OrderBy(_ => Guid.NewGuid()).ToList();
                reels.Add(new Reel(generate, speedCalculator));
            }

            return reels;
        }
    }
}