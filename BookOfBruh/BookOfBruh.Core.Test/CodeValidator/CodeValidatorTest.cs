namespace BookOfBruh.Core.Test.CodeValidator
{
    using System.Collections.Generic;
    using CodeValidation;
    using CSharpFunctionalExtensions;
    using FluentAssertions;
    using Xunit;

    public class CodeValidatorTest
    {
        [Theory]
        [InlineData(2352, 23)]
        [InlineData(2351, 2)]

        public void ValidCodeShouldReturnCorrectAmountOfBruhCoins(int code, double expected)
        {
            // Arrange
            AcceptedCodes acceptedCodes = new AcceptedCodes();
            CodeValidator testee = new CodeValidator(acceptedCodes);

            // Act
            Result<double> validate = testee.Validate(code);

            // Assert
            validate.Value.Should().Be(expected);
        }

    }
}
