// ReSharper disable ArrangeThisQualifier
namespace BookOfBruh.View.AcceptanceTest.Control
{
    using System.Threading.Tasks;
    using Infrastructure;
    using Ninject;
    using View.Control;
    using Xunit;

    public class ControlTest
    {
        private readonly ControlStep _;

        public ControlTest()
        {
            IKernel kernel = new StandardKernel(new BookOfBruhTestModule());
            var controlViewModel = kernel.Get<ControlViewModel>();
            _ = new ControlStep(controlViewModel);
        }


        [Fact]
        public async Task SpinWithStakeOneShouldReturnThree()
        {
            _.GivenTheWalletContainsOneBruhCoinAndTheStakeIsOne();
            await _.WhenIPressSpinAndRollThreeTenInARow();
            _.ThenTheWalletShouldBeCorrect();
        }
    }
}