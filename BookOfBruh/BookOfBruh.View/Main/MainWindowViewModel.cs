namespace BookOfBruh.View.Main
{
    using System;
    using Control;
    using Infrastructure;
    using Infrastructure.Commands;
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

            this.ViewClosedCommand = new RelayCommand(ViewClosed);
        }

        public RelayCommand ViewClosedCommand { get; set; }
        public SlotViewModel SlotViewModel { get; }
        public ControlViewModel ControlViewModel { get; }
        public StakeViewModel StakeViewModel { get; }

        private void OpenStake(object sender, EventArgs e)
        {
            this.ShowStakeWindow();
        }

        private void StakeChanged(object sender, StakeEventArgs e)
        {
            this.ControlViewModel.Stake = e.Stake;
            this.CloseStakeView();
        }

        private void ShowStakeWindow()
        {
            this.stakeViewService.CreateWindow(this.StakeViewModel);
        }

        private void ViewClosed()
        {
            this.CloseStakeView();
        }

        private void CloseStakeView()
        {
            this.StakeViewModel.RequestClose();
        }
    }
}
