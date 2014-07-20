using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using System.Windows;

namespace AwesomeCalculator.Main
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;

        public Shell()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            this.ModuleManager.LoadModuleCompleted +=
                (s, e) =>
                {
                    //if (e.ModuleInfo.ModuleName == EmailModuleName)
                    //{
                    //    this.RegionManager.RequestNavigate(
                    //        RegionNames.MainContentRegion,
                    //        InboxViewUri);
                    //}
                };
        }
    }
}
