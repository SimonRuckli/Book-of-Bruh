namespace BookOfBruh.Core.SlotGeneration
{
    using System.Collections.Generic;
    using Reels;

    public interface IReelsGenerator
    {
        List<IReel> Generate(int count);
    }
}