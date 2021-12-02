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
        }

        public RelayCommand SelectStakeOneClickCommand { get; set; }

        public EventHandler<StakeEventArgs>? StakeChanged { get; set; }

        private bool SelectStakeOneIsValid()
        {
            return true;
        }

        private void SelectStakeOneClick()
        {
            this.RaiseStakeChangedEventWithArgs(1);
        }

        private void RaiseStakeChangedEventWithArgs(double stake)
        {
            var args = new StakeEventArgs(stake);
            this.StakeChanged?.Invoke(this, args);
        }
    }
}
