namespace BookOfBruh.Core.Slot
{
    using Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        public ISymbol Generate(int number)
        {
            return new TenSymbol();
        }
    }
}