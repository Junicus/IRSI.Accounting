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
	private readonly Store _store;
	private readonly Concept _concept;
	private readonly Mock<IInventoryChartOfAccounts> _chartOfAccounts = new Mock<IInventoryChartOfAccounts>();
	private readonly List<Account> _accounts = new List<Account>();

	private readonly InventoryExtensionLineParser _subject;

	public InventoryExtensionLineParserTests()
	{
	  _concept = new Concept { Id = 1, Name = "Concept 1", Number = "1" };

	  _store = new Store
	  {
		Id = 1,
		Name = "Store 1",
		Concept = _concept,
		Number = "1",
		InsightName = "1 Store 1"
	  };

	  _accounts.Add(new Account() { Name = "Account1", Number = "1" });

	  _chartOfAccounts.Setup(x => x.FindAccount("Concept 1", _accounts[0].Name)).Returns(_accounts[0]);
	  _chartOfAccounts.Setup(x => x.FindAccount("Concept 1", "BADACCOUNT")).Returns<Account>(null);
	  _chartOfAccounts.Setup(x => x.FindAccount(It.IsAny<string>(), It.IsAny<string>())).Returns<Account>(null);

	  _subject = new InventoryExtensionLineParser(_chartOfAccounts.Object);
	}

	[TestMethod]
	public void ParseLineIsNullWhenLineHasNoSplit()
	{
	  var test = "TEST";
	  var result = _subject.ParseLine(_store, test);
	  Assert.IsNull(result);
	}

	[TestMethod]
	public void ParseLineIsNullWhenLineHasSplitButAccountIsInvalid()
	{
	  var test = "TEST1, TEST2";
	  var result = _subject.ParseLine(_store, test);
	  Assert.IsNull(result);
	}

	[TestMethod]
	public void ParseLineIsNullWhenCorrectFormatButAccountInvalid()
	{
	  var test = "Total:,BADACCOUNT,$186.99";
	  _chartOfAccounts.Setup(x =>
	  x.FindAccount(_concept.Name, It.Is<string>(arg => arg == _accounts[0].Name)))
	  .Returns(_accounts[0]);
	  var result = _subject.ParseLine(_store, test);
	  Assert.IsNull(result);
	}

	[TestMethod]
	public void ParseLineIsNotNullWhenCorrectFormat()
	{
	  var test = "Total:,Account1,$186.99";
	  _chartOfAccounts.Setup(x =>
	  x.FindAccount(_concept.Name, It.Is<string>(arg => arg == _accounts[0].Name)))
	  .Returns(_accounts[0]);

	  var result = _subject.ParseLine(_store, test);
	  Assert.IsNotNull(result);
	  Assert.AreEqual(_store.Name, result.Store);
	  Assert.AreEqual(_accounts[0].Name, result.AccountName);
	  Assert.AreEqual("1-1", result.AccountNumber);
	  Assert.AreEqual(186.99m, result.Amount);
	}

	[TestMethod]
	public void ParseLineIsNotNullWhenCorrectFormatHasThousands()
	{
	  var test = "Total:,Account1,$1,186.99";
	  _chartOfAccounts.Setup(x =>
	  x.FindAccount(_concept.Name, It.Is<string>(arg => arg == _accounts[0].Name)))
	  .Returns(_accounts[0]);

	  var result = _subject.ParseLine(_store, test);
	  Assert.IsNotNull(result);
	  Assert.AreEqual(_store.Name, result.Store);
	  Assert.AreEqual(_accounts[0].Name, result.AccountName);
	  Assert.AreEqual("1-1", result.AccountNumber);
	  Assert.AreEqual(1186.99m, result.Amount);
	}

  }
}
