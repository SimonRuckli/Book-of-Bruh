namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Drawing;
    using BookOfBruh.Core.Symbols;
    using CSharpFunctionalExtensions;
    using BookOfBruh.Core.GameData;
    using System.Collections.Generic;
    using System.Linq;

    public class SlotAnalyzer
    {
        public double Analyze(Slots slots)
        {

            List<(ISymbol symbol, int count)> sameSymbols = CalculateSameSymbols(slots);

            return CalculateMultiplier(sameSymbols);
            
        }

        private static double CalculateMultiplier(List<(ISymbol symbol, int count)> sameSymbols)
        {
            int multiplier = 0;

            foreach ((ISymbol symbol, int count) in sameSymbols)
            {
                switch (count)
                {
                    case 3:
                        multiplier += 3 * symbol.Rarity;
                        break;
                    case 4:
                        multiplier += 6 * symbol.Rarity;
                        break;
                    case 5:
                        multiplier += 24 * symbol.Rarity;
                        break;
                }
            }

            return multiplier;
        }

        private static List<(ISymbol symbol, int count)> CalculateSameSymbols(Slots slots)
        {
            List<(ISymbol symbol, int count)> sameSymbols = new List<(ISymbol symbol, int count)>();

            for (int i = 0; i < slots.Rows; i++)
            {
                Point start = new Point(0, i);
                List <Point> pattern = CalculateSameSymbolCount(slots.Symbols, start);
                if (IsPatternValid(pattern))
                {
                    sameSymbols.Add((slots.Symbols[start.X, start.Y], pattern.Count));
                }
            }

            return sameSymbols;
        }

        private static List<Point> CalculateSameSymbolCount(ISymbol[,] symbols, Point start)
        {
            List<Point> points = new List<Point>() { start };

            Result<Point> nextPosition = FindNextCountableSymbolPosition(start, symbols);

            while (nextPosition.IsSuccess)
            {
                points.Add(nextPosition.Value);
                nextPosition = FindNextCountableSymbolPosition(nextPosition.Value, symbols);
            }

            return points;
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

        private static bool IsPatternValid(IReadOnlyList<Point> pattern)
        {
            return CanPatternBeOnlyDiagonal(pattern)
                   && IsPatternOnlyDiagonal(pattern)
                   || IsPatternSymmetrical(pattern);
        }

        private static bool IsPatternOnlyDiagonal(IReadOnlyList<Point> pattern)
        {
            for (int i = 1; i < pattern.Count; i++)
            {
                if (pattern[i].Y == pattern[i - 1].Y)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPatternSymmetrical(IReadOnlyCollection<Point> pattern)
        {
            IEnumerable<Point> reverse = pattern.Reverse<Point>();

            IEnumerable<(Point o, Point r)> zip = pattern.Zip(reverse);

            IEnumerable<(Point o, Point r)> same = zip.Where(z => z.o.Y == z.r.Y);

            return same.Count() == pattern.Count();
        }

        private static bool CanPatternBeOnlyDiagonal(IReadOnlyCollection<Point> pattern)
        {
            return pattern.Count is 3 or 5;
        }
    }
}
