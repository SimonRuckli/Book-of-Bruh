namespace BookOfBruh.Core
{
    using System.Collections.Generic;
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
                generate.Shuffle();
                reels.Add(new Reel(generate));
            }

            return reels;
        }
    }
}