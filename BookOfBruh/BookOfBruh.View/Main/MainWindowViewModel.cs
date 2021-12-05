﻿namespace BookOfBruh.View.Main
{
    using System;
    using Control;
    using Infrastructure;
    using Slot;
    using Stake;

    public class MainWindowViewModel : NotifyPropertyChangedBase
    {
        private readonly IStakeViewService stakeViewService;

        public MainWindowViewModel(
            SlotViewModel slotViewModel, 
            ControlViewModel controlViewModel, 
            StakeViewModel stakeViewModel,
            IStakeViewService stakeViewService
            )
        {
            this.stakeViewService = stakeViewService;
            this.SlotViewModel = slotViewModel;
            this.ControlViewModel = controlViewModel;
            this.StakeViewModel = stakeViewModel;

            this.StakeViewModel.StakeChanged += this.StakeChanged;
            this.ControlViewModel.OpenStake += this.OpenStake;
        }

        private void OpenStake(object? sender, EventArgs e)
        {
            this.ShowStakeWindow();
        }

        private void StakeChanged(object? sender, StakeEventArgs e)
        {
            this.ControlViewModel.Stake = e.Stake;
        }

        private void ShowStakeWindow()
        {
            this.stakeViewService.CreateWindow(this.StakeViewModel);
        }

        public SlotViewModel SlotViewModel { get; }

        public ControlViewModel ControlViewModel { get; }
        public StakeViewModel StakeViewModel { get; }
    }
}
