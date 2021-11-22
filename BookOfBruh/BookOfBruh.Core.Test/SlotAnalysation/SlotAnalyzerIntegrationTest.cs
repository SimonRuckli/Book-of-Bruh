namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using GameData;
    using BookOfBruh.Core.SlotAnalysation;
    using Symbols;
    using FluentAssertions;
    using Ninject;
    using Xunit;
    using Helper;

    public class SlotAnalyzerIntegrationTest
    {
        private readonly StandardKernel kernel;

        public SlotAnalyzerIntegrationTest()
        {
            this.kernel = new StandardKernel(new TestModule());
        }

        [Theory]

        // All valid patterns

        [InlineData("|TTT_-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 3)]

        [InlineData("|TTTT-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 9)]

        [InlineData("|TTTTT|" +
                    "|-_-_-|" +
                    "|-_-_-|", 24)]

        [InlineData("|T_-_-|" +
                    "|-T-_-|" +
                    "|-_T_-|",3)]

        [InlineData("|T_T_-|" +
                    "|-T-_-|" +
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
                    "|-_-_-|", 9)]

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
                    "|TTTT-|", 9)]

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

        // Invalid patterns

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 0)]

        [InlineData("|TT-_-|" +
                    "|-_T_-|" +
                    "|-_-_-|", 0)]

        [InlineData("|T_-_-|" +
                    "|-T-TT|" +
                    "|-_T_-|", 3)]

        // Several patterns

        [InlineData("|TTT_-|" +
                    "|-_-_-|" +
                    "|TTT_-|", 6)]

        [InlineData("|TTT_-|" +
                    "|TTT_-|" +
                    "|TTT_-|", 27)]

        // ASymbol 
        [InlineData("|-_-_-|" +
                    "|A_-_A|" +
                    "|-AAA-|", 33.6)]

        [InlineData("|AAAA-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 12.6)]

        [InlineData("|-_-_-|" +
                    "|A_A_-|" +
                    "|-A-_-|", 4.2)]

        // QSymbol 
        [InlineData("|-Q-_-|" +
                    "|Q_Q_-|" +
                    "|-_-_-|", 3.6)]

        [InlineData("|-_Q_-|" +
                    "|-Q-Q-|" +
                    "|Q_-_Q|", 28.8)]

        [InlineData("|-_-_-|" +
                    "|QQQQ-|" +
                    "|-_-_-|", 10.8)]

        // KSymbol 
        [InlineData("|-_-_-|" +
                    "|KKK_-|" +
                    "|-_-_-|", 3.6)]

        [InlineData("|K_-_K|" +
                    "|-K-K-|" +
                    "|-_K_-|", 28.8)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|KKKK-|", 10.8)]

        // JSymbol
        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|JJJJ-|", 9)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|JJJJJ|", 24)]

        [InlineData("|-_J_-|" +
                    "|-J-_-|" +
                    "|J_-_-|", 3)]
        // JoegiSymbol
        [InlineData("|-_-_-|" +
                    "|H_-_H|" +
                    "|-HHH-|", 48)]

        [InlineData("|-_H_-|" +
                    "|-H-_-|" +
                    "|H_-_-|", 6)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|HHHH-|", 18)]
        // VincSymbol
        [InlineData("|-_-V-|" +
                    "|V_V_V|" +
                    "|-V-_-|", 60)]

        [InlineData("|V_-_-|" +
                    "|-V-_-|" +
                    "|-_V_-|", 7.5)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|VVVV-|", 22.5)]
        // SSymbol
        [InlineData("|-_-S-|" +
                    "|S_S_S|" +
                    "|-S-_-|", 72)]

        [InlineData("|S_-_-|" +
                    "|-S-_-|" +
                    "|-_S_-|", 9)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|SSSS-|", 27)]
        // WildSymbol
        [InlineData("|-_-W-|" +
                    "|W_W_W|" +
                    "|-W-_-|", 90)]

        [InlineData("|-_-A-|" +
                    "|W_A_A|" +
                    "|-A-_-|", 33.6)]

        [InlineData("|-TTT-|" +
                    "|W_-_W|" +
                    "|-AAA-|", 57.6)]


        [InlineData("|-TTT-|" +
                    "|W_-_T|" +
                    "|-AAA-|", 24)]


        public void SlotAnalyzerShouldReturnCorrectMultiplierWhen(string inputPattern, double expected)
        {
            // Arrange
            IPatternMatcher patternMatcher = this.kernel.Get<IPatternMatcher>();

            SlotAnalyzer testee = new SlotAnalyzer(patternMatcher);

            ISymbol[,] symbols = SymbolTestHelper.SymbolsFromPattern(inputPattern);

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().BeApproximately(expected, 0.0001);
        }
    }
}
