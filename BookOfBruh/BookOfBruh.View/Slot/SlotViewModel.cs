namespace BookOfBruh.View.Slot
{
    using System.Collections.Generic;
    using Core;
    using Core.GameData;
    using Core.Reels;

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
