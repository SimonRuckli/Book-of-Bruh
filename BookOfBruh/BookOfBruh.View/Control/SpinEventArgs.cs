namespace BookOfBruh.View.Control
{
    using System;
    using Core.GameData;

    public class SpinEventArgs : EventArgs
    {
        public SpinEventArgs(SpinResult spinResult)
        {
            this.SpinResult = spinResult;
        }

        public SpinResult SpinResult { get;}
    }
}