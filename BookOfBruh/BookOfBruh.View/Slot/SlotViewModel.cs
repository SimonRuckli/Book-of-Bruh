namespace BookOfBruh.View.Slot
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Core;
    using Core.Reels;
    using Core.Symbols;
    using NotifyPropertyChangedBase = Infrastructure.NotifyPropertyChangedBase;

    public class SlotViewModel : NotifyPropertyChangedBase
    {
        private readonly Game game;

        public SlotViewModel(Game game)
        {
            this.game = game;
        }

        public List<IReel> Reels => game.Reels;

        public ObservableCollection<Row> Rows => ConvertToRowsList(game.Reels);

        private static ObservableCollection<Row> ConvertToRowsList(List<IReel> reels)
        {
            ObservableCollection<Row> rows = new()
            {
                new Row(),
                new Row(),
                new Row(),
            };

            foreach (IReel reel in reels)
            {
                rows[0].AddSymbol(reel.First);
                rows[1].AddSymbol(reel.Second);
                rows[2].AddSymbol(reel.Third);
            }

            return rows;
        }

        public class Row
        {
            public List<string> SymbolPaths { get; } = new List<string>();

            public void AddSymbol(ISymbol symbol)
            {
                this.SymbolPaths.Add(ConvertSymbolsToPath(symbol));
            }

            private static string ConvertSymbolsToPath(ISymbol symbol)
            {
                return symbol?.GetType().ToString();
            }
        }

    }
}
