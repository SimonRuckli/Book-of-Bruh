namespace BookOfBruh.Core.SlotGeneration
{
    using System.Collections.Generic;
    using BookOfBruh.Core.Symbols;

    public class SymbolGenerator : ISymbolGenerator
    {
        private readonly List<ISymbol> symbols;

        public SymbolGenerator(ISymbolListGenerator symbolListGenerator)
        {
            this.symbols = symbolListGenerator.Generate();
        }
        
        public ISymbol Generate(int number)
        {
            return this.symbols[number];
        }
    }
}