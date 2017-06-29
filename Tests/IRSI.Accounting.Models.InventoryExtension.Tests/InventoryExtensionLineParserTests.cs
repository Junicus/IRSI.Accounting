using System;
using System.Collections.Generic;
using IRSI.Accounting.Common.Models;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using IRSI.Accounting.Modules.InventoryExtension.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IRSI.Accounting.Models.InventoryExtension.Tests
{
  [TestClass]
  public class InventoryExtensionLineParserTests
  {
	private readonly Mock<IStoresRepository> _storeRepo = new Mock<IStoresRepository>();
	private readonly Mock<IInventoryChartOfAccounts> _chartOfAccounts = new Mock<IInventoryChartOfAccounts>();
	private readonly List<Concept> _concepts = new List<Concept>();
	private readonly List<Store> _stores = new List<Store>();
	private readonly List<Account> _accounts = new List<Account>();

	private readonly InventoryExtensionLineParser _subject;

	public InventoryExtensionLineParserTests()
	{
	  _concepts.Add(new Concept { Id = 1, Name = "Concept 1", Number = "1" });
	  _stores.Add(new Store { Id = 1, Name = "Store 1", Concept = _concepts[0], Number = "1", InsightName = "1 Store 1" });
	  _accounts.Add(new Account() { Name = "Account1", Number = "1" });

	  _storeRepo.Setup(x => x.GetStores()).Returns(_stores);
	  _chartOfAccounts.Setup(x =>
		x.FindAccount(It.Is<string>(arg => arg == _concepts[0].Name), It.Is<string>(arg => arg == _accounts[0].Name)))
		.Returns(_accounts[0]);
	  _chartOfAccounts.Setup(x =>
		x.FindAccount(It.IsAny<string>(), It.IsAny<string>()))
		.Returns<Account>(null);

	  _subject = new InventoryExtensionLineParser(_storeRepo.Object, _chartOfAccounts.Object);
	}

	[TestMethod]
	public void ParseLineIsNullWhenLineHasNoSplit()
	{
	  var storeNumber = "1";
	  var test = "TEST";
	  var result = _subject.ParseLine(storeNumber, test);
	  Assert.IsNull(result);
	}

	[TestMethod]
	public void ParseLineIsNullWhenLineHasSplitButAccountIsInvalid()
	{
	  var storeNumber = "1";
	  var test = "TEST1, TEST2";
	  var result = _subject.ParseLine(storeNumber, test);
	  Assert.IsNull(result);
	}

	[TestMethod]
	public void ParseLineIsNotNullWhenCorrectFormat()
	{
	  var storeNumber = "1";
	  var test = "Total:,Account1,$186.99";
	  _chartOfAccounts.Setup(x =>
	  x.FindAccount(It.Is<string>(arg => arg == _concepts[0].Name), It.Is<string>(arg => arg == _accounts[0].Name)))
	  .Returns(_accounts[0]);

	  var result = _subject.ParseLine(storeNumber, test);
	  Assert.IsNotNull(result);
	  Assert.AreEqual("Store 1", result.Store);
	  Assert.AreEqual("Account1", result.AccountName);
	  Assert.AreEqual("1-1", result.AccountNumber);
	  Assert.AreEqual(186.99m, result.Amount);
	}

	[TestMethod]
	public void ParseLineIsNotNullWhenCorrectFormatHasThousands()
	{
	  var storeNumber = "1";
	  var test = "Total:,Account1,$1,186.99";
	  _chartOfAccounts.Setup(x =>
	  x.FindAccount(It.Is<string>(arg => arg == _concepts[0].Name), It.Is<string>(arg => arg == _accounts[0].Name)))
	  .Returns(_accounts[0]);

	  var result = _subject.ParseLine(storeNumber, test);
	  Assert.IsNotNull(result);
	  Assert.AreEqual("Store 1", result.Store);
	  Assert.AreEqual("Account1", result.AccountName);
	  Assert.AreEqual("1-1", result.AccountNumber);
	  Assert.AreEqual(1186.99m, result.Amount);
	}

  }
}
