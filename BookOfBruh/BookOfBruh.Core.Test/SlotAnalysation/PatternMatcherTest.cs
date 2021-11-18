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
        
        // Find single Correct Pattern

        [InlineData("|PPP_-|" +
                    "|-_-_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|PPP_-|" +
                "|-_-_-|" +
                "|-_-_-|"
            })]

        [InlineData("|PPPP-|" +
                    "|-_-_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|PPPP-|" +
                "|-_-_-|" +
                "|-_-_-|"
            })]

        [InlineData("|PPPPP|" +
                    "|-_-_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|PPPPP|" +
                "|-_-_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|PPP_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|-_-_-|" +
                "|PPP_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|PPPP-|" +
                    "|-_-_-|",
            new string[]
            {
                "|-_-_-|" +
                "|PPPP-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|PPPPP|" +
                    "|-_-_-|",
            new string[]
            {
                "|-_-_-|" +
                "|PPPPP|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|PPP_-|",
            new string[]
            {
                "|-_-_-|" +
                "|-_-_-|" +
                "|PPP_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|PPPP-|",
            new string[]
            {
                "|-_-_-|" +
                "|-_-_-|" +
                "|PPPP-|"
            })]

        [InlineData("|-_-_-|" +
                    "|-_-_-|" +
                    "|PPPPP|",
            new string[]
            {
                "|-_-_-|" +
                "|-_-_-|" +
                "|PPPPP|"
            })]

        [InlineData("|P_P_-|" +
                    "|-P-_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|P_P_-|" +
                "|-P-_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|P_P_-|" +
                    "|-P-_-|",
            new string[]
            {
                "|-_-_-|" +
                "|P_P_-|" +
                "|-P-_-|"
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

        [InlineData("|-_-_-|" +
                    "|-P-_-|" +
                    "|P_P_-|",
            new string[]
            {
                "|-_-_-|" +
                "|-P-_-|" +
                "|P_P_-|"
            })]

        [InlineData("|P_P_P|" +
                    "|-P-P-|" +
                    "|-_-_-|",
            new string[]
            {
                "|P_P_P|" +
                "|-P-P-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|P_P_P|" +
                    "|-P-P-|",
            new string[]
            {
                "|-_-_-|" +
                "|P_P_P|" +
                "|-P-P-|"
            })]

        [InlineData("|-P-P-|" +
                    "|P_P_P|" +
                    "|-_-_-|",
            new string[]
            {
                "|-P-P-|" +
                "|P_P_P|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|-P-P-|" +
                    "|P_P_P|",
            new string[]
            {
                "|-_-_-|" +
                "|-P-P-|" +
                "|P_P_P|"
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

        [InlineData("|-_P_-|" +
                    "|-P-_-|" +
                    "|P_-_-|",
            new string[]
            {
                "|-_P_-|" +
                "|-P-_-|" +
                "|P_-_-|",
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

        [InlineData("|-_P_-|" +
                    "|-P-P-|" +
                    "|P_-_P|",
            new string[]
            {
                "|-_P_-|" +
                "|-P-P-|" +
                "|P_-_P|",
            })]

        [InlineData("|P_-_P|" +
                    "|-PPP-|" +
                    "|-_-_-|",
            new string[]
            {
                "|P_-_P|" +
                "|-PPP-|" +
                "|-_-_-|",
            })]

        [InlineData("|-_-_-|" +
                    "|P_-_P|" +
                    "|-PPP-|",
            new string[]
            {
                "|-_-_-|" +
                "|P_-_P|" +
                "|-PPP-|",
            })]

        [InlineData("|-_-_-|" +
                    "|-PPP-|" +
                    "|P_-_P|",
            new string[]
            {
                "|-_-_-|" +
                "|-PPP-|" +
                "|P_-_P|",
            })]

        [InlineData("|-PPP-|" +
                    "|P_-_P|" +
                    "|-_-_-|",
            new string[]
            {
                "|-PPP-|" +
                "|P_-_P|" +
                "|-_-_-|",
            })]

        [InlineData("|-P-_-|" +
                    "|P_P_P|" +
                    "|-_-P-|",
            new string[]
            {
                "|-P-_-|" +
                "|P_P_P|" +
                "|-_-P-|",
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
        

        public void PatternMatcherShouldReturnCorrectSinglePattern(string input, string[] patterns)
        {
            // Arrange
            List<Point> pointList = PatternTestHelper.PointsFromString(input);
            List<Pattern> expected = PatternTestHelper.PatternsFromStringPatterns(patterns);
            
            IPatternMatcher testee = new PatternMatcher(
                new LinePatternMatcher(),
                new TrianglePatternMatcher(),
                new DiagonalPatternMatcher(),
                new UPatternMatcher(new LinePatternMatcher()));

            // Act
            List<Pattern> result = testee.FindMatches(pointList);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]

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

        [InlineData("|P_-_-|" +
                    "|-P-P-|" +
                    "|-_P_-|",
            new string[]
            {
                "|P_-_-|" +
                "|-P-_-|" +
                "|-_P_-|",
            })]

        [InlineData("|P_P_-|" +
                    "|-P-P-|" +
                    "|-_-_-|",
            new string[]
            {
                "|P_P_-|" +
                "|-P-_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|P_P_-|" +
                    "|-P-P-|",
            new string[]
            {
                "|-_-_-|" +
                "|P_P_-|" +
                "|-P-_-|"
            })]

        [InlineData("|-P-P-|" +
                    "|P_P_-|" +
                    "|-_-_-|",
            new string[]
            {
                "|-P-_-|" +
                "|P_P_-|" +
                "|-_-_-|"
            })]

        [InlineData("|-_-_-|" +
                    "|-P-P-|" +
                    "|P_P_-|",
            new string[]
            {
                "|-_-_-|" +
                "|-P-_-|" +
                "|P_P_-|"
            })]

        [InlineData("|P_-_P|" +
                    "|-PPPP|" +
                    "|-_-_-|",
            new string[]
            {
                "|P_-_P|" +
                "|-PPP-|" +
                "|-_-_-|"
            })]

        [InlineData("|P_-_P|" +
                    "|-PP_-|" +
                    "|-_-_-|",
            new string[]
            {
            })]

        public void PatternMatcherShouldReturnIncorrectSinglePattern(string input, string[] patterns)
        {
            // Arrange
            List<Point> pointList = PatternTestHelper.PointsFromString(input);
            List<Pattern> expected = PatternTestHelper.PatternsFromStringPatterns(patterns);

            IPatternMatcher testee = new PatternMatcher(
                new LinePatternMatcher(),
                new TrianglePatternMatcher(),
                new DiagonalPatternMatcher(),
                new UPatternMatcher(new LinePatternMatcher()));

            // Act
            List<Pattern> result = testee.FindMatches(pointList);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]

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

        [InlineData("|-P-_-|" +
                    "|P-P_P|" +
                    "|-P-P-|",
         new string[]
         {
                "|-_-_-|" +
                "|P_P_P|" +
                "|-P-P-|",

                "|-P-_-|" +
                "|P_P_P|" +
                "|-_-P-|",
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

        [InlineData("|-P-P-|" +
                    "|P_P_P|" +
                    "|-P-P-|",
         new string[]
         {
                "|-_-_-|" +
                "|P_P_P|" +
                "|-P-P-|",

                "|-P-P-|" +
                "|P_P_P|" +
                "|-_-_-|",

                "|-P-_-|" +
                "|P_P_P|" +
                "|-_-P-|",

                "|-_-P-|" +
                "|P_P_P|" +
                "|-P-_-|",
         })]

        [InlineData("|-P-_-|" +
                    "|P_P_-|" +
                    "|-P-_-|",
         new string[]
         {
                "|-_-_-|" +
                "|P_P_-|" +
                "|-P-_-|",

                "|-P-_-|" +
                "|P_P_-|" +
                "|-_-_-|",
         })]

        [InlineData("|-P-_-|" +
                    "|PPPPP|" +
                    "|-P-_-|",
         new string[]
         {
                "|-_-_-|" +
                "|P_P_-|" +
                "|-P-_-|",

                "|-P-_-|" +
                "|P_P_-|" +
                "|-_-_-|",

                "|-_-_-|" +
                "|PPPPP|" +
                "|-_-_-|",
         })]

        [InlineData("|-P-P-|" +
                    "|PPPPP|" +
                    "|-P-_-|",
         new string[]
         {
                "|-P-P-|" +
                "|P_P_P|" +
                "|-_-_-|",

                "|-_-_-|" +
                "|PPPPP|" +
                "|-_-_-|",

                "|-_-P-|" +
                "|P_P_P|" +
                "|-P-_-|",
         })]

        [InlineData("|-PPP-|" +
                    "|P_-_P|" +
                    "|-PPP-|",
         new string[]
         {
                "|-PPP-|" +
                "|P_-_P|" +
                "|-_-_-|",

                "|-_-_-|" +
                "|P_-_P|" +
                "|-PPP-|",
         })]


        [InlineData("|-PPPP|" +
                    "|PPPPP|" +
                    "|-PPPP|",
         new string[]
         {
                "|-_-_-|" +
                "|PPPPP|" +
                "|-_-_-|",

                "|-P-P-|" +
                "|P_P_P|" +
                "|-_-_-|",

                "|-_-_-|" +
                "|P_P_P|" +
                "|-P-P-|",

                "|-_-P-|" +
                "|P_P_P|" +
                "|-P-_-|",

                "|-P-_-|" +
                "|P_P_P|" +
                "|-_-P-|",

                "|-PPP-|" +
                "|P_-_P|" +
                "|-_-_-|",

                "|-_-_-|" +
                "|P_-_P|" +
                "|-PPP-|",
         })]

        public void PatternMatcherShouldReturnCorrectMultiplePattern(string input, string[] patterns)
        {
            // Arrange
            List<Point> pointList = PatternTestHelper.PointsFromString(input);
            List<Pattern> expected = PatternTestHelper.PatternsFromStringPatterns(patterns);

            IPatternMatcher testee = new PatternMatcher(
                new LinePatternMatcher(),
                new TrianglePatternMatcher(),
                new DiagonalPatternMatcher(),
                new UPatternMatcher(new LinePatternMatcher()));

            // Act
            List<Pattern> result = testee.FindMatches(pointList);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
