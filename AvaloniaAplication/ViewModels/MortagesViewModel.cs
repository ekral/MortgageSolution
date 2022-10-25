using SharedProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaAplication.ViewModels
{
    public class MortgagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly DatabaseService databaseService;


        private ObservableCollection<ViewModel> mortgages = null!;
        public ObservableCollection<ViewModel> Mortgages
        {
            get => mortgages;
            set
            {
                mortgages = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mortgages)));
            }
        }

        private ViewModel? _selectedMortgage;

        public ViewModel? SelectedMortgage
        {
            get => _selectedMortgage;
            set
            {
                _selectedMortgage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMortgage)));
            }
        }

        public MortgagesViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            Mortgages = new ObservableCollection<ViewModel>();
            SelectedMortgage = null;
        }

        public async Task LoadMortgages()
        {
            await Task.Delay(5000);

            List<Model> models = await databaseService.GetAllAsync();

            Mortgages = new ObservableCollection<ViewModel>(models.Select(x => new ViewModel(x)));
            SelectedMortgage = Mortgages.FirstOrDefault();
        }

        public async Task Save()
        {
            // TODO dialog box
            if (SelectedMortgage is not null)
            {
                await databaseService.UpdateAsync(SelectedMortgage.Model);
            }
        }
    }
}
