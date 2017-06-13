using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IRSI.Accounting.Modules.StockTransfer.Services;
using IRSI.Accounting.Modules.StockTransfer.ViewModels;
using IRSI.Accounting.Modules.StockTransfer.Views;
using Prism.Modularity;

namespace IRSI.Accounting.Modules.StockTransfer
{
  public class StockTransferModuleRegistry : Module
  {
	protected override void Load(ContainerBuilder builder)
	{
	  base.Load(builder);

	  builder.RegisterType<StockTransferFileParser>().As<IStockTransferFileParser>();
	  builder.RegisterType<StockTransferImportConfiguration>().As<IStockTransferImportConfiguration>();

	  builder.RegisterType<StockTransferModuleViewModel>().As<IStockTransferModuleViewModel>();
	  builder.RegisterType<StockTransferTabViewModel>().As<IStockTransferTabViewModel>();
	  builder.RegisterType<ImportStockTransferViewModel>().As<IImportStockTransferViewModel>();

	  builder.RegisterType<StockTransferTabView>().Named<object>(typeof(StockTransferTabView).Name);
	  builder.RegisterType<ImportStockTransferView>().Named<object>(typeof(ImportStockTransferView).Name);
	  builder.RegisterType<StockTransferInOutPairView>().Named<object>(typeof(StockTransferInOutPairView).Name);

	  builder.RegisterType<StockTransferModule>().As<IModule>();
	}
  }
}
