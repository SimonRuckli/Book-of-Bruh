// ReSharper disable ArrangeThisQualifier
namespace BookOfBruh.View.AcceptanceTest.Slot
{
    using Infrastructure;
    using Main;
    using Ninject;
    using Xunit;

    public class SlotTest
    {
        private readonly SlotStep _;

        public SlotTest()
        {
            IKernel kernel = new StandardKernel(new BookOfBruhTestModule());

            MainWindowViewModel mainWindowViewModel = kernel.Get<MainWindowViewModel>();
            _ = new SlotStep(mainWindowViewModel);
        }


        [Fact]
        public void SpinShouldFillSlots()
        {
            _.GivenTheSlotsAreEmpty();
            _.WhenISpin();
            _.ThenTheSlotsAreFilled();
        }
    }
}