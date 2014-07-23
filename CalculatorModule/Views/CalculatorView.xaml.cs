using CalculatorModule.ViewModel;
using System.Windows.Controls;

namespace CalculatorModule.Views
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : UserControl
    {
        public CalculatorView()
        {
            InitializeComponent();
            DataContext = new CalculatorViewModel();
        }
    }
}
