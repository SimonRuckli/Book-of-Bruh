namespace BookOfBruh.View.Control
{
    using BookOfBruh.View.Wallet;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for ControlsView.xaml
    /// </summary>
    public partial class ControlsView : UserControl
    {
        public ControlsView()
        {
            this.InitializeComponent();
        }

        private void Label_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WalletView win = new WalletView();
            win.Show();
        }
    }
}
