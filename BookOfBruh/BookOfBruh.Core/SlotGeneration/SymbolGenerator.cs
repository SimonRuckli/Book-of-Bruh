namespace BookOfBruh.Core.SlotGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using BookOfBruh.Core.Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        private readonly List<ISymbol> symbols;

        public SymbolGenerator()
        {
            this.symbols = GenerateSymbols();
        }

        private static List<ISymbol> GenerateSymbols()
        {
            List<ISymbol> test = new List<ISymbol>();

            for (int i = 0; i < 18; i++)
            {
                test.Add(new TenSymbol());
                test.Add(new JSymbol());
            }

            for (int i = 0; i < 14; i++)
            {
                test.Add(new QSymbol());
                test.Add(new KSymbol());
            }

            for (int i = 0; i < 10; i++)
            {
                test.Add(new ASymbol());
            }

            for (int i = 0; i < 8; i++)
            {
                test.Add(new JoegiSymbol());
            }

            for (int i = 0; i < 7; i++)
            {
                test.Add(new VincSymbol());
            }

            for (int i = 0; i < 6; i++)
            {
                test.Add(new SimiSymbol());
            }

            for (int i = 0; i < 5; i++)
            {
                test.Add(new WildSymbol());
            }

            return test;
        }
        public ISymbol Generate(int number)
        {
            return this.symbols[number];
        }
    }
}