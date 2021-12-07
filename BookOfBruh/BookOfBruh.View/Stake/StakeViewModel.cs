namespace BookOfBruh.View.Stake
{
    using System;
    using Infrastructure;
    using Infrastructure.Commands;

    public class StakeViewModel : NotifyPropertyChangedBase
    {
        public StakeViewModel()
        {
            this.SelectStakeOneClickCommand = new RelayCommand(this.SelectStakeOneClick, this.SelectStakeOneIsValid);
            this.SelectStakeTwoClickCommand = new RelayCommand(this.SelectStakeTwoClick, this.SelectStakeTwoIsValid);
            this.SelectStakeFiveClickCommand = new RelayCommand(this.SelectStakeFiveClick, this.SelectStakeFiveIsValid);
            this.SelectStakePointTenClickCommand = new RelayCommand(this.SelectStakePointTenClick, this.SelectStakePointTenIsValid);
            this.SelectStakePointTwentyClickCommand = new RelayCommand(this.SelectStakePointTwentyClick, this.SelectStakePointTwentyIsValid);
            this.SelectStakePointFiftyClickCommand = new RelayCommand(this.SelectStakePointFiftyClick, this.SelectStakePointFiftyIsValid);
        }


        public EventHandler CloseView { get; set; }

        public EventHandler<StakeEventArgs> StakeChanged { get; set; }

        public RelayCommand SelectStakeOneClickCommand { get; set; }

        public RelayCommand SelectStakeTwoClickCommand { get; set; }
        public RelayCommand SelectStakePointTenClickCommand { get; set; }
        public RelayCommand SelectStakePointFiftyClickCommand { get; set; }
        public RelayCommand SelectStakePointTwentyClickCommand { get; set; }
        public RelayCommand SelectStakeFiveClickCommand { get; set; }

        private bool SelectStakeOneIsValid()
        {
            return true;
        }

        private bool SelectStakeTwoIsValid()
        {
            return true;
        }

        private bool SelectStakeFiveIsValid()
        {
            return true;
        }

        private bool SelectStakePointTenIsValid()
        {
            return true;
        }

        private bool SelectStakePointTwentyIsValid()
        {
            return true;
        }

        private bool SelectStakePointFiftyIsValid()
        {
            return true;
        }

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
            var args = new StakeEventArgs(stake);
            this.StakeChanged?.Invoke(this, args);
        }

        public void RequestClose()
        {
            this.CloseView?.Invoke(this, EventArgs.Empty);
        }
    }
}
