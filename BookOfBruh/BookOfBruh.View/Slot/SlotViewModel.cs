namespace BookOfBruh.View.Slot
{
    using System.Collections.Generic;
    using Core;
    using Core.Reels;
    using NotifyPropertyChangedBase = Infrastructure.NotifyPropertyChangedBase;

    public class SlotViewModel : NotifyPropertyChangedBase
    {
        public List<IReel> Reels { get; }

        public SlotViewModel(Game game)
        {
            this.Reels = game.Reels;
        }

    }
}
