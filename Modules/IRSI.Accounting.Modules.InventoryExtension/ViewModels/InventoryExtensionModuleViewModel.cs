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

namespace IRSI.Accounting.Modules.InventoryExtension.ViewModels
{
  public class InventoryExtensionModuleViewModel : BindableBase, IInventoryExtensionModuleViewModel, INavigationAware
  {
	private ICommand _showInventoryExtensionView;
	private readonly IRegionManager _regionManager;
	private readonly IEventAggregator _eventAggregator;

	public InventoryExtensionModuleViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
	{
	  _regionManager = regionManager;
	  _eventAggregator = eventAggregator;

	  _showInventoryExtensionView = new DelegateCommand(() =>
	  {
		var InventoryExtensionTavView = new Uri("InventoryExtensionTabView", UriKind.Relative);
		_regionManager.RequestNavigate(RegionNames.ModulesTabRegion, InventoryExtensionTavView, NavigationCompleted);
	  });

	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Subscribe(OnNavigationCompleted, ThreadOption.UIThread);
	}

	public ICommand ShowInventoryExtensionView
	{
	  get => _showInventoryExtensionView;
	  set => SetProperty<ICommand>(ref _showInventoryExtensionView, value, "ShowInventoryExtensionView");
	}

	private void NavigationCompleted(NavigationResult result)
	{
	  if (result.Result != true) return;
	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Publish("InventoryExtension");
	}

	private void OnNavigationCompleted(string publisher)
	{
	  if (publisher == "InventoryExtension") return;
	}

	public bool IsNavigationTarget(NavigationContext navigationContext)
	{
	  return false;
	}

	public void OnNavigatedFrom(NavigationContext navigationContext)
	{
	}

	public void OnNavigatedTo(NavigationContext navigationContext)
	{
	}
  }
}
