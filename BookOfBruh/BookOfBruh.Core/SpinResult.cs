namespace BookOfBruh.Core
{
    public class SpinResult 
    {
        public Slots Slots { get; }
        public double BruhCoins { get; }

        public SpinResult(Slots slots, double bruhCoins)
        {
            this.Slots = slots;
            this.BruhCoins = bruhCoins;
        }
    }
}