using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IRSI.Accounting.Common;
using IRSI.Accounting.Common.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace IRSI.Accounting.Modules.StockTransfer.ViewModels
{
  public class StockTransferModuleViewModel : BindableBase, IStockTransferModuleViewModel
  {
	private ICommand _showStockTransferView;
	private readonly IEventAggregator _eventAggregator;

	public StockTransferModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
	{
	  _eventAggregator = eventAggregator;
	  _showStockTransferView = new DelegateCommand(() =>
	  {
		var stockTransferTabView = new Uri("StockTransferTabView", UriKind.Relative);
		regionManager.RequestNavigate(RegionNames.ModulesTabRegion, stockTransferTabView, NavigationCompleted);
	  });
	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Subscribe(OnNavigationCompleted);
	}

	public ICommand ShowStockTransferView
	{
	  get { return _showStockTransferView; }
	  set
	  {
		SetProperty<ICommand>(ref _showStockTransferView, value, "ShowStockTransferView");
	  }
	}

	private void NavigationCompleted(NavigationResult result)
	{
	  if (result.Result != true) return;
	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Publish("StockTransfer");
	}

	private void OnNavigationCompleted(string publisher)
	{
	  if (publisher == "StockTransfer") return;
	}

	public void OnNavigatedTo(NavigationContext navigationContext)
	{
	  throw new NotImplementedException();
	}

	public bool IsNavigationTarget(NavigationContext navigationContext)
	{
	  throw new NotImplementedException();
	}

	public void OnNavigatedFrom(NavigationContext navigationContext)
	{
	  throw new NotImplementedException();
	}
  }
}
