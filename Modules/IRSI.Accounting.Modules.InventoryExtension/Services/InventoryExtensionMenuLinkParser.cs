using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common.Models;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.InventoryExtension.Exceptions;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using NLog;

namespace IRSI.Accounting.Modules.InventoryExtension.Services
{
  public class InventoryExtensionMenuLinkParser : IInventoryExtensionParser
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();
	private readonly IInventoryExtensionFileReader _fileReader;
	private readonly IInventoryExtensionLineParser _lineParser;
	private readonly IStoresRepository _storeRepository;
	private IEnumerable<Store> _stores = null;

	public InventoryExtensionMenuLinkParser(IStoresRepository storeRepository, IInventoryExtensionLineParser lineParser, IInventoryExtensionFileReader fileReader)
	{
	  _storeRepository = storeRepository;
	  _lineParser = lineParser;
	  _fileReader = fileReader;
	}

	public IEnumerable<InventoryExtensionItem> ParseFile(string filename)
	{
	  var lines = _fileReader.ReadFile(filename);
	  var store = GetStore(lines);
	  return GetItems(lines, store);
	}

	private Store GetStore(IEnumerable<string> lines)
	{
	  string storeNumber = GetStoreNumber(lines);
	  LoadStores();
	  var store = _stores.SingleOrDefault(s => s.Number == storeNumber);
	  if (store == null)
		throw new Exceptions.InvalidDataException();
	  return store;
	}

	private static string GetStoreNumber(IEnumerable<string> lines)
	{
	  var storeNumber = string.Empty;
	  if (lines.Any())
		storeNumber = lines.First().Split(' ')[0];
	  return storeNumber;
	}

	private void LoadStores()
	{
	  if (_stores == null)
	  {
		_stores = _storeRepository.GetStores();
	  }
	}

	private List<InventoryExtensionItem> GetItems(IEnumerable<string> lines, Store store)
	{
	  var items = new List<InventoryExtensionItem>();
	  foreach (var line in lines)
	  {
		var item = _lineParser.ParseLine(store, line);
		if (item != null)
		  items.Add(item);
	  }
	  return items;
	}
  }
}
