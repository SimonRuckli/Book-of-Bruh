namespace BookOfBruh.Core.Reels
{
    using System.Threading.Tasks;
    using Symbols;

    public interface IReel
    {
        Task Spin(int times);

        ISymbol First { get; }
        ISymbol Second { get; }
        ISymbol Third { get; }
    }
}