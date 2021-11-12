namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using BookOfBruh.Core.Symbols;
    using CSharpFunctionalExtensions;
    using BookOfBruh.Core.GameData;

    public class SlotAnalyzer
    {
        public double Analyze(Slots slots)
        {
            int sameSymbolCount = CalculateSameSymbolCount(slots.Symbols);

            ISymbol startSymbol = slots.Symbols[0, 0];

            if (sameSymbolCount == 3)
            {
                return 3 * startSymbol.Rarity;
            }
            if (sameSymbolCount == 4)
            {
                return 6 * startSymbol.Rarity;
            }
            if (sameSymbolCount == 5)
            {
                return 24 * startSymbol.Rarity;
            }

            return 0;
        }

        private static int CalculateSameSymbolCount(ISymbol[,] symbols)
        {
            int sameSymbolCount = 1;

            Point start = new Point(0, 0);

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
