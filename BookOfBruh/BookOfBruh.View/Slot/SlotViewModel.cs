namespace BookOfBruh.View.Slot
{
    using Core.GameData;
    using Core.Symbols;
    using Infrastructure;

    public class SlotViewModel : NotifyPropertyChangedBase
    {
        public Slots Slots { get; set; }

        public string Symbol00 => SymbolToString(this.Slots?.Symbols[0, 0]);
        public string Symbol10 => SymbolToString(this.Slots?.Symbols[1, 0]);
        public string Symbol20 => SymbolToString(this.Slots?.Symbols[2, 0]);
        public string Symbol30 => SymbolToString(this.Slots?.Symbols[3, 0]);
        public string Symbol40 => SymbolToString(this.Slots?.Symbols[4, 0]);

        public string Symbol01 => SymbolToString(this.Slots?.Symbols[0, 1]);
        public string Symbol11 => SymbolToString(this.Slots?.Symbols[1, 1]);
        public string Symbol21 => SymbolToString(this.Slots?.Symbols[2, 1]);
        public string Symbol31 => SymbolToString(this.Slots?.Symbols[3, 1]);
        public string Symbol41 => SymbolToString(this.Slots?.Symbols[4, 1]);

        public string Symbol02 => SymbolToString(this.Slots?.Symbols[0, 2]);
        public string Symbol12 => SymbolToString(this.Slots?.Symbols[1, 2]);
        public string Symbol22 => SymbolToString(this.Slots?.Symbols[2, 2]);
        public string Symbol32 => SymbolToString(this.Slots?.Symbols[3, 2]);
        public string Symbol42 => SymbolToString(this.Slots?.Symbols[4, 2]);

        private static string SymbolToString(ISymbol slotsSymbol)
        {
            return slotsSymbol?.GetType().Name;
        }
    }
}
