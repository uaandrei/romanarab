using Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using RomanNumbersCalculator.BL.Calculator;
using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using RomanNumbersCalculator.BL.StringNumberParser;
using RomanNumbersCalculator.ViewModel;

namespace RomanCalculatorModule
{
    public class RomanCalculatorModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        public RomanCalculatorModule(IRegionViewRegistry registry, IUnityContainer container)
        {
            _regionViewRegistry = registry;
            container.RegisterType<IStringNumberParser, RomanStringParser>();
            container.RegisterType<INumberProvider, RomanNumbersProvider>();
            container.RegisterType<ISpecification<string>, ConsecutiveRomanPositionalsMustBeDescendingAndUnique>();
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(Views.CalculatorView));
        }
    }
}
