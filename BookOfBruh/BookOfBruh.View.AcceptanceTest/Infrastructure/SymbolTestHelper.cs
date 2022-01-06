namespace BookOfBruh.View.AcceptanceTest.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Symbols;

    internal class SymbolTestHelper
    {

        internal static ISymbol[,] SymbolsFromPattern(string pattern)
        {
            List<List<ISymbol>> enumerable = pattern.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(line => line.Select(c => SymbolFromChar(c)).ToList()).ToList();

            var symbols = new ISymbol[5, 3];

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
                '-' => new Fs(),
                '_' => new Fs2(),
                _ => throw new ArgumentException()
            };
        }
    }
    internal struct Fs : ISymbol
    {
        public double Value => 0;
    }
    internal struct Fs2 : ISymbol
    {
        public double Value => 0;
    }
}
