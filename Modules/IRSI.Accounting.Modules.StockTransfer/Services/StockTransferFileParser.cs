using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IRSI.Accounting.Common.Models;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.StockTransfer.Models;
using NLog;

namespace IRSI.Accounting.Modules.StockTransfer.Services
{
  public class StockTransferFileParser : IStockTransferFileParser
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();
	private readonly IStoresRepository _storesRepository;
	private IEnumerable<Store> _stores;

	public Regex _storesTransferInStart = new Regex(".+ to .+", RegexOptions.Compiled);
	public Regex _storesTransferOutStart = new Regex(".+ from .+", RegexOptions.Compiled);
	public Regex _storeNumbers = new Regex("[0-9]{1,3}", RegexOptions.Compiled);

	public StockTransferFileParser(IStoresRepository storesRepository)
	{
	  _storesRepository = storesRepository;
	}

	public StockTransferResult ParseFile(string filePath, string concept)
	{
	  if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException("filePath");
	  if (!File.Exists(filePath)) throw new ArgumentOutOfRangeException("filePath", "File does not exis in filesystem");

	  var result = new StockTransferResult();
	  result.TransferIns = new List<StockTransferItemData>();
	  result.TransferOuts = new List<StockTransferItemData>();

	  var lines = File.ReadAllLines(filePath);
	  StockTransferItemData currentTransfer = null;
	  var startParsing = false;
	  var currentFrom = string.Empty;
	  var currentTo = string.Empty;

	  //Process transfer ins
	  foreach (var line in lines)
	  {
		if (line.StartsWith("Transfer Total:") ||
			line.StartsWith("V 14.2.499.0") ||
			line.StartsWith("Multiple Selection") ||
			line.StartsWith("Description"))
		{
		  continue;
		}

		if (line.StartsWith("Transfer In Total"))
		{
		  startParsing = false;
		  break;
		}

		if (line.StartsWith("Transfer In"))
		{
		  startParsing = true;
		  continue;
		}

		if (startParsing)
		{
		  if (_storesTransferInStart.IsMatch(line))
		  {
			var matches = _storeNumbers.Matches(line);
			currentFrom = matches[0].ToString();
			currentTo = matches[1].ToString();
		  }
		  else if (line.StartsWith("Transfer:"))
		  {
			currentTransfer = new StockTransferItemData();
			var parts = line.Split(new char[] { ',' });
			currentTransfer.From = currentFrom;
			currentTransfer.To = currentTo;
			currentTransfer.TransferDate = DateTime.ParseExact(parts.Last(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
			result.TransferIns.Add(currentTransfer);
		  }
		  else
		  {
			var parts = line.Split(new char[] { ',' });
			var stockTransferLine = new StockTransferLineItemData();
			if (parts.Count() == 6)
			{
			  stockTransferLine.ItemName = parts[0];
			  stockTransferLine.Account = parts[1];
			  stockTransferLine.UnitAmount = decimal.Parse(parts[2]);
			  stockTransferLine.Unit = parts[3];
			  stockTransferLine.UnitCost = decimal.Parse(parts[4], NumberStyles.Currency);
			  stockTransferLine.Total = decimal.Parse(parts[5], NumberStyles.Currency);
			  currentTransfer.Lines.Add(stockTransferLine);
			}
			else
			{
			  stockTransferLine.ItemName = $"{parts[0]}, {parts[1]}";
			  stockTransferLine.Account = parts[2];
			  stockTransferLine.UnitAmount = decimal.Parse(parts[3]);
			  stockTransferLine.Unit = parts[4];
			  stockTransferLine.UnitCost = decimal.Parse(parts[5], NumberStyles.Currency);
			  stockTransferLine.Total = decimal.Parse(parts[6], NumberStyles.Currency);
			  currentTransfer.Lines.Add(stockTransferLine);
			}
		  }
		}
	  }

	  startParsing = false;
	  //Process Transfer outs
	  foreach (var line in lines)
	  {
		if (line.StartsWith("Transfer Total:") ||
			line.StartsWith("V 14.2.499.0") ||
			line.StartsWith("Multiple Selection") ||
			line.StartsWith("Description"))
		{
		  continue;
		}

		if (line.StartsWith("Transfer Out Total"))
		{
		  startParsing = false;
		  break;
		}


		if (line.StartsWith("Transfer Out"))
		{
		  startParsing = true;
		  continue;
		}

		if (startParsing)
		{
		  if (_storesTransferOutStart.IsMatch(line))
		  {
			var matches = _storeNumbers.Matches(line);
			currentTo = matches[0].ToString();
			currentFrom = matches[1].ToString();
			continue;
		  }

		  if (line.StartsWith("Transfer:"))
		  {
			currentTransfer = new StockTransferItemData();
			var parts = line.Split(new char[] { ',' });
			currentTransfer.From = currentFrom;
			currentTransfer.To = currentTo;
			currentTransfer.TransferDate = DateTime.ParseExact(parts.Last(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
			result.TransferOuts.Add(currentTransfer);
		  }
		  else
		  {
			var parts = line.Split(new char[] { ',' });
			var stockTransferLine = new StockTransferLineItemData();
			if (parts.Count() == 6)
			{
			  stockTransferLine.ItemName = parts[0];
			  stockTransferLine.Account = parts[1];
			  stockTransferLine.UnitAmount = decimal.Parse(parts[2]);
			  stockTransferLine.Unit = parts[3];
			  stockTransferLine.UnitCost = decimal.Parse(parts[4], NumberStyles.Currency);
			  stockTransferLine.Total = decimal.Parse(parts[5], NumberStyles.Currency);
			  currentTransfer.Lines.Add(stockTransferLine);
			}
			else
			{
			  stockTransferLine.ItemName = $"{parts[0]}, {parts[1]}";
			  stockTransferLine.Account = parts[2];
			  stockTransferLine.UnitAmount = decimal.Parse(parts[3]);
			  stockTransferLine.Unit = parts[4];
			  stockTransferLine.UnitCost = decimal.Parse(parts[5], NumberStyles.Currency);
			  stockTransferLine.Total = decimal.Parse(parts[6], NumberStyles.Currency);
			  currentTransfer.Lines.Add(stockTransferLine);
			}
		  }
		}
	  }

	  return result;
	}

	public async Task<StockTransferResult> ParseFileAsync(string filePath, string concept)
	{
	  var result = await Task.Factory.StartNew(() => { return ParseFile(filePath, concept); });
	  return result;
	}
  }
}
