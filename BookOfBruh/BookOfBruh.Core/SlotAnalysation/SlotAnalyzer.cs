namespace BookOfBruh.Core.SlotAnalysation
{
    using System;
    using BookOfBruh.Core.GameData;

    public class SlotAnalyzer
    {
        public double Analyze(Slots slots)
        {
            int symbol1 = 1;
            int symbol2 = 1;
            int symbol3 = 1;

            for (int i = 0; i < slots.Symbols.GetLength(0) - 1; i++)
            {
                if(slots.Symbols[i, 0] == slots.Symbols[i + 1, 0])
                {
                    if (slots.Symbols[0, 0] == slots.Symbols[i + 1, 0])
                        symbol1++;
                    if (slots.Symbols[0, 1] == slots.Symbols[i + 1, 0])
                        symbol2++;
                    if (slots.Symbols[0, 2] == slots.Symbols[i + 1, 0])
                        symbol3++;
                }
                if (slots.Symbols[i, 0] == slots.Symbols[i + 1, 1])
                {
                    if (slots.Symbols[0, 0] == slots.Symbols[i + 1, 0])
                        symbol1++;
                    if (slots.Symbols[0, 1] == slots.Symbols[i + 1, 0])
                        symbol2++;
                    if (slots.Symbols[0, 2] == slots.Symbols[i + 1, 0])
                        symbol3++;
                }
            }

            return 0.00;
        }
    }
}
