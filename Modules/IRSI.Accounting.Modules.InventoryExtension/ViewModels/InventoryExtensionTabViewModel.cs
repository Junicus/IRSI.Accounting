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
  public class InventoryExtensionTabViewModel : BindableBase, IInventoryExtensionTabViewModel
  {
	private readonly IRegionManager _regionManager;
	private readonly IEventAggregator _eventAggregator;

	private ICommand _showInventoryExtensionMenuLinkView;
	private ICommand _showInventoryExtensionIslandWideView;

	public InventoryExtensionTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
	{
	  _regionManager = regionManager;
	  _eventAggregator = eventAggregator;

	  _showInventoryExtensionMenuLinkView = new DelegateCommand(() =>
	  {
		RequestNavigate(new Uri("MenuLinkView", UriKind.Relative));
	  });

	  _showInventoryExtensionIslandWideView = new DelegateCommand(() =>
	  {
		RequestNavigate(new Uri("IslandWideView", UriKind.Relative));
	  });
	}

	private void RequestNavigate(Uri uri)
	{
	  _regionManager.RequestNavigate(RegionNames.ContentRegion, uri, NavigationCompleted);
	}

	public ICommand ShowInventoryExtensionMenuLinkView
	{
	  get => _showInventoryExtensionMenuLinkView;
	  set => SetProperty<ICommand>(ref _showInventoryExtensionMenuLinkView, value, nameof(ShowInventoryExtensionMenuLinkView));
	}

	public ICommand ShowInventoryExtensionIslandWideView
	{
	  get => _showInventoryExtensionIslandWideView;
	  set => SetProperty<ICommand>(ref _showInventoryExtensionIslandWideView, value, nameof(ShowInventoryExtensionIslandWideView));
	}

	private void NavigationCompleted(NavigationResult result)
	{
	  if (result.Result != true)
	  {
		return;
	  }
	  _eventAggregator.GetEvent<NavigationCompletedEvent>().Publish("InventoryExtension");
	}
  }
}
