namespace BookOfBruh.Core.CodeValidation
{
    using System.Collections.Generic;
    using CSharpFunctionalExtensions;

    public interface ICodeValidator
    {
        Result<double> Validate(int code);
    }

    public class CodeValidator : ICodeValidator
    {
        private readonly Dictionary<int, double> codeValues;

        public CodeValidator(Dictionary<int, double> codeValues)
        {
            this.codeValues = codeValues;
        }

        public Result<double> Validate(int code)
        {
            return codeValues[code];
        }
    }
}
