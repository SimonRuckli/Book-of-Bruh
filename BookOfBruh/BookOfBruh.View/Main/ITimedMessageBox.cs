namespace BookOfBruh.View.Main
{
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

        public TimedMessageBox(InfoBoxViewModel infoBoxViewModel)
        {
            this.infoBoxViewModel = infoBoxViewModel;
        }

        public async Task ShowFor(string title, string message, int milliseconds)
        {
            this.infoBoxViewModel.Message = message;

            InfoBoxView view = new InfoBoxView
            {
                DataContext = this.infoBoxViewModel, 
                Topmost = true,
                Title = title
            };

            await this.ShowWindowFor(view, milliseconds);
        }

        private async Task ShowWindowFor(Window view, int milliseconds)
        {
            view.ShowDialog();
            await Task.Delay(milliseconds);
            view.Close();
        }
    }
}