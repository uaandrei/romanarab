using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;

namespace RomanCalculatorModule
{
    [ModuleExport(typeof(RomanCalculatorModule))]
    public class RomanCalculatorModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public RomanCalculatorModule()
        {
        }

        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion("MainRegion", typeof(Views.CalculatorView));
        }
    }
}
