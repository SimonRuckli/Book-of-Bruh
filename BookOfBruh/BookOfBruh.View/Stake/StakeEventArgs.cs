namespace BookOfBruh.View.Stake
{
    using System;

    public class StakeEventArgs : EventArgs
    {
        public StakeEventArgs(double stake)
        {
            this.Stake = stake;
        }
        public double Stake { get; }
    }
}