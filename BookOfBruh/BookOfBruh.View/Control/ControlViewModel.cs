namespace BookOfBruh.View.Control
{
    using System;
    using System.Threading.Tasks;
    using Core;
    using Core.GameData;
    using Infrastructure.Commands;
    using Infrastructure.EventArgs;

    public class ControlViewModel : NotifyPropertyChangedBase
    {
        private readonly Game game;

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
        public EventHandler<FinishedSpinEventArgs> FinishedSpin;
        public EventHandler StartedSpin;

        public double BruhCoins => this.game.Player.BruhCoins;

        public double Stake
        {
            get => this.game.Player.Stake;
            set => this.game.Player.Stake = value;
        }

        private async void SpinClick()
        {
            this.StartedSpin?.Invoke(this, EventArgs.Empty);

            Task<double> spin = this.game.Spin(this.Stake);

            this.RefreshBruhCoins();

            double win = await spin;

            this.RefreshBruhCoins();

            this.FinishedSpin?.Invoke(this, new FinishedSpinEventArgs(win));
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
        public void RefreshBruhCoins()
        {
            this.OnPropertyChanged(nameof(this.BruhCoins));
        }
    }
}
