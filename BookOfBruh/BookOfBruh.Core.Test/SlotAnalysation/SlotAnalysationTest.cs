namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using Xunit;
    using FluentAssertions;
    using BookOfBruh.Core.SlotAnalysation;
    using BookOfBruh.Core.GameData;
    using BookOfBruh.Core.Symbols;

    public class SlotAnalysationTest
    {
        [Fact]
        public void test()
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();
            ISymbol[,] symbols = new ISymbol[5, 3]
            {
                {new ASymbol(), new ASymbol(), new ASymbol()},
                {new ASymbol(), new ASymbol(), new ASymbol()},
                {new ASymbol(), new ASymbol(), new ASymbol()},
                {new ASymbol(), new ASymbol(), new ASymbol()},
                {new ASymbol(), new ASymbol(), new ASymbol()},
            };
            Slots input = new Slots(symbols);
            // Act
            testee.Analyze(input);
            // Assert
        }
    }
}
