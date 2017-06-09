﻿using System;
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

	  builder.RegisterType<InventoryExtensionModuleViewModel>().As<IInventoryExtensionModuleViewModel>();
	  builder.RegisterType<InventoryExtensionTabViewModel>().As<IInventoryExtensionTabViewModel>();
	  builder.RegisterType<InventoryExtensionMenuLinkViewModel>().Named<IInventoryExtensionViewModel>("MenuLinkViewModel");
	  builder.RegisterType<InventoryExtensionIslandWideViewModel>().Named<IInventoryExtensionViewModel>("IslandWideViewModel");

	  builder.RegisterType<InventoryExtensionTabView>().Named<object>("InventoryExtensionTabView");
	  builder.RegisterType<MenuLinkView>().Named<object>("MenuLinkView");
	  builder.RegisterType<IslandWideView>().Named<object>("IslandWideView");

	  builder.RegisterType<InventoryExtensionModule>().As<IModule>();
	}
  }
}
