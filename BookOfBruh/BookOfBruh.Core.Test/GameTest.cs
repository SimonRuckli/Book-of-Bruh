namespace BookOfBruh.Core.Test
{
    using CodeValidation;
    using GameData;
    using BookOfBruh.Core.SlotAnalysation;
    using SlotGeneration;
    using CSharpFunctionalExtensions;
    using FluentAssertions;
    using Helper;
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
            ISlotGenerator fakeSlotGenerator = new FakeSlotGenerator( new Slots(SymbolTestHelper.SymbolsFromPattern(generatedSlot)));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(patternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator();

            IPlayer fakePlayer = new FakePlayer();

            SpinResult expected = new SpinResult(new Slots(SymbolTestHelper.SymbolsFromPattern(generatedSlot)), bruhCoins);

            Game testee = new Game(fakePlayer, fakeCodeValidator, fakeSlotGenerator, fakeSlotAnalyzer);

            // Act
            Result<SpinResult> result = testee.Spin(stake);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
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

        public double Analyze(Slots slots)
        {
            return this.patternPoint;
        }
    }

    internal class FakeCodeValidator : ICodeValidator
    {
        public Result<double> Validate(int code)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class FakeWallet : IWallet
    {
        public double BruhCoins { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }

    internal class FakePlayer : IPlayer
    {
        public string Name => throw new System.NotImplementedException();

        public double BruhCoins => throw new System.NotImplementedException();

        public void AddBruhCoins(double bruhCoins)
        {
            throw new System.NotImplementedException();
        }
    }
}
