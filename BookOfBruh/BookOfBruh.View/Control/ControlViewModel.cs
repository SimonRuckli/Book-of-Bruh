namespace BookOfBruh.View.Control
{
    using System;
    using Core;
    using Core.GameData;
    using Core.Reels;
    using Infrastructure.Commands;
    using Infrastructure.EventArgs;

    public class ControlViewModel : NotifyPropertyChangedBase
    {
        private readonly Game game;
        private double stake = 1;

        public ControlViewModel(Game game)
        {
            this.game = game;
            
            this.SpinClickCommand = new RelayCommand(this.SpinClick, this.SpinIsValid);
            this.OpenStakeClickCommand = new RelayCommand(this.OpenStakeClick);
            this.OpenWalletClickCommand = new RelayCommand(this.OpenWalletClick);
        }

        public RelayCommand OpenWalletClickCommand { get; }
        public RelayCommand OpenStakeClickCommand { get; }
        public RelayCommand SpinClickCommand { get; }

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
            }
        }

        public void AddToWallet()
        {
            this.RefreshBruhCoins();
        }

        private async void SpinClick()
        {

           SpinResult result = await this.game.Spin(this.Stake);

            this.Spin?.Invoke(this, new SpinEventArgs(result));
        }

        private bool SpinIsValid()
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

        private void RefreshBruhCoins()
        {
            this.OnPropertyChanged(nameof(this.BruhCoins));
        }
    }
}
