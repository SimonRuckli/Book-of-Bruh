namespace BookOfBruh.View.Main
{
    using Control;
    using Infrastructure;
    using Slot;
    using Stake;

    public class MainWindowViewModel : NotifyPropertyChangedBase
    {
        public MainWindowViewModel(
            SlotViewModel slotViewModel, 
            ControlViewModel controlViewModel, 
            StakeViewModel stakeViewModel)
        {
            SlotViewModel = slotViewModel;
            ControlViewModel = controlViewModel;
            StakeViewModel = stakeViewModel;

            this.StakeViewModel.StakeChanged += StakeChanged;
        }

        private void StakeChanged(object? sender, StakeEventArgs e)
        {
            this.ControlViewModel.Stake = e.Stake;
        }

        public SlotViewModel SlotViewModel { get; }

        public ControlViewModel ControlViewModel { get; }
        public StakeViewModel StakeViewModel { get; }
    }
}
