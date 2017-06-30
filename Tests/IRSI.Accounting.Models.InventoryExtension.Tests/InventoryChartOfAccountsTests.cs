using System;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using IRSI.Accounting.Modules.InventoryExtension.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IRSI.Accounting.Models.InventoryExtension.Tests
{
  [TestClass]
  public class InventoryChartOfAccountsTests
  {
	private readonly InventoryChartOfAccounts _subject;

	public InventoryChartOfAccountsTests()
	{
	  _subject = new InventoryChartOfAccounts();
	}

	[TestMethod]
	public void FindAccountShouldReturnNullWhenAccountNotFound()
	{
	  var result = _subject.FindAccount("Chili's Grill & Bar", "INVALIDNAME");
	  Assert.IsNull(result);
	}

	[TestMethod]
	public void FindAccountShouldReturnNullWhenConceptNotFound()
	{
	  var result = _subject.FindAccount("INVALIDNAME", "COGS - BAKERY");
	  Assert.IsNull(result);
	}

	[TestMethod]
	public void FindAccountShouldReturnAccountWhenValidConceptValidAccount()
	{
	  var result = _subject.FindAccount("Chili's Grill & Bar", "COGS - BAKERY");
	  Assert.IsNotNull(result);
	  Assert.IsInstanceOfType(result, typeof(Account));
	}
  }
}
