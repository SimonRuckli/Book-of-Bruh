namespace BookOfBruh.Core.GameData
{
    public static class SlotMachineConstants
    {
        /// <summary>
        /// Number of reels in the slot machine
        /// </summary>
        public const int ReelCount = 5;

        /// <summary>
        /// Number of symbols visible per reel
        /// </summary>
        public const int SymbolsPerReel = 3;

        /// <summary>
        /// Minimum base spin duration in milliseconds
        /// </summary>
        public const int MinSpinDuration = 80;

        /// <summary>
        /// Maximum base spin duration in milliseconds
        /// </summary>
        public const int MaxSpinDuration = 100;

        /// <summary>
        /// Additional delay per reel in milliseconds
        /// </summary>
        public const int ReelDelayIncrement = 20;
    }
}
