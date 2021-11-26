namespace BookOfBruh.View.Control
{
    using Core;
    using Core.GameData;
    using CSharpFunctionalExtensions;
    using Infrastructure;
    using Infrastructure.Commands;

    public class ControlViewModel : NotifyPropertyChangedBase
    {
        private readonly Game game;

        public ControlViewModel(Game game)
        {
            this.game = game;
            this.SpinClickCommand = new RelayCommand(this.SpinClick, this.SpinIsValid);
        }

        public RelayCommand SpinClickCommand { get; set; }

        public double BruhCoins
        {
            get
            {
                return game.Player.BruhCoins;
            }
        }

        public float Stake { get; set; }

        private bool SpinIsValid()
        {
            return true;
        }

        private void SpinClick()
        {
            Result<SpinResult> result = this.game.Spin(this.Stake);

            SpinResult resultValue = result.Value;
            game.Player.BruhCoins += resultValue.BruhCoins;
        }

    }
}
