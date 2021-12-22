namespace BookOfBruh.Core
{
    using System.Threading.Tasks;

    public abstract class GameState
    {
        protected IGameStateContext GameStateContext;

        public void SetContext(IGameStateContext gameStateContext)
        {
            this.GameStateContext = gameStateContext;
        }

        public abstract void Handle();

        public abstract Task<double> TrySpin();
    }

    public class SpinningState : GameState
    {
        public override void Handle()
        {
            if (this.GameStateContext.BruhCoins >= this.GameStateContext.Stake)
            {
                this.GameStateContext.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.GameStateContext.TransitionTo(new NotEnoughBruhCoinState());
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
            if (this.GameStateContext.BruhCoins >= this.GameStateContext.Stake)
            {
                this.GameStateContext.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.GameStateContext.TransitionTo(new NotEnoughBruhCoinState());
            }
        }

        public override async Task<double> TrySpin()
        {
            this.GameStateContext.TransitionTo(new SpinningState());
            return await this.GameStateContext.Spin();
        }
    }

    public class NotEnoughBruhCoinState : GameState
    {
        public override void Handle()
        {
            if (this.GameStateContext.BruhCoins >= this.GameStateContext.Stake)
            {
                this.GameStateContext.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.GameStateContext.TransitionTo(new NotEnoughBruhCoinState());
            }
        }

        public override Task<double> TrySpin()
        {
            return Task.FromResult<double>(-1);
        }
    }
}