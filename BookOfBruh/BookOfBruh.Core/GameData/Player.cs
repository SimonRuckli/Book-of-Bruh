namespace BookOfBruh.Core.GameData
{
    public interface IPlayer
    {
        public double BruhCoins { get; set; }
        public double Stake { get; set; }
    }

    public class Player : NotifyPropertyChangedBase, IPlayer
    {
        private double bruhCoins;
        private double stake = 1;

        public double BruhCoins
        {
            get => this.bruhCoins;
            set
            {
                this.bruhCoins = value;
                OnPropertyChanged();
            }
        }

        public double Stake
        {
            get => stake;
            set
            {
                stake = value;
                OnPropertyChanged();
            }
        }
    }
}
