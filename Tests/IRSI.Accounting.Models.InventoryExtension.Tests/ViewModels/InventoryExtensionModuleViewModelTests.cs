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
  public class InventoryExtensionModuleViewModelTests
  {
	private readonly Mock<NavigationCompletedEvent> _event = new Mock<NavigationCompletedEvent>();
	private readonly Mock<IRegionManager> _regionManagerMock = new Mock<IRegionManager>();
	private readonly Mock<IEventAggregator> _eventAggregatorMock = new Mock<IEventAggregator>();

	private readonly InventoryExtensionModuleViewModel _subject;

	public InventoryExtensionModuleViewModelTests()
	{
	  //_event.Setup(x => x.Subscribe(It.IsAny<Action<string>>(), ThreadOption.UIThread));
	  _eventAggregatorMock.Setup(x => x.GetEvent<NavigationCompletedEvent>()).Returns(_event.Object);
	  _subject = new InventoryExtensionModuleViewModel(_regionManagerMock.Object, _eventAggregatorMock.Object);
	}

	[TestMethod]
	public void NewInventoryExtensionGetsEvent()
	{
	  Mock<NavigationCompletedEvent> navevent = new Mock<NavigationCompletedEvent>();
	  Mock<IRegionManager> regionManagerMock = new Mock<IRegionManager>();
	  Mock<IEventAggregator> eventAggregatorMock = new Mock<IEventAggregator>();

	  //navevent.Setup(x => x.Subscribe(It.IsAny<Action<string>>(), ThreadOption.UIThread));
	  eventAggregatorMock.Setup(x => x.GetEvent<NavigationCompletedEvent>()).Returns(navevent.Object);
	  InventoryExtensionModuleViewModel subject = new InventoryExtensionModuleViewModel(regionManagerMock.Object, eventAggregatorMock.Object);

	  eventAggregatorMock.Verify(x => x.GetEvent<NavigationCompletedEvent>());
	}

	[TestMethod]
	public void NewInventoryExtensionHasCommand()
	{
	  Assert.IsNotNull(_subject.ShowInventoryExtensionView);
	}

	[TestMethod]
	public void NewInventoryIsNavigationTargetIsFalse()
	{
	  Assert.IsFalse(_subject.IsNavigationTarget(null));
	}

	[TestMethod]
	public void ExecutingShowInventoryCallsRequestNavigateOnRegionManager()
	{
	  _subject.ShowInventoryExtensionView.Execute(null);
	  _regionManagerMock.Verify(x => x.RequestNavigate(It.IsAny<string>(), It.IsAny<Uri>(), It.IsAny<Action<NavigationResult>>()));
	}
  }
}
