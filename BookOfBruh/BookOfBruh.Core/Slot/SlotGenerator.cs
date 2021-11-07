namespace BookOfBruh.Core.Slot
{
    public class SlotGenerator
    {
        private readonly ISymbolGenerator symbolGenerator;

        public SlotGenerator(ISymbolGenerator symbolGenerator)
        {
            this.symbolGenerator = symbolGenerator;
        }

        public Slots Generate()
        {
            ISymbol[,] symbols = new ISymbol[5, 3];

            for (int x = 0; x < symbols.GetLength(0); x++)
            {
                for (int y = 0; y < symbols.GetLength(1); y++)
                {
                    symbols[x, y] = this.symbolGenerator.Generate(0);
                }
            }
            return new Slots(symbols);
        }
    }
}