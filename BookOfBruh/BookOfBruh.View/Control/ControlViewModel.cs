namespace BookOfBruh.View.Control
{
    using System;
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
            this.OpenStakeClickCommand = new RelayCommand(this.OpenStakeClick, this.OpenStakeIsValid);
        }

        private bool OpenStakeIsValid()
        {
            return true;
        }

        private void OpenStakeClick()
        {
            this.OpenStake?.Invoke(this, EventArgs.Empty);
        }

        public RelayCommand OpenStakeClickCommand { get; set; }

        public RelayCommand SpinClickCommand { get; set; }

        public double BruhCoins => this.game.Player.BruhCoins;

        public double Stake { get; set; }

        public EventHandler OpenStake;

        private bool SpinIsValid()
        {
            return true;
        }

        private void SpinClick()
        {
            Result<SpinResult> result = this.game.Spin(this.Stake);

            SpinResult resultValue = result.Value;
            this.game.Player.BruhCoins += resultValue.BruhCoins;
        }

    }
}
