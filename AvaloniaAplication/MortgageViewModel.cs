using SharedProject;
using System.ComponentModel;

namespace AvaloniaAplication
{
    public class MortgageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly Model model;
        private readonly CalculationService calculationService;

        public double LoanAmount
        {
            get => model.LoanAmount;
            set
            {
                model.LoanAmount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoanAmount)));
                Calculate();
            }
        }

        public double InterestRate
        {
            get => model.InterestRate;
            set
            {
                model.InterestRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InterestRate)));
                Calculate();
            }
        }

        public int LoanTerm
        {
            get => model.LoanTerm;
            set
            {
                model.LoanTerm = value;
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

        public MortgageViewModel(Model model)
        {
            this.model = model;
            calculationService = new CalculationService();

            Calculate();
        }

        private void Calculate()
        {
            MonthlyPayment = calculationService.MonthlyPayment(LoanAmount, InterestRate, LoanTerm);
        }
    }
}
