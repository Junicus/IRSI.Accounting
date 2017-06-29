using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IRSI.Accounting.Modules.InventoryExtension.Services;
using IRSI.Accounting.Modules.InventoryExtension.ViewModels;
using IRSI.Accounting.Modules.InventoryExtension.Views;
using Prism.Modularity;

namespace IRSI.Accounting.Modules.InventoryExtension
{
  public class InventoryExtensionModuleRegistry : Module
  {
	protected override void Load(ContainerBuilder builder)
	{
	  base.Load(builder);

	  builder.RegisterType<InventoryChartOfAccounts>().As<IInventoryChartOfAccounts>();

	  builder.RegisterType<InventoryExtensionMenuLinkParser>().Named<IInventoryExtensionParser>("MenuLinkParser");
	  builder.RegisterType<InventoryExtensionIslandWideParser>().Named<IInventoryExtensionParser>("IslandWideParser");

	  builder.RegisterType<InventoryExtensionLineParser>().As<IInventoryExtensionLineParser>().SingleInstance();

	  builder.RegisterType<InventoryExtensionModuleViewModel>().As<IInventoryExtensionModuleViewModel>();
	  builder.RegisterType<InventoryExtensionTabViewModel>().As<IInventoryExtensionTabViewModel>();
	  builder.RegisterType<InventoryExtensionMenuLinkViewModel>().Named<IInventoryExtensionViewModel>("MenuLinkViewModel");
	  builder.RegisterType<InventoryExtensionIslandWideViewModel>().Named<IInventoryExtensionViewModel>("IslandWideViewModel");

	  builder.RegisterType<InventoryExtensionTabView>().Named<object>(typeof(InventoryExtensionTabView).Name);
	  builder.RegisterType<MenuLinkView>().Named<object>(typeof(MenuLinkView).Name);
	  builder.RegisterType<IslandWideView>().Named<object>(typeof(IslandWideView).Name);

	  builder.RegisterType<InventoryExtensionModule>().As<IModule>();
	}
  }
}
