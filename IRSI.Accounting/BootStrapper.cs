using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using IRSI.Accounting.Common.MVVM.DialogService;
using IRSI.Accounting.Data;
using IRSI.Accounting.Data.Repositories;
using IRSI.Accounting.Views;
using Prism.Autofac;
using Prism.Modularity;

namespace IRSI.Accounting
{
  public class Bootstrapper : AutofacBootstrapper
  {
	protected override DependencyObject CreateShell()
	{
	  return Container.Resolve<Shell>();
	}

	protected override void InitializeShell()
	{
	  base.InitializeShell();
	  Application.Current.MainWindow = (Shell)this.Shell;
	  Application.Current.MainWindow.Show();
	}

	protected override void ConfigureModuleCatalog()
	{
	  base.ConfigureModuleCatalog();

	  string[] assemblyScannerPattern = new[] { @"IRSI.Accounting.Modules.*.dll" };
	  Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

	  List<Assembly> assemblies = new List<Assembly>();
	  assemblies.AddRange(Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories)
		.Where(filename => assemblyScannerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
		.Select(Assembly.LoadFile));

	  foreach (var assembly in assemblies)
	  {
		var moduleTypes = assembly.DefinedTypes.Where(t => t.IsAssignableTo<IModule>());
		foreach (var module in moduleTypes)
		{
		  ModuleCatalog.AddModule(new ModuleInfo
		  {
			ModuleName = module.Name,
			ModuleType = module.AssemblyQualifiedName
		  });
		}
	  }
	}

	protected override void ConfigureContainerBuilder(ContainerBuilder builder)
	{
	  base.ConfigureContainerBuilder(builder);
	  builder.RegisterType<Shell>();

	  builder.RegisterType<InMemoryStoresRepository>().As<IStoresRepository>();
	  builder.RegisterType<GLRepository>().As<IGLRepository>();
	  builder.RegisterType<FolderBrowserDialogService>().As<IFolderBrowserDialogService>();
	  builder.RegisterType<DialogService>().As<IDialogService>();

	  string[] assemblyScannerPattern = new[] { @"IRSI.Accounting.Modules.*.dll" };
	  Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

	  List<Assembly> assemblies = new List<Assembly>();
	  assemblies.AddRange(Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories)
		.Where(filename => assemblyScannerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
		.Select(Assembly.LoadFile));

	  foreach (var assembly in assemblies)
	  {
		builder.RegisterAssemblyModules(assembly);
	  }
	}
  }
}
