namespace BookOfBruh.Core.GameData
{
    using System.Collections.Generic;
    using SlotAnalysation;

    public class SpinResult 
    {
        
        public SpinResult(Slots slots, double bruhCoins, List<Pattern> patterns)
        {
            this.Slots = slots;
            this.BruhCoins = bruhCoins;
            this.Patterns = patterns;
        }
        public Slots Slots { get; }
        public double BruhCoins { get; }
        public List<Pattern> Patterns { get; }
    }
}