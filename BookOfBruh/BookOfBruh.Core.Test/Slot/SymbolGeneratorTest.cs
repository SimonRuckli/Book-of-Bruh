using System.Linq;

namespace BookOfBruh.Core.Test.Slot
{
    using Symbols;
    using FluentAssertions;
    using Xunit;
    using BookOfBruh.Core.Slot;

    public class SymbolGeneratorTest
    {
        [Fact]
        public void SymbolGeneratorShouldReturnTenSymbolWhenNumberEven()
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
        public void SymbolGeneratorShouldReturnJSymbolWhenNumberOdd()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new JSymbol();

            // Act
            ISymbol result = testee.Generate(1);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnQSymbolWhenNumberIsEvenAndDividableByThree()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new QSymbol();

            // Act
            ISymbol result = testee.Generate(6);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnKSymbolWhenNumberIsOddAndDividableByThree()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new KSymbol();

            // Act
            ISymbol result = testee.Generate(3);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnASymbolWhenNumberIsDividableBySeven()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new ASymbol();

            // Act
            ISymbol result = testee.Generate(7);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnJoegiSymbolWhenNumberIsDividableByNine()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new JoegiSymbol();

            // Act
            ISymbol result = testee.Generate(9);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnVincSymbolWhenNumberIsDividableByEleven()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new VincSymbol();

            // Act
            ISymbol result = testee.Generate(11);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void SymbolGeneratorShouldReturnSimiSymbolWhenNumberIsDividableByThirteen()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new SimiSymbol();

            // Act
            ISymbol result = testee.Generate(13);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void GenerateNSymbols()
        {
            
            ISymbolGenerator testee = new SymbolGenerator();

            const int n = 1000;

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