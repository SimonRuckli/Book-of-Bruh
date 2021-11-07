﻿namespace BookOfBruh.Core.Test.Slot
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
    }
}