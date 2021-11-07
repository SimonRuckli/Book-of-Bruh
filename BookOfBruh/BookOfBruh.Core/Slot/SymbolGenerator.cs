namespace BookOfBruh.Core.Slot
{
    using Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        public ISymbol Generate(int number)
        {
            if (number % 2 == 0)
            {
                return new TenSymbol();
            }

            return new JSymbol();
        }
    }
}