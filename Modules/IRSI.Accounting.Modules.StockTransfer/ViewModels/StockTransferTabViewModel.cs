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

namespace IRSI.Accounting.Modules.StockTransfer.ViewModels
{
  public class StockTransferTabViewModel : BindableBase, IStockTransferTabViewModel
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	private ICommand _showImportStockTransfer;

	private readonly IEventAggregator _eventAggregator;


	public StockTransferTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
	{
	  _eventAggregator = eventAggregator;
	  _showImportStockTransfer = new DelegateCommand(() =>
	  {
		log.Debug("Showing StockTransferView");
		var importStockTransferView = new Uri("ImportStockTransferView", UriKind.Relative);
		regionManager.RequestNavigate(RegionNames.ContentRegion, importStockTransferView, NavigationComplete);
	  });
	}

	public ICommand ShowImportStockTransfer
	{
	  get { return _showImportStockTransfer; }
	  set
	  {
		SetProperty<ICommand>(ref _showImportStockTransfer, value, "ShowImportStockTransfer");
	  }
	}

	private void NavigationComplete(NavigationResult result)
	{
	  log.Debug("Navigation Completed...");
	  if (result.Result != true)
	  {
		log.Error(result.Error);
		return;
	  }
	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Publish("StockTransfer");
	}

	private void OnNavigationCompleted(string publisher)
	{

	}
  }
}
