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

    public class Game : NotifyPropertyChangedBase, ISlotMachine, IGameStateContext
    {
        private readonly ICodeValidator codeValidator;
        private readonly ISlotConverter slotConverter;
        private readonly ISlotAnalyzer slotAnalyzer;
        private readonly Random random;
        private GameState state;
        private double stake;


        public Game(ICodeValidator codeValidator, ISlotConverter slotConverter, ISlotAnalyzer slotAnalyzer, IReelsGenerator reelsGenerator, GameState state)
        {
            this.codeValidator = codeValidator;
            this.slotConverter = slotConverter;
            this.slotAnalyzer = slotAnalyzer;
            this.Reels = reelsGenerator.Generate(5);
            this.State = state;
            this.State.SetContext(this);
            this.random = new Random();
        }
        

        public List<IReel> Reels { get; }

        public double Stake
        {
            get => stake;
            set
            {
                stake = value;
                this.State.Handle();
                OnPropertyChanged();
            }
        }

        public double BruhCoins { get; private set; }

        public GameState State
        {
            get => state;
            private set
            {
                this.state = value;
                OnPropertyChanged();
            }
        }

        public async Task<double> Spin()
        {
            this.BruhCoins -= this.Stake;

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

            double win = analyzeResult.Multiplier * this.Stake;

            this.BruhCoins += win;

            this.State.Handle();

            return win;
        }

        public Result<double> AddToWallet(int code)
        {
            Result<double> validate = this.codeValidator.Validate(code);

            if (validate.IsSuccess)
            {
                this.BruhCoins += validate.Value;
            }

            this.State.Handle();
            return validate;
        }

        public void TransitionTo(GameState newState)
        {
            this.State = newState;
            this.State.SetContext(this);
        }
    }

    public interface IGameStateContext
    {
        double Stake { get; set; }
        double BruhCoins { get; }

        void TransitionTo(GameState newState);

        Task<double> Spin();
    }

    public interface ISlotMachine
    {
        double Stake { get; set; }
        double BruhCoins { get; }

        List<IReel> Reels { get; }

        GameState State { get; }

        Result<double> AddToWallet(int code);
    }
}
