namespace BookOfBruh.Core.SlotGeneration
{
    using System.Collections.Generic;
    using System.Linq;
    using GameData;
    using Reels;
    using Symbols;

    public interface ISlotConverter
    {
        Slots Convert(List<IReel> reels);
    }

    public class SlotConverter : ISlotConverter
    {
        public Slots Convert(List<IReel> reels)
        {
            ISymbol[,] symbols = new ISymbol[5, 3];

            foreach ((IReel reel, int i) in reels.Select((reel, i) => (reel, i)))
            {
                symbols[i, 0] = reel.First;
                symbols[i, 1] = reel.Second;
                symbols[i, 2] = reel.Third;
            }

            return new Slots(symbols);
        }
    }
}