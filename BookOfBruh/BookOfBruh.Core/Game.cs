namespace BookOfBruh.Core
{
    using System;
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
        private readonly Random random;


        public Game(IPlayer player, ICodeValidator codeValidator, ISlotConverter slotConverter, ISlotAnalyzer slotAnalyzer, IReelsGenerator reelsGenerator)
        {
            this.Player = player;
            this.codeValidator = codeValidator;
            this.slotConverter = slotConverter;
            this.slotAnalyzer = slotAnalyzer;
            this.Reels = reelsGenerator.Generate(5);
            this.random = new Random();
        }

        public IPlayer Player { get; }

        public List<IReel> Reels { get; }

        public async Task<SpinResult> Spin(double stake)
        {
            this.Player.BruhCoins -= stake;

            foreach (IReel reel in Reels)
            {
                reel.First.IsPattern = false;
                reel.Second.IsPattern = false;
                reel.Third.IsPattern = false;
            }

            List<Task> spinningReels = Reels.Select((reel, i) => reel.Spin(random.Next(50,100) + i * random.Next(10,30))).ToList();

            await Task.WhenAll(spinningReels);

            Slots slots = slotConverter.Convert(Reels);

            AnalyzeResult analyzeResult = this.slotAnalyzer.Analyze(slots);

            for (int x = 0; x < this.Reels.Count; x++)
            {
                this.Reels[x].First.IsPattern = analyzeResult.Patterns.Any(pt => pt.Value.Any(p => p.X == x && p.Y == 0));
                this.Reels[x].Second.IsPattern = analyzeResult.Patterns.Any(pt => pt.Value.Any(p => p.X == x && p.Y == 1));
                this.Reels[x].Third.IsPattern = analyzeResult.Patterns.Any(pt => pt.Value.Any(p => p.X == x && p.Y == 2));
            }

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
