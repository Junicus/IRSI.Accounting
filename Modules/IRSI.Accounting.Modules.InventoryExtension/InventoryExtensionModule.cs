using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common;
using IRSI.Accounting.Modules.InventoryExtension.Views;
using Prism.Modularity;
using Prism.Regions;

namespace IRSI.Accounting.Modules.InventoryExtension
{
  [Module(ModuleName = "InventoryExtensionModule")]
  public class InventoryExtensionModule : IModule
  {
	private readonly IRegionManager _regionManager;

	public InventoryExtensionModule(IRegionManager regionManager)
	{
	  _regionManager = regionManager;
	}

	public void Initialize()
	{
	  _regionManager.RegisterViewWithRegion(RegionNames.ModulesGroupRegion, typeof(InventoryExtensionModuleView));
	}
  }
}
