namespace BookOfBruh.Core.Slot
{
    using Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        public ISymbol Generate(int number)
        {
            if (number % 13 == 0)
            {
                return new SimiSymbol();
            }
            if (number % 11 == 0)
            {
                return new VincSymbol();
            }
            if (number % 9 == 0)
            {
                return new JoegiSymbol();
            }
            if (number % 7 == 0)
            {
                return new ASymbol();
            }

            if (number % 2 == 0)
            {
                if (number % 3 == 0)
                {
                    return new QSymbol();
                }
                return new TenSymbol();
            }
            else
            {
                if (number % 3 == 0)
                {
                    return new KSymbol();
                }
                return new JSymbol();
            }
        }
    }
}