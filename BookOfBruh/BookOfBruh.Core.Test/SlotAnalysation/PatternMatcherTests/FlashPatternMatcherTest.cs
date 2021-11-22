namespace BookOfBruh.Core.Test.SlotAnalysation.PatternMatcherTests
{
    using Helper;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using BookOfBruh.Core.SlotAnalysation.PatternMatchers;
    using FluentAssertions;
    using Xunit;

    public class FlashPatternMatcherTest
    {
        [Theory]

        [InlineData("|-P-_-|" +
                    "|P_P_P|" +
                    "|-_-P-|",

            "|-P-_-|" +
            "|P_P_P|" +
            "|-_-P-|",

            "|-P-_-|" +
            "|P_P_-|" +
            "|-_-_-|",

            "|-_-_-|" +
            "|-_P_P|" +
            "|-_-P-|", -1)]

        [InlineData("|-_-P-|" +
                    "|P_P_P|" +
                    "|-P-_-|",

            "|-_-P-|" +
            "|P_P_P|" +
            "|-P-_-|",

            "|-_-_-|" +
            "|P_P_-|" +
            "|-P-_-|",

            "|-_-P-|" +
            "|-_P_P|" +
            "|-_-_-|", 1)]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenCorrectPattern(string inputString, string expectedString, string firstTriangle, string secondTriangle, int direction)
        {
            // Arrange
            IFlashPatternMatcher testee = new FlashPatternMatcher(new FakeTrianglePattern(PatternTestHelper.PointsFromString(firstTriangle), PatternTestHelper.PointsFromString(secondTriangle)));

            List<Point> input = PatternTestHelper.PointsFromString(inputString);

            List<Point> expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            List<Point> result = testee.FindMatches(direction, input.OrderBy(p => p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }

    public class FakeTrianglePattern : ITrianglePatternMatcher
    {
        private readonly List<Point> first;
        private readonly List<Point> second;

        public FakeTrianglePattern(List<Point> first, List<Point> second)
        {
            this.first = first;
            this.second = second;
        }

        public List<Point> FindMatchesAt(int position, int direction, List<Point> input)
        {
            return position == 0 ? this.first : this.second;
        }
    }
}
