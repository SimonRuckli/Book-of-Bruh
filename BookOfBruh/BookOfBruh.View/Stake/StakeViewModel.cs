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
        }

        public EventHandler<StakeEventArgs> StakeChanged { get; set; }

        public RelayCommand SelectStakeOneClickCommand { get; set; }

        public RelayCommand SelectStakeTwoClickCommand { get; set; }

        private bool SelectStakeOneIsValid()
        {
            return true;
        }

        private bool SelectStakeTwoIsValid()
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

        private void RaiseStakeChangedEventWithArgs(double stake)
        {
            var args = new StakeEventArgs(stake);
            this.StakeChanged?.Invoke(this, args);
        }
    }
}
