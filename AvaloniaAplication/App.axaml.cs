using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AvaloniaAplication
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                MainViewModel mainViewModel = new MainViewModel();
                desktop.MainWindow = new MortgagesListWindow() { DataContext = mainViewModel };
                await mainViewModel.LoadMortgages();

            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
