using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaAplication.ViewModels;
using AvaloniaAplication.Views;
using SharedProject;

namespace AvaloniaAplication
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            DatabaseService databaseService = new DatabaseService();
            MortgagesCollectionViewModel viewModel = new MortgagesCollectionViewModel(databaseService);
            
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MortgagesWindow() { DataContext = viewModel };
            }

            base.OnFrameworkInitializationCompleted();

            if (await databaseService.EnsureCreatedAsync())
            {
                await databaseService.InsertAsync(new Model(8000000.0, 6.0, 30));
                await databaseService.InsertAsync(new Model(4000000.0, 5.7, 20));
                await databaseService.InsertAsync(new Model(10800000.0, 5.8, 15));
            }
        }
    }
}
