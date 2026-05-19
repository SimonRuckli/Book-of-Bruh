namespace BookOfBruh.View.Slot
{
    using System.Collections.Generic;
    using Core;
    using Core.GameData;
    using Core.Reels;

    public class SlotViewModel : NotifyPropertyChangedBase
    {
        private readonly ISlotMachine slotMachine;

        public SlotViewModel(ISlotMachine slotMachine)
        {
            this.slotMachine = slotMachine;
        }

        public List<IReel> Reels => slotMachine.Reels;

    }
}