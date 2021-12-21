namespace BookOfBruh.Core.Reels
{
    using Symbols;

    public class Slot : NotifyPropertyChangedBase
    {
        private ISymbol symbol;
        private bool isPattern;

        public ISymbol Symbol
        {
            get => symbol;
            set
            {
                symbol = value;
                OnPropertyChanged();
            }
        }

        public bool IsPattern
        {
            get => isPattern;
            set
            {
                isPattern = value;
                OnPropertyChanged();
            }
        }
    }
}