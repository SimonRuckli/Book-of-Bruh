namespace BookOfBruh.View.AcceptanceTest.Slot
{
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
        public void GivenTheSlotsAreEmpty()
        {
            this.mainWindowViewModel.SlotViewModel.Slot00.Symbol.Should().BeNullOrEmpty();
        }


        [When(@"When I spin")]
        public void WhenISpin()
        {
            this.mainWindowViewModel.ControlViewModel.SpinClickCommand.Execute();
        }


        [Then(@"Then the slots are filled")]
        public void ThenTheSlotsAreFilled()
        {

            this.mainWindowViewModel.SlotViewModel.Slot00.Should().NotBeNull();
        }
    }
}