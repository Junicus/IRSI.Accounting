using System;
using System.Collections.Generic;
using System.Globalization;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using IRSI.Accounting.Modules.InventoryExtension.Views.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IRSI.Accounting.Models.InventoryExtension.Tests
{
  [TestClass]
  public class AmountSumConverterTests
  {
	InventoryExtensionItem item1 = new InventoryExtensionItem { Amount = 100.0m, Tax = 100.0m };
	InventoryExtensionItem item2 = new InventoryExtensionItem { Amount = 200.0m, Tax = 200.0m };
	InventoryExtensionItem item3 = new InventoryExtensionItem { Amount = 100.0m, Tax = 0m };
	InventoryExtensionItem item4 = new InventoryExtensionItem { Amount = 200.0m, Tax = 0m };
	InventoryExtensionItem item5 = new InventoryExtensionItem { Amount = 0m, Tax = 100m };
	InventoryExtensionItem item6 = new InventoryExtensionItem { Amount = 0m, Tax = 200m };


	private readonly AmountSumConverter _subject = new AmountSumConverter();

	[TestMethod]
	[ExpectedException(typeof(NotImplementedException))]
	public void ConvertBachShouldThrowNotImplementedException()
	{
	  _subject.ConvertBack(null, default(Type), null, CultureInfo.InvariantCulture);
	}

	[TestMethod]
	public void ConvertShouldReturn0IfNotCorrectType()
	{
	  var result = _subject.Convert(null, default(Type), null, CultureInfo.InvariantCulture);
	  Assert.AreEqual(0, result);
	}

	[TestMethod]
	public void ConvertShouldReturnSumOfItems()
	{
	  var result = _subject.Convert(new List<InventoryExtensionItem> { item1, item2 }, default(Type), null, CultureInfo.InvariantCulture);
	  Assert.AreEqual(600m, result);
	}

	[TestMethod]
	public void ConvertShouldReturnSumOfItemsMixed()
	{
	  var result = _subject.Convert(new List<InventoryExtensionItem> { item3, item5 }, default(Type), null, CultureInfo.InvariantCulture);
	  Assert.AreEqual(200m, result);
	}

	[TestMethod]
	public void ConvertShouldReturnSumOfItemsOnlyAmount()
	{
	  var result = _subject.Convert(new List<InventoryExtensionItem> { item3, item4 }, default(Type), null, CultureInfo.InvariantCulture);
	  Assert.AreEqual(300m, result);
	}

	[TestMethod]
	public void ConvertShouldReturnSumOfItemsOnlyTax()
	{
	  var result = _subject.Convert(new List<InventoryExtensionItem> { item5, item6 }, default(Type), null, CultureInfo.InvariantCulture);
	  Assert.AreEqual(300m, result);
	}
  }
}
