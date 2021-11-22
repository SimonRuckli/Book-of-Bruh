namespace BookOfBruh.Core.Test.Slot
{
    using Symbols;
    using FluentAssertions;
    using Xunit;
    using GameData;
    using SlotGeneration;

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
            ISymbol[,] symbols = Helper.SymbolTestHelper.SymbolsFromPattern("|AAAAA|" + 
                                                                            "|AAAAA|" +
                                                                            "|AAAAA|");

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
