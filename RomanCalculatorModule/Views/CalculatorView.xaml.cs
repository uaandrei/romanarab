using Microsoft.Practices.Unity;
using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using RomanNumbersCalculator.BL.StringNumberParser;
using RomanNumbersCalculator.ViewModel;
using System.Windows.Controls;

namespace RomanCalculatorModule.Views
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : UserControl
    {
        public CalculatorView(IUnityContainer container)
        {
            InitializeComponent();
            DataContext = new CalculatorViewModel(container);

        }
    }
}
