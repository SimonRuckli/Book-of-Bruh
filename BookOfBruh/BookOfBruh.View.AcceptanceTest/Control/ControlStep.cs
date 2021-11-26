namespace BookOfBruh.View.AcceptanceTest.Control
{
    using Core;
    using TechTalk.SpecFlow;
    using View.Control;

    public class ControlStep
    {
        private readonly ControlViewModel controlViewModel;
        private readonly Game game;

        public ControlStep(ControlViewModel controlViewModel)
        {
            this.controlViewModel = controlViewModel;
        }

        [Given(@"The Wallet Contains One Bruh Coin And The Stake Is One")]
        public void GivenTheWalletContainsOneBruhCoinAndTheStakeIsOne()
        {
        }

        [When(@"IPressSpinAndRollThreeTenInARow")]
        public void WhenIPressSpinAndRollThreeTenInARow()
        {
            throw new System.NotImplementedException();
        }


        [Then(@"The Wallet Should Be Six And The Slot Should Be Displayed")]
        public void ThenTheWalletShouldBeSixAndTheSlotShouldBeDisplayed()
        {
            throw new System.NotImplementedException();
        }
    }
}