namespace BookOfBruh.Core.CodeValidation
{
    using System.Collections.Generic;
    using System.Linq;
    using CSharpFunctionalExtensions;

    public interface ICodeValidator
    {
        Result<double> Validate(int code);
    }

    public class CodeValidator : ICodeValidator
    {
        private readonly AcceptedCodes acceptedCodes;

        public CodeValidator(AcceptedCodes acceptedCodes)
        {
            this.acceptedCodes = acceptedCodes;
        }

        public Result<double> Validate(int code)
        {
            double bruhCoin;
            if(acceptedCodes.CodeList.TryGetValue(code, out bruhCoin))
            {
                return Result.Success(bruhCoin);
            }
            else
            {
                return Result.Failure<double>("Code not found!");
            }
        }
    }
}
