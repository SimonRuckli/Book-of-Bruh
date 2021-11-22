namespace BookOfBruh.Core
{
    using System;
    using CodeValidation;
    using GameData;
    using SlotAnalysation;
    using SlotGeneration;
    using CSharpFunctionalExtensions;


    public class Game
    {
        private readonly IPlayer player;
        private readonly ICodeValidator codeValidator;
        private readonly ISlotGenerator slotGenerator;
        private readonly ISlotAnalyzer slotAnalyzer;


        public Game(IPlayer player, ICodeValidator codeValidator, ISlotGenerator slotGenerator, ISlotAnalyzer slotAnalyzer)
        {
            this.player = player;
            this.codeValidator = codeValidator;
            this.slotGenerator = slotGenerator;
            this.slotAnalyzer = slotAnalyzer;
        }

        public Result<SpinResult> Spin(double stake)
        {
            Slots generate = this.slotGenerator.Generate();
            double analyze = this.slotAnalyzer.Analyze(generate);
            return new SpinResult(generate, analyze * stake);
        }

        public Result<double> AddToWallet(int code)
        {
            throw new NotImplementedException();
        }
    }
}
