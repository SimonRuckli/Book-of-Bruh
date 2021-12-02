namespace BookOfBruh.View.Stake
{
    using System;
    using Infrastructure.Commands;

    public class StakeViewModel
    {
        public StakeViewModel()
        {
            this.SelectStakeOneClickCommand = new RelayCommand(this.SelectStakeOneClick, this.SelectStakeOneIsValid);
        }

        public RelayCommand SelectStakeOneClickCommand { get; set; }

        public EventHandler StakeChanged;

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

            this.StakeChanged.Invoke(this, new StakeEventArgs(stake));
        }
    }
}
