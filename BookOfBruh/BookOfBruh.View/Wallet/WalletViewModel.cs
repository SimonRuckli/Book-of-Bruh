namespace BookOfBruh.View.Wallet
{
    using System;
    using Core;
    using Core.Reels;
    using CSharpFunctionalExtensions;
    using Infrastructure.Commands;
    using Infrastructure.EventArgs;

    public class WalletViewModel : NotifyPropertyChangedBase
    {
        private readonly Game game;

        public WalletViewModel(Game game)
        {
            this.game = game;

            this.AddToWalletCommand = new RelayCommand(this.AddToWalletClick);
        }

        public RelayCommand AddToWalletCommand { get; }

        public event EventHandler CloseView;
        public event EventHandler<AddToWalletArgs> AddedToWallet;

        public double BruhCoins => game.Player.BruhCoins;

        public int Code { get; set; }

        public void RequestClose()
        {
            this.CloseView?.Invoke(this, EventArgs.Empty);
        }

        private void AddToWalletClick()
        {
            Result<double> addToWalletResult = this.game.AddToWallet(this.Code);
            this.AddedToWallet?.Invoke(this, new AddToWalletArgs(addToWalletResult));
        }
    }
}