namespace BookOfBruh.Core.Test.SlotAnalysation.PatternMatcherTests
{
    using System.Linq;
    using BookOfBruh.Core.SlotAnalysation.PatternMatchers;
    using FluentAssertions;
    using Xunit;
    using Helper;

    public class TrianglePatternMatcherTest
    {
        [Theory]

        [InlineData(
            "|P_P_-|" +
            "|-P-_-|" +
            "|-_-_-|",

            "|P_P_-|" +
            "|-P-_-|" +
            "|-_-_-|", 0, 1)]

        [InlineData(
            "|-_-_-|" +
            "|-P-_-|" +
            "|P_P_-|",

            "|-_-_-|" +
            "|-P-_-|" +
            "|P_P_-|", 0, -1)]

        [InlineData(
            "|-_-_-|" +
            "|P_P_-|" +
            "|-P-_-|",

            "|-_-_-|" +
            "|P_P_-|" +
            "|-P-_-|", 0, 1)]

        [InlineData(
            "|-P-_-|" +
            "|P_P_-|" +
            "|-_-_-|",

            "|-P-_-|" +
            "|P_P_-|" +
            "|-_-_-|", 0, -1)]

        [InlineData(
            "|-P-P-|" +
            "|-_P_-|" +
            "|-_-_-|",

            "|-P-P-|" +
            "|-_P_-|" +
            "|-_-_-|", 1, 1)]

        [InlineData(
            "|P_P_P|" +
            "|-P-P-|" +
            "|-_-_-|",

            "|P_P_P|" +
            "|-P-P-|" +
            "|-_-_-|", 0, 1)]

        [InlineData(
            "|-_-_-|" +
            "|-P-P-|" +
            "|P_P_P|",

            "|-_-_-|" +
            "|-P-P-|" +
            "|P_P_P|", 0, -1)]

        [InlineData(
            "|-_-_-|" +
            "|P_P_P|" +
            "|-P-P-|",

            "|-_-_-|" +
            "|P_P_P|" +
            "|-P-P-|", 0, 1)]

        [InlineData(
            "|-P-P-|" +
            "|P_P_P|" +
            "|-_-_-|",

            "|-P-P-|" +
            "|P_P_P|" +
            "|-_-_-|", 0, -1)]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenCorrectPattern(string inputString, string expectedString, int position, int direction)
        {
            // Arrange
            ITrianglePatternMatcher testee = new TrianglePatternMatcher();

            var input = PatternTestHelper.PointsFromString(inputString);

            var expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            var result = testee.FindMatchesAt(position, direction, input.OrderBy(p => p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]

        [InlineData("|P_P_-|" +
                    "|-P-_-|" +
                    "|-_-_-|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|-_-_-|", 0, -1)]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenIncorrectPattern(string inputString, string expectedString, int position, int direction)
        {
            // Arrange
            ITrianglePatternMatcher testee = new TrianglePatternMatcher();

            var input = PatternTestHelper.PointsFromString(inputString);

            var expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            var result = testee.FindMatchesAt(position, direction, input.OrderBy(p => p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

    }
}
