namespace BookOfBruh.View.Main
{
    using Stake;

    public interface IStakeViewService
    {
        public void CreateWindow(StakeViewModel stakeViewModel);
    }

    public class StakeViewService : IStakeViewService
    {
        public void CreateWindow(StakeViewModel stakeViewModel)
        {
            StakeView view = new StakeView
            {
                DataContext = stakeViewModel,
                Topmost = true
            };
            view.Show();
        }
    }
}