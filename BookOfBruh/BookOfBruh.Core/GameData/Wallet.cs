namespace BookOfBruh.Core.GameData
{
    public interface IWallet
    {
        public double BruhCoins { get; set; }
    }

    public class Wallet
    {
        public Wallet(double bruhCoins)
        {
            this.BruhCoins = bruhCoins;
        }

        public double BruhCoins { get; set; }
    }
}
