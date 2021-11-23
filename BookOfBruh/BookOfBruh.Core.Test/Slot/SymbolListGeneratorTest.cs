namespace BookOfBruh.Core.Test.Slot
{
    using System.Collections.Generic;
    using System.Linq;
    using SlotGeneration;
    using Symbols;
    using Xunit;
    using FluentAssertions;
    using FluentAssertions.Execution;

    public class SymbolListGeneratorTest
    {
        [Fact]
        public void SymbolListGeneratorShouldReturnCorrectAmountOfSymbols()
        {
            // Arrange
            SymbolListGenerator testee = new SymbolListGenerator();


            const int levelOneSymbolChance = 18;
            const int levelTwoSymbolChance = 14;
            const int levelThreeSymbolChance = 10;
            const int levelFourSymbolChance = 8;
            const int levelFiveSymbolChance = 7;
            const int levelSixSymbolChance = 6;
            const int levelSevenSymbolChance = 5;

        // Act

        List<ISymbol> result = testee.Generate();

            // Assert
            using (new AssertionScope())
            {

            }
            result.Count(s => s is JSymbol).Should().Be(levelOneSymbolChance);
            result.Count(s => s is TenSymbol).Should().Be(levelOneSymbolChance);

            result.Count(s => s is QSymbol).Should().Be(levelTwoSymbolChance);
            result.Count(s => s is KSymbol).Should().Be(levelTwoSymbolChance);

            result.Count(s => s is ASymbol).Should().Be(levelThreeSymbolChance);

            result.Count(s => s is JoegiSymbol).Should().Be(levelFourSymbolChance);
            result.Count(s => s is VincSymbol).Should().Be(levelFiveSymbolChance);
            result.Count(s => s is SimiSymbol).Should().Be(levelSixSymbolChance);

            result.Count(s => s is WildSymbol).Should().Be(levelSevenSymbolChance);

        }
    }
}
