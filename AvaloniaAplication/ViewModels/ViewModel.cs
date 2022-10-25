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
                if (SetProperty(Model.InterestRate, value, Model, (m, v) => m.InterestRate = v))
                {
                    Calculate();
                }
            }
        }

        public int LoanTerm
        {
            get => Model.LoanTerm;
            set
            {
                if (SetProperty(Model.LoanTerm, value, Model, (m, v) => m.LoanTerm = v))
                {
                    Calculate();
                }
            }
        }

        private double monthlyPayment;

        public double MonthlyPayment
        {
            get => monthlyPayment;
            private set => SetProperty(ref monthlyPayment, value);
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
