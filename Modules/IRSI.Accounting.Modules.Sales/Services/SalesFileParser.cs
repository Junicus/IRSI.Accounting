using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using IRSI.Accounting.Common.Models;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.Sales.Models;
using NLog;

namespace IRSI.Accounting.Modules.Sales.Services
{
  public class SalesFileParser : ISalesFileParser
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();
	private readonly IStoresRepository _storesRepsitory;
	private readonly IIndex<string, ISalesLineParser> _lineParsers;
	IEnumerable<Store> _stores;

	public SalesFileParser(IIndex<string, ISalesLineParser> lineParsers, IStoresRepository storesRepository)
	{
	  _lineParsers = lineParsers;
	  _storesRepsitory = storesRepository;
	}

	private IEnumerable<SalesItemData> ParseFile(string filePath)
	{
	  if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException("filePath");
	  if (!File.Exists(filePath)) throw new ArgumentOutOfRangeException("filePath", "File does not exist in filesystem");

	  var results = new List<SalesItemData>();

	  var lines = File.ReadAllLines(filePath);
	  var concept = DetermineConcept(lines[0]);

	  foreach (var line in lines)
	  {
		if (DetermineIsStoreEntry(line))
		{
		  ISalesLineParser parser = null;
		  switch (concept)
		  {
			case "100":
			  parser = _lineParsers[typeof(CGBSalesLineParser).Name];
			  break;
			case "200":
			  parser = _lineParsers[typeof(RMGSalesLineParser).Name];
			  break;
			case "300":
			  parser = _lineParsers[typeof(OTBSalesLineParser).Name];
			  break;
			case "400":
			  parser = _lineParsers[typeof(PFCSalesLineParser).Name];
			  break;
		  }

		  var items = parser.ParseLine(line);

		  foreach (var item in items)
		  {
			results.Add(item);
		  }
		}
	  }

	  return results;
	}

	private string DetermineConcept(string line)
	{
	  string concept = string.Empty;
	  if (line.Contains("Chilis Ledger Report"))
		concept = "100";
	  else if (line.Contains("RMG Ledger Report"))
		concept = "200";
	  else if (line.Contains("OTB Ledger 2"))
		concept = "300";
	  else if (line.Contains("PF Chang`s Ledger Report"))
		concept = "400";

	  return concept;
	}

	private bool DetermineIsStoreEntry(string line)
	{
	  if (_stores == null) _stores = _storesRepsitory.GetStores();
	  foreach (var store in _stores)
	  {
		if (line.Contains(store.InsightName))
		  return true;
	  }
	  return false;
	}

	public async Task<IEnumerable<SalesItemData>> ParseFileAsync(string filePath)
	{
	  var results = await Task.Factory.StartNew(() => { return ParseFile(filePath); });
	  return results;
	}
  }
}
