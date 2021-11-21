namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BookOfBruh.Core.Symbols;

    internal class SymbolTestHelper
    {

        internal static ISymbol[,] SymbolsFromPattern(string pattern)
        {
            List<List<ISymbol>> enumerable = pattern.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(line => line.Select(c => SymbolFromChar(c)).ToList()).ToList();

            ISymbol[,] symbols = new ISymbol[5, 3];

            for (int y = 0; y < enumerable.Count; y++)
            {
                for (int x = 0; x < enumerable[y].Count; x++)
                {
                    symbols[x, y] = enumerable[y][x];
                }
            }

            return symbols;
        }

        private static ISymbol SymbolFromChar(char c)
        {
            return c switch
            {
                'T' => new TenSymbol(),
                'Q' => new QSymbol(),
                'S' => new SimiSymbol(),
                'H' => new JoegiSymbol(),
                'V' => new VincSymbol(),
                'W' => new WildSymbol(),
                'A' => new ASymbol(),
                'J' => new JSymbol(),
                'K' => new KSymbol(),
                '-' => new FS(),
                '_' => new FS2(),
                _ => throw new ArgumentException()
            };
        }
    }
    internal struct FS : ISymbol
    {
        public double Rarity => 0;
    }
    internal struct FS2 : ISymbol
    {
        public double Rarity => 0;
    }
}
