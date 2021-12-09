namespace BookOfBruh.View.Control
{
    public abstract class ControlState
    {
        protected ControlViewModel Context;

        public void SetContext(ControlViewModel context)
        {
            this.Context = context;
        }

        public abstract void Handle();
    }

    public class SpinningState : ControlState
    {
        public override void Handle()
        {
            if (this.Context.BruhCoins >= this.Context.Stake)
            {
                this.Context.TransitionTo(new ReadyToSpinState());
            }
            else
            {

                this.Context.TransitionTo(new NotEnoughBruhCoinState());
            }
        }
    }

    public class ReadyToSpinState : ControlState
    {
        public override void Handle()
        {
            this.Context.TransitionTo(new SpinningState());
        }
    }

    public class NotEnoughBruhCoinState : ControlState
    {
        public override void Handle()
        {
            this.Context.TransitionTo(new ReadyToSpinState());
        }
    }
}
