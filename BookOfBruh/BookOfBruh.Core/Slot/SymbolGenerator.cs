﻿namespace BookOfBruh.Core.Slot
{
    using Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        public ISymbol Generate(int number)
        {
            if (number % 8 == 0)
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