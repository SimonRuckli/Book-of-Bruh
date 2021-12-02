namespace BookOfBruh.Core.GameData
{
    public interface IPlayer
    {
        public double BruhCoins { get; set; }
        public void AddBruhCoins(double bruhCoins);
    }

    public class Player : IPlayer
    {
        private readonly Wallet wallet;

        public Player(Wallet wallet)
        {
            this.wallet = wallet;
        }

        public double BruhCoins
        {
            get => this.wallet.BruhCoins;
            set => this.wallet.BruhCoins = value;
        }

        public string Name { get; set; }

        public void AddBruhCoins(double bruhCoins)
        {
            throw new System.NotImplementedException();
        }
    }
}
