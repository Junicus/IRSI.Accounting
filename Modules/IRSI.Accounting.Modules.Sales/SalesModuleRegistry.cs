using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IRSI.Accounting.Modules.Sales.Services;
using IRSI.Accounting.Modules.Sales.ViewModels;
using IRSI.Accounting.Modules.Sales.Views;
using Prism.Modularity;

namespace IRSI.Accounting.Modules.Sales
{
  public class SalesModuleRegistry : Module
  {
	protected override void Load(ContainerBuilder builder)
	{
	  base.Load(builder);

	  builder.RegisterType<SalesFileParser>().As<ISalesFileParser>();

	  builder.RegisterType<CGBSalesLineParser>().Named<ISalesLineParser>(typeof(CGBSalesLineParser).Name);
	  builder.RegisterType<RMGSalesLineParser>().Named<ISalesLineParser>(typeof(RMGSalesLineParser).Name);
	  builder.RegisterType<OTBSalesLineParser>().Named<ISalesLineParser>(typeof(OTBSalesLineParser).Name);
	  builder.RegisterType<PFCSalesLineParser>().Named<ISalesLineParser>(typeof(PFCSalesLineParser).Name);

	  builder.RegisterType<SalesImportConfigurationService>().As<ISalesImportConfiguration>();

	  builder.RegisterType<SalesModuleViewModel>().As<ISalesModuleViewModel>();
	  builder.RegisterType<SalesTabViewModel>().As<ISalesTabViewModel>();
	  builder.RegisterType<ImportSalesAlohaViewModel>().As<IImportSalesAlohaViewModel>();

	  builder.RegisterType<SalesTabView>().Named<object>(typeof(SalesTabView).Name);
	  builder.RegisterType<ImportSalesAlohaView>().Named<object>(typeof(ImportSalesAlohaView).Name);

	  builder.RegisterType<SalesModule>().As<IModule>();
	}
  }
}
