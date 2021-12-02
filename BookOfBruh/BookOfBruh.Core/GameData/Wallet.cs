namespace BookOfBruh.Core.GameData
{
    public interface IWallet
    {
        public double BruhCoins { get; set; }
    }

    public class Wallet : IWallet
    {
        public double BruhCoins { get; set; }
    }
}
