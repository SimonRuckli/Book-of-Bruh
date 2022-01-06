namespace BookOfBruh.View.AcceptanceTest.Infrastructure
{
    using System.Collections.Generic;
    using Core.GameData;
    using Core.Reels;
    using Core.SlotGeneration;
    using Core.Symbols;

    internal class FakeSlotConverter : ISlotConverter
    {
        public Slots Convert(IEnumerable<IReel> reels)
        {
            const string pattern = "|TTT_-|" +
                                   "|-_-_-|" +
                                   "|-_-_-|";

            ISymbol[,] symbols = SymbolTestHelper.SymbolsFromPattern(pattern);

            return new Slots(symbols);
        }
    }
}
