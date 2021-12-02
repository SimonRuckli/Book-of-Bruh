namespace BookOfBruh.View.AcceptanceTest.Stake
{
    using FluentAssertions;
    using View.Control;
    using View.Stake;

    public class StakeStep
    {
        private readonly StakeViewModel stakeViewModel;
        private readonly ControlViewModel controlViewModel;

        public StakeStep(StakeViewModel stakeViewModel, ControlViewModel controlViewModel)
        {
            this.stakeViewModel = stakeViewModel;
            this.controlViewModel = controlViewModel;
        }

        public void GivenTheStakeIsZero()
        {
            controlViewModel.Stake = 0;
        }

        public void WhenIPressStakeOne()
        {
            stakeViewModel.SelectStakeOneClickCommand.Execute();
        }

        public void ThenTheStakeShouldBeChangedToOne()
        {
            controlViewModel.Stake.Should().Be(1);
        }
    }
}
