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
        public void SymbolGeneratorShouldReturnTenSymbolWhenNumberIsUnderTwenty()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new TenSymbol();

            // Act
            ISymbol result = testee.Generate(2);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnJSymbolWhenNumberIsBetweenTwentyAndForty()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new JSymbol();

            // Act
            ISymbol result = testee.Generate(30);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnQSymbolWhenNumberIsBetweenFortyAndFiftyFive()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new QSymbol();

            // Act
            ISymbol result = testee.Generate(50);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnKSymbolWhenNumberIsBetweenFiftyFiveAndSeventy()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new KSymbol();

            // Act
            ISymbol result = testee.Generate(60);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnASymbolWhenNumberIsBetweenSeventyAndEighty()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new ASymbol();

            // Act
            ISymbol result = testee.Generate(75);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnJoegiSymbolWhenNumberIsBetweenEightyAndEightyEight()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new JoegiSymbol();

            // Act
            ISymbol result = testee.Generate(84);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnVincSymbolWhenNumberIsBetweenEightyEightAndNinetyFour()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new VincSymbol();

            // Act
            ISymbol result = testee.Generate(90);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnSimiSymbolWhenNumberIsBetweenNinetyFourAndNinetyEight()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new SimiSymbol();

            // Act
            ISymbol result = testee.Generate(95);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnWildSymbolWhenNumberIsBetweenNinetyEightAndHundred()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new WildSymbol();

            // Act
            ISymbol result = testee.Generate(99);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void GenerateNSymbols()
        {
            
            ISymbolGenerator testee = new SymbolGenerator();

            const int n = 100;

            ISymbol[] symbols = new ISymbol[n];
           

            for (int i = 0; i < n; i++)
            {
                symbols[i] = testee.Generate(i);
            }

            int jSymbolCount = symbols.Count(s => s is JSymbol);
            int tenSymbolCount = symbols.Count(s => s is TenSymbol);

            int qSymbolCount = symbols.Count(s => s is QSymbol);
            int kSymbolCount = symbols.Count(s => s is KSymbol);

            int aSymbolCount = symbols.Count(s => s is ASymbol);

            int joegiSymbolCount = symbols.Count(s => s is JoegiSymbol);

            int vincSymbolCount = symbols.Count(s => s is VincSymbol);

            int simiSymbolCount = symbols.Count(s => s is SimiSymbol);

            int wildSymbolCount = symbols.Count(s => s is WildSymbol);
        }
    }
}