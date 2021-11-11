namespace BookOfBruh.Core.SlotGeneration
{
    using System.Collections.Generic;
    using BookOfBruh.Core.Symbols;

    public interface ISymbolListGenerator
    {
        List<ISymbol> Generate();
    }
}
