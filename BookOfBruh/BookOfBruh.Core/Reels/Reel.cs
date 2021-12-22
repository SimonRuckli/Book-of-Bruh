namespace BookOfBruh.Core.Reels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GameData;
    using Symbols;

    public class Reel : NotifyPropertyChangedBase, IReel
    {
        private readonly List<ISymbol> symbols;
        private readonly ISpeedCalculator speedCalculator;

        private int firstIndex;
        private int secondIndex;
        private int thirdIndex;

        public Reel(List<ISymbol> symbols, ISpeedCalculator speedCalculator)
        {
            this.symbols = symbols;
            this.speedCalculator = speedCalculator;

            First = new Slot();
            Second = new Slot();
            Third = new Slot();

            this.firstIndex = 2;
            this.secondIndex = 1;
            this.thirdIndex = 0;
        }

        public Slot First { get; }
        public Slot Second { get; }
        public Slot Third { get; }


        public async Task Spin(int times)
        {
            List<int> speeds = this.speedCalculator.Calculate(times);

            for (int i = 0; i < times; i++)
            {
                this.UpdateIndexes();
                await Task.Delay(speeds[i]);
                this.UpdateSymbols();
            }
        }

        private void UpdateSymbols()
        {
            this.First.Symbol = symbols[firstIndex];
            this.Second.Symbol = symbols[secondIndex];
            this.Third.Symbol = symbols[thirdIndex];
        }

        private void UpdateIndexes()
        {
            this.firstIndex = this.NextIndex(this.firstIndex);
            this.secondIndex = this.NextIndex(this.secondIndex);
            this.thirdIndex = this.NextIndex(this.thirdIndex);
        }

        private int NextIndex(int index)
        {
            if (index < symbols.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            return index;
        }
    }
}