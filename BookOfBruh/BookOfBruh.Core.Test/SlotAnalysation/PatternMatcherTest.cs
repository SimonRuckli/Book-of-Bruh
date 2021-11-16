namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using Xunit;
    using FluentAssertions;
    using BookOfBruh.Core.SlotAnalysation;
    using System.Collections.Generic;
    using System.Drawing;

    public class PatternMatcherTest
    {
        [Theory]
        
        [InlineData("|PPP_-|" +
                    "|-_-_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|PPP_-|" +
                "|-_-_-|" +
                "|-_-_-|"
            })]

        [InlineData("|PPP_-|" +
                    "|-_-P-|" +
                    "|-_-_-|",
            new string[]
            {
                "|PPP_-|" +
                "|-_-_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-P-|" +
                    "|PPP_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|-_-_-|" +
                "|PPP_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|PPP_P|" +
                    "|-_-_-|",
            new string[]
            {
                "|-_-_-|" +
                "|PPP_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-P-_-|" +
                    "|P_P_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|-P-_-|" +
                "|P_P_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-P-_-|" +
                    "|PPP_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|-P-_-|" +
                "|P_P_-|" +
                "|-_-_-|",

                "|-_-_-|" +
                "|PPP_-|" +
                "|-_-_-|",
            })]

        [InlineData("|-P-P-|" +
                    "|PPP_P|" +
                    "|-_-_-|",
            new string[]
            {
                "|-P-P-|" +
                "|P_P_P|" +
                "|-_-_-|",

                "|-_-_-|" +
                "|PPP_-|" +
                "|-_-_-|",
            })]

        [InlineData("|-_-_-|" +
                    "|PPP_P|" +
                    "|-P-P-|",
            new string[]
            {
                "|-_-_-|" +
                "|P_P_P|" +
                "|-P-P-|",

                "|-_-_-|" +
                "|PPP_-|" +
                "|-_-_-|",
            })]

        [InlineData("|-P-_-|" +
                    "|P-P_P|" +
                    "|-P-P-|",
            new string[]
            {
                "|-_-_-|" +
                "|P_P_P|" +
                "|-P-P-|",

                "|-P-_-|" +
                "|P_P_-|" +
                "|-_-_-|",
            })]

        [InlineData("|-_-P-|" +
                    "|P_P_P|" +
                    "|-P-_-|",
            new string[]
            {
                "|-_-P-|" +
                "|P_P_P|" +
                "|-P-_-|",
            })]

        [InlineData("|P_-_-|" +
                    "|-P-_-|" +
                    "|-_P_-|",
            new string[]
            {
                "|P_-_-|" +
                "|-P-_-|" +
                "|-_P_-|",
            })]

        [InlineData("|P_-_-|" +
                    "|-P-P-|" +
                    "|-_P_-|",
            new string[]
            {
                "|P_-_-|" +
                "|-P-_-|" +
                "|-_P_-|",
            })]

        [InlineData("|P_-_P|" +
                    "|-P-P-|" +
                    "|-_P_-|",
            new string[]
            {
                "|P_-_P|" +
                "|-P-P-|" +
                "|-_P_-|",
            })]

        public void PatternMatcherShould(string input, string[] patterns)
        {
            // Arrange
            List<Point> pointList = PatternTestHelper.PointsFromString(input);
            List<Pattern> expected = PatternTestHelper.PatternsFromStringPatterns(patterns);
            
            PatternMatcher testee = new PatternMatcher();

            // Act
            List<Pattern> result = testee.FindMatches(pointList);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
