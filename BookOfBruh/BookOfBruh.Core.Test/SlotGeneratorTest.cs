namespace BookOfBruh.Core.Test
{
    using Xunit;
    using FluentAssertions;

    public class SlotGeneratorTest
    {
        [Fact]
        public void SlotGeneratorShouldReturnCorrectSlotSize()
        {
            // Arrange
            SlotGenerator testee = new SlotGenerator();
            ISymbol[,] symbols = new ISymbol[5, 3];
            Slots expected = new Slots(symbols);

            // Act
            Slots result = testee.Generate();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
