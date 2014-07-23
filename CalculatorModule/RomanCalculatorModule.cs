using Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace CalculatorModule
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
            _regionViewRegistry.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Views.CalculatorView));
        }
    }
}
