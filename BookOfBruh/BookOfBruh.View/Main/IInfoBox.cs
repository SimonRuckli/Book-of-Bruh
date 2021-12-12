namespace BookOfBruh.View.Main
{
    using System;
    using View.InfoBox;

    public interface IInfoBox
    {
        void ShowWindow(string message);
    }

    public class InfoBox : IInfoBox
    {
        private readonly InfoBoxViewModel infoBoxViewModel;

        private InfoBoxView view;

        public InfoBox(InfoBoxViewModel infoBoxViewModel)
        {
            this.infoBoxViewModel = infoBoxViewModel;

            this.infoBoxViewModel.FocusLost += this.CloseWindow;
        }

        public void ShowWindow(string message)
        {
            this.infoBoxViewModel.Message = message;

            this.view = new InfoBoxView
            {
                DataContext = this.infoBoxViewModel,
            };

            this.view.Show();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            this.view.Close();
        }
    }
}