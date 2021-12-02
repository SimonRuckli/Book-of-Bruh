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

        public void ThenTheStakeShouldBeChangedToOne()
        {
            mainWindowViewModel.ControlViewModel.Stake.Should().Be(1);
        }
    }
}
