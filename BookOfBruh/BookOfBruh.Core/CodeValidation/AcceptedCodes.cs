namespace BookOfBruh.Core.CodeValidation
{
    using System.Collections.Generic;

    public class AcceptedCodes
    {
        public Dictionary<int, double> CodeList;
        public AcceptedCodes()
        {
            CodeList = CreateCodeDictionary();
        }

        private Dictionary<int, double> CreateCodeDictionary()
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
