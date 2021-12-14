namespace BookOfBruh.View.ViewService
{
    using Wallet;

    public interface IWalletViewService
    {
        public void CreateWindow(WalletViewModel walletViewModel);
    }

    public class WalletViewService : IWalletViewService
    {
        public void CreateWindow(WalletViewModel walletViewModel)
        {
            WalletView view = new WalletView(walletViewModel)
            {
                Topmost = true
            };
            view.ShowDialog();
        }
    }
}
