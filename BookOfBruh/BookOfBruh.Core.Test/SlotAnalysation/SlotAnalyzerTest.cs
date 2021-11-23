namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using Helper;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Xunit;
    using FluentAssertions;
    using BookOfBruh.Core.SlotAnalysation;
    using GameData;
    using Symbols;

    public class SlotAnalyzerTest
    {
        [Theory]

        // All valid patterns

        [InlineData("|TTT_-|" +
                    "|-_-_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|PPP_-|" +
                        "|-_-_-|" +
                        "|-_-_-|"
                    }
                    , 3)]

        [InlineData("|TTTT-|" +
                    "|-_-_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|PPPP-|" +
                        "|-_-_-|" +
                        "|-_-_-|"
                    }
                    , 9)]

        [InlineData("|TTTTT|" +
                    "|-_-_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|PPPPP|" +
                        "|-_-_-|" +
                        "|-_-_-|"
                    }
                    , 24)]
       
        [InlineData("|T_-_-|" +
                    "|-T-_-|" +
                    "|-_T_-|",
                    new string[]
                    {
                        "|P_-_-|" +
                        "|-P-_-|" +
                        "|-_P_-|"
                    }
                    , 3)]
       
        [InlineData("|T_T_-|" +
                    "|-T-_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|P_P_-|" +
                        "|-P-_-|" +
                        "|-_-_-|"
                    }
                    , 3)]
       
        [InlineData("|T_T_T|" +
                    "|-T-T-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|P_P_P|" +
                        "|-P-P-|" +
                        "|-_-_-|"
                    }
                    , 24)]
       
        [InlineData("|T_-_T|" +
                    "|-TTT-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|P_-_P|" +
                        "|-PPP-|" +
                        "|-_-_-|"
                    }
                    , 24)]
       
        [InlineData("|T_-_T|" +
                    "|-T-T-|" +
                    "|-_T_-|",
                    new string[]
                    {
                        "|P_-_P|" +
                        "|-P-P-|" +
                        "|-_P_-|"
                    }
                    , 24)]
       
        [InlineData("|-_-_-|" +
                    "|TTT_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|PPP_-|" +
                        "|-_-_-|"
                    }
                    , 3)]

        [InlineData("|-_-_-|" +
                    "|TTTT-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|PPPP-|" +
                        "|-_-_-|"
                    }
                    , 9)]

        [InlineData("|-_-_-|" +
                    "|TTTTT|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|PPPPP|" +
                        "|-_-_-|"
                    }
                    , 24)]

        [InlineData("|-T-_-|" +
                    "|T_T_T|" +
                    "|-_-T-|",
                    new string[]
                    {
                        "|-P-_-|" +
                        "|P_P_P|" +
                        "|-_-P-|"
                    }
                    , 24)]

        [InlineData("|-_-T-|" +
                    "|T_T_T|" +
                    "|-T-_-|",
                    new string[]
                    {
                        "|-_-P-|" +
                        "|P_P_P|" +
                        "|-P-_-|"
                    }
                    , 24)]

        [InlineData("|-_-_-|" +
                    "|T_T_T|" +
                    "|-T-T-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|P_P_P|" +
                        "|-P-P-|"
                    }
                    , 24)]

        [InlineData("|-T-T-|" +
                    "|T_T_T|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-P-P-|" +
                        "|P_P_P|" +
                        "|-_-_-|"
                    }
                    , 24)]

        [InlineData("|-_-_-|" +
                    "|T_-_T|" +
                    "|-TTT-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|P_-_P|" +
                        "|-PPP-|"
                    }
                    , 24)]

        [InlineData("|-TTT-|" +
                    "|T_-_T|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-PPP-|" +
                        "|P_-_P|" +
                        "|-_-_-|"
                    }
                    , 24)]

        [InlineData("|-_-_-|" +
                    "|T_T_-|" +
                    "|-T-_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|P_P_-|" +
                        "|-P-_-|"
                    }
                    , 3)]

        [InlineData("|-T-_-|" +
                    "|T-T_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-P-_-|" +
                        "|P_P_-|" +
                        "|-_-_-|"
                    }
                    , 3)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTT_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPP_-|"
                    }
                    , 3)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTTT-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPPP-|"
                    }
                    , 9)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|TTTTT|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPPPP|"
                    }
                    , 24)]

        [InlineData("|-_T_-|" +
                    "|-T-_-|" +
                    "|T_-_-|",
                    new string[]
                    {
                        "|-_P_-|" +
                        "|-P-_-|" +
                        "|P_-_-|"
                    }
                    , 3)]

        [InlineData("|-_-_-|" +
                    "|-T-_-|" +
                    "|T_T_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-P-_-|" +
                        "|P_P_-|"
                    }
                    , 3)]

        [InlineData("|-_-_-|" +
                    "|-T-T-|" +
                    "|T_T_T|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-P-P-|" +
                        "|P_P_P|"
                    }
                    , 24)]

        [InlineData("|-_-_-|" +
                    "|-TTT-|" +
                    "|T_-_T|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-PPP-|" +
                        "|P_-_P|"
                    }
                    , 24)]

        [InlineData("|-_T_-|" +
                    "|-T-T-|" +
                    "|T_-_T|", 
                    new string[]
                    {
                        "|-_P_-|" +
                        "|-P-P-|" +
                        "|P_-_P|"
                    } 
                    , 24)]

        // Invalid patterns

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|-_-_-|",
                new string[]
                {
                    "|-_-_-|" +
                    "|-_-_-|" +
                    "|-_-_-|"
                }
                , 0)]

        [InlineData("|TT-_-|" +
                    "|-_T_-|" +
                    "|-_-_-|",
                new string[]
                {
                    "|-_-_-|" +
                    "|-_-_-|" +
                    "|-_-_-|"
                }
                , 0)]

        [InlineData("|T_-_-|" +
                    "|-T-TT|" +
                    "|-_T_-|",
                new string[]
                {
                    "|P_-_-|" +
                    "|-P-_-|" +
                    "|-_P_-|"
                }
                , 3)]

        // Several patterns

        [InlineData("|TTT_-|" +
                    "|-_-_-|" +
                    "|TTT_-|",
                new string[]
                {
                    "|PPP_-|" +
                    "|-_-_-|" +
                    "|-_-_-|",

                    "|-_-_-|" +
                    "|-_-_-|" +
                    "|PPP_-|",
                }
                , 6)]

        [InlineData("|TTT_-|" +
                    "|TTT_-|" +
                    "|TTT_-|",
                new string[]
                {
                    "|PPP_-|" +
                    "|-_-_-|" +
                    "|-_-_-|",

                    "|P-P_-|" +
                    "|-P-_-|" +
                    "|-_-_-|",

                    "|P_-_-|" +
                    "|-P-_-|" +
                    "|--P_-|",

                    "|-_-_-|" +
                    "|PPP_-|" +
                    "|-_-_-|",

                    "|-P-_-|" +
                    "|P-P_-|" +
                    "|-_-_-|",

                    "|-_-_-|" +
                    "|P-P_-|" +
                    "|-P-_-|",

                    "|-_-_-|" +
                    "|-_-_-|" +
                    "|PPP_-|",

                    "|-_-_-|" +
                    "|-P-_-|" +
                    "|P-P_-|",

                    "|-_P_-|" +
                    "|-P-_-|" +
                    "|P--_-|"
                }
                , 27)]

        // ASymbol 
        [InlineData("|-_-_-|" +
                    "|A_-_A|" +
                    "|-AAA-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|P_-_P|" +
                        "|-PPP-|"
                    }
                    , 33.6)]

        [InlineData("|AAAA-|" +
                    "|-_-_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|PPPP-|" +
                        "|-_-_-|" +
                        "|-_-_-|"
                    }
                    , 12.6)]

        [InlineData("|-_-_-|" +
                    "|A_A_-|" +
                    "|-A-_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|P_P_-|" +
                        "|-P-_-|"
                    }
                    , 4.2)]

        // QSymbol 
        [InlineData("|-Q-_-|" +
                    "|Q_Q_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-P-_-|" +
                        "|P_P_-|" +
                        "|-_-_-|"
                    }
                    , 3.6)]
        [InlineData("|-_Q_-|" +
                    "|-Q-Q-|" +
                    "|Q_-_Q|",
                    new string[]
                    {
                        "|-_P_-|" +
                        "|-P-P-|" +
                        "|P_-_P|"
                    }
                    , 28.8)]
        [InlineData("|-_-_-|" +
                    "|QQQQ-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|PPPP-|" +
                        "|-_-_-|"
                    }
                    , 10.8)]

        // KSymbol 
        [InlineData("|-_-_-|" +
                    "|KKK_-|" +
                    "|-_-_-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|PPP_-|" +
                        "|-_-_-|"
                    }
                    , 3.6)]
        [InlineData("|K_-_K|" +
                    "|-K-K-|" +
                    "|-_K_-|",
                    new string[]
                    {
                        "|P_-_P|" +
                        "|-P-P-|" +
                        "|-_P_-|"
                    }
                    , 28.8)]
        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|KKKK-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPPP-|"
                    }
                    , 10.8)]
        // JSymbol
        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|JJJJ-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPPP-|"
                    }
                    , 9)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|JJJJJ|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPPPP|"
                    }
                    , 24)]

        [InlineData("|-_J_-|" +
                    "|-J-_-|" +
                    "|J_-_-|",
                    new string[]
                    {
                        "|-_P_-|" +
                        "|-P-_-|" +
                        "|P_-_-|"
                    }
                    , 3)]
        // JoegiSymbol
        [InlineData("|-_-_-|" +
                    "|H_-_H|" +
                    "|-HHH-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|P_-_P|" +
                        "|-PPP-|"
                    }
                    , 48)]

        [InlineData("|-_H_-|" +
                    "|-H-_-|" +
                    "|H_-_-|",
                    new string[]
                    {
                        "|-_P_-|" +
                        "|-P-_-|" +
                        "|P_-_-|"
                    }
                    , 6)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|HHHH-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPPP-|"
                    }
                    , 18)]
        // VincSymbol
        [InlineData("|-_-V-|" +
                    "|V_V_V|" +
                    "|-V-_-|",
                    new string[]
                    {
                        "|-_-P-|" +
                        "|P_P_P|" +
                        "|-P-_-|"
                    }
                    , 60)]

        [InlineData("|V_-_-|" +
                    "|-V-_-|" +
                    "|-_V_-|",
                    new string[]
                    {
                        "|P_-_-|" +
                        "|-P-_-|" +
                        "|-_P_-|"
                    }
                    , 7.5)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|VVVV-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPPP-|"
                    }
                    , 22.5)]
        // SSymbol
        [InlineData("|-_-S-|" +
                    "|S_S_S|" +
                    "|-S-_-|",
                    new string[]
                    {
                        "|-_-P-|" +
                        "|P_P_P|" +
                        "|-P-_-|"
                    }
                    , 72)]

        [InlineData("|S_-_-|" +
                    "|-S-_-|" +
                    "|-_S_-|",
                    new string[]
                    {
                        "|P_-_-|" +
                        "|-P-_-|" +
                        "|-_P_-|"
                    }
                    , 9)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|SSSS-|",
                    new string[]
                    {
                        "|-_-_-|" +
                        "|-_-_-|" +
                        "|PPPP-|"
                    }
                    , 27)]
        // WildSymbol
        [InlineData("|-_-W-|" +
                    "|W_W_W|" +
                    "|-W-_-|",
                    new string[]
                    {
                        "|-_-P-|" +
                        "|P_P_P|" +
                        "|-P-_-|"
                    }
                    , 90)]
        
        [InlineData("|-_-A-|" +
                    "|W_A_A|" +
                    "|-A-_-|",
                    new string[]
                    {
                        "|-_-P-|" +
                        "|P_P_P|" +
                        "|-P-_-|"
                    }
                    , 33.6)]
        
        [InlineData("|-TTT-|" +
                    "|W_-_W|" +
                    "|-AAA-|",
                    new string[]
                    { 
                        "|-PPP-|" +
                        "|P_-_P|" +
                        "|-_-_-|",

                        "|-_-_-|" +
                        "|P_-_P|" +
                        "|-PPP-|",
                    }
                    , 57.6)]


        public void SlotAnalyzerShouldReturnCorrectMultiplierWhen(string inputPattern, string[] stringPatterns, double expected)
        {
            // Arrange
            List<Pattern> patterns = PatternTestHelper.PatternsFromStringPatterns(stringPatterns);
            IPatternMatcher patternMatcher = new FakePatternMatcher(patterns);

            SlotAnalyzer testee = new SlotAnalyzer(patternMatcher);

            ISymbol[,] symbols = SymbolTestHelper.SymbolsFromPattern(inputPattern);

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().BeApproximately(expected, 0.0001);
        }

        internal class FakePatternMatcher : IPatternMatcher
        {
            private readonly List<Pattern> patterns = new List<Pattern>();

            public FakePatternMatcher(List<Pattern> patterns)
            {
                foreach (Pattern pattern in patterns)
                {
                    this.patterns.Add(new Pattern(pattern.Value.OrderBy(p => p.X).ToList()));
                }
            }

            public List<Pattern> FindMatches(List<Point> input)
            {
                List<Point> orderedInput = input.OrderBy(p => p.X).ToList();
                if (this.patterns.Count > 1)
                {
                    List<Pattern> matching = new List<Pattern>();

                    foreach (Pattern pattern in this.patterns)
                    {
                        List<Point> test = pattern.Value.Where(point => orderedInput.Contains(point)).ToList();
                        if (pattern.Value.SequenceEqual(test))
                        {
                            matching.Add(pattern);
                        }
                    }
                    return matching;
                }
                return this.patterns;
            }
        }
    }
}
