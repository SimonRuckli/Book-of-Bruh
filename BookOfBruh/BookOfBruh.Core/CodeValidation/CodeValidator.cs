namespace BookOfBruh.Core.CodeValidation
{
    using System;
    using CSharpFunctionalExtensions;

    public interface ICodeValidator
    {
        Result<double> Validate(int code);
    }

    public class CodeValidator : ICodeValidator
    {
        public Result<double> Validate(int code)
        {
            throw new NotImplementedException();
        }
    }
}
