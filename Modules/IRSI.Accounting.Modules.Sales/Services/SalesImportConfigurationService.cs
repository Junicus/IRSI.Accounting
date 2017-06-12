using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Modules.Sales.Models;

namespace IRSI.Accounting.Modules.Sales.Services
{
  public class SalesImportConfigurationService : ISalesImportConfiguration
  {
	private IList<AccountConfig> _configurations;

	public SalesImportConfigurationService()
	{
	  _configurations = new List<AccountConfig>();

	  #region CGB Configuration
	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Food Sales",
		AccountNumber = "4110",
		CostCenterType = CostCenterTypes.Store,
		Column = 5,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "NA Bev Sales",
		AccountNumber = "4200",
		CostCenterType = CostCenterTypes.Store,
		Column = 7,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Liquor Sales",
		AccountNumber = "4263",
		CostCenterType = CostCenterTypes.Store,
		Column = 9,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Beer Sales",
		AccountNumber = "4261",
		CostCenterType = CostCenterTypes.Store,
		Column = 11,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Wine Sales",
		AccountNumber = "4262",
		CostCenterType = CostCenterTypes.Store,
		Column = 13,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Taxes",
		AccountNumber = "2324",
		CostCenterType = CostCenterTypes.Concept,
		Column = 17,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Empl Comps",
		AccountNumber = "4220",
		CostCenterType = CostCenterTypes.Store,
		Column = 18,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Client Comps",
		AccountNumber = "5331",
		CostCenterType = CostCenterTypes.Store,
		Column = 19,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Irsi Comps",
		AccountNumber = "7029",
		CostCenterType = CostCenterTypes.Office,
		Column = 20,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "BOG Payment",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 24,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "iEat",
		AccountNumber = "2326",
		CostCenterType = CostCenterTypes.Store,
		Column = 25,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "GC Payment",
		AccountNumber = "6452",
		CostCenterType = CostCenterTypes.Store,
		Column = 27,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Gift Card Sales",
		AccountNumber = "6451",
		CostCenterType = CostCenterTypes.Store,
		Column = 29,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Other Income Sales",
		AccountNumber = "6228",
		CostCenterType = CostCenterTypes.Store,
		Column = 31,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Special Liquor Promo",
		AccountNumber = "4265",
		CostCenterType = CostCenterTypes.Store,
		Column = 33,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Promo",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 35,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Facebook Promo",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 36,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "St Judes Sales",
		AccountNumber = "2340",
		CostCenterType = CostCenterTypes.None,
		Column = 39,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Petty",
		AccountNumber = "2322",
		CostCenterType = CostCenterTypes.None,
		Column = 40,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Amex Payment",
		AccountNumber = "1252",
		CostCenterType = CostCenterTypes.None,
		Column = 42,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Visa/MC Payment",
		AccountNumber = "1253",
		CostCenterType = CostCenterTypes.None,
		Column = 44,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "ATH Payment",
		AccountNumber = "1022",
		CostCenterType = CostCenterTypes.None,
		Column = 46,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Discover Payment",
		AccountNumber = "1254",
		CostCenterType = CostCenterTypes.None,
		Column = 48,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "CC Offline Payment",
		AccountNumber = "1022",
		CostCenterType = CostCenterTypes.None,
		Column = 50,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Deposits",
		AccountNumber = "1024",
		CostCenterType = CostCenterTypes.None,
		Column = 52,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "100",
		AccountName = "Over/Short",
		AccountNumber = "6285",
		CostCenterType = CostCenterTypes.Store,
		Column = 0,
		SignType = SignTypes.Debit
	  });
	  #endregion

	  #region RMG Configuration
	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Food Sales",
		AccountNumber = "4110",
		CostCenterType = CostCenterTypes.Store,
		Column = 5,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "NA Bev Sales",
		AccountNumber = "4200",
		CostCenterType = CostCenterTypes.Store,
		Column = 7,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Liquor Sales",
		AccountNumber = "4263",
		CostCenterType = CostCenterTypes.Store,
		Column = 9,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Beer Sales",
		AccountNumber = "4261",
		CostCenterType = CostCenterTypes.Store,
		Column = 11,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Wine Sales",
		AccountNumber = "4262",
		CostCenterType = CostCenterTypes.Store,
		Column = 13,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Special Activity",
		AccountNumber = "4310",
		CostCenterType = CostCenterTypes.Store,
		Column = 15,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Taxes",
		AccountNumber = "2324",
		CostCenterType = CostCenterTypes.Concept,
		Column = 19,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Empl Comps",
		AccountNumber = "4220",
		CostCenterType = CostCenterTypes.Store,
		Column = 20,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Client Comps",
		AccountNumber = "5331",
		CostCenterType = CostCenterTypes.Store,
		Column = 21,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Irsi Comps",
		AccountNumber = "7029",
		CostCenterType = CostCenterTypes.Office,
		Column = 22,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "BOG Payment",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 27,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "iEat",
		AccountNumber = "2326",
		CostCenterType = CostCenterTypes.Store,
		Column = 28,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "GC Payment",
		AccountNumber = "6452",
		CostCenterType = CostCenterTypes.Store,
		Column = 30,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Gift Card Sales",
		AccountNumber = "6451",
		CostCenterType = CostCenterTypes.Store,
		Column = 32,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Other Income Sales",
		AccountNumber = "6228",
		CostCenterType = CostCenterTypes.Store,
		Column = 34,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Service Charge",
		AccountNumber = "6128",
		CostCenterType = CostCenterTypes.Store,
		Column = 35,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Special Liquor Promo",
		AccountNumber = "4265",
		CostCenterType = CostCenterTypes.Store,
		Column = 39,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Promo",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 41,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Facebook Promo",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 42,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Petty",
		AccountNumber = "2322",
		CostCenterType = CostCenterTypes.None,
		Column = 44,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Amex Payment",
		AccountNumber = "1252",
		CostCenterType = CostCenterTypes.None,
		Column = 46,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Visa/MC Payment",
		AccountNumber = "1253",
		CostCenterType = CostCenterTypes.None,
		Column = 48,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Discover Payment",
		AccountNumber = "1254",
		CostCenterType = CostCenterTypes.None,
		Column = 50,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "CC Offline Payment",
		AccountNumber = "1022",
		CostCenterType = CostCenterTypes.None,
		Column = 52,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "ATH Payment",
		AccountNumber = "1022",
		CostCenterType = CostCenterTypes.None,
		Column = 54,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Deposits",
		AccountNumber = "1024",
		CostCenterType = CostCenterTypes.None,
		Column = 56,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "200",
		AccountName = "Over/Short",
		AccountNumber = "6285",
		CostCenterType = CostCenterTypes.Store,
		Column = 0,
		SignType = SignTypes.Debit
	  });
	  #endregion

	  #region OTB Configuration
	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Food Sales",
		AccountNumber = "4110",
		CostCenterType = CostCenterTypes.Store,
		Column = 5,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "NA Bev Sales",
		AccountNumber = "4200",
		CostCenterType = CostCenterTypes.Store,
		Column = 7,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Liquor Sales",
		AccountNumber = "4263",
		CostCenterType = CostCenterTypes.Store,
		Column = 9,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Beer Sales",
		AccountNumber = "4261",
		CostCenterType = CostCenterTypes.Store,
		Column = 11,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Wine Sales",
		AccountNumber = "4262",
		CostCenterType = CostCenterTypes.Store,
		Column = 13,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Special Activity",
		AccountNumber = "4310",
		CostCenterType = CostCenterTypes.Store,
		Column = 15,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Taxes",
		AccountNumber = "2324",
		CostCenterType = CostCenterTypes.Concept,
		Column = 18,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Empl Comps",
		AccountNumber = "4220",
		CostCenterType = CostCenterTypes.Store,
		Column = 20,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Client Comps",
		AccountNumber = "5331",
		CostCenterType = CostCenterTypes.Store,
		Column = 21,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Irsi Comps",
		AccountNumber = "7029",
		CostCenterType = CostCenterTypes.Office,
		Column = 22,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "BOG Payment",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 25,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "iEat",
		AccountNumber = "2326",
		CostCenterType = CostCenterTypes.Store,
		Column = 27,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "GC Payment",
		AccountNumber = "6452",
		CostCenterType = CostCenterTypes.Store,
		Column = 29,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Gift Card Sales",
		AccountNumber = "6451",
		CostCenterType = CostCenterTypes.Store,
		Column = 31,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Other Income Sales",
		AccountNumber = "6228",
		CostCenterType = CostCenterTypes.Store,
		Column = 33,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Service Charge",
		AccountNumber = "6128",
		CostCenterType = CostCenterTypes.Store,
		Column = 34,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Special Liquor Promo",
		AccountNumber = "4265",
		CostCenterType = CostCenterTypes.Store,
		Column = 36,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Promo",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 38,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Petty",
		AccountNumber = "2322",
		CostCenterType = CostCenterTypes.None,
		Column = 40,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Amex Payment",
		AccountNumber = "1252",
		CostCenterType = CostCenterTypes.None,
		Column = 42,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Visa/MC Payment",
		AccountNumber = "1253",
		CostCenterType = CostCenterTypes.None,
		Column = 44,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "ATH Payment",
		AccountNumber = "1022",
		CostCenterType = CostCenterTypes.None,
		Column = 46,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Discover Payment",
		AccountNumber = "1254",
		CostCenterType = CostCenterTypes.None,
		Column = 48,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "CC Offline Payment",
		AccountNumber = "1022",
		CostCenterType = CostCenterTypes.None,
		Column = 50,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Deposits",
		AccountNumber = "1024",
		CostCenterType = CostCenterTypes.None,
		Column = 52,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "300",
		AccountName = "Over/Short",
		AccountNumber = "6285",
		CostCenterType = CostCenterTypes.Store,
		Column = 0,
		SignType = SignTypes.Debit
	  });
	  #endregion

	  #region PFC Configuration
	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Food Sales",
		AccountNumber = "4110",
		CostCenterType = CostCenterTypes.Store,
		Column = 5,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "NA Bev Sales",
		AccountNumber = "4200",
		CostCenterType = CostCenterTypes.Store,
		Column = 7,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Liquor Sales",
		AccountNumber = "4263",
		CostCenterType = CostCenterTypes.Store,
		Column = 9,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Beer Sales",
		AccountNumber = "4261",
		CostCenterType = CostCenterTypes.Store,
		Column = 11,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Wine Sales",
		AccountNumber = "4262",
		CostCenterType = CostCenterTypes.Store,
		Column = 13,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Special Activities",
		AccountNumber = "4310",
		CostCenterType = CostCenterTypes.Store,
		Column = 14,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Taxes",
		AccountNumber = "2324",
		CostCenterType = CostCenterTypes.Concept,
		Column = 19,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Empl Comps",
		AccountNumber = "4220",
		CostCenterType = CostCenterTypes.Store,
		Column = 20,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Client Comps",
		AccountNumber = "5331",
		CostCenterType = CostCenterTypes.Store,
		Column = 21,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Irsi Comps",
		AccountNumber = "7029",
		CostCenterType = CostCenterTypes.Office,
		Column = 22,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "BOG Payment",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 25,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "iEat",
		AccountNumber = "2326",
		CostCenterType = CostCenterTypes.Store,
		Column = 27,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "GC Payment",
		AccountNumber = "6452",
		CostCenterType = CostCenterTypes.Store,
		Column = 29,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Gift Card Sales",
		AccountNumber = "6451",
		CostCenterType = CostCenterTypes.Store,
		Column = 31,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Other Income Sales",
		AccountNumber = "6228",
		CostCenterType = CostCenterTypes.Store,
		Column = 33,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Service Charge",
		AccountNumber = "6128",
		CostCenterType = CostCenterTypes.Store,
		Column = 34,
		SignType = SignTypes.Credit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Promo",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 36,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Special Liquor Promo",
		AccountNumber = "4265",
		CostCenterType = CostCenterTypes.Store,
		Column = 38,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Special App Promo",
		AccountNumber = "5115",
		CostCenterType = CostCenterTypes.Store,
		Column = 40,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Petty",
		AccountNumber = "2322",
		CostCenterType = CostCenterTypes.None,
		Column = 42,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Amex Payment",
		AccountNumber = "1252",
		CostCenterType = CostCenterTypes.None,
		Column = 44,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Visa/MC Payment",
		AccountNumber = "1253",
		CostCenterType = CostCenterTypes.None,
		Column = 46,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "ATH Payment",
		AccountNumber = "1022",
		CostCenterType = CostCenterTypes.None,
		Column = 48,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Discover Payment",
		AccountNumber = "1254",
		CostCenterType = CostCenterTypes.None,
		Column = 50,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "CC Offline Payment",
		AccountNumber = "1022",
		CostCenterType = CostCenterTypes.None,
		Column = 52,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Deposits",
		AccountNumber = "1024",
		CostCenterType = CostCenterTypes.None,
		Column = 54,
		SignType = SignTypes.Debit
	  });

	  _configurations.Add(new AccountConfig
	  {
		Concept = "400",
		AccountName = "Over/Short",
		AccountNumber = "6285",
		CostCenterType = CostCenterTypes.Store,
		Column = 0,
		SignType = SignTypes.Debit
	  });
	  #endregion

	}

	public AccountConfig GetConfiguration(string concept, string accountName)
	{
	  return _configurations.Where(c => c.Concept == concept).Where(c => c.AccountName == accountName).SingleOrDefault();
	}
  }
}
