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
    public class MortgagesViewModel : ViewModelBase
    {
        private readonly DatabaseService databaseService;

        private ObservableCollection<ViewModel> mortgages = null!;
        public ObservableCollection<ViewModel> Mortgages
        {
            get => mortgages;
            set => SetProperty(ref mortgages, value);
        }

        private ViewModel? selectedMortgage;

        public ViewModel? SelectedMortgage
        {
            get => selectedMortgage;
            set => SetProperty(ref selectedMortgage, value);
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
