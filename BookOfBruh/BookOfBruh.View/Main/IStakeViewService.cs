namespace BookOfBruh.View.Main
{
    using Stake;

    public interface IStakeViewService
    {
        public void CreateWindow(StakeViewModel stakeViewModel);
        public void CloseWindow();
    }

    public class StakeViewService : IStakeViewService
    {
        private StakeView view;

        public void CreateWindow(StakeViewModel stakeViewModel)
        {
           this.view = new StakeView
           {
                DataContext = stakeViewModel,

                Topmost = true
           };

            this.view.Show();
        }

        public void CloseWindow()
        {
            view?.Close();
        }
    }
}