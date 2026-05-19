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

        private readonly IStakeViewService stakeViewService;
        private readonly IWalletViewService walletViewService;
        public readonly WalletViewModel WalletViewModel;

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
            this.WalletViewModel = walletViewModel;
            this.stakeViewService = stakeViewService;
            this.walletViewService = walletViewService;

            this.ControlViewModel.StartedSpin += this.StartedSpin;
            this.ControlViewModel.FinishedSpin += this.FinishedSpin;

            this.ControlViewModel.OpenStake += this.OpenStake;
            this.StakeViewModel.StakeChanged += this.StakeChanged;

            this.ControlViewModel.OpenWallet += this.OpenWallet;
            this.WalletViewModel.AddedToWallet += this.AddToWallet;

            this.ViewClosedCommand = new RelayCommand(this.ViewClosed);
        }

        public SlotViewModel SlotViewModel { get; }
        public ControlViewModel ControlViewModel { get; }
        public StakeViewModel StakeViewModel { get; }
        public WinViewModel WinViewModel { get; }

        public RelayCommand ViewClosedCommand { get; set; }

        private void StartedSpin(object sender, EventArgs e)
        {
            this.WinViewModel.StartedSpinning();
        }

        private void FinishedSpin(object sender, FinishedSpinEventArgs e)
        {
            this.WinViewModel.FinishedSpinning(e.Win);
            this.ControlViewModel.RefreshSpinButton();
        }

        private void OpenStake(object sender, EventArgs e)
        {
            this.stakeViewService.CreateWindow(this.StakeViewModel);
        }

        private void StakeChanged(object sender, StakeEventArgs e)
        {
            this.ControlViewModel.Stake = e.Stake;
            this.ControlViewModel.RefreshSpinButton();
            this.CloseStakeView();
        }

        private void OpenWallet(object sender, EventArgs e)
        {
            this.walletViewService.CreateWindow(this.WalletViewModel);
        }

        private void AddToWallet(object sender, AddToWalletArgs e)
        {
            if (e.AddToWallet.IsSuccess)
            {
                this.ControlViewModel.RefreshBruhCoins();
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
            this.WalletViewModel.RequestClose();
        }

        private void CloseStakeView()
        {
            this.StakeViewModel.RequestClose();
        }
    }
}