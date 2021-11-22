namespace BookOfBruh.Core.GameData
{
    using Symbols;

    public class Slots
    {
        public int Columns => this.Symbols.GetLength(0);
        public int Rows => this.Symbols.GetLength(1);

        public ISymbol[,] Symbols { get; }

        public Slots(ISymbol[,] symbols)
        {
            this.Symbols = symbols;
        }
    }
}
