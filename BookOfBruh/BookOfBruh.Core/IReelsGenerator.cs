namespace BookOfBruh.Core
{
    using System.Collections.Generic;
    using Reels;

    public interface IReelsGenerator
    {
        List<IReel> Generate(int count);
    }
}