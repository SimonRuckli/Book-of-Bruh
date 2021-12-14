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
            this.OpenStakeClickCommand = new RelayCommand(this.OpenStakeClick);
            this.OpenWalletClickCommand = new RelayCommand(this.OpenWalletClick);
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
            get => this.stake;
            set
            {
                this.stake = value;
                this.state.Handle();
            }
        }

        public void AddToWallet()
        {
            this.state.Handle();
            this.RefreshBruhCoins();
        }

        public void FinishedSpinning()
        {
            this.state.Handle();

            this.RefreshBruhCoins();
        }

        public void TransitionTo(ControlState newState)
        {
            this.state = newState;
            this.state.SetContext(this);
        }

        private void SpinClick()
        {
            bool trySpin = this.state.TrySpin();

            Result<SpinResult> result = this.game.Spin(this.Stake);

            this.Spin?.Invoke(this, new SpinEventArgs(result.Value));
        }

        private bool SpinIsValid()
        {
            return this.state is ReadyToSpinState;
        }

        private void OpenStakeClick()
        {
            this.OpenStake?.Invoke(this, EventArgs.Empty);
        }

        private void OpenWalletClick()
        {
            this.OpenWallet?.Invoke(this, EventArgs.Empty);
        }

        private void RefreshBruhCoins()
        {
            this.OnPropertyChanged(nameof(this.BruhCoins));
        }
    }
}
