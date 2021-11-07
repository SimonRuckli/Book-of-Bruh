namespace BookOfBruh.Core
{
    public class Slots
    {
        public ISymbol[,] Symbols { get; }

        public Slots(ISymbol[,] symbols)
        {
            this.Symbols = symbols;
        }
    }
}
