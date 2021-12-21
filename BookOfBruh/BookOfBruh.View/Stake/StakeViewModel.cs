namespace BookOfBruh.View.Stake
{
    using System;
    using Core.Reels;
    using Infrastructure.Commands;
    using Infrastructure.EventArgs;

    public class StakeViewModel : NotifyPropertyChangedBase
    {
        public StakeViewModel()
        {
            this.SelectStakeOneClickCommand = new RelayCommand(this.SelectStakeOneClick);
            this.SelectStakeTwoClickCommand = new RelayCommand(this.SelectStakeTwoClick);
            this.SelectStakeFiveClickCommand = new RelayCommand(this.SelectStakeFiveClick);
            this.SelectStakePointTenClickCommand = new RelayCommand(this.SelectStakePointTenClick);
            this.SelectStakePointTwentyClickCommand = new RelayCommand(this.SelectStakePointTwentyClick);
            this.SelectStakePointFiftyClickCommand = new RelayCommand(this.SelectStakePointFiftyClick);
        }



        public RelayCommand SelectStakeOneClickCommand { get; }
        public RelayCommand SelectStakeTwoClickCommand { get; }
        public RelayCommand SelectStakePointTenClickCommand { get; }
        public RelayCommand SelectStakePointFiftyClickCommand { get; }
        public RelayCommand SelectStakePointTwentyClickCommand { get; }
        public RelayCommand SelectStakeFiveClickCommand { get; }

        public EventHandler CloseView;
        public EventHandler<StakeEventArgs> StakeChanged;

        private void SelectStakeOneClick()
        {
            this.RaiseStakeChangedEventWithArgs(1);
        }

        private void SelectStakeTwoClick()
        {
            this.RaiseStakeChangedEventWithArgs(2);
        }

        private void SelectStakeFiveClick()
        {
            this.RaiseStakeChangedEventWithArgs(5);
        }

        private void SelectStakePointTenClick()
        {
            this.RaiseStakeChangedEventWithArgs(0.1);
        }

        private void SelectStakePointTwentyClick()
        {
            this.RaiseStakeChangedEventWithArgs(0.2);
        }

        private void SelectStakePointFiftyClick()
        {
            this.RaiseStakeChangedEventWithArgs(0.5);
        }

        private void RaiseStakeChangedEventWithArgs(double stake)
        {
            StakeEventArgs args = new StakeEventArgs(stake);
            this.StakeChanged?.Invoke(this, args);
        }

        public void RequestClose()
        {
            this.CloseView?.Invoke(this, EventArgs.Empty);
        }
    }
}
