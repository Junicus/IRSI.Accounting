using System;
using System.Linq;
using IRSI.Accounting.Modules.InventoryExtension.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IRSI.Accounting.Models.InventoryExtension.Tests
{
  [TestClass]
  public class InventoryExtensionFileReaderTests
  {
	public readonly InventoryExtensionFileReader _subject;

	public InventoryExtensionFileReaderTests()
	{
	  _subject = new InventoryExtensionFileReader();
	}

	[TestMethod]
	public void ReadFileShouldReturnEmptyListWhenFileNotFound()
	{
	  var result = _subject.ReadFile("FILENOTFOUND");
	  Assert.IsNotNull(result);
	  Assert.IsFalse(result.Any());
	}

	[TestMethod]
	public void ReadFileShouldReturnListOfStringsWhenFileFound()
	{
	  var result = _subject.ReadFile("301.txt");
	  Assert.IsNotNull(result);
	  Assert.IsTrue(result.Any());
	}
  }
}
