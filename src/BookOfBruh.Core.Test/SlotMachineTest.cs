namespace BookOfBruh.Core.Test
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CodeValidation;
    using GameData;
    using BookOfBruh.Core.SlotAnalysation;
    using SlotGeneration;
    using CSharpFunctionalExtensions;
    using FluentAssertions;
    using Helper;
    using Reels;
    using Symbols;
    using Xunit;

    public class SlotMachineTest
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

        public async Task SpinShouldReturnCorrectSpinResult(string generatedSlot, double patternPoint, double stake, double bruhCoins )
        {
            // Arrange
            const double fakeBruhCoin = 0;

            ISlotConverter fakeSlotConverter = new FakeSlotConverter( new Slots(SymbolTestHelper.SymbolsFromPattern(generatedSlot)));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(patternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator(fakeBruhCoin);
            IReelsGenerator reelsGenerator = new FakeReelsGenerator();
            SlotMachineState state = new ReadyToSpinState();
            
            var testee = new SlotMachine(fakeCodeValidator, fakeSlotConverter, fakeSlotAnalyzer, reelsGenerator, state){Stake = stake};

            // Act
            double result = await testee.Spin();

            // Assert
            result.Should().Be(bruhCoins);
        }

        [Theory]

        [InlineData(1245, 1)]

        [InlineData(32423, 4)]

        public void AddToWalletShouldReturnCorrectAmountOfBruhCoins(int code, double bruhCoins)
        {
            // Arrange
            const double fakePatternPoint = 0;
            ISlotConverter fakeSlotConverter = new FakeSlotConverter( new Slots(new ISymbol[5,3]));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(fakePatternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator(bruhCoins);
            IReelsGenerator reelsGenerator = new FakeReelsGenerator();
            SlotMachineState state = new ReadyToSpinState();
            
            var testee = new SlotMachine(fakeCodeValidator, fakeSlotConverter, fakeSlotAnalyzer, reelsGenerator, state);

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
            ISlotConverter fakeSlotConverter = new FakeSlotConverter( new Slots(new ISymbol[5,3]));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(fakePatternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator(bruhCoins);
            IReelsGenerator reelsGenerator = new FakeReelsGenerator();
            

            SlotMachineState state = new ReadyToSpinState();

            var testee = new SlotMachine(fakeCodeValidator, fakeSlotConverter, fakeSlotAnalyzer, reelsGenerator, state);
            
            // Act
            Result<double> result = testee.AddToWallet(code);

            // Assert
            result.IsFailure.Should().BeTrue();
        }

        [Theory]

        [InlineData(1, 34, 34)]

        public void AddToWalletShouldAddMoneyToPlayer(int code, double bruhCoins, double playerPast)
        {
            // Arrange
            const double fakePatternPoint = 0;
            ISlotConverter fakeSlotConverter = new FakeSlotConverter( new Slots(new ISymbol[5,3]));
            ISlotAnalyzer fakeSlotAnalyzer = new FakeSlotAnalyzer(fakePatternPoint);
            ICodeValidator fakeCodeValidator = new FakeCodeValidator(bruhCoins);
            IReelsGenerator reelsGenerator = new FakeReelsGenerator();
            
            SlotMachineState state = new ReadyToSpinState();

            var testee = new SlotMachine(fakeCodeValidator, fakeSlotConverter, fakeSlotAnalyzer, reelsGenerator, state);
            
            // Act
            testee.AddToWallet(code);

            // Assert
            testee.BruhCoins.Should().Be(playerPast);
        }
    }

    public class FakeReelsGenerator : IReelsGenerator
    {
        public List<IReel> Generate(int count)
        {
            return new List<IReel>();
        }
    }

    internal class FakeSlotConverter : ISlotConverter
    {
        private readonly Slots slots;

        public FakeSlotConverter(Slots slots)
        {
            this.slots = slots;
        }

        public Slots Convert(IEnumerable<IReel> reels)
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
}
