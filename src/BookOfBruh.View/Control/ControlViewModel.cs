namespace BookOfBruh.View.Control
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Core;
    using Core.GameData;
    using Infrastructure.Commands;
    using Infrastructure.EventArgs;

    public class ControlViewModel : NotifyPropertyChangedBase
    {
        private readonly ISlotMachine slotMachine;

        public ControlViewModel(ISlotMachine slotMachine)
        {
            this.slotMachine = slotMachine;
            
            this.SpinClickCommand = new AsyncRelayCommand(this.SpinClick, this.SpinIsValid);
            this.OpenStakeClickCommand = new RelayCommand(this.OpenStakeClick);
            this.OpenWalletClickCommand = new RelayCommand(this.OpenWalletClick);
        }
        

        public RelayCommand OpenWalletClickCommand { get; }
        public RelayCommand OpenStakeClickCommand { get; }
        public AsyncRelayCommand SpinClickCommand { get; }

        public EventHandler OpenStake;
        public EventHandler OpenWallet;
        public EventHandler<FinishedSpinEventArgs> FinishedSpin;
        public EventHandler StartedSpin;

        public double BruhCoins => this.slotMachine.BruhCoins;

        public double Stake
        {
            get => this.slotMachine.Stake;
            set => this.slotMachine.Stake = value;
        }

        public void RefreshSpinButton()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        private async Task SpinClick()
        {
            this.StartedSpin?.Invoke(this, EventArgs.Empty);

            var spin = this.slotMachine.State.TrySpin();

            this.RefreshBruhCoins();

            var win = await spin;

            this.RefreshBruhCoins();

            this.FinishedSpin?.Invoke(this, new FinishedSpinEventArgs(win));
        }

        private bool SpinIsValid()
        {
            return this.slotMachine.State is ReadyToSpinState;
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
