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
            _ = new ControlStep(kernel.Get<ControlViewModel>());
        }


        [Fact]
        public void SpinWithStakeOneShouldReturnSix()
        {
            _.GivenTheTextBoxesAreFilled();
            _.WhenIPressCalculationButton();
            _.ThenTheResultShouldBe();
        }
    }
}