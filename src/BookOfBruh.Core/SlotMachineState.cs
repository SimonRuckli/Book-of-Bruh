namespace BookOfBruh.Core
{
    using System.Threading.Tasks;

    public abstract class SlotMachineState
    {
        protected ISlotMachineStateContext SlotMachineStateContext;

        public void SetContext(ISlotMachineStateContext slotMachineStateContext)
        {
            this.SlotMachineStateContext = slotMachineStateContext;
        }

        public abstract void Handle();

        public abstract Task<double> TrySpin();
    }

    public class SpinningState : SlotMachineState
    {
        public override void Handle()
        {
            if (this.SlotMachineStateContext.BruhCoins >= this.SlotMachineStateContext.Stake)
            {
                this.SlotMachineStateContext.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.SlotMachineStateContext.TransitionTo(new NotEnoughBruhCoinState());
            }
        }

        public override Task<double> TrySpin()
        {
            return Task.FromResult<double>(-1);
        }
    }

    public class ReadyToSpinState : SlotMachineState
    {
        public override void Handle()
        {
            if (this.SlotMachineStateContext.BruhCoins >= this.SlotMachineStateContext.Stake)
            {
                this.SlotMachineStateContext.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.SlotMachineStateContext.TransitionTo(new NotEnoughBruhCoinState());
            }
        }

        public override async Task<double> TrySpin()
        {
            this.SlotMachineStateContext.TransitionTo(new SpinningState());
            return await this.SlotMachineStateContext.Spin();
        }
    }

    public class NotEnoughBruhCoinState : SlotMachineState
    {
        public override void Handle()
        {
            if (this.SlotMachineStateContext.BruhCoins >= this.SlotMachineStateContext.Stake)
            {
                this.SlotMachineStateContext.TransitionTo(new ReadyToSpinState());
            }
            else
            {
                this.SlotMachineStateContext.TransitionTo(new NotEnoughBruhCoinState());
            }
        }

        public override Task<double> TrySpin()
        {
            return Task.FromResult<double>(-1);
        }
    }
}