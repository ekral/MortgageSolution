using AvaloniaAplication;
using SharedProject;

namespace UnitTests
{
    public class UnitTestModel
    {
        [Fact]
        public void TestMonthlyPaymentValidInputValidMonthlyPayment()
        {
            CalculationService calculation = new CalculationService();
            double monthlyPayment = calculation.MonthlyPayment(8000000.0, 6.0, 30);

            Assert.Equal(47964.04, monthlyPayment, 2);
        }
    }

    public class UnitTestViewModel
    {
        [Fact]
        public void TestMonthlyPaymentValidInputValidMonthlyPayment()
        {
            Model model = new Model();
            ViewModel viewModel = new ViewModel(model);
            viewModel.LoanAmount = 8000000.0;
            viewModel.InterestRate = 6.0;
            viewModel.LoanTerm = 30;
            
            double monthlyPayment =  viewModel.MonthlyPayment;

            Assert.Equal(47964.04, monthlyPayment, 2);
        }
    }
}