using BookOfBruh.Core.Slot;
using BookOfBruh.Core.Symbols;
using FluentAssertions;
using Xunit;

namespace BookOfBruh.Core.Test.Slot
{
    public class SlotGeneratorTest
    {
        [Fact]
        public void SlotGeneratorShouldReturnCorrectSlotSize()
        {
            // Arrange
            SlotGenerator testee = new SlotGenerator(new FakeSymbolGenerator(null));
            ISymbol[,] symbols = new ISymbol[5, 3];
            Slots expected = new Slots(symbols);

            // Act
            Slots result = testee.Generate();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void SlotGeneratorShouldReturnOnlyASymbol()
        {
            // Arrange
            ISymbolGenerator symbolGenerator = new FakeSymbolGenerator(new ASymbol());
            SlotGenerator testee = new SlotGenerator(symbolGenerator);
            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new ASymbol(), new ASymbol(), new ASymbol()},
                {new ASymbol(), new ASymbol(), new ASymbol()},
                {new ASymbol(), new ASymbol(), new ASymbol()},
                {new ASymbol(), new ASymbol(), new ASymbol()},
                {new ASymbol(), new ASymbol(), new ASymbol()},
            };

            Slots expected = new Slots(symbols);

            // Act
            Slots result = testee.Generate();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }

    public class FakeSymbolGenerator : ISymbolGenerator
    {
        private readonly ISymbol fakeSymbol;

        public FakeSymbolGenerator(ISymbol fakeSymbol)
        {
            this.fakeSymbol = fakeSymbol;
        }

        public ISymbol Generate(int number)
        {
            return this.fakeSymbol;
        }
    }
}
