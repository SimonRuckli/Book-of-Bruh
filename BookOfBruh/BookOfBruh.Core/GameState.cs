namespace BookOfBruh.Core
{
    using System.Threading.Tasks;

    public abstract class GameState
    {
        protected ISpinnable Context;

        public void SetContext(ISpinnable context)
        {
            this.Context = context;
        }

        public abstract void Handle();

        public abstract Task<double> TrySpin();
    }

    public class SpinningState : GameState
    {
        public override void Handle()
        {
            if (this.Context.Player.BruhCoins >= this.Context.Player.Stake)
            {
                this.Context.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.Context.TransitionTo(new NotEnoughBruhCoinState());
            }
        }

        public override Task<double> TrySpin()
        {
            return Task.FromResult<double>(-1);
        }
    }

    public class ReadyToSpinState : GameState
    {
        public override void Handle()
        {
            if (this.Context.Player.BruhCoins >= this.Context.Player.Stake)
            {
                this.Context.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.Context.TransitionTo(new NotEnoughBruhCoinState());
            }
        }

        public override async Task<double> TrySpin()
        {
            this.Context.TransitionTo(new SpinningState());
            return await this.Context.Spin();
        }
    }

    public class NotEnoughBruhCoinState : GameState
    {
        public override void Handle()
        {
            if (this.Context.Player.BruhCoins >= this.Context.Player.Stake)
            {
                this.Context.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.Context.TransitionTo(new NotEnoughBruhCoinState());
            }
        }

        public override Task<double> TrySpin()
        {
            return Task.FromResult<double>(-1);
        }
    }
}