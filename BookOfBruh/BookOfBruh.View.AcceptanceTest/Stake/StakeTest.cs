namespace BookOfBruh.View.AcceptanceTest.Stake
{
    using Control;
    using Infrastructure;
    using Ninject;
    using View.Control;
    using View.Stake;
    using Xunit;

    public class StakeTest
    {
        private readonly StakeStep _;

        public StakeTest()
        {
            IKernel kernel = new StandardKernel(new BookOfBruhTestModule());
            StakeViewModel stakeViewModel = kernel.Get<StakeViewModel>();
            ControlViewModel controlViewModel = kernel.Get<ControlViewModel>();
            _ = new StakeStep(stakeViewModel, controlViewModel);
        }


        [Fact]
        public void CLickStakeOneShouldChangeStakeToStakeOne()
        {
            _.GivenTheStakeIsZero();
            _.WhenIPressStakeOne();
            _.ThenTheStakeShouldBeChangedToOne();
        }
    }
}
