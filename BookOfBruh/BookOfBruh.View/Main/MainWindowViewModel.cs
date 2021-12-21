namespace BookOfBruh.View.Main
{
    using System;
    using Control;
    using Core.GameData;
    using Infrastructure.Commands;
    using Infrastructure.EventArgs;
    using Slot;
    using Stake;
    using ViewService;
    using Wallet;
    using Win;

    public class MainWindowViewModel : NotifyPropertyChangedBase
    {
        private readonly WalletViewModel walletViewModel;

        private readonly IStakeViewService stakeViewService;
        private readonly IWalletViewService walletViewService;

        public MainWindowViewModel(
            SlotViewModel slotViewModel, 
            ControlViewModel controlViewModel, 
            StakeViewModel stakeViewModel,
            WinViewModel winViewModel,
            WalletViewModel walletViewModel,
            IStakeViewService stakeViewService,
            IWalletViewService walletViewService
        )
        {
            this.SlotViewModel = slotViewModel;
            this.ControlViewModel = controlViewModel;
            this.StakeViewModel = stakeViewModel;
            this.WinViewModel = winViewModel;
            this.walletViewModel = walletViewModel;
            this.stakeViewService = stakeViewService;
            this.walletViewService = walletViewService;

            this.ControlViewModel.Spin += this.Spin;

            this.ControlViewModel.OpenStake += this.OpenStake;
            this.StakeViewModel.StakeChanged += this.StakeChanged;

            this.ControlViewModel.OpenWallet += this.OpenWallet;
            this.walletViewModel.AddedToWallet += this.AddToWallet;

            this.ViewClosedCommand = new RelayCommand(this.ViewClosed);
        }

        public SlotViewModel SlotViewModel { get; }
        public ControlViewModel ControlViewModel { get; }
        public StakeViewModel StakeViewModel { get; }
        public WinViewModel WinViewModel { get; }

        public RelayCommand ViewClosedCommand { get; set; }

        private void Spin(object sender, SpinEventArgs e)
        {
            this.WinViewModel.StartedSpinning();
        }

        private void OpenStake(object sender, EventArgs e)
        {
            this.stakeViewService.CreateWindow(this.StakeViewModel);
        }

        private void StakeChanged(object sender, StakeEventArgs e)
        {
            this.ControlViewModel.Stake = e.Stake;
            this.CloseStakeView();
        }

        private void OpenWallet(object sender, EventArgs e)
        {
            this.walletViewService.CreateWindow(this.walletViewModel);
        }

        private void AddToWallet(object sender, AddToWalletArgs e)
        {
            if (e.AddToWallet.IsSuccess)
            {
                this.ControlViewModel.AddToWallet();
                this.CloseWalletView();
            }
        }

        private void ViewClosed()
        {
            this.CloseStakeView();
            this.CloseWalletView();
        }

        private void CloseWalletView()
        {
            this.walletViewModel.RequestClose();
        }

        private void CloseStakeView()
        {
            this.StakeViewModel.RequestClose();
        }
    }
}