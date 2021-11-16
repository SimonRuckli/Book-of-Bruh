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

        [InlineData("|-P-_-|" +
                    "|P_P_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|-P-_-|" +
                "|P_P_-|" +
                "|-_-_-|"
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
