namespace BookOfBruh.View.Wallet
{
    using System;
    using Core;
    using Core.GameData;
    using Infrastructure.Commands;
    using Infrastructure.EventArgs;

    public class WalletViewModel : NotifyPropertyChangedBase
    {
        private readonly ISlotMachine slotMachine;

        public WalletViewModel(ISlotMachine slotMachine)
        {
            this.slotMachine = slotMachine;

            this.AddToWalletCommand = new RelayCommand(this.AddToWalletClick);
        }

        public RelayCommand AddToWalletCommand { get; }

        public event EventHandler CloseView;
        public event EventHandler<AddToWalletArgs> AddedToWallet;

        public double BruhCoins => slotMachine.BruhCoins;

        public int Code { get; set; }

        public void RequestClose()
        {
            this.CloseView?.Invoke(this, EventArgs.Empty);
        }

        private void AddToWalletClick()
        {
            var addToWalletResult = this.slotMachine.AddToWallet(this.Code);
            this.AddedToWallet?.Invoke(this, new AddToWalletArgs(addToWalletResult));
        }
    }
}