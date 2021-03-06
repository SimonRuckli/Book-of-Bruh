namespace BookOfBruh.Core.CodeValidation
{
    using System.Collections.Generic;

    public interface IAcceptedCodes
    {
        public Dictionary<int, double> CodeList { get; }
    }

    public class AcceptedCodes : IAcceptedCodes
    {
        public Dictionary<int, double> CodeList { get; }

        public AcceptedCodes()
        {
            CodeList = CreateCodeDictionary();
        }

        private static Dictionary<int, double> CreateCodeDictionary()
        {
            return new Dictionary<int, double>() {
                { 420, 10 },
                { 69, 25 },
                { 455, 50 },
                { 80085, 1000 }
            };
        }
    }
}
