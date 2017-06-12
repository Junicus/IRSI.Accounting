using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common.Models;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.Sales.Models;

namespace IRSI.Accounting.Modules.Sales.Services
{
  public class RMGSalesLineParser : ISalesLineParser
  {
	private readonly ISalesImportConfiguration _configurationService;
	private readonly IStoresRepository _storesRepository;
	private Store _currentStore;

	public RMGSalesLineParser(ISalesImportConfiguration configurationService, IStoresRepository storesRepository)
	{
	  _configurationService = configurationService;
	  _storesRepository = storesRepository;
	}

	public IEnumerable<SalesItemData> ParseLine(string line)
	{
	  List<SalesItemData> results = new List<SalesItemData>();

	  SetCurrentStore(line);

	  results.Add(GetItemData(line, "Food Sales"));
	  results.Add(GetItemData(line, "NA Bev Sales"));
	  results.Add(GetItemData(line, "Liquor Sales"));
	  results.Add(GetItemData(line, "Beer Sales"));
	  results.Add(GetItemData(line, "Wine Sales"));
	  results.Add(GetItemData(line, "Special Activity"));
	  results.Add(GetItemData(line, "Gift Card Sales"));
	  results.Add(GetItemData(line, "Other Income Sales"));
	  results.Add(GetItemData(line, "Service Charge"));
	  results.Add(GetItemData(line, "Taxes"));

	  results.Add(GetItemData(line, "Empl Comps"));
	  results.Add(GetItemData(line, "Client Comps"));
	  results.Add(GetItemData(line, "Irsi Comps"));
	  results.Add(GetItemData(line, "Special Liquor Promo"));
	  results.Add(GetItemData(line, "Facebook Promo"));
	  results.Add(GetItemData(line, "Promo"));

	  results.Add(GetItemData(line, "BOG Payment"));
	  results.Add(GetItemData(line, "iEat"));
	  results.Add(GetItemData(line, "GC Payment"));
	  results.Add(GetItemData(line, "Amex Payment"));
	  results.Add(GetItemData(line, "Visa/MC Payment"));
	  results.Add(GetItemData(line, "ATH Payment"));
	  results.Add(GetItemData(line, "Discover Payment"));
	  results.Add(GetItemData(line, "CC Offline Payment"));
	  results.Add(GetItemData(line, "Deposits"));

	  results.Add(GetItemData(line, "Petty"));

	  var totalCredits = results.Sum(i => i.Credit);
	  var totalDebits = results.Sum(i => i.Debit);
	  var configOverShort = _configurationService.GetConfiguration("200", "Over/Short");
	  var itemOverShort = new SalesItemData()
	  {
		Store = results.First().Store,
		StoreNumber = results.First().StoreNumber,
		AccountName = "Over/Short",
		AccountNumber = GetAccountNumber(configOverShort, _currentStore),
		Amount = (totalCredits + totalDebits) * -1
	  };

	  if (itemOverShort.Amount < 0)
	  {
		itemOverShort.Debit = Math.Abs(itemOverShort.Amount);
	  }
	  else
	  {
		itemOverShort.Credit = Math.Abs(itemOverShort.Amount);
	  }

	  results.Add(itemOverShort);
	  return results;
	}

	private string GetAccountNumber(AccountConfig accountConfig, Store store)
	{
	  var accountNumber = string.Empty;
	  switch (accountConfig.CostCenterType)
	  {
		case CostCenterTypes.None:
		  accountNumber = accountConfig.AccountNumber;
		  break;
		case CostCenterTypes.Concept:
		  accountNumber = accountConfig.AccountNumber + "-" + accountConfig.Concept;
		  break;
		case CostCenterTypes.Office:
		  accountNumber = accountConfig.AccountNumber + "-099";
		  break;
		case CostCenterTypes.Store:
		  accountNumber = accountConfig.AccountNumber + "-" + store.Number;
		  break;
	  }
	  return accountNumber;
	}

	private decimal GetAmount(string amountText, AccountConfig accountConfig)
	{
	  var amount = Convert.ToDecimal(amountText);
	  switch (accountConfig.SignType)
	  {
		case SignTypes.Credit:
		  return Math.Abs(amount) * -1;
		case SignTypes.Debit:
		  return Math.Abs(amount);
	  }
	  return 0;
	}

	private void SetCurrentStore(string line)
	{
	  var parts = line.Split('\t');
	  _currentStore = _storesRepository.GetStoreByInsightName(parts[1].Replace("\"", ""));
	}

	private SalesItemData GetItemData(string line, string accountName)
	{
	  var parts = line.Split('\t');
	  var accountConfig = _configurationService.GetConfiguration("200", accountName);

	  var accountNumber = GetAccountNumber(accountConfig, _currentStore);
	  var amount = GetAmount(parts[accountConfig.Column], accountConfig);

	  var result = new SalesItemData()
	  {
		Store = _currentStore.Name,
		StoreNumber = _currentStore.Number,
		AccountName = accountConfig.AccountName,
		AccountNumber = accountNumber,
		Amount = amount
	  };

	  if (amount < 0)
	  {
		result.Credit = amount;
	  }
	  else
	  {
		result.Debit = amount;
	  }

	  return result;
	}
  }
}
