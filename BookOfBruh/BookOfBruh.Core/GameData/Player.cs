namespace BookOfBruh.Core.GameData
{
    public interface IPlayer
    {
        public string Name { get; }
        public double BruhCoins { get; }
        public void AddBruhCoins(double bruhCoins);
    }

    public class Player : IPlayer
    {
        private Wallet wallet;

        public Player(string name, Wallet wallet)
        {
            this.Name = name;
            this.wallet = wallet;
        }

        public double BruhCoins => this.wallet.BruhCoins;

        public string Name { get; set; }

        public void AddBruhCoins(double bruhCoins)
        {
            throw new System.NotImplementedException();
        }
    }
}
