namespace BookOfBruh.View.Infrastructure.EventArgs
{
    using System;

    public class FinishedSpinEventArgs : EventArgs
    {
        public FinishedSpinEventArgs(double win)
        {
            Win = win;
        }

        public double Win { get; }
    }
}