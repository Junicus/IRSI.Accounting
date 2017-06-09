using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common.Models;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using NLog;
using Excel = Microsoft.Office.Interop.Excel;

namespace IRSI.Accounting.Modules.InventoryExtension.Services
{
  public class InventoryExtensionIslandWideParser : IInventoryExtensionParser
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();
	private readonly IStoresRepository _storeRepository;
	private readonly IInventoryChartOfAccounts _chartOfAccounts;
	private IEnumerable<Store> _stores;

	public InventoryExtensionIslandWideParser(IStoresRepository storesRepository, IInventoryChartOfAccounts chartOfAccounts)
	{
	  _storeRepository = storesRepository;
	  _chartOfAccounts = chartOfAccounts;
	}

	public IEnumerable<InventoryExtensionItem> ParseFile(string filename)
	{
	  List<InventoryExtensionItem> items = new List<InventoryExtensionItem>();

	  log.Debug("Starting Excel");
	  var excelApp = new Excel.Application();
	  excelApp.Visible = false;

	  try
	  {
		if (_stores == null)
		{
		  _stores = _storeRepository.GetStores();
		}

		log.Debug(string.Format("Opening file: {0}", filename));
		Excel.Workbook file = excelApp.Workbooks.Open(filename);
		Excel.Worksheet sheet1 = (Excel.Worksheet)file.Worksheets[1];

		log.Debug("Start parsing file");
		var currLine = 2;
		do
		{
		  string flagCell = sheet1.Cells[currLine, "A"].Value2.ToString();

		  int storeId = 0;
		  if (int.TryParse(sheet1.Cells[currLine, "A"].Value2.ToString(), out storeId))
		  {
			var store = (from s in _stores
						 where s.Number == storeId.ToString()
						 select s).SingleOrDefault();
			string amountText = sheet1.Cells[currLine, "E"].Value2.ToString();
			string accountName = sheet1.Cells[currLine, "C"].Value2.ToString();
			var account = _chartOfAccounts.FindAccount(store.Concept.Name, accountName);
			if (account != null)
			{
			  var item = new InventoryExtensionItem();
			  item.Store = store.Name;
			  item.AccountNumber = account.Number + "-" + store.Number;
			  item.AccountName = account.Name;
			  var amount = 0.0m;
			  decimal.TryParse(amountText, out amount);
			  item.Amount = Math.Round(amount, 2);
			  if (account.IsTaxable)
			  {
				var tax = amount * 0.115m;
				item.Tax = Math.Round(tax, 2);
			  }
			  else
			  {
				item.Tax = 0.0m;
			  }

			  items.Add(item);
			}
		  }
		  else if (
			  sheet1.Cells[currLine, "A"].Value2.ToString() != "Totals" &&
			  sheet1.Cells[currLine, "A"].Value2.ToString() != "Gran Total")
		  {
			string amountText = sheet1.Cells[currLine, "E"].Value2.ToString();
			var item = new InventoryExtensionItem();
			item.Store = "Office";
			item.AccountNumber = "1360-099";
			item.AccountName = "Office";
			var amount = 0.0m;
			decimal.TryParse(amountText, out amount);
			item.Amount = Math.Round(amount, 2);
			item.Tax = 0.0m;

			items.Add(item);
		  }
		  currLine += 1;
		} while (sheet1.Cells[currLine, "A"].Value2 != null);
	  }
	  catch (Exception e)
	  {
		log.Error(e, $"Exception parsing excel file: {filename}");
	  }
	  finally
	  {
		excelApp.Quit();
		excelApp = null;
	  }

	  return items;
	}
  }
}
