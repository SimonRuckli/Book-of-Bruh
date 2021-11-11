namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using Xunit;
    using FluentAssertions;
    using BookOfBruh.Core.SlotAnalysation;
    using BookOfBruh.Core.GameData;
    using BookOfBruh.Core.Symbols;

    public class SlotAnalyzerTest
    {
        [Fact]
        public void SlotAnalyzerShouldReturnThreeWhenThreeTenSymbolsInARow()
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();
            const double expected = 3;

            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new FS(), new FS(), new FS()},
                {new FS(), new FS(), new FS()},
            };

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SlotAnalyzerShouldReturnSixWhenFourTenSymbolsInARow()
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();
            const double expected = 6;

            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new FS(), new FS(), new FS()},
            };

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SlotAnalyzerShouldReturnTwentyFourWhenFiveTenSymbolsInARow()
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();
            const double expected = 24;

            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
            };

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SlotAnalyzerShouldReturnThreeWhenThreeTenSymbolsInDiagonal()
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();
            const double expected = 3;

            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new TenSymbol(), new FS(), new FS()},
                {new FS(), new TenSymbol(), new FS()},
                {new FS(), new FS(), new TenSymbol()},
                {new FS(), new FS(), new FS()},
                {new FS(), new FS(), new FS()},
            };

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SlotAnalyzerShouldReturnThreeWhenThreeTenSymbolsInTriangle()
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();
            const double expected = 3;

            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new TenSymbol(), new FS(), new FS()},
                {new FS(), new TenSymbol(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new FS(), new FS(), new FS()},
                {new FS(), new FS(), new FS()},
            };

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SlotAnalyzerShouldReturnTwentyFourWhenFiveTenSymbolsInTriangle()
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();
            const double expected = 24;

            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new TenSymbol(), new FS(), new FS()},
                {new FS(), new TenSymbol(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
                {new FS(), new TenSymbol(), new FS()},
                {new TenSymbol(), new FS(), new FS()},
            };

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SlotAnalyzerShouldReturnTwentyFourWhenFiveTenSymbolsInUForm()
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();
            const double expected = 24;

            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new FS(), new FS(), new TenSymbol()},
                {new FS(), new TenSymbol(), new FS()},
                {new FS(), new TenSymbol(), new FS()},
                {new FS(), new TenSymbol(), new FS()},
                {new FS(), new FS(), new TenSymbol()},
            };

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }
    }

    internal struct FS : ISymbol
    {
        public byte Rarity  => 100;
    }
}
