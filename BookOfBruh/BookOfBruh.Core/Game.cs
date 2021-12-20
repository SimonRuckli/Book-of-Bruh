namespace BookOfBruh.Core
{
    using System.Collections.Generic;
    using CodeValidation;
    using GameData;
    using SlotAnalysation;
    using SlotGeneration;
    using CSharpFunctionalExtensions;
    using Reels;

    public class Game
    {
        private readonly ICodeValidator codeValidator;
        private readonly ISlotConverter slotConverter;
        private readonly ISlotAnalyzer slotAnalyzer;


        public Game(IPlayer player, ICodeValidator codeValidator, ISlotConverter slotConverter, ISlotAnalyzer slotAnalyzer, List<IReel> reels)
        {
            this.Player = player;
            this.codeValidator = codeValidator;
            this.slotConverter = slotConverter;
            this.slotAnalyzer = slotAnalyzer;
            Reels = reels;
        }

        public IPlayer Player { get; }

        public List<IReel> Reels { get; }

        public Result<SpinResult> Spin(double stake)
        {
            this.Player.BruhCoins -= stake;

            Slots slots = slotConverter.Convert(Reels);

            AnalyzeResult analyzeResult = this.slotAnalyzer.Analyze(slots);

            double win = analyzeResult.Multiplier * stake;

            this.Player.BruhCoins += win;

            return new SpinResult(slots, win, analyzeResult.Patterns);
        }

        public Result<double> AddToWallet(int code)
        {
            Result<double> validate = this.codeValidator.Validate(code);

            if (validate.IsSuccess)
            {
                this.Player.BruhCoins += validate.Value;
            }

            return validate;
        }
    }
}
