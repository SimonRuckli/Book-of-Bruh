namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using Xunit;
    using FluentAssertions;
    using BookOfBruh.Core.SlotAnalysation;
    using BookOfBruh.Core.GameData;
    using BookOfBruh.Core.Symbols;

    public class SlotAnalyzerTest
    {
        [Theory]

        [InlineData("|TTT--|" +
                    "|-----|" +
                    "|-----|", 3)]

        [InlineData("|TTTT-|" +
                    "|-----|" +
                    "|-----|", 6)]

        [InlineData("|TTTTT|" +
                    "|-----|" +
                    "|-----|", 24)]
       
        [InlineData("|T----|" +
                    "|-T---|" +
                    "|--T--|", 3)]
       
        [InlineData("|T-T--|" +
                    "|-T---|" +
                    "|-----|", 3)]
       
        [InlineData("|T-T-T|" +
                    "|-T-T-|" +
                    "|-----|", 24)]
       
        [InlineData("|T---T|" +
                    "|-TTT-|" +
                    "|-----|", 24)]
       
        [InlineData("|T---T|" +
                    "|-T-T-|" +
                    "|--T--|", 24)]
       
        [InlineData("|-----|" +
                    "|TTT--|" +
                    "|-----|", 3)]

        [InlineData("|-----|" +
                    "|TTTT-|" +
                    "|-----|", 6)]

        [InlineData("|-----|" +
                    "|TTTTT|" +
                    "|-----|", 24)]

        [InlineData("|-T---|" +
                    "|T-T-T|" +
                    "|---T-|", 24)]

        [InlineData("|---T-|" +
                    "|T-T-T|" +
                    "|-T---|", 24)]

        [InlineData("|-----|" +
                    "|T-T-T|" +
                    "|-T-T-|", 24)]

        [InlineData("|-T-T-|" +
                    "|T-T-T|" +
                    "|-----|", 24)]

        [InlineData("|-----|" +
                    "|T---T|" +
                    "|-TTT-|", 24)]

        [InlineData("|-TTT-|" +
                    "|T---T|" +
                    "|-----|", 24)]

        [InlineData("|-----|" +
                    "|T-T--|" +
                    "|-T---|", 3)]

        [InlineData("|-T---|" +
                    "|T-T--|" +
                    "|-----|", 3)]

        [InlineData("|-----|" +
                    "|-----|" +
                    "|TTT--|", 3)]

        [InlineData("|-----|" +
                    "|-----|" +
                    "|TTTT-|", 6)]

        [InlineData("|-----|" +
                    "|-----|" +
                    "|TTTTT|", 24)]

        [InlineData("|--T--|" +
                    "|-T---|" +
                    "|T----|", 3)]

        [InlineData("|-----|" +
                    "|-T---|" +
                    "|T-T--|", 3)]

        [InlineData("|-----|" +
                    "|-T-T-|" +
                    "|T-T-T|", 24)]

        [InlineData("|-----|" +
                    "|-TTT-|" +
                    "|T---T|", 24)]

        [InlineData("|--T--|" +
                    "|-T-T-|" +
                    "|T---T|", 24)]


        public void SlotAnalyzerShouldReturnCorrectMultiplicatorWhen(string pattern, int expected)
        {
            // Arrange
            SlotAnalyzer testee = new SlotAnalyzer();

            ISymbol[,] symbols = SymbolTestHelper.SymbolsFromPattern(pattern);

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }
    }

    internal struct FS : ISymbol
    {
        public byte Rarity  => 0;
    }
}
