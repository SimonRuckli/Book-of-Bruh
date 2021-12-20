namespace BookOfBruh.Core.Reels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Symbols;

    public class Reel : NotifyPropertyChangedBase, IReel
    {
        private readonly List<ISymbol> symbols;

        private int firstIndex;
        private int secondIndex;
        private int thirdIndex;

        private ISymbol first;
        private ISymbol second;
        private ISymbol third;

        public Reel(List<ISymbol> symbols)
        {
            this.symbols = symbols;
            this.firstIndex = 0;
            this.secondIndex = 1;
            this.thirdIndex = 2;
        }

        public ISymbol First
        {
            get => first;
            private set
            {
                first = value;
                OnPropertyChanged();
            }
        }

        public ISymbol Second
        {
            get => second;
            private set
            {
                second = value; 
                OnPropertyChanged();
            }
        }

        public ISymbol Third
        {
            get => third;
            private set
            {
                third = value;
                OnPropertyChanged();
            }
        }

        public async Task Spin(int times)
        {
            for (int i = 0; i < times; i++)
            {
                this.UpdateIndexes();
                await Task.Delay(100);
                this.UpdateSymbols();
            }
        }

        private void UpdateSymbols()
        {
            this.First = symbols[firstIndex];
            this.Second = symbols[secondIndex];
            this.Third = symbols[thirdIndex];
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