namespace BookOfBruh.View.Main
{
    public interface IWinDisplayer
    {
        void Display(double win);
    }

    public class WinDisplayer : IWinDisplayer
    {
        private readonly ITimedMessageBox timedMessageBox;

        public WinDisplayer(ITimedMessageBox timedMessageBox)
        {
            this.timedMessageBox = timedMessageBox;
        }

        public void Display(double win)
        {
            const int milliseconds = 1000;
            

            this.timedMessageBox.ShowFor("Gewinn!",$"Du hast {win} Bruhcoins gewonnen", milliseconds);
            
        }
    }
}