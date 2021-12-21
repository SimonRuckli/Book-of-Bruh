namespace BookOfBruh.View.AcceptanceTest.Infrastructure
{
    using Core.GameData;

    internal class FakeIPlayer : IPlayer
    {
        public double BruhCoins { get; set; } = 1;
        public double Stake { get; set; }
    }
}
