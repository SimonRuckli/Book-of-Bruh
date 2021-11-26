namespace BookOfBruh.View.AcceptanceTest.Control
{
    using FluentAssertions;
    using TechTalk.SpecFlow;
    using View.Control;

    public class ControlStep
    {
        private readonly ControlViewModel controlViewModel;

        public ControlStep(ControlViewModel controlViewModel)
        {
            this.controlViewModel = controlViewModel;
        }

        [Given(@"The Wallet Contains One Bruh Coin And The Stake Is One")]
        public void GivenTheWalletContainsOneBruhCoinAndTheStakeIsOne()
        {
            controlViewModel.Stake = 1f;
        }

        [When(@"IPressSpinAndRollThreeTenInARow")]
        public void WhenIPressSpinAndRollThreeTenInARow()
        {
            controlViewModel.SpinClickCommand.Execute();
        }


        [Then(@"The Wallet Should Be Six And The Slot Should Be Displayed")]
        public void ThenTheWalletShouldBeThree()
        {
            this.controlViewModel.BruhCoins.Should().Be(3);
        }
    }
}