namespace BookOfBruh.Core.SlotGeneration
{
    using System.Collections.Generic;
    using Symbols;

    public interface ISymbolListGenerator
    {
        List<ISymbol> Generate();
    }
}
