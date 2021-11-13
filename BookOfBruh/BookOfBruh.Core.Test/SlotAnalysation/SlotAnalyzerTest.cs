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

        [InlineData("|TTT_-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 3)]

        [InlineData("|TTTT-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 6)]

        [InlineData("|TTTTT|" +
                    "|-_-_-|" +
                    "|-_-_-|", 24)]
       
        [InlineData("|T_-_-|" +
                    "|-T-_-|" +
                    "|-_T_-|", 3)]
       
        [InlineData("|T_T_-|" +
                    "|-T---|" +
                    "|-_-_-|", 3)]
       
        [InlineData("|T_T_T|" +
                    "|-T-T-|" +
                    "|-_-_-|", 24)]
       
        [InlineData("|T_-_T|" +
                    "|-TTT-|" +
                    "|-_-_-|", 24)]
       
        [InlineData("|T_-_T|" +
                    "|-T-T-|" +
                    "|-_T_-|", 24)]
       
        [InlineData("|-_-_-|" +
                    "|TTT_-|" +
                    "|-_-_-|", 3)]

        [InlineData("|-_-_-|" +
                    "|TTTT-|" +
                    "|-_-_-|", 6)]

        [InlineData("|-_-_-|" +
                    "|TTTTT|" +
                    "|-_-_-|", 24)]

        [InlineData("|-T-_-|" +
                    "|T_T_T|" +
                    "|-_-T-|", 24)]

        [InlineData("|-_-T-|" +
                    "|T_T_T|" +
                    "|-T-_-|", 24)]

        [InlineData("|-_-_-|" +
                    "|T_T_T|" +
                    "|-T-T-|", 24)]

        [InlineData("|-T-T-|" +
                    "|T_T_T|" +
                    "|-_-_-|", 24)]

        [InlineData("|-_-_-|" +
                    "|T_-_T|" +
                    "|-TTT-|", 24)]

        [InlineData("|-TTT-|" +
                    "|T_-_T|" +
                    "|-_-_-|", 24)]

        [InlineData("|-_-_-|" +
                    "|T_T_-|" +
                    "|-T-_-|", 3)]

        [InlineData("|-T-_-|" +
                    "|T-T_-|" +
                    "|-_-_-|", 3)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTT_-|", 3)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTTT-|", 6)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTTTT|", 24)]

        [InlineData("|-_T_-|" +
                    "|-T-_-|" +
                    "|T_-_-|", 3)]

        [InlineData("|-_-_-|" +
                    "|-T-_-|" +
                    "|T_T_-|", 3)]

        [InlineData("|-_-_-|" +
                    "|-T-T-|" +
                    "|T_T_T|", 24)]

        [InlineData("|-_-_-|" +
                    "|-TTT-|" +
                    "|T_-_T|", 24)]

        [InlineData("|-_T_-|" +
                    "|-T-T-|" +
                    "|T_-_T|", 24)]


        public void SlotAnalyzerShouldReturnCorrectMultiplierWhen(string pattern, int expected)
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

        [Theory]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 0)]

        [InlineData("|TT-_-|" +
                    "|-_T_-|" +
                    "|-_-_-|", 0)]

        [InlineData("|T_-_-|" +
                    "|-T-TT|" +
                    "|-_T_-|", 0)]

        public void SlotAnalyzerShouldReturnZeroWhen(string pattern, int expected)
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

        [Theory]
        
        [InlineData("|TTT_-|" +
                    "|-_-_-|" +
                    "|TTT_-|", 6)]
        
        [InlineData("|TTT_-|" +
                    "|TTT_-|" +
                    "|TTT_-|", 27)]

        public void SlotAnalyzerShouldReturnCorrectMultiplierWhenSeveralPattern(string pattern, int expected)
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
}
