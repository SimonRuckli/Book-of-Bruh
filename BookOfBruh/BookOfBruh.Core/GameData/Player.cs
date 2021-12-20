namespace BookOfBruh.Core.GameData
{ using Reels;
    public interface IPlayer
    {
        public double BruhCoins { get; set; }
    }

    public class Player : NotifyPropertyChangedBase, IPlayer
    {
        private readonly Wallet wallet;

        public Player(Wallet wallet)
        {
            this.wallet = wallet;
        }

        public double BruhCoins
        {
            get => this.wallet.BruhCoins;
            set
            {
                this.wallet.BruhCoins = value;
                OnPropertyChanged();
            }
        }

        public string Name { get; set; }
        
    }
}
