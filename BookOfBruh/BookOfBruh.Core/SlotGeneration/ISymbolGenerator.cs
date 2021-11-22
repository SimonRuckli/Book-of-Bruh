namespace BookOfBruh.Core.SlotGeneration
{
    using Symbols;

    public interface ISymbolGenerator
    {
        public ISymbol Generate(int number);
    }
}