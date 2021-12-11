namespace BookOfBruh.View.Main
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using InfoBox;

    public interface ITimedMessageBox
    {
        Task ShowFor(string title, string message, int milliseconds);
    }

    public class TimedMessageBox : ITimedMessageBox
    {
        private readonly InfoBoxViewModel infoBoxViewModel;

        private InfoBoxView view;

        public TimedMessageBox(InfoBoxViewModel infoBoxViewModel)
        {
            this.infoBoxViewModel = infoBoxViewModel;

            this.infoBoxViewModel.FocusLost += this.CloseWindow;

        }

        public async Task ShowFor(string title, string message, int milliseconds)
        {
            this.infoBoxViewModel.Message = message;

            this.view = new InfoBoxView
            {
                DataContext = this.infoBoxViewModel,
                Title = title
            };

            await this.ShowWindowFor( milliseconds);
        }

        private async Task ShowWindowFor(int milliseconds)
        {
            this.view.Show();
            await Task.Delay(milliseconds);
            this.view.Close();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            this.view.Close();
        }
    }
}