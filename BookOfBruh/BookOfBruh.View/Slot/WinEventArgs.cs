namespace BookOfBruh.View.Slot
{
    using System;

    public class WinEventArgs : EventArgs
    {
        public WinEventArgs(double win)
        {
            this.BruhCoin = win;
        }

        public double BruhCoin { get; }
    }
}