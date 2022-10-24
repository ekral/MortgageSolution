using SharedProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaAplication
{
    public class MortagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly DatabaseService databaseService;


        private ObservableCollection<ViewModel>? mortgages;
        public ObservableCollection<ViewModel>? Mortgages 
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

        public MortagesViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public async Task LoadMortgages()
        {
            System.Diagnostics.Debug.WriteLine("Loading Mortgages");
            await Task.Delay(20000);
            System.Diagnostics.Debug.WriteLine("After delay");

            List<Model> models = await databaseService.GetAllAsync();

            Mortgages = new ObservableCollection<ViewModel>(models.Select(x => new ViewModel(x)));
            SelectedMortgage = Mortgages.FirstOrDefault();
        }

        public async Task SaveSelected()
        {
            // TODO dialog box

            if (SelectedMortgage is not null)
            {
                await databaseService.UpdateAsync(SelectedMortgage.Model);
            }
        }
    }
}
