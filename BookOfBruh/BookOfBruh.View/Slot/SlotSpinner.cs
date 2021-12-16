namespace BookOfBruh.View.Slot
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.SlotGeneration;
    using Core.Symbols;

    public interface ISlotSpinner
    {
        IAsyncEnumerable<ISymbol> GenerateSpinSymbols(int spins, int delay, ISymbol endSymbol);
    }

    public class SlotSpinner : ISlotSpinner
    {
        private readonly List<ISymbol> symbolList;
        private readonly Random random;

        public SlotSpinner(ISymbolListGenerator symbolListGenerator)
        {
            this.symbolList = symbolListGenerator.Generate();
            this.random = new Random();
        }

        public async IAsyncEnumerable<ISymbol> GenerateSpinSymbols(int spins, int delay, ISymbol endSymbol)
        {
            int max = symbolList.Count - 1;
            int symbolIndex = random.Next(max);

            for (int i = 0; i < spins; i++)
            {
                symbolIndex = NextIndex(symbolIndex, max);
                await Task.Delay(delay);
                yield return this.symbolList[symbolIndex];
            }
            yield return endSymbol;
        }

        private static int NextIndex(int index, int max)
        {
            if (index == max)
            {
                return 0;
            }

            return index + 1;
        }
    }
}
