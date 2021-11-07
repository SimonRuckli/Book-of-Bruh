namespace BookOfBruh.Core.Slot
{
    using Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        public ISymbol Generate(int number)
        {
            if (number % 2 == 0)
            {
                if (number % 3 == 0)
                {
                    return new QSymbol();
                }
                return new TenSymbol();
            }

            return new JSymbol();
        }
    }
}