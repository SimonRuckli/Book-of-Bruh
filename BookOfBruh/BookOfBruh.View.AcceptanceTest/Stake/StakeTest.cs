namespace BookOfBruh.View.AcceptanceTest.Stake
{
    using Infrastructure;
    using Main;
    using Ninject;
    using Xunit;

    public class StakeTest
    {
        private readonly StakeStep _;

        public StakeTest()
        {
            IKernel kernel = new StandardKernel(new BookOfBruhTestModule());
            MainWindowViewModel mainWindowViewModel = kernel.Get<MainWindowViewModel>();
            _ = new StakeStep(mainWindowViewModel);
        }

        [Fact]
        public void ClickStakeOneShouldChangeStakeToStakeOne()
        {
            _.GivenTheStakeIsZero();
            _.WhenIPressStakeOne();
            _.ThenTheStakeShouldBeChangedTo(1);
        }
        
        [Fact]
        public void ClickStakeTwoShouldChangeStakeToStakeTwo()
        {
            _.GivenTheStakeIsZero();
            _.WhenIPressStakeTwo();
            _.ThenTheStakeShouldBeChangedTo(2);
        }
    }
}
