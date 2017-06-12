using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common;
using IRSI.Accounting.Modules.Sales.Views;
using Prism.Modularity;
using Prism.Regions;

namespace IRSI.Accounting.Modules.Sales
{
  [Module(ModuleName = "SalesModule")]
  public class SalesModule : IModule
  {
	private readonly IRegionManager _regionManager;

	public SalesModule(IRegionManager regionManager)
	{
	  _regionManager = regionManager;
	}

	public void Initialize()
	{
	  _regionManager.RegisterViewWithRegion(RegionNames.ModulesGroupRegion, typeof(SalesModuleView));
	}
  }
}
