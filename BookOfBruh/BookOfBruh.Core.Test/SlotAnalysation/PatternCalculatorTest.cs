using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace BookOfBruh.Core.Test.SlotAnalysation
{
    public class PatternCalculatorTest
    {
        [Fact]
        public void GetCorrectPatterns()
        {
            // Arrange
            PatternCalculator testee = new PatternCalculator();
            List<Point> input = new List<Point>()
            {
                new Point(0, 0),
                new Point(1, 0),
                new Point(2, 0),
                new Point(1, 1),
            };  
            
            List<Point> pattern1 = new List<Point>()
            {
                new Point(0, 0),
                new Point(1, 0),
                new Point(2, 0),
            }; 

            List<Point> pattern2 = new List<Point>()
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 0),
            };

            List<Pattern> expected = new List<Pattern>()
            {
                new Pattern(pattern1),
                new Pattern(pattern2),
            };

            // Act

            List<Pattern> patterns = testee.Calculate(input);

            // Assert
            patterns.Should().BeEquivalentTo(expected);
        }
    }




    public class Pattern
    {
        public List<Point> Points { get; }

        public Pattern(List<Point> points)
        {
            this.Points = points;
        }
    }

    public class PatternCalculator  
    {
        public List<Pattern> Calculate(List<Point> input)
        {
            List<Pattern> patterns = new List<Pattern>();
            Result<Pattern> oneLinePattern = GetOneLinePattern(input);

            if (oneLinePattern.IsSuccess)
            {
                patterns.Add(oneLinePattern.Value);
            }    
            Result<Pattern> trianglePattern = GetTrianglePattern(input);

            if (trianglePattern.IsSuccess)
            {
                patterns.Add(trianglePattern.Value);
            }

            return patterns;
        }

        private Result<Pattern> GetTrianglePattern(List<Point> points)
        {
            List<Point> pattern = new List<Point>();
            Point previous = Point.Empty;

            foreach (Point point in points)
            {
                if (point.X == 0)
                {
                    pattern.Add(point);
                }
                else if(point.Y != previous.Y)
                {
                    pattern.Add(point);
                }

                previous = point;
            }

            if (pattern.Count >= 3)
            {
                return new Pattern(pattern);
            }

            return Result.Failure<Pattern>("Is no One Line Pattern");
        }

        private static Result<Pattern> GetOneLinePattern(List<Point> points)
        {
            int rowIndex = points.First().Y;

            List<Point> pattern = points.Where(point => point.Y == rowIndex).ToList();

            if (pattern.Count >= 3)
            {
                return new Pattern(pattern);
            }

            return Result.Failure<Pattern>("Is no One Line Pattern");
        }
    }
}
