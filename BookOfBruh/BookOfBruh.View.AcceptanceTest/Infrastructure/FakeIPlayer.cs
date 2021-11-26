namespace BookOfBruh.View.AcceptanceTest.Infrastructure
{
    using Core.GameData;

    internal class FakeIPlayer : IPlayer
    {
        public string Name { get; }
        public double BruhCoins { get; set; } = 1;

        public void AddBruhCoins(double bruhCoins)
        {
            throw new System.NotImplementedException();
        }
    }
}
