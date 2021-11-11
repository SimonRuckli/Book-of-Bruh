﻿namespace BookOfBruh.Core.SlotGeneration
{
    using System;
    using BookOfBruh.Core.GameData;
    using BookOfBruh.Core.Symbols;

    public class SlotGenerator
    {
        private readonly ISymbolGenerator symbolGenerator;
        private readonly Random random;

        public SlotGenerator(ISymbolGenerator symbolGenerator)
        {
            this.symbolGenerator = symbolGenerator;
            this.random = new Random();
        }

        public Slots Generate()
        {
            ISymbol[,] symbols = new ISymbol[5, 3];

            for (int x = 0; x < symbols.GetLength(0); x++)
            {
                for (int y = 0; y < symbols.GetLength(1); y++)
                {
                    int next = this.random.Next(1000);
                    symbols[x, y] = this.symbolGenerator.Generate(next);
                }
            }
            return new Slots(symbols);
        }
    }
}