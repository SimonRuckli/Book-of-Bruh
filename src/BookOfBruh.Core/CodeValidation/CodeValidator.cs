namespace BookOfBruh.Core.CodeValidation
{
    using CSharpFunctionalExtensions;

    public interface ICodeValidator
    {
        Result<double> Validate(int code);
    }

    public class CodeValidator : ICodeValidator
    {
        private readonly IAcceptedCodes acceptedCodes;

        public CodeValidator(IAcceptedCodes acceptedCodes)
        {
            this.acceptedCodes = acceptedCodes;
        }
        
        public Result<double> Validate(int code)
        {
            return acceptedCodes.CodeList.TryGetValue(code, out var bruhCoin) 
                ? Result.Success(bruhCoin) : Result.Failure<double>("Code not found!");
        }
    }
}
