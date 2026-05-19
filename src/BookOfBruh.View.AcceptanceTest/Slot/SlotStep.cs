namespace BookOfBruh.View.AcceptanceTest.Slot
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using Main;
    using TechTalk.SpecFlow;

    public class SlotStep
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public SlotStep(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        [Given(@"Given the slots are empty")]
        public void GivenTheSlotsAreEmptyAndThePlayerAddedMoney()
        {
            this.mainWindowViewModel.WalletViewModel.Code = 69;
            this.mainWindowViewModel.WalletViewModel.AddToWalletCommand.Execute();
            this.mainWindowViewModel.SlotViewModel.Reels[0].First.Symbol.Should().BeNull();
            this.mainWindowViewModel.WalletViewModel.BruhCoins.Should().Be(25);
        }


        [When(@"When I spin")]
        public async Task WhenISpin()
        {
            await this.mainWindowViewModel.ControlViewModel.SpinClickCommand.ExecuteAsync();
        }


        [Then(@"Then the slots are filled")]
        public void ThenTheSlotsAreFilled()
        {

            this.mainWindowViewModel.SlotViewModel.Reels[0].First.Symbol.Should().NotBeNull();
        }
    }
}