using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common;
using IRSI.Accounting.Modules.StockTransfer.Views;
using Prism.Modularity;
using Prism.Regions;

namespace IRSI.Accounting.Modules.StockTransfer
{
  [Module(ModuleName = "StockTransferModule")]
  public class StockTransferModule : IModule
  {
	private readonly IRegionManager _regionManager;

	public StockTransferModule(IRegionManager regionManager)
	{
	  _regionManager = regionManager;
	}

	public void Initialize()
	{
	  _regionManager.RegisterViewWithRegion(RegionNames.ModulesGroupRegion, typeof(StockTransferModuleView));
	}
  }
}
