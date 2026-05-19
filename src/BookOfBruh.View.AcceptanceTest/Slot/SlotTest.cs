// ReSharper disable ArrangeThisQualifier
namespace BookOfBruh.View.AcceptanceTest.Slot
{
    using System.Threading.Tasks;
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

            var mainWindowViewModel = kernel.Get<MainWindowViewModel>();
            _ = new SlotStep(mainWindowViewModel);
        }


        [Fact]
        public async Task SpinShouldFillSlots()
        {
            _.GivenTheSlotsAreEmptyAndThePlayerAddedMoney();
            await _.WhenISpin();
            _.ThenTheSlotsAreFilled();
        }
    }
}