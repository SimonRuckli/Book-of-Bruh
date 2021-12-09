namespace BookOfBruh.View.Wallet
{
    using System;
    using Core;
    using CSharpFunctionalExtensions;
    using Infrastructure;
    using Infrastructure.Commands;

    public class WalletViewModel : NotifyPropertyChangedBase
    {
        private readonly Game game;

        public WalletViewModel(Game game)
        {
            this.game = game;

            this.AddToWalletCommand = new RelayCommand(this.AddToWalletClick, this.AddToWalletIsValid);
        }


        public event EventHandler CloseView;

        public RelayCommand AddToWalletCommand { get; set; }

        public double BruhCoins => game.Player.BruhCoins;

        public int Code { get; set; }

        private bool AddToWalletIsValid()
        {
            return true;
        }

        private void AddToWalletClick()
        {
            Result<double> addToWalletResult = this.game.AddToWallet(this.Code);
        }

        public void RequestClose()
        {
            this.CloseView?.Invoke(this, EventArgs.Empty);
        }
    }
}