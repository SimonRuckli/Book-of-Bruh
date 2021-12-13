namespace BookOfBruh.View.Slot
{
    using Core.GameData;
    using Core.Symbols;
    using Infrastructure;

    public class SlotViewModel : NotifyPropertyChangedBase
    {
        public string Symbol00 { get; private set; }
        public string Symbol10 { get; private set; }
        public string Symbol20 { get; private set; }
        public string Symbol30 { get; private set; }
        public string Symbol40 { get; private set; }

        public string Symbol01 { get; private set; }
        public string Symbol11 { get; private set; }
        public string Symbol21 { get; private set; }
        public string Symbol31 { get; private set; }
        public string Symbol41 { get; private set; }

        public string Symbol02 { get; private set; }
        public string Symbol12 { get; private set; }
        public string Symbol22 { get; private set; }
        public string Symbol32 { get; private set; }
        public string Symbol42 { get; private set; }

        public void RenderSpin(SpinResult spinResult)
        {
            this.Symbol00 = this.SymbolToPath(spinResult.Slots.Symbols[0, 0]);
            this.Symbol10 = this.SymbolToPath(spinResult.Slots.Symbols[1, 0]);
            this.Symbol20 = this.SymbolToPath(spinResult.Slots.Symbols[2, 0]);
            this.Symbol30 = this.SymbolToPath(spinResult.Slots.Symbols[3, 0]);
            this.Symbol40 = this.SymbolToPath(spinResult.Slots.Symbols[4, 0]);

            this.Symbol01 = this.SymbolToPath(spinResult.Slots.Symbols[0, 1]);
            this.Symbol11 = this.SymbolToPath(spinResult.Slots.Symbols[1, 1]);
            this.Symbol21 = this.SymbolToPath(spinResult.Slots.Symbols[2, 1]);
            this.Symbol31 = this.SymbolToPath(spinResult.Slots.Symbols[3, 1]);
            this.Symbol41 = this.SymbolToPath(spinResult.Slots.Symbols[4, 1]);

            this.Symbol02 = this.SymbolToPath(spinResult.Slots.Symbols[0, 2]);
            this.Symbol12 = this.SymbolToPath(spinResult.Slots.Symbols[1, 2]);
            this.Symbol22 = this.SymbolToPath(spinResult.Slots.Symbols[2, 2]);
            this.Symbol32 = this.SymbolToPath(spinResult.Slots.Symbols[3, 2]);
            this.Symbol42 = this.SymbolToPath(spinResult.Slots.Symbols[4, 2]);
        }

        private string SymbolToPath(ISymbol symbol)
        {
            string symbolName = symbol?.GetType().Name;
            return $"pack://application:,,,/BookOfBruh.View;component/Images/{symbolName}.png";
        }
    }
}
