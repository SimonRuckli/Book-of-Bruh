namespace BookOfBruh.View.Wallet
{
    using System;
    using CSharpFunctionalExtensions;

    public class AddToWalletArgs : EventArgs
    {
        public AddToWalletArgs(Result<double> addToWallet)
        {
            AddToWallet = addToWallet;
        }

        public Result<double> AddToWallet { get; set; }
    }
}