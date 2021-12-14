﻿namespace BookOfBruh.View.Main
{
    using System;
    using Control;
    using Core.GameData;
    using Infrastructure;
    using Infrastructure.Commands;
    using Slot;
    using Stake;
    using Wallet;
    using Win;

    public class MainWindowViewModel : NotifyPropertyChangedBase
    {

        private readonly IStakeViewService stakeViewService;
        private readonly WalletViewModel walletViewModel;
        private readonly IWalletViewService walletViewService;

        public MainWindowViewModel(
            SlotViewModel slotViewModel, 
            ControlViewModel controlViewModel, 
            StakeViewModel stakeViewModel,
            WinViewModel winViewModel,
            IStakeViewService stakeViewService,
            WalletViewModel walletViewModel,
            IWalletViewService walletViewService
        )
        {
            this.stakeViewService = stakeViewService;
            this.walletViewModel = walletViewModel;
            this.walletViewService = walletViewService;
            this.SlotViewModel = slotViewModel;
            this.ControlViewModel = controlViewModel;
            this.StakeViewModel = stakeViewModel;
            this.WinViewModel = winViewModel;

            this.StakeViewModel.StakeChanged += this.StakeChanged;
            this.ControlViewModel.OpenStake += this.OpenStake;
            this.ControlViewModel.OpenWallet += this.OpenWallet;
            this.ControlViewModel.Spin += this.Spin;
            this.walletViewModel.AddedToWallet += this.AddToWallet;
            this.SlotViewModel.FinishedSpinning += this.FinishedSpinning;

            this.ViewClosedCommand = new RelayCommand(this.ViewClosed);
        }

        private void FinishedSpinning(object sender, WinEventArgs e)
        {
            this.ControlViewModel.FinishedSpinning();
            this.WinViewModel.FinishedSpinning(e.BruhCoin);
        }

        public RelayCommand ViewClosedCommand { get; set; }
        public SlotViewModel SlotViewModel { get; }
        public ControlViewModel ControlViewModel { get; }
        public StakeViewModel StakeViewModel { get; }
        public WinViewModel WinViewModel { get; }


        private void AddToWallet(object sender, AddToWalletArgs e)
        {
            if (e.AddToWallet.IsSuccess)
            {
                this.ControlViewModel.AddToWallet();
                this.CloseWalletView();
            }
        }

        private void OpenStake(object sender, EventArgs e)
        {
            this.ShowStakeWindow();
        }
        private void OpenWallet(object sender, EventArgs e)
        {
            this.ShowWalletWindow();
        }

        private void StakeChanged(object sender, StakeEventArgs e)
        {
            this.ControlViewModel.Stake = e.Stake;
            this.CloseStakeView();
        }

        private async void Spin(object sender, SpinEventArgs e)
        {
            await this.SlotViewModel.RenderSpin(e.SpinResult);
        }

        private void ShowStakeWindow()
        {
            this.stakeViewService.CreateWindow(this.StakeViewModel);
        }

        private void ShowWalletWindow()
        {
            this.walletViewService.CreateWindow(this.walletViewModel);
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
