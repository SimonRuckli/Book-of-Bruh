namespace BookOfBruh.View.Slot
{
    using System.Collections.Generic;
    using Core;
    using Core.Reels;
    using NotifyPropertyChangedBase = Infrastructure.NotifyPropertyChangedBase;

    public class SlotViewModel : NotifyPropertyChangedBase
    {
        private readonly Game game;

        public SlotViewModel(Game game)
        {
            this.game = game;
        }

        public List<IReel> Reels => game.Reels;

    }
}
