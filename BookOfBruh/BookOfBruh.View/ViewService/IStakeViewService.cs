namespace BookOfBruh.View.ViewService
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
           var view = new StakeView(stakeViewModel)
           {
               Topmost = true
           };
            
            view.ShowDialog();
        }
    }
}