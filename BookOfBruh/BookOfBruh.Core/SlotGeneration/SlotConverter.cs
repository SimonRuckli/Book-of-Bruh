namespace BookOfBruh.Core.SlotGeneration
{
    using System.Collections.Generic;
    using System.Linq;
    using GameData;
    using Reels;
    using Symbols;

    public interface ISlotConverter
    {
        Slots Convert(IEnumerable<IReel> reels);
    }

    public class SlotConverter : ISlotConverter
    {
        public Slots Convert(IEnumerable<IReel> reels)
        {
            var symbols = new ISymbol[5, 3];

            foreach ((IReel reel, int i) in reels.Select((reel, i) => (reel, i)))
            {
                symbols[i, 0] = reel.First.Symbol;
                symbols[i, 1] = reel.Second.Symbol;
                symbols[i, 2] = reel.Third.Symbol;
            }

            return new Slots(symbols);
        }
    }
}