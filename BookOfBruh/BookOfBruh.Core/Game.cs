namespace BookOfBruh.Core
{
    using CodeValidation;
    using GameData;
    using SlotAnalysation;
    using SlotGeneration;
    using CSharpFunctionalExtensions;


    public class Game
    {
        private readonly ICodeValidator codeValidator;
        private readonly ISlotGenerator slotGenerator;
        private readonly ISlotAnalyzer slotAnalyzer;


        public Game(IPlayer player, ICodeValidator codeValidator, ISlotGenerator slotGenerator, ISlotAnalyzer slotAnalyzer)
        {
            this.Player = player;
            this.codeValidator = codeValidator;
            this.slotGenerator = slotGenerator;
            this.slotAnalyzer = slotAnalyzer;
        }

        public IPlayer Player { get; }

        public Result<SpinResult> Spin(double stake)
        {
            Slots generate = this.slotGenerator.Generate();
            double analyze = this.slotAnalyzer.Analyze(generate);
            this.Player.BruhCoins -= stake;

            double win = analyze * stake;

            this.Player.BruhCoins += win;

            return new SpinResult(generate, win);
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
