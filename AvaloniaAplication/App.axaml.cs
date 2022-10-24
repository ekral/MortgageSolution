using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SharedProject;

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
                DatabaseService databaseService = new DatabaseService();
            
                // TODO prevest na IoC container
                // zavolat EnsureCreated

                MortagesViewModel mainViewModel = new MortagesViewModel(databaseService);
                desktop.MainWindow = new MainWindow() { DataContext = mainViewModel };

                if(await databaseService.EnsureCreatedAsync())
                {
                    await databaseService.InsertAsync(new Model(8000000.0, 6.0, 30));
                    await databaseService.InsertAsync(new Model(4000000.0, 5.7, 20));
                    await databaseService.InsertAsync(new Model(10800000.0, 5.8, 15));
                }

                await mainViewModel.LoadMortgages();
                
                // TODO overit do ktere metody dat asynchronni inicializaci
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
