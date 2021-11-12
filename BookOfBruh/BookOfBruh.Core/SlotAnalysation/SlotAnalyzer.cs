namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using BookOfBruh.Core.Symbols;
    using CSharpFunctionalExtensions;
    using BookOfBruh.Core.GameData;
    using System.Collections.Generic;

    public class SlotAnalyzer
    {
        public double Analyze(Slots slots)
        {

            List<(ISymbol symbol, int count)> sameSymbols = CalculateSameSymbols(slots);

            return CalculateMultiplicator(sameSymbols);
            
        }

        private static double CalculateMultiplicator(List<(ISymbol symbol, int count)> sameSymbols)
        {
            int multiplicator = 0;

            foreach ((ISymbol symbol, int count) sameSymbol in sameSymbols)
            {
                if (sameSymbol.count == 3)
                {
                    multiplicator += 3 * sameSymbol.symbol.Rarity;
                }
                if (sameSymbol.count == 4)
                {
                    multiplicator += 6 * sameSymbol.symbol.Rarity;
                }
                if (sameSymbol.count == 5)
                {
                    multiplicator += 24 * sameSymbol.symbol.Rarity;
                }
            }

            return multiplicator;
        }

        private static List<(ISymbol symbol, int count)> CalculateSameSymbols(Slots slots)
        {
            List<(ISymbol symbol, int count)> sameSymbols = new List<(ISymbol symbol, int count)>();

            for (int i = 0; i < slots.Rows; i++)
            {
                Point start = new Point(0, i);
                int count = CalculateSameSymbolCount(slots.Symbols, start);
                sameSymbols.Add((slots.Symbols[start.X, start.Y], count));
            }

            return sameSymbols;
        }

        private static int CalculateSameSymbolCount(ISymbol[,] symbols, Point start)
        {
            int sameSymbolCount = 1;

            Result<Point> nextPosition = FindNextCountableSymbolPosition(start, symbols);

            while (nextPosition.IsSuccess)
            {
                sameSymbolCount++;
                nextPosition = FindNextCountableSymbolPosition(nextPosition.Value, symbols);
            }

            return sameSymbolCount;
        }

        private static Result<Point> FindNextCountableSymbolPosition(Point current, ISymbol[,] symbols)
        {
            Point next = new Point(current.X + 1, current.Y - 1);

            ISymbol currentSymbol = symbols[current.X, current.Y];

            if (next.Y < 0)
            {
                next.Y++;
            }

            while (next.Y < 3 && next.X < 5)
            {
                if (symbols[next.X, next.Y].GetType() == currentSymbol.GetType())
                {
                    return next;
                }

                next.Y++;
            }

            return Result.Failure<Point>("Found no next Symbol");
        }
    }
}
