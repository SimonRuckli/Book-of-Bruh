using CSharpFunctionalExtensions;

namespace BookOfBruh.Core
{
    using System;
    using BookOfBruh.Core.CodeValidation;
    using BookOfBruh.Core.GameData;
    using BookOfBruh.Core.SlotAnalysation;
    using BookOfBruh.Core.SlotGeneration;

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
            return new SpinResult(new Slots(new Symbols.ISymbol[5, 3]), 1);
        }

        public Result<double> AddToWallet(int code)
        {
            throw new NotImplementedException();
        }
    }
}
