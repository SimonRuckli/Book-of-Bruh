namespace BookOfBruh.View.InfoBox
{
    using System;
    using Infrastructure;
    using Infrastructure.Commands;

    public class InfoBoxViewModel : NotifyPropertyChangedBase
    {
        public InfoBoxViewModel()
        {
            this.LostFocusCommand = new RelayCommand(this.LostFocus);
        }

        public string Message { get; set; }

        public RelayCommand LostFocusCommand { get; set; }

        public EventHandler FocusLost;

        private void LostFocus()
        {
            this.FocusLost?.Invoke(this, EventArgs.Empty);
        }
    }
}
