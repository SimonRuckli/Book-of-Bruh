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
        private double stake = 1;

        public ControlViewModel(Game game, ControlState state)
        {
            this.game = game;

            this.state = state;
            this.state.SetContext(this);

            this.SpinClickCommand = new RelayCommand(this.SpinClick, this.SpinIsValid);
            this.OpenStakeClickCommand = new RelayCommand(this.OpenStakeClick, this.OpenStakeIsValid);
            this.OpenWalletClickCommand = new RelayCommand(this.OpenWalletClick, this.OpenWalletIsValid);
        }

        public RelayCommand OpenWalletClickCommand { get; set; }

        public RelayCommand OpenStakeClickCommand { get; set; }

        public RelayCommand SpinClickCommand { get; set; }

        public EventHandler OpenStake;
        public EventHandler OpenWallet;
        public EventHandler<SpinEventArgs> Spin;

        public double BruhCoins => this.game.Player.BruhCoins;

        public double Stake
        {
            get => stake;
            set
            {
                stake = value;
                this.state.Handle();
            }
        }


        public void TransitionTo(ControlState newState)
        {
            this.state = newState;
            this.state.SetContext(this);
        }

        private bool OpenStakeIsValid()
        {
            return true;
        }

        private bool OpenWalletIsValid()
        {
            return true;
        }

        private void OpenStakeClick()
        {
            this.OpenStake?.Invoke(this, EventArgs.Empty);
        }

        private void OpenWalletClick()
        {
            this.OpenWallet?.Invoke(this, EventArgs.Empty);
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

            this.RefreshBruhCoins();
        }

        public void RefreshBruhCoins()
        {
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
