using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IRSI.Accounting.Modules.InventoryExtension.Services;
using IRSI.Accounting.Modules.InventoryExtension.ViewModels;
using Prism.Modularity;

namespace IRSI.Accounting.Modules.InventoryExtension
{
  public class InventoryExtensionModuleRegistry : Module
  {
	protected override void Load(ContainerBuilder builder)
	{
	  base.Load(builder);

	  builder.RegisterType<InventoryChartOfAccounts>().As<IInventoryChartOfAccounts>();

	  builder.RegisterType<InventoryExtensionModuleViewModel>().As<IInventoryExtensionModuleViewModel>();

	  builder.RegisterType<InventoryExtensionModule>().As<IModule>();
	}
  }
}
