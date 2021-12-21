namespace BookOfBruh.Core.Reels
{
    using System.Threading.Tasks;

    public interface IReel
    {
        Task Spin(int times);

        Slot First { get; }
        Slot Second { get; }
        Slot Third { get; }
    }
}