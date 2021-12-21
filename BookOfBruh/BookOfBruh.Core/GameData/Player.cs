namespace BookOfBruh.Core.GameData
{
    public interface IPlayer
    {
        public double BruhCoins { get; set; }
    }

    public class Player : NotifyPropertyChangedBase, IPlayer
    {
        private double bruhCoins;

        public double BruhCoins
        {
            get => this.bruhCoins;
            set
            {
                this.bruhCoins = value;
                OnPropertyChanged();
            }
        }

        public string Name { get; set; }
        
    }
}
