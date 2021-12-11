namespace BookOfBruh.View
{
    using System.Windows;
    using Infrastructure;
    using Main;
    using Ninject;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            IKernel kernel = new StandardKernel(new BookOfBruhModule());
            MainWindow mainWindow = new MainWindow { DataContext = kernel.Get<MainWindowViewModel>() };
            mainWindow.InitializeComponent();
            mainWindow.Show();
        }
    }
}
