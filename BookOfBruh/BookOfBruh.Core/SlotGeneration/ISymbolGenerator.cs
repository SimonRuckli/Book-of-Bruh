namespace BookOfBruh.Core.SlotGeneration
{
    using BookOfBruh.Core.Symbols;

    public interface ISymbolGenerator
    {
        public ISymbol Generate(int number);
    }
}