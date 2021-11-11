namespace BookOfBruh.Core.SlotAnalysation
{
    using BookOfBruh.Core.Symbols;
    using CSharpFunctionalExtensions;
    using BookOfBruh.Core.GameData;

    public class SlotAnalyzer
    {
        public double Analyze(Slots slots)
        {
            int sameSymbolCount = 1;

            bool foundNextValue = true;
            int currentX = 0;
            int currentY = 0;

            while (foundNextValue)
            {
                Result<(int x, int y)> nextPosition = this.FindNextCountableSymbolPosition(currentX, currentY, slots.Symbols);

                if (nextPosition.IsSuccess)
                {
                    sameSymbolCount++;
                    (currentX, currentY) = nextPosition.Value;
                }
                else
                {
                    foundNextValue = false;
                }
            }

            if (sameSymbolCount == 4)
            {
                return 6;
            }
            if (sameSymbolCount == 5)
            {
                return 24;
            }
            if (sameSymbolCount == 3)
            {
                return 3;
            }

            return 0;
        }

        private Result<(int x, int y)> FindNextCountableSymbolPosition(int currentX, int currentY, ISymbol[,] symbols)
        {
            int nextX = currentX + 1;
            int nextY = currentY - 1;

            ISymbol currentSymbol = symbols[currentX, currentY];

            if (nextY < 0)
            {
                nextY++;
            }

            while (nextY < 3 && nextX < 5)
            {
                if (symbols[nextX, nextY].GetType() == currentSymbol.GetType())
                {
                    return (nextX, nextY);
                }

                nextY++;
            }

            return Result.Failure<(int x, int y)>("Found no next Symbol");
        }
    }
}
