namespace BookOfBruh.Core.SlotGeneration
{
    using System;
    using BookOfBruh.Core.Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        public ISymbol Generate(int number)
        {
            if (number < 20)
            {
                return new TenSymbol();
            }
            if (number is >= 20 and < 40)
            {
                return new JSymbol();
            }
            if (number is >= 40 and < 55)
            {
                return new QSymbol();
            }
            if (number is >= 55 and < 70)
            {
                return new KSymbol();
            }
            if (number is >= 70 and < 80)
            {
                return new ASymbol();
            }
            if (number is >= 80 and < 88)
            {
                return new JoegiSymbol();
            }
            if (number is >= 88 and < 94)
            {
                return new VincSymbol();
            }
            if (number is >= 94 and < 98)
            {
                return new SimiSymbol();
            }
            if (number is >= 98 and < 100)
            {
                return new WildSymbol();
            }

            throw new ArgumentOutOfRangeException($"{number} cannot be over 99");
        }
    }
}