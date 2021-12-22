namespace BookOfBruh.View.Infrastructure.EventArgs
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