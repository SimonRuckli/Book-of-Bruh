﻿namespace BookOfBruh.View.Win
{
    using Infrastructure;

    public class WinViewModel : NotifyPropertyChangedBase
    {
        public double BruhCoins { get; private set; }

        public void StartedSpinning()
        {
            this.BruhCoins = 0;
        }

        public void FinishedSpinning(double win)
        {
            this.BruhCoins = win;
        }
    }
}
