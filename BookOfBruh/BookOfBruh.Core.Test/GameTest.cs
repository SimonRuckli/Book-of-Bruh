namespace BookOfBruh.Core.Test
{
    using CodeValidation;
    using GameData;
    using BookOfBruh.Core.SlotAnalysation;
    using SlotGeneration;
    using CSharpFunctionalExtensions;
    using FluentAssertions;
    using Xunit;

    public class GameTest
    {
        [Fact]
        public void SpinShouldReturnCorrectSpinResult()
        {
            // Arrange
            ISlotGenerator fakeSlotGenerator = new FakeSlotGenerator();
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer();
            ICodeValidator fakeCodeValidator = new FakeCodeValidator();
            IPlayer fakePlayer = new FakePlayer();
            int stake = 1;
            SpinResult expected = new SpinResult(new Slots(new Symbols.ISymbol[5,3]), 1);

            Game testee = new Game(fakePlayer, fakeCodeValidator, fakeSlotGenerator, fakeSlotAnalyzer);

            // Act
            Result<SpinResult> result = testee.Spin(stake);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }
    }

    internal class FakeSlotGenerator : ISlotGenerator
    {
        public Slots Generate()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class FakeSlotAnalyzer : ISlotAnalyzer
    {
        public double Analyze(Slots slots)
        {
            throw new System.NotImplementedException();
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
