namespace BookOfBruh.Core.Test
{
    using BookOfBruh.Core.CodeValidation;
    using BookOfBruh.Core.GameData;
    using BookOfBruh.Core.SlotAnalysation;
    using BookOfBruh.Core.SlotGeneration;
    using CSharpFunctionalExtensions;
    using FluentAssertions;
    using Xunit;
    public class GameTest
    {
        [Fact]
        public void SpinShouldReturnCorrectSpinResult()
        {
            // Arrange
            ISlotGenerator fakeSlotGenerator = new IFakeSlotGenerator();
            ISlotAnalyzer fakeSlotAnalyzer = new IFakeSlotAnalyzer();
            ICodeValidator fakeCodeValidator = new IFakeCodeValidator();
            IPlayer fakePlayer = new IFakePlayer();
            int stake = 1;
            SpinResult expected = new SpinResult(new Slots(new Symbols.ISymbol[5,3]), 1);

            Game testee = new Game(fakePlayer, fakeCodeValidator, fakeSlotGenerator, fakeSlotAnalyzer);

            // Act
            Result<SpinResult> result = testee.Spin(stake);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }
    }

    internal class IFakeSlotGenerator : ISlotGenerator
    {
        public Slots Generate()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class IFakeSlotAnalyzer : ISlotAnalyzer
    {
        public double Analyze(Slots slots)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class IFakeCodeValidator : ICodeValidator
    {
        public Result<double> Validate(int code)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class IFakeWallet : IWallet
    {
        public double BruhCoins { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }

    internal class IFakePlayer : IPlayer
    {
        public string Name => throw new System.NotImplementedException();

        public double BruhCoins => throw new System.NotImplementedException();

        public void AddBruhCoins(double bruhCoins)
        {
            throw new System.NotImplementedException();
        }
    }
}
