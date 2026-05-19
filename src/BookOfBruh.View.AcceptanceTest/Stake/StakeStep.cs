namespace BookOfBruh.View.AcceptanceTest.Stake
{
    using FluentAssertions;
    using Main;

    public class StakeStep
    {
        private readonly MainWindowViewModel mainWindowViewModel;
        
        public StakeStep(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public void GivenTheStakeIsZero()
        {
            this.mainWindowViewModel.ControlViewModel.Stake = 0;
        }

        public void WhenIPressStakeOne()
        {
            this.mainWindowViewModel.StakeViewModel.SelectStakeOneClickCommand.Execute();
        }
        public void WhenIPressStakeTwo()
        {
            this.mainWindowViewModel.StakeViewModel.SelectStakeTwoClickCommand.Execute();
        }

        public void WhenIPressStakeFive()
        {
            this.mainWindowViewModel.StakeViewModel.SelectStakeFiveClickCommand.Execute();
        }

        public void WhenIPressStakePointTwenty()
        {
            this.mainWindowViewModel.StakeViewModel.SelectStakePointTwentyClickCommand.Execute();
        }

        public void WhenIPressStakePointFifty()
        {
            this.mainWindowViewModel.StakeViewModel.SelectStakePointFiftyClickCommand.Execute();
        }

        public void WhenIPressStakePointTen()
        {
            this.mainWindowViewModel.StakeViewModel.SelectStakePointTenClickCommand.Execute();
        }
        
        public void ThenTheStakeShouldBeChangedTo(double stake)
        {
            this.mainWindowViewModel.ControlViewModel.Stake.Should().Be(stake);
        }
    }
}
