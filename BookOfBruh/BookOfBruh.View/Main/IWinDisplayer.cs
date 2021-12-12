namespace BookOfBruh.View.Main
{
    public interface IWinDisplayer
    {
        void Display(double win);
    }

    public class WinDisplayer : IWinDisplayer
    {
        private readonly IInfoBox infoBox;

        public WinDisplayer(IInfoBox infoBox)
        {
            this.infoBox = infoBox;
        }

        public void Display(double win)
        {
            this.infoBox.ShowWindow($"Du hast {win} Bruhcoins gewonnen");
        }
    }
}