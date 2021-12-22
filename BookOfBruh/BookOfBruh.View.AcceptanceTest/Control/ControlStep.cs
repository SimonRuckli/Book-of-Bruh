namespace BookOfBruh.View.AcceptanceTest.Control
{
    using System.Threading.Tasks;
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
            this.controlViewModel.Stake = 1;
        }

        [When(@"IPressSpinAndRollThreeTenInARow")]
        public async Task WhenIPressSpinAndRollThreeTenInARow()
        {
            await this.controlViewModel.SpinClickCommand.ExecuteAsync();
        }


        [Then(@"The Wallet Should Be Correct And The Slot Should Be Displayed")]
        public void ThenTheWalletShouldBeCorrect()
        {
            this.controlViewModel.BruhCoins.Should().BeInRange(0.149,0.51);
        }
    }
}