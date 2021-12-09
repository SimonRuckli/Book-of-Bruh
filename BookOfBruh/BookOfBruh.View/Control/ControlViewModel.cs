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
        private ControlState state;

        public ControlViewModel(Game game, ControlState state)
        {
            this.game = game;

            this.state = state;
            this.state.SetContext(this);

            this.SpinClickCommand = new RelayCommand(this.SpinClick, this.SpinIsValid);
            this.OpenStakeClickCommand = new RelayCommand(this.OpenStakeClick, this.OpenStakeIsValid);
        }

        public RelayCommand OpenStakeClickCommand { get; set; }

        public RelayCommand SpinClickCommand { get; set; }

        public EventHandler OpenStake;
        public EventHandler<SpinEventArgs> Spin;

        public double BruhCoins => this.game.Player.BruhCoins;

        public double Stake { get; set; }

        public void TransitionTo(ControlState newState)
        {
            this.state = newState;
            this.state.SetContext(this);
        }

        private bool OpenStakeIsValid()
        {
            return true;
        }

        private void OpenStakeClick()
        {
            this.OpenStake?.Invoke(this, EventArgs.Empty);
        }

        private bool SpinIsValid()
        {
            return this.state is ReadyToSpinState;
        }

        private void SpinClick()
        {
            this.state.Handle();

            Result<SpinResult> result = this.game.Spin(this.Stake);
            
            this.Spin?.Invoke(this, new SpinEventArgs(result.Value));

            OnPropertyChanged(nameof(this.BruhCoins));

            this.state.Handle();
        }

    }

    public class SpinEventArgs : EventArgs
    {
        public SpinEventArgs(SpinResult spinResult)
        {
            SpinResult = spinResult;
        }

        public SpinResult SpinResult { get;}
    }
}
