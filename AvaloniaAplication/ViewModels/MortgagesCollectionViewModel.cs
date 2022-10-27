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
    public class MortgagesCollectionViewModel : ViewModelBase
    {
        private readonly DatabaseService databaseService;

        private ObservableCollection<MortgageViewModel> mortgages = null!;
        public ObservableCollection<MortgageViewModel> Mortgages
        {
            get => mortgages;
            set => SetProperty(ref mortgages, value);
        }

        private MortgageViewModel? selectedMortgage;

        public MortgageViewModel? SelectedMortgage
        {
            get => selectedMortgage;
            set => SetProperty(ref selectedMortgage, value);
        }

        public MortgagesCollectionViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            Mortgages = new ObservableCollection<MortgageViewModel>();
            SelectedMortgage = null;
        }

        public async Task LoadMortgages()
        {
            await Task.Delay(5000);

            List<Model> models = await databaseService.GetAllAsync();

            Mortgages = new ObservableCollection<MortgageViewModel>(models.Select(x => new MortgageViewModel(x)));
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
