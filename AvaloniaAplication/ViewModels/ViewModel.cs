using SharedProject;
using System.ComponentModel;

namespace AvaloniaAplication.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        public Model Model { get; }

        private readonly CalculationService calculationService;

        public double LoanAmount
        {
            get => Model.LoanAmount;
            set
            {
                if(SetProperty(Model.LoanAmount, value, Model, (m,v) => m.LoanAmount = v))
                {
                    Calculate();
                }
            }
        }

        public double InterestRate
        {
            get => Model.InterestRate;
            set
            {
                Model.InterestRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InterestRate)));
                Calculate();
            }
        }

        public int LoanTerm
        {
            get => Model.LoanTerm;
            set
            {
                Model.LoanTerm = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoanTerm)));
                Calculate();
            }
        }

        private double _monthlyPayment;

        public double MonthlyPayment
        {
            get => _monthlyPayment;
            private set
            {
                _monthlyPayment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MonthlyPayment)));
            }
        }

        public ViewModel(Model model)
        {
            Model = model;
            calculationService = new CalculationService();

            Calculate();
        }

        private void Calculate()
        {
            MonthlyPayment = calculationService.MonthlyPayment(LoanAmount, InterestRate, LoanTerm);
        }
    }
}
