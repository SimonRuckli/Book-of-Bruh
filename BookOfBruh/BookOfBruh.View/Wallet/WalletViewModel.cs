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
        public event EventHandler<AddToWalletArgs> AddedToWallet;

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
            this.AddedToWallet?.Invoke(this, new AddToWalletArgs(addToWalletResult));
        }

        public void RequestClose()
        {
            this.CloseView?.Invoke(this, EventArgs.Empty);
        }
    }

    public class AddToWalletArgs : EventArgs
    {
        public AddToWalletArgs(Result<double> addToWallet)
        {
            AddToWallet = addToWallet;
        }

        public Result<double> AddToWallet { get; set; }
    }
}