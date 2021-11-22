using BookOfBruh.Core.Test.Helper;

namespace BookOfBruh.Core.Test.SlotAnalysation.PatternMatcherTests
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using BookOfBruh.Core.SlotAnalysation.PatternMatchers;
    using FluentAssertions;
    using Xunit;

    public class UPatternMatcherTest
    {

        [Theory]
        [InlineData("|P_-_P|" +
                    "|-PPP-|" +
                    "|-_-_-|",

            "|P_-_P|" +
            "|-PPP-|" +
            "|-_-_-|",

            "|-_-_-|" +
            "|-PPP-|" +
            "|-_-_-|", 1)]

        [InlineData("|-_-_-|" +
                    "|-PPP-|" +
                    "|P_-_P|",

            "|-_-_-|" +
            "|-PPP-|" +
            "|P_-_P|",

            "|-_-_-|" +
            "|-PPP-|" +
            "|-_-_-|", -1)]

        [InlineData("|-_-_-|" +
                    "|P_-_P|" +
                    "|-PPP-|",

            "|-_-_-|" +
            "|P_-_P|" +
            "|-PPP-|",

            "|-_-_-|" +
            "|-_-_-|" +
            "|-PPP-|", 1)]

        [InlineData("|-PPP-|" +
                    "|P_-_P|" +
                    "|-_-_-|",

            "|-PPP-|" +
            "|P_-_P|" +
            "|-_-_-|",

            "|-PPP-|" +
            "|-_-_-|" +
            "|-_-_-|", -1)]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenCorrectPattern(string inputString, string expectedString, string linePatternString, int direction)
        {
            // Arrange
            IUPatternMatcher testee = new UPatternMatcher(new FakeLinePattern(PatternTestHelper.PointsFromString(linePatternString)));

            List<Point> input = PatternTestHelper.PointsFromString(inputString);

            List<Point> expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            List<Point> result = testee.FindMatches(direction, input.OrderBy(p => p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }   
        
        [Theory]

        [InlineData("|-PPP-|" +
                    "|PP-_P|" +
                    "|-_-_-|",

            "|-PPP-|" +
            "|P_-_P|" +
            "|-_-_-|",

            "|-PPP-|" +
            "|-_-_-|" +
            "|-_-_-|", -1)]

        public void DiagonalPatternMatcherShouldReturnCorrectPatternWhenIncorrectPattern(string inputString, string expectedString, string linePatternString, int direction)
        {
            // Arrange
            IUPatternMatcher testee = new UPatternMatcher(new FakeLinePattern(PatternTestHelper.PointsFromString(linePatternString)));

            List<Point> input = PatternTestHelper.PointsFromString(inputString);

            List<Point> expected = PatternTestHelper.PointsFromString(expectedString);

            // Act
            List<Point> result = testee.FindMatches(direction, input.OrderBy(p => p.X).ToList());

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }

    public class FakeLinePattern : ILinePatternMatcher
    {
        private readonly List<Point> pointsFromString;

        public FakeLinePattern(List<Point> pointsFromString)
        {
            this.pointsFromString = pointsFromString;
        }

        public List<Point> FindMatchesAt(int position, List<Point> input)
        {
            return this.pointsFromString;
        }
    }
}
