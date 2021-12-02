namespace BookOfBruh.View.AcceptanceTest.Control
{
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
            ControlViewModel controlViewModel = kernel.Get<ControlViewModel>();
            _ = new ControlStep(controlViewModel);
        }


        [Fact]
        public void SpinWithStakeOneShouldReturnThree()
        {
            _.GivenTheWalletContainsOneBruhCoinAndTheStakeIsOne();
            _.WhenIPressSpinAndRollThreeTenInARow();
            _.ThenTheWalletShouldBeThree();
        }
    }
}