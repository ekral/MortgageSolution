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
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly DatabaseService databaseService;


        private ObservableCollection<MortgageViewModel>? mortgages;
        public ObservableCollection<MortgageViewModel>? Mortgages 
        { 
            get => mortgages;
            set
            {
                mortgages = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mortgages)));
            }
        }

        private MortgageViewModel? _selectedMortgage;

        public MortgageViewModel? SelectedMortgage
        {
            get => _selectedMortgage;
            set
            {
                _selectedMortgage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMortgage)));
            }
        }

        public MainViewModel()
        {
            databaseService = new DatabaseService();
        }

        public async Task LoadMortgages()
        {
            List<Model> models = await databaseService.GetAllAsync();

            Mortgages = new ObservableCollection<MortgageViewModel>(models.Select(x => new MortgageViewModel(x)));
            SelectedMortgage = Mortgages.FirstOrDefault();
        }
    }
}
