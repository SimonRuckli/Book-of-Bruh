namespace BookOfBruh.Core.Test.SlotAnalysation
{
    using Xunit;
    using FluentAssertions;
    using BookOfBruh.Core.SlotAnalysation;
    using System.Collections.Generic;
    using System.Drawing;

    public class PatternMatcherTest
    {
        [Fact]
        public void PatternMatcherShould()
        {
            // Arrange
            List<Point> pointList = new List<Point>()
            {
                new Point() { X = 0, Y = 0 },
                new Point() { X = 1, Y = 0 },
                new Point() { X = 2, Y = 0 }
            };
            
            Pattern testee = new Pattern(pointList);
            // Act
            List<Pattern> result = testee.FindMatches(pointList);
            // Assert
        }
    }
}
