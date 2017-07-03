using System;
using IRSI.Accounting.Common.Events;
using IRSI.Accounting.Modules.InventoryExtension.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using Prism.Regions;

namespace IRSI.Accounting.Models.InventoryExtension.Tests.ViewModels
{
  [TestClass]
  public class InventoryExtensionTabViewModelTests
  {
	private readonly Mock<NavigationCompletedEvent> _event = new Mock<NavigationCompletedEvent>();
	private readonly Mock<IRegionManager> _regionManagerMock = new Mock<IRegionManager>();
	private readonly Mock<IEventAggregator> _eventAggregatorMock = new Mock<IEventAggregator>();

	private readonly InventoryExtensionTabViewModel _subject;

	public InventoryExtensionTabViewModelTests()
	{
	  //_event.Setup(x => x.Subscribe(It.IsAny<Action<string>>(), ThreadOption.UIThread));
	  _eventAggregatorMock.Setup(x => x.GetEvent<NavigationCompletedEvent>()).Returns(_event.Object);
	  _subject = new InventoryExtensionTabViewModel(_regionManagerMock.Object, _eventAggregatorMock.Object);
	}

	[TestMethod]
	public void NewInventoryExtensionHasCommandsAndCanBeExecuted()
	{
	  Assert.IsNotNull(_subject.ShowInventoryExtensionIslandWideView);
	  Assert.IsNotNull(_subject.ShowInventoryExtensionMenuLinkView);
	  Assert.IsTrue(_subject.ShowInventoryExtensionIslandWideView.CanExecute(null));
	  Assert.IsTrue(_subject.ShowInventoryExtensionMenuLinkView.CanExecute(null));
	}

	[TestMethod]
	public void ExecutingShowIslandWideCallsRequestNavigateOnRegionManager()
	{
	  _subject.ShowInventoryExtensionIslandWideView.Execute(null);
	  _regionManagerMock.Verify(x => x.RequestNavigate(It.IsAny<string>(), It.IsAny<Uri>(), It.IsAny<Action<NavigationResult>>()));
	}

	[TestMethod]
	public void ExecutingShowMenuLinkCallsRequestNavigateOnRegionManager()
	{
	  _subject.ShowInventoryExtensionMenuLinkView.Execute(null);
	  _regionManagerMock.Verify(x => x.RequestNavigate(It.IsAny<string>(), It.IsAny<Uri>(), It.IsAny<Action<NavigationResult>>()));
	}
  }
}
