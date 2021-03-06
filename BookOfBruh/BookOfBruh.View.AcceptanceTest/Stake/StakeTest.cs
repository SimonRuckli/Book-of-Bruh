// ReSharper disable ArrangeThisQualifier
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
            var mainWindowViewModel = kernel.Get<MainWindowViewModel>();
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
        
        [Fact]
        public void ClickStakeFiveShouldChangeStakeToStakeFive()
        {
            _.GivenTheStakeIsZero();
            _.WhenIPressStakeFive();
            _.ThenTheStakeShouldBeChangedTo(5);
        }
        
        [Fact]
        public void ClickStakePointTenShouldChangeStakeToStakePointTen()
        {
            _.GivenTheStakeIsZero();
            _.WhenIPressStakePointTen();
            _.ThenTheStakeShouldBeChangedTo(0.1);
        }
        
        [Fact]
        public void ClickStakePointTwentyShouldChangeStakeToStakePointTwenty()
        {
            _.GivenTheStakeIsZero();
            _.WhenIPressStakePointTwenty();
            _.ThenTheStakeShouldBeChangedTo(0.2);
        }
        
        [Fact]
        public void ClickStakePointFiftyShouldChangeStakeToStakePointFifty()
        {
            _.GivenTheStakeIsZero();
            _.WhenIPressStakePointFifty();
            _.ThenTheStakeShouldBeChangedTo(0.5);
        }
    }
}
