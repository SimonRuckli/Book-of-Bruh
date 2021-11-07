﻿namespace BookOfBruh.Core.Test
{
    using Xunit;
    using FluentAssertions;
    using Slot;
    using Symbols;

    public class SymbolGeneratorTest
    {
        [Fact]
        public void SymbolGeneratorShouldReturnTenSymbolWhenZero()
        {
            // Arrange
            ISymbolGenerator testee = new SymbolGenerator();
            ISymbol expected = new TenSymbol();

            // Act
            ISymbol result = testee.Generate(0);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
