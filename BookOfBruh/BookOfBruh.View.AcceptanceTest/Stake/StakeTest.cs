﻿namespace BookOfBruh.View.AcceptanceTest.Stake
{
    using Control;
    using Infrastructure;
    using Main;
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
            MainWindowViewModel mainWindowViewModel = kernel.Get<MainWindowViewModel>();
            _ = new StakeStep(mainWindowViewModel);
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
