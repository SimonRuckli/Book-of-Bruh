namespace BookOfBruh.Core.SlotAnalysation
{
    using System.Collections.Generic;
    using System.Drawing;
    using GameData;
    using Symbols;

    public interface ISameSymbolCalculator
    {
        List<Point> Calculate(Point startPoint, Slots slots, ISymbol symbol);
    }

    public class SameSymbolCalculator : ISameSymbolCalculator
    {
        public List<Point> Calculate(Point startPoint, Slots slots, ISymbol symbol)
        {
            var points = new List<Point>() { startPoint };

            const int ignoreFirst = 1;

            for (int y = 0; y < slots.Rows; y++)
            {
                for (int x = ignoreFirst; x < slots.Columns; x++)
                {
                    ISymbol current = slots.Symbols[x, y];
                    if (current.GetType() == symbol.GetType() || current is WildSymbol)
                    {
                        points.Add(new Point(x, y));
                    }
                }
            }

            return points;
        
        }
    }
}