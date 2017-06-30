using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common.Models;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.InventoryExtension.Models;

namespace IRSI.Accounting.Modules.InventoryExtension.Services
{
  public class InventoryExtensionLineParser : IInventoryExtensionLineParser
  {
	private readonly IInventoryChartOfAccounts _chartOfAccounts;

	public InventoryExtensionLineParser(IInventoryChartOfAccounts chartOfAccounts)
	{
	  _chartOfAccounts = chartOfAccounts;
	}

	public InventoryExtensionItem ParseLine(Store store, string line)
	{
	  var parts = line.Split(',');
	  if (parts.Length <= 1 || !parts[0].StartsWith("Total:"))
		return null;

	  var returnvalue = new InventoryExtensionItem();

	  var accountName = parts[1];
	  var account = _chartOfAccounts.FindAccount(store.Concept.Name, accountName);
	  if (account == null) { return null; }

	  var amount = 0.0m;
	  if (account != null)
	  {
		returnvalue.Store = store.Name;
		returnvalue.AccountNumber = account.Number + "-" + store.Number;
		returnvalue.AccountName = account.Name;
		var amountstring = string.Empty;
		if (parts.Length > 3)
		{
		  for (var i = 2; i < parts.Length; i++)
		  {
			amountstring += parts[i];
		  }
		}
		else
		{
		  amountstring = parts[2];
		}
		amountstring = amountstring.Replace("$", string.Empty);
		decimal.TryParse(amountstring, out amount);
		returnvalue.Amount = amount;
	  }

	  return returnvalue;
	}
  }
}
