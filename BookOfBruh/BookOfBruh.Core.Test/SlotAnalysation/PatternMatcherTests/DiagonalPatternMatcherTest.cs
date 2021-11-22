namespace BookOfBruh.Core.Test.SlotAnalysation.PatternMatcherTests
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using BookOfBruh.Core.SlotAnalysation.PatternMatchers;
    using FluentAssertions;
    using Xunit;
    using Helper;


    public class DiagonalPatternMatcherTest
    {
        [Theory]
        [InlineData("|P_-_-|" +
                    "|-P-_-|" +
                    "|-_P_-|",

                    "|P_-_-|" +
                    "|-P-_-|" +
                    "|-_P_-|")]

        [InlineData("|-_P_-|" +
                    "|-P-_-|" +
                    "|P_-_-|",

                    "|-_P_-|" +
                    "|-P-_-|" +
                    "|P_-_-|")]

        [InlineData("|P_-_P|" +
                    "|-P-P-|" +
                    "|-_P_-|",

                    "|P_-_P|" +
                    "|-P-P-|" +
                    "|-_P_-|")]

        [InlineData("|-_P_-|" +
                    "|-P-P-|" +
                    "|P_-_P|",

                    "|-_P_-|" +
                    "|-P-P-|" +
                    "|P_-_P|")]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenCorrectPattern(string inputString, string expectedString)
        {
            // Arrange
            IDiagonalPatternMatcher testee = new DiagonalPatternMatcher();

            List<Point> input = PatternTestHelper.PointsFromString(inputString);

            List<Point> expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            List<Point> result = testee.FindMatches(input.OrderBy(p=>p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("|P_-_-|" +
                    "|-P-P-|" +
                    "|-_P_-|",

                    "|P_-_-|" +
                    "|-P-_-|" +
                    "|-_P_-|")]

        [InlineData("|-_P_-|" +
                    "|-P-_-|" +
                    "|PP-_-|",

                    "|-_P_-|" +
                    "|-P-_-|" +
                    "|P_-_-|")]

        [InlineData("|P_-_P|" +
                    "|-P-PP|" +
                    "|-_P_-|",

                    "|P_-_P|" +
                    "|-P-P-|" +
                    "|-_P_-|")]

        [InlineData("|-_P_-|" +
                    "|-P-P-|" +
                    "|P_P_P|",

                    "|-_P_-|" +
                    "|-P-P-|" +
                    "|P_-_P|")]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenIncorrectPattern(string inputString, string expectedString)
        {
            // Arrange
            IDiagonalPatternMatcher testee = new DiagonalPatternMatcher();

            List<Point> input = PatternTestHelper.PointsFromString(inputString);

            List<Point> expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            List<Point> result = testee.FindMatches(input.OrderBy(p=>p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
