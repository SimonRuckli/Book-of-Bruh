namespace BookOfBruh.Core.Test.CodeValidator
{
    using CodeValidation;
    using CSharpFunctionalExtensions;
    using FluentAssertions;
    using Xunit;

    public class CodeValidatorTest
    {
        [Fact]
        public void ValidCodeShouldReturnCorrectAmountOfBruhCoins()
        {
            // Arrange
            CodeValidator testee = new CodeValidator();
            const int code = 2352;
            const double expected = 23;

            // Act
            Result<double> validate = testee.Validate(code);

            // Assert
            validate.Value.Should().Be(expected);
        }

    }
}
