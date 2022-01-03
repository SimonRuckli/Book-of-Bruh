namespace BookOfBruh.Core.Test.CodeValidator
{
    using System.Collections.Generic;
    using CodeValidation;
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
            IAcceptedCodes acceptedCodes = new FakeAcceptedCodes();
            var testee = new CodeValidator(acceptedCodes);

            // Act
            var validate = testee.Validate(code);

            // Assert
            validate.Value.Should().Be(expected);
        }

    }

    public class FakeAcceptedCodes : IAcceptedCodes
    {
        public Dictionary<int, double> CodeList { get; } = new Dictionary<int, double>()
        {
            {2352, 23},
            {2351, 2}
        };

    }
}
