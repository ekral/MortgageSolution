using Avalonia.Controls;

namespace AvaloniaApplicationSimple
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new ViewModels.ViewModel();
            InitializeComponent();
        }
    }
}