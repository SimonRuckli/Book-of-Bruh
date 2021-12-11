namespace BookOfBruh.View.Stake
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaktionslogik für StakeView.xaml
    /// </summary>
    public partial class StakeView : Window
    {
        public StakeView(StakeViewModel stakeViewModel)
        {
            this.DataContext = stakeViewModel;

            stakeViewModel.CloseView += this.CloseView;

            InitializeComponent();
        }

        private void CloseView(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
