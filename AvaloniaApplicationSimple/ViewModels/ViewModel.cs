using SharedProject;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AvaloniaApplicationSimple.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        private readonly DatabaseService _databaseService = new();

        private ObservableCollection<Model> _mortgages = new();
        public ObservableCollection<Model> Mortgages
        {
            get => _mortgages;
            set => SetProperty(ref _mortgages, value);
        }

        public async void LoadAsync()
        {
            await _databaseService.EnsureCreatedAsync();

            List<Model> models = await _databaseService.GetAllAsync();

            foreach (Model model in models)
            {
                Mortgages.Add(model);
                await Task.Delay(2000);
            }
            //Mortgages = new ObservableCollection<Model>(models);
        }
    }
}
