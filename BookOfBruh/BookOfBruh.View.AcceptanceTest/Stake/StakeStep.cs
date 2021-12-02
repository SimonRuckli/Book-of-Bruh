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
            mainWindowViewModel.ControlViewModel.Stake = 0;
        }

        public void WhenIPressStakeOne()
        {
            mainWindowViewModel.StakeViewModel.SelectStakeOneClickCommand.Execute();
        }

        public void ThenTheStakeShouldBeChangedTo(double stake)
        {
            mainWindowViewModel.ControlViewModel.Stake.Should().Be(stake);
        }

        public void WhenIPressStakeTwo()
        {
            mainWindowViewModel.StakeViewModel.SelectStakeTwoClickCommand.Execute();
        }

        public void WhenIPressStakeFive()
        {
            mainWindowViewModel.StakeViewModel.SelectStakeFiveClickCommand.Execute();
        }

        public void WhenIPressStakePointTwenty()
        {
            mainWindowViewModel.StakeViewModel.SelectStakePointTwentyClickCommand.Execute();
        }

        public void WhenIPressStakePointFifty()
        {
            mainWindowViewModel.StakeViewModel.SelectStakePointFiftyClickCommand.Execute();
        }

        public void WhenIPressStakePointTen()
        {
            mainWindowViewModel.StakeViewModel.SelectStakePointTenClickCommand.Execute();
        }
    }
}
