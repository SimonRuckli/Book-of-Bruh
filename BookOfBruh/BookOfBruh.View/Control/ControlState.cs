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
        public abstract bool TrySpin();
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

        public override bool TrySpin()
        {
            return false;
        }
    }

    public class ReadyToSpinState : ControlState
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

        public override bool TrySpin()
        {
            this.Context.TransitionTo(new SpinningState());
            return true;
        }
    }

    public class NotEnoughBruhCoinState : ControlState
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

        public override bool TrySpin()
        {
            return false;
        }
    }
}
