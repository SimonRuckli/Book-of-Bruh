namespace BookOfBruh.Core.Reels
{
    using Symbols;

    public interface IReel
    {
        void Spin(int times);

        ISymbol First { get; }
        ISymbol Second { get; }
        ISymbol Third { get; }
    }
}