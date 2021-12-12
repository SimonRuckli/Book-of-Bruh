namespace BookOfBruh.View.Slot
{
    using Core.GameData;
    using Core.Symbols;
    using Infrastructure;

    public class SlotViewModel : NotifyPropertyChangedBase
    {
        public Slots Slots { get; set; }
        
        public string Symbol00 => SymbolToPath(this.Slots?.Symbols[0, 0]);
        public string Symbol10 => SymbolToPath(this.Slots?.Symbols[1, 0]);
        public string Symbol20 => SymbolToPath(this.Slots?.Symbols[2, 0]);
        public string Symbol30 => SymbolToPath(this.Slots?.Symbols[3, 0]);
        public string Symbol40 => SymbolToPath(this.Slots?.Symbols[4, 0]);

        public string Symbol01 => SymbolToPath(this.Slots?.Symbols[0, 1]);
        public string Symbol11 => SymbolToPath(this.Slots?.Symbols[1, 1]);
        public string Symbol21 => SymbolToPath(this.Slots?.Symbols[2, 1]);
        public string Symbol31 => SymbolToPath(this.Slots?.Symbols[3, 1]);
        public string Symbol41 => SymbolToPath(this.Slots?.Symbols[4, 1]);

        public string Symbol02 => SymbolToPath(this.Slots?.Symbols[0, 2]);
        public string Symbol12 => SymbolToPath(this.Slots?.Symbols[1, 2]);
        public string Symbol22 => SymbolToPath(this.Slots?.Symbols[2, 2]);
        public string Symbol32 => SymbolToPath(this.Slots?.Symbols[3, 2]);
        public string Symbol42 => SymbolToPath(this.Slots?.Symbols[4, 2]);

        private string SymbolToPath(ISymbol slotsSymbol)
        {
            string symbolName = slotsSymbol?.GetType().Name;
            return $"pack://application:,,,/BookOfBruh.View;component/Images/{symbolName}.png";
        }
    }
}
