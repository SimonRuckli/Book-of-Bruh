namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using GameData;
    using BookOfBruh.Core.SlotAnalysation;
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
                    "|-_-_-|", 1.15)]

        [InlineData("|TTTT-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 3.449999)]

        [InlineData("|TTTTT|" +
                    "|-_-_-|" +
                    "|-_-_-|", 9.2)]

        [InlineData("|T_-_-|" +
                    "|-T-_-|" +
                    "|-_T_-|",1.15)]

        [InlineData("|T_T_-|" +
                    "|-T-_-|" +
                    "|-_-_-|", 1.15)]

        [InlineData("|T_T_T|" +
                    "|-T-T-|" +
                    "|-_-_-|", 9.2)]

        [InlineData("|T_-_T|" +
                    "|-TTT-|" +
                    "|-_-_-|", 9.2)]

        [InlineData("|T_-_T|" +
                    "|-T-T-|" +
                    "|-_T_-|", 9.2)]

        [InlineData("|-_-_-|" +
                    "|TTT_-|" +
                    "|-_-_-|", 1.15)]

        [InlineData("|-_-_-|" +
                    "|TTTT-|" +
                    "|-_-_-|", 3.449999)]

        [InlineData("|-_-_-|" +
                    "|TTTTT|" +
                    "|-_-_-|", 9.2)]

        [InlineData("|-T-_-|" +
                    "|T_T_T|" +
                    "|-_-T-|", 9.2)]

        [InlineData("|-_-T-|" +
                    "|T_T_T|" +
                    "|-T-_-|", 9.2)]

        [InlineData("|-_-_-|" +
                    "|T_T_T|" +
                    "|-T-T-|", 9.2)]

        [InlineData("|-T-T-|" +
                    "|T_T_T|" +
                    "|-_-_-|", 9.2)]

        [InlineData("|-_-_-|" +
                    "|T_-_T|" +
                    "|-TTT-|", 9.2)]

        [InlineData("|-TTT-|" +
                    "|T_-_T|" +
                    "|-_-_-|", 9.2)]

        [InlineData("|-_-_-|" +
                    "|T_T_-|" +
                    "|-T-_-|", 1.15)]

        [InlineData("|-T-_-|" +
                    "|T-T_-|" +
                    "|-_-_-|", 1.15)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTT_-|", 1.15)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTTT-|", 3.449999)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTTTT|", 9.2)]

        [InlineData("|-_T_-|" +
                    "|-T-_-|" +
                    "|T_-_-|", 1.15)]

        [InlineData("|-_-_-|" +
                    "|-T-_-|" +
                    "|T_T_-|", 1.15)]

        [InlineData("|-_-_-|" +
                    "|-T-T-|" +
                    "|T_T_T|", 9.2)]

        [InlineData("|-_-_-|" +
                    "|-TTT-|" +
                    "|T_-_T|", 9.2)]

        [InlineData("|-_T_-|" +
                    "|-T-T-|" +
                    "|T_-_T|", 9.2)]

        // Invalid patterns

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 0)]

        [InlineData("|TT-_-|" +
                    "|-_T_-|" +
                    "|-_-_-|", 0)]

        [InlineData("|T_-_-|" +
                    "|-T-TT|" +
                    "|-_T_-|", 1.15)]

        // Several patterns

        [InlineData("|TTT_-|" +
                    "|-_-_-|" +
                    "|TTT_-|",2.3)]

        [InlineData("|TTT_-|" +
                    "|TTT_-|" +
                    "|TTT_-|", 10.35)]

        // ASymbol 
        [InlineData("|-_-_-|" +
                    "|A_-_A|" +
                    "|-AAA-|", 12.88)]

        [InlineData("|AAAA-|" +
                    "|-_-_-|" +
                    "|-_-_-|", 4.83)]

        [InlineData("|-_-_-|" +
                    "|A_A_-|" +
                    "|-A-_-|",1.61)]

        // QSymbol 
        [InlineData("|-Q-_-|" +
                    "|Q_Q_-|" +
                    "|-_-_-|", 1.38)]

        [InlineData("|-_Q_-|" +
                    "|-Q-Q-|" +
                    "|Q_-_Q|",11.04)]

        [InlineData("|-_-_-|" +
                    "|QQQQ-|" +
                    "|-_-_-|", 4.14)]

        // KSymbol 
        [InlineData("|-_-_-|" +
                    "|KKK_-|" +
                    "|-_-_-|", 1.38)]

        [InlineData("|K_-_K|" +
                    "|-K-K-|" +
                    "|-_K_-|",11.04)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|KKKK-|", 4.14)]

        // JSymbol
        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|JJJJ-|", 3.449999)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|JJJJJ|", 9.2)]

        [InlineData("|-_J_-|" +
                    "|-J-_-|" +
                    "|J_-_-|", 1.15)]
        // JoegiSymbol
        [InlineData("|-_-_-|" +
                    "|H_-_H|" +
                    "|-HHH-|",18.4)]

        [InlineData("|-_H_-|" +
                    "|-H-_-|" +
                    "|H_-_-|",2.3)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|HHHH-|", 6.899999)]
        // VincSymbol
        [InlineData("|-_-V-|" +
                    "|V_V_V|" +
                    "|-V-_-|", 23)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "VVVV-|", 8.625)]
        // SSymbol
        [InlineData("|-_-S-|" +
                    "|S_S_S|" +
                    "|-S-_-|", 27.6)]

        [InlineData("|S_-_-|" +
                    "|-S-_-|" +
                    "|-_S_-|", 3.449999)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|SSSS-|", 10.35)]
        // WildSymbol
        [InlineData("|-_-W-|" +
                    "|W_W_W|" +
                    "|-W-_-|", 34.5)]

        [InlineData("|-_-A-|" +
                    "|W_A_A|" +
                    "|-A-_-|", 12.88)]

        [InlineData("|-TTT-|" +
                    "|W_-_W|" +
                    "|-AAA-|", 22.08)]

        [InlineData("|-TTT-|" +
                    "|W_-_T|" +
                    "|-AAA-|", 9.2)]

        [InlineData("|-_-_-|" +
                    "|W_A_A|" +
                    "|-W-A-|", 12.88)]


        public void SlotAnalyzerShouldReturnCorrectMultiplierWhen(string inputPattern, double expected)
        {
            // Arrange
            var patternMatcher = this.kernel.Get<IPatternMatcher>();

            var testee = new SlotAnalyzer(patternMatcher);

            var symbols = SymbolTestHelper.SymbolsFromPattern(inputPattern);

            var input = new Slots(symbols);

            // Act
            var result = testee.Analyze(input);

            // Assert
            result.Multiplier.Should().BeApproximately(expected, 0.0001);
        }
    }
}
