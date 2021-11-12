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
            int sameSymbolCount = 1;
            
            Point current = new Point(0, 0);

            Result<Point> nextPosition = FindNextCountableSymbolPosition(current, slots.Symbols);

            while (nextPosition.IsSuccess)
            {
                sameSymbolCount++;
                current = nextPosition.Value;
                nextPosition = FindNextCountableSymbolPosition(current, slots.Symbols);
            }

            if (sameSymbolCount == 3)
            {
                return 3;
            }
            if (sameSymbolCount == 4)
            {
                return 6;
            }
            if (sameSymbolCount == 5)
            {
                return 24;
            }

            return 0;
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
