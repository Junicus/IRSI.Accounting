using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using NLog;

namespace IRSI.Accounting.Modules.InventoryExtension.Services
{
  public class InventoryExtensionMenuLinkParser : IInventoryExtensionParser
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();
	private readonly IInventoryExtensionLineParser _lineParser;

	public InventoryExtensionMenuLinkParser(IInventoryExtensionLineParser lineParser)
	{
	  _lineParser = lineParser;
	}

	public IEnumerable<InventoryExtensionItem> ParseFile(string filename)
	{
	  List<InventoryExtensionItem> items = new List<InventoryExtensionItem>();
	  try
	  {
		var lines = File.ReadAllLines(filename);
		var storeNumber = lines[0].Split(' ')[0];
		foreach (var line in lines)
		{
		  var item = _lineParser.ParseLine(storeNumber, line);
		  if (item != null)
		  {
			items.Add(item);
		  }
		}
	  }
	  catch (Exception ex)
	  {
		log.Error(ex);
	  }
	  return items;
	}
  }
}
