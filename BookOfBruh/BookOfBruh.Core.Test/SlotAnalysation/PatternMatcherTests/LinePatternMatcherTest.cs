namespace BookOfBruh.Core.Test.SlotAnalysation.PatternMatcherTests
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using BookOfBruh.Core.SlotAnalysation.PatternMatchers;
    using FluentAssertions;
    using Xunit;

    public class LinePatternMatcherTest
    {
        [Theory]

        [InlineData("|PPP_-|" +
                    "|-_-_-|" +
                    "|-_-_-|",

            "|PPP_-|" +
            "|-_-_-|" +
            "|-_-_-|", 0)]

        [InlineData("|PPPP-|" +
                    "|-_-_-|" +
                    "|-_-_-|",

            "|PPPP-|" +
            "|-_-_-|" +
            "|-_-_-|", 0)]

        [InlineData("|PPPPP|" +
                    "|-_-_-|" +
                    "|-_-_-|",

            "|PPPPP|" +
            "|-_-_-|" +
            "|-_-_-|", 0)]

        [InlineData("|-_-_-|" +
                    "|PPP_-|" +
                    "|-_-_-|",

            "|-_-_-|" +
            "|PPP_-|" +
            "|-_-_-|", 0)]

        [InlineData("|-_-_-|" +
                    "|PPPP-|" +
                    "|-_-_-|",

            "|-_-_-|" +
            "|PPPP-|" +
            "|-_-_-|", 0)]

        [InlineData("|-_-_-|" +
                    "|PPPPP|" +
                    "|-_-_-|",

            "|-_-_-|" +
            "|PPPPP|" +
            "|-_-_-|", 0)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|PPP_-|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|PPP_-|", 0)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|PPPP-|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|PPPP-|", 0)]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|PPPPP|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|PPPPP|", 0)]


        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|-PPP-|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|-PPP-|", 1)]


        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|-PPPP|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|-PPPP|", 1)]


        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|-_PPP|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|-_PPP|", 2)]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenCorrectPattern(string inputString, string expectedString, int startPosition)
        {
            // Arrange
            ILinePatternMatcher testee = new LinePatternMatcher();

            List<Point> input = PatternTestHelper.PointsFromString(inputString);

            List<Point> expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            List<Point> result = testee.FindMatchesAt(startPosition, input.OrderBy(p => p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }  
        
        [Theory]

        [InlineData("|-_-_-|" +
                    "|-_-P-|" +
                    "|-PPPP|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|-PPPP|", 1)]


        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|-_PP-|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|-_-_-|", 2)]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenIncorrectPattern(string inputString, string expectedString, int startPosition)
        {
            // Arrange
            ILinePatternMatcher testee = new LinePatternMatcher();

            List<Point> input = PatternTestHelper.PointsFromString(inputString);

            List<Point> expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            List<Point> result = testee.FindMatchesAt(startPosition, input.OrderBy(p => p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
