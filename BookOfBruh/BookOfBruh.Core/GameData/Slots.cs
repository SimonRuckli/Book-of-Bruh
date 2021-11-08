namespace BookOfBruh.Core.GameData
{
    using BookOfBruh.Core.Symbols;

    public class Slots
    {
        public ISymbol[,] Symbols { get; }

        public Slots(ISymbol[,] symbols)
        {
            this.Symbols = symbols;
        }
    }
}
