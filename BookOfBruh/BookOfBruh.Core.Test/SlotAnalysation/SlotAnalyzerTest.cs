using System.Collections.Generic;
using System.Drawing;

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
                    , 6)]

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
                    , 6)]

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
                    , 6)]

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


        public void SlotAnalyzerShouldReturnCorrectMultiplierWhen(string pattern, string[] stringPatterns, int expected)
        {
            // Arrange
            List<Pattern> patterns = PatternTestHelper.PatternsFromStringPatterns(stringPatterns);
            IPatternMatcher patternMatcher = new FakePatternMatcher(patterns);

            SlotAnalyzer testee = new SlotAnalyzer(patternMatcher);

            ISymbol[,] symbols = SymbolTestHelper.SymbolsFromPattern(pattern);

            Slots input = new Slots(symbols);

            // Act
            double result = testee.Analyze(input);

            // Assert
            result.Should().Be(expected);
        }

        internal class FakePatternMatcher : IPatternMatcher
        {
            private readonly List<Pattern> patterns;

            public FakePatternMatcher(List<Pattern> patterns)
            {
                this.patterns = patterns;
            }

            public List<Pattern> FindMatches(List<Point> input)
            {
                return this.patterns;
            }
        }

        /*
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
        */
    }
}
