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

namespace IRSI.Accounting.Modules.Sales.ViewModels
{
  public class SalesModuleViewModel : BindableBase, ISalesModuleViewModel
  {
	private readonly IRegionManager _regionManager;
	private readonly IEventAggregator _eventAggregator;
	private ICommand _showSalesView;

	public SalesModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
	{
	  _regionManager = regionManager;

	  _showSalesView = new DelegateCommand(() =>
	  {
		var salesTabView = new Uri("SalesTabView", UriKind.Relative);
		regionManager.RequestNavigate(RegionNames.ModulesTabRegion, salesTabView, NavigationCompleted);
	  });

	  _eventAggregator = eventAggregator;
	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Subscribe(OnNavigationCompleted, ThreadOption.UIThread);
	}

	public ICommand ShowSalesView
	{
	  get => _showSalesView;
	  set => SetProperty<ICommand>(ref _showSalesView, value, nameof(ShowSalesView));
	}

	private void NavigationCompleted(NavigationResult result)
	{
	  if (result.Result != true) return;

	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Publish("Sales");
	}

	private void OnNavigationCompleted(string publisher)
	{
	  if (publisher == "Sales") return;
	}

	public bool IsNavigationTarget(NavigationContext navigationContext)
	{
	  throw new NotImplementedException();
	}

	public void OnNavigatedFrom(NavigationContext navigationContext)
	{
	  throw new NotImplementedException();
	}

	public void OnNavigatedTo(NavigationContext navigationContext)
	{
	  throw new NotImplementedException();
	}
  }
}
