namespace BookOfBruh.Core.SlotGeneration
{
    using System.Collections.Generic;
    using Symbols;

    public class SymbolListGenerator : ISymbolListGenerator
    {
        private const int levelOneSymbolChance = 18;
        private const int levelTwoSymbolChance = 14;
        private const int levelThreeSymbolChance = 10;
        private const int levelFourSymbolChance = 8;
        private const int levelFiveSymbolChance = 7;
        private const int levelSixSymbolChance = 6;
        private const int levelSevenSymbolChance = 5;

        public List<ISymbol> Generate()
        {
            var symbols = new List<ISymbol>();

            symbols.AddRange(GenerateListOfSameSymbols(new TenSymbol(), levelOneSymbolChance));
            symbols.AddRange(GenerateListOfSameSymbols(new JSymbol(), levelOneSymbolChance));
            symbols.AddRange(GenerateListOfSameSymbols(new QSymbol(), levelTwoSymbolChance));
            symbols.AddRange(GenerateListOfSameSymbols(new KSymbol(), levelTwoSymbolChance));
            symbols.AddRange(GenerateListOfSameSymbols(new ASymbol(), levelThreeSymbolChance));
            symbols.AddRange(GenerateListOfSameSymbols(new JoegiSymbol(), levelFourSymbolChance));
            symbols.AddRange(GenerateListOfSameSymbols(new VincSymbol(), levelFiveSymbolChance));
            symbols.AddRange(GenerateListOfSameSymbols(new SimiSymbol(), levelSixSymbolChance));
            symbols.AddRange(GenerateListOfSameSymbols(new WildSymbol(), levelSevenSymbolChance));

            return symbols;
        }

        private static IEnumerable<ISymbol> GenerateListOfSameSymbols(ISymbol symbol, int count)
        {
            var symbols = new List<ISymbol>();

            for (int i = 0; i < count; i++)
            {
                symbols.Add(symbol);
            }

            return symbols;
        }
    }
}