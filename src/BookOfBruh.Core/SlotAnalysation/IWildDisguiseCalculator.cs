namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using GameData;
    using Symbols;

    public interface IWildDisguiseCalculator
    {
        List<ISymbol> Calculate(Point startPoint, Slots slots);
    }

    public class WildDisguiseCalculator : IWildDisguiseCalculator
    {
        public List<ISymbol> Calculate(Point startPoint, Slots slots)
        {
            var disguises = new List<ISymbol> { new WildSymbol() };

            int nextColumn = startPoint.X + 1;

            for (int y = -1; y <= +1; y++)
            {
                var nextPoint = new Point(nextColumn, startPoint.Y + y);

                if (IsInRange(nextPoint, slots))
                {
                    ISymbol symbol = slots.Symbols[nextColumn, startPoint.Y + y];

                    if (symbol is WildSymbol)
                    {
                        disguises.AddRange(Calculate(nextPoint, slots));
                    }
                    else
                    {
                        disguises.Add(symbol);
                    }
                }
            }

            return disguises.Distinct().ToList();
        }


        private static bool IsInRange(Point point, Slots slots)
        {
            if (0 > point.X || point.Y < 0)
            {
                return false;
            }

            if (slots.Columns <= point.X || point.Y >= slots.Rows)
            {
                return false;
            }

            return true;
        }
    }
}