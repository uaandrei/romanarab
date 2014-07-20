using Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using RomanNumbersCalculator.BL.Calculator;
using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using RomanNumbersCalculator.ViewModel;

namespace RomanCalculatorModule
{
    public class RomanCalculatorModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        public RomanCalculatorModule(IRegionViewRegistry registry)
        {
            _regionViewRegistry = registry;
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(Views.CalculatorView));
        }
    }
}
