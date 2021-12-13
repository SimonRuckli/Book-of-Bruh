namespace BookOfBruh.Core.Test
{
    using System.Collections.Generic;
    using CodeValidation;
    using GameData;
    using BookOfBruh.Core.SlotAnalysation;
    using SlotGeneration;
    using CSharpFunctionalExtensions;
    using FluentAssertions;
    using Helper;
    using Symbols;
    using Xunit;

    public class GameTest
    {
        [Theory]

        [InlineData("|TTT_-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 3, 1, 3
            )]

        [InlineData("|TTTT-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 6, 2, 12
            )]

        public void SpinShouldReturnCorrectSpinResult(string generatedSlot, double patternPoint, double stake, double bruhCoins )
        {
            // Arrange
            const double fakeBruhCoin = 0;

            ISlotGenerator fakeSlotGenerator = new FakeSlotGenerator( new Slots(SymbolTestHelper.SymbolsFromPattern(generatedSlot)));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(patternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator(fakeBruhCoin);

            IPlayer fakePlayer = new FakePlayer(0);

            SpinResult expected = new SpinResult(new Slots(SymbolTestHelper.SymbolsFromPattern(generatedSlot)), bruhCoins);

            Game testee = new Game(fakePlayer, fakeCodeValidator, fakeSlotGenerator, fakeSlotAnalyzer);

            // Act
            Result<SpinResult> result = testee.Spin(stake);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }

        [Theory]

        [InlineData(1245, 1)]

        [InlineData(32423, 4)]

        public void AddToWalletShouldReturnCorrectAmountOfBruhCoins(int code, double bruhCoins)
        {
            // Arrange
            const double fakePatternPoint = 0;
            ISlotGenerator fakeSlotGenerator = new FakeSlotGenerator( new Slots(new ISymbol[5,3]));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(fakePatternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator(bruhCoins);

            IPlayer fakePlayer = new FakePlayer(0);
            
            Game testee = new Game(fakePlayer, fakeCodeValidator, fakeSlotGenerator, fakeSlotAnalyzer);

            double expected = bruhCoins;

            // Act
            Result<double> result = testee.AddToWallet(code);

            // Assert
            result.Value.Should().Be(expected);
        }

        [Theory]

        [InlineData(0, 0)]

        public void AddToWalletShouldReturnFailWhenCodeNotValid(int code, double bruhCoins)
        {
            // Arrange
            const double fakePatternPoint = 0;
            ISlotGenerator fakeSlotGenerator = new FakeSlotGenerator( new Slots(new ISymbol[5,3]));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(fakePatternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator(bruhCoins);

            IPlayer fakePlayer = new FakePlayer(0);
            
            Game testee = new Game(fakePlayer, fakeCodeValidator, fakeSlotGenerator, fakeSlotAnalyzer);
            
            // Act
            Result<double> result = testee.AddToWallet(code);

            // Assert
            result.IsFailure.Should().BeTrue();
        }

        [Theory]

        [InlineData(1, 34, 0, 34)]

        public void AddToWalletShouldAddMoneyToPlayer(int code, double bruhCoins, double playerBefore, double playerPast)
        {
            // Arrange
            const double fakePatternPoint = 0;
            ISlotGenerator fakeSlotGenerator = new FakeSlotGenerator( new Slots(new ISymbol[5,3]));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(fakePatternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator(bruhCoins);

            IPlayer fakePlayer = new FakePlayer(playerBefore);
            
            Game testee = new Game(fakePlayer, fakeCodeValidator, fakeSlotGenerator, fakeSlotAnalyzer);
            
            // Act
            testee.AddToWallet(code);

            // Assert
            testee.Player.BruhCoins.Should().Be(playerPast);
        }
    }

    internal class FakeSlotGenerator : ISlotGenerator
    {
        private readonly Slots slots;

        public FakeSlotGenerator(Slots slots)
        {
            this.slots = slots;
        }

        public Slots Generate()
        {
            return this.slots;
        }
    }

    internal class FakeSlotAnalyzer : ISlotAnalyzer
    {
        private readonly double patternPoint;

        public FakeSlotAnalyzer(double patternPoint)
        {
            this.patternPoint = patternPoint;
        }

        public AnalyzeResult Analyze(Slots slots)
        {
            return new AnalyzeResult(this.patternPoint, new List<Pattern>());
        }
    }

    internal class FakeCodeValidator : ICodeValidator
    {
        private readonly double bruhCoins;

        public FakeCodeValidator(double bruhCoins)
        {
            this.bruhCoins = bruhCoins;
        }

        public Result<double> Validate(int code)
        {
            return this.bruhCoins == 0 ? Result.Failure<double>("Not a valid Code") : this.bruhCoins;
        }
    }

    internal class FakeWallet : IWallet
    {
        public double BruhCoins { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }

    internal class FakePlayer : IPlayer
    {
        public FakePlayer(double playerBefore)
        {
            this.BruhCoins = playerBefore;
        }

        public string Name => throw new System.NotImplementedException();

        public double BruhCoins { get; set; }

        public void AddBruhCoins(double bruhCoins)
        {
            this.BruhCoins += bruhCoins;
        }
    }
}
