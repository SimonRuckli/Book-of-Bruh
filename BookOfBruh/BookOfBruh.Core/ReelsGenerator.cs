namespace BookOfBruh.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Reels;
    using SlotGeneration;
    using Symbols;

    public class ReelsGenerator : IReelsGenerator
    {
        private readonly ISymbolListGenerator symbolListGenerator;

        public ReelsGenerator(ISymbolListGenerator symbolListGenerator)
        {
            this.symbolListGenerator = symbolListGenerator;
        }


        public List<IReel> Generate(int count)
        {
            List<IReel> reels = new List<IReel>();
            List<ISymbol> generate = symbolListGenerator.Generate();

            for (int i = 0; i < count; i++)
            {
                generate = generate.OrderBy(_ => Guid.NewGuid()).ToList();
                reels.Add(new Reel(generate));
            }

            return reels;
        }
    }
}