namespace BookOfBruh.View.AcceptanceTest.Stake
{
    using FluentAssertions;
    using Main;
    using View.Control;
    using View.Stake;

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
    }
}
