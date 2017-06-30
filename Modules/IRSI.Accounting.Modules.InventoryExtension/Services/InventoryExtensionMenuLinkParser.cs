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
	private IEnumerable<Store> _stores = null;
	private static readonly Logger log = LogManager.GetCurrentClassLogger();
	private readonly IInventoryExtensionLineParser _lineParser;
	private readonly IInventoryExtensionFileReader _fileReader;
	private readonly IStoresRepository _storeRepository;

	public InventoryExtensionMenuLinkParser(IStoresRepository storeRepository, IInventoryExtensionLineParser lineParser, IInventoryExtensionFileReader fileReader)
	{
	  _storeRepository = storeRepository;
	  _lineParser = lineParser;
	  _fileReader = fileReader;
	}

	public IEnumerable<InventoryExtensionItem> ParseFile(string filename)
	{
	  var lines = _fileReader.ReadFile(filename);
	  var storeNumber = string.Empty;
	  if (lines.Any())
		storeNumber = lines.First().Split(' ')[0];
	  if (_stores == null)
	  {
		_stores = _storeRepository.GetStores();
	  }
	  var store = _stores.SingleOrDefault(s => s.Number == storeNumber);
	  if (store == null)
	  {
		throw new Exceptions.InvalidDataException();
	  }

	  List<InventoryExtensionItem> items = new List<InventoryExtensionItem>();
	  foreach (var line in lines)
	  {
		var item = _lineParser.ParseLine(store, line);
		if (item != null)
		{
		  items.Add(item);
		}
	  }
	  return items;
	}
  }
}
