namespace BookOfBruh.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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


        public Game(IPlayer player, ICodeValidator codeValidator, ISlotConverter slotConverter, ISlotAnalyzer slotAnalyzer, IReelsGenerator reelsGenerator)
        {
            this.Player = player;
            this.codeValidator = codeValidator;
            this.slotConverter = slotConverter;
            this.slotAnalyzer = slotAnalyzer;
            Reels = reelsGenerator.Generate(5);
        }

        public IPlayer Player { get; }

        public List<IReel> Reels { get; }

        public async Task<SpinResult> Spin(double stake)
        {
            this.Player.BruhCoins -= stake;

            List<Task> spinningReels = Reels.Select(reel => reel.Spin(10)).ToList();

            await Task.WhenAll(spinningReels);

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
