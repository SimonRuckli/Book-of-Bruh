namespace BookOfBruh.Core.Slot
{
    using BookOfBruh.Core.Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        public ISymbol Generate(int number)
        {
            return new TenSymbol();
        }
    }
}