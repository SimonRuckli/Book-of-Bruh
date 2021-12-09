namespace BookOfBruh.View.Wallet
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaktionslogik für WalletView.xaml
    /// </summary>
    public partial class WalletView : Window
    {
        public WalletView(WalletViewModel walletViewModel)
        {
            this.DataContext = walletViewModel;

            walletViewModel.CloseView += this.CloseView;

            InitializeComponent();
        }

        private void CloseView(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
