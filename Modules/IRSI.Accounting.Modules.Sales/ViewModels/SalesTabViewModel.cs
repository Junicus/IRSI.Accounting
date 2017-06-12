using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IRSI.Accounting.Common;
using IRSI.Accounting.Common.Events;
using NLog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace IRSI.Accounting.Modules.Sales.ViewModels
{
  public class SalesTabViewModel : BindableBase, ISalesTabViewModel
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();
	private readonly IRegionManager _regionManager;
	private readonly IEventAggregator _eventAggregator;

	private ICommand _showImportSalesAloha;

	public SalesTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
	{
	  _regionManager = regionManager;

	  _showImportSalesAloha = new DelegateCommand(() =>
	  {
		log.Debug("Showing ImportSalesAlohaView");
		var importSalesAlohaView = new Uri("ImportSalesAlohaView", UriKind.Relative);
		regionManager.RequestNavigate(RegionNames.ContentRegion, importSalesAlohaView, NavigationCompleted);
	  });

	  _eventAggregator = eventAggregator;
	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Subscribe(OnNavigationCompleted, ThreadOption.UIThread);
	}

	public ICommand ShowImportSalesAloha
	{
	  get => _showImportSalesAloha;
	  set => SetProperty<ICommand>(ref _showImportSalesAloha, value, nameof(ShowImportSalesAloha));
	}

	private void NavigationCompleted(NavigationResult result)
	{
	  log.Debug("Navigation Completed...");
	  if (result.Result != true)
	  {
		log.Error(result.Error);
		return;
	  }

	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Publish("Sales");
	}

	private void OnNavigationCompleted(string publisher)
	{
	}
  }
}
