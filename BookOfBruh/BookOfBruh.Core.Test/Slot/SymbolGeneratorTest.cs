using System.Linq;

namespace BookOfBruh.Core.Test.Slot
{
    using BookOfBruh.Core.SlotGeneration;
    using Symbols;
    using FluentAssertions;
    using Xunit;

    public class SymbolGeneratorTest
    {
        [Fact]
        public void SymbolGeneratorShouldReturnEighteenTenSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 18;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is TenSymbol).Should().Be(Expected);
            
        }

        [Fact]
        public void SymbolGeneratorShouldReturnEighteenJSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 18;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is JSymbol).Should().Be(Expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnFourteenQSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 14;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is QSymbol).Should().Be(Expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnFourteenKSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 14;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is KSymbol).Should().Be(Expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnTenASymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 10;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is ASymbol).Should().Be(Expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnEightJoegiSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 8;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is JoegiSymbol).Should().Be(Expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnSevenVincSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 7;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is VincSymbol).Should().Be(Expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnSixSimiSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 6;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is SimiSymbol).Should().Be(Expected);

        }

        [Fact]
        public void SymbolGeneratorShouldReturnFiveWildSymbolWhenHundredSymbolsGenerated()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            const int N = 100;
            const int Expected = 5;

            ISymbol[] symbols = new ISymbol[N];

            // Act
            for (int i = 0; i < N; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            // Assert
            symbols.Count(s => s is WildSymbol).Should().Be(Expected);

        }
    }
}