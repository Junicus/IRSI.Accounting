using System;
using System.Collections.Generic;
using IO = System.IO;
using System.Linq;
using IRSI.Accounting.Common.Models;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.InventoryExtension.Exceptions;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using IRSI.Accounting.Modules.InventoryExtension.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IRSI.Accounting.Models.InventoryExtension.Tests
{
  [TestClass]
  public class InventoryExtensionMenuLinkParserTests
  {
	private Account account1 = new Account() { Name = "Account1", Number = "1" };
	private Account account2 = new Account() { Name = "Account2", Number = "1" };
	private Concept concept1 = new Concept { Id = 1, Name = "Concept 1", Number = "1" };
	private Store store1;

	private readonly List<string> _goodData = new List<string>();
	private readonly List<string> _badData = new List<string>();

	private readonly Mock<IStoresRepository> _storeRepo = new Mock<IStoresRepository>();
	private readonly Mock<IInventoryChartOfAccounts> _chartOfAccounts = new Mock<IInventoryChartOfAccounts>();
	private readonly IInventoryExtensionLineParser _lineParser;
	private readonly Mock<IInventoryExtensionFileReader> _fileReaderMock = new Mock<IInventoryExtensionFileReader>();

	private readonly InventoryExtensionMenuLinkParser _subject;

	public InventoryExtensionMenuLinkParserTests()
	{
	  store1 = new Store { Id = 1, Name = "Store1", Concept = concept1, Number = "1", InsightName = "1 Store 1" };

	  _chartOfAccounts.Setup(x => x.FindAccount(concept1.Name, account1.Name)).Returns(account1);
	  _chartOfAccounts.Setup(x => x.FindAccount(concept1.Name, account2.Name)).Returns(account2);
	  _chartOfAccounts.Setup(x => x.FindAccount(concept1.Name, "BADACCOUNT")).Returns<Account>(null);

	  _lineParser = new InventoryExtensionLineParser(_chartOfAccounts.Object);

	  _goodData.Add("1 Store1,Test");
	  _goodData.Add("Total:,Account1,$186.99");
	  _goodData.Add("Total:,Account2,$830.95");

	  _badData.Add("INVALID");

	  _storeRepo.Setup(x => x.GetStores()).Returns(new List<Store> { store1 });

	  _fileReaderMock.Setup(x => x.ReadFile("INVALIDNAME")).Throws(new InvalidFileNameException());
	  _fileReaderMock.Setup(x => x.ReadFile("VALIDNAMEINVALIDDATA")).Returns(_badData);
	  _fileReaderMock.Setup(x => x.ReadFile("VALIDNAME")).Returns(_goodData);

	  _subject = new InventoryExtensionMenuLinkParser(_storeRepo.Object, _lineParser, _fileReaderMock.Object);
	}

	[TestMethod]
	[ExpectedException(typeof(InvalidFileNameException))]
	public void ParseFileWithInvalidFilenameThrowsInvalidFileNameException()
	{
	  _subject.ParseFile("INVALIDNAME");
	}

	[TestMethod]
	[ExpectedException(typeof(InvalidDataException))]
	public void ParseFileWithValidFilenameInvalidDataThrowsInvalidDataException()
	{
	  _subject.ParseFile("VALIDNAMEINVALIDDATA");
	}

	[TestMethod]
	public void ParseFileWithValidFilenameValidDataReturnsListOfInventoryExtensionItem()
	{
	  var results = _subject.ParseFile("VALIDNAME");
	  Assert.IsNotNull(results);
	  Assert.AreEqual(2, results.Count());
	}

	[TestMethod]
	public void ParseFileIntegrationTest()
	{
	  var concept = new Concept { Id = 3, Name = "On The Border", Number = "300" };
	  var store = new Store { Id = 30, Name = "301 OTB Guaynabo", Concept = concept, Number = "301", InsightName = "01 OTB Plaza Guaynabo" };
	  Mock<IStoresRepository> mockRepo = new Mock<IStoresRepository>();
	  mockRepo.Setup(x => x.GetStores()).Returns(new List<Store> { store });

	  var subject = new InventoryExtensionMenuLinkParser(mockRepo.Object,
		new InventoryExtensionLineParser(new InventoryChartOfAccounts()),
		new InventoryExtensionFileReader());

	  var results = subject.ParseFile("301.txt");
	  Assert.IsNotNull(results);
	  Assert.AreEqual(17, results.Count());
	}
  }
}
