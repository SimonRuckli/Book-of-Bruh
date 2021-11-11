using System.Collections.Generic;
using System.Data;
using System.Linq;
using BookOfBruh.Core.Symbols;

namespace BookOfBruh.Core.SlotAnalysation
{
    using System;
    using BookOfBruh.Core.GameData;

    public class SlotAnalyzer
    {
        public double Analyze(Slots slots)
        {
            List<ISymbol> row = new List<ISymbol>();
          
            for (int x = 0; x < slots.Columns; x++)
            {
                if (row.Count == 0)
                {
                    row.Add(slots.Symbols[x,0]);
                }
                else if(slots.Symbols[x,0].GetType() == row.Last().GetType())
                {
                    row.Add(slots.Symbols[x,0]);
                }
            }

            if (row.Count == 4)
            {
                return 6;
            }
            if (row.Count == 5)
            {
                return 24;
            }

            return 3;
        }
    }
}
