using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Modules.InventoryExtension.Models;

namespace IRSI.Accounting.Modules.InventoryExtension.Services
{
  public class InventoryChartOfAccounts : IInventoryChartOfAccounts
  {
	private readonly Dictionary<string, ChartOfAccounts> _chartOfAccountsDictionary;

	public InventoryChartOfAccounts()
	{
	  _chartOfAccountsDictionary = new Dictionary<string, ChartOfAccounts>();

	  _chartOfAccountsDictionary.Add("Chili's Grill & Bar", new ChartOfAccounts());
	  _chartOfAccountsDictionary.Add("Romano's Macaroni Grill", new ChartOfAccounts());
	  _chartOfAccountsDictionary.Add("On The Border", new ChartOfAccounts());
	  _chartOfAccountsDictionary.Add("PF Chang's China Bistro", new ChartOfAccounts());

	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - BAKERY", Number = "5106" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - BEER", Number = "5261" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - CHEESE", Number = "5113" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - DAIRY", Number = "5105" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - DESSERTS", Number = "5107" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - DRESSINGS & SALSAS", Number = "5110" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - LIQUOR", Number = "5263" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - MEAT", Number = "5101" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - NON-ALCOHOLIC", Number = "5210" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - OTHER FOOD", Number = "5114" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - PASTA", Number = "5111" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - POULTRY", Number = "5102" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - PRODUCE", Number = "5104" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - SEAFOOD", Number = "5103" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - SOUPS", Number = "5108" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - WINE", Number = "5262" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - SHORTENING", Number = "5109" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "COGS - OIL", Number = "5112" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "BAR EXPENSES", Number = "6255" });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Flatware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Culture Club", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Cleaning Supplies", Number = "6223", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Entertainment", Number = "6280", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Prep/Bar", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Equipment", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "China/Tableware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Bar Expense", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Plateware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Cooking Supplies", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Dinning Room", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Dish/Janitorial/Hostess", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Glassware", Number = "6212", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Menu", Number = "6256", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Office Supplies", Number = "6220", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Silverware", Number = "6215", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Supplies Dining Room and Kitchen", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Chili's Grill & Bar"].Accounts.Add(new Account() { Name = "Uniforms", Number = "6245" });

	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - BAKERY", Number = "5106" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - BEER", Number = "5261" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - CHEESE", Number = "5113" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - DAIRY", Number = "5105" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - DESSERTS", Number = "5107" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - DRESSINGS & SALSAS", Number = "5110" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - LIQUOR", Number = "5263" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - MEAT", Number = "5101" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - N/A BEVERAGES", Number = "5210" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - OTHER FOOD", Number = "5114" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - PASTA", Number = "5111" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - POULTRY", Number = "5102" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - PRODUCE", Number = "5104" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - SEAFOOD", Number = "5103" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - SOUPS", Number = "5108" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - WINE", Number = "5262" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - SHORTENING", Number = "5109" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "COGS - OIL", Number = "5112" });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "BAR EXPENSES", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Flatware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Culture Club", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Cleaning Supplies", Number = "6223", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Entertainment", Number = "6280", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Prep/Bar", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Equipment", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "China/Tableware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Bar Expense", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Plateware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Cooking Supplies", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Dinning Room", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Dish/Janitorial/Hostess", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Glassware", Number = "6212", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Menu", Number = "6256", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Office Supplies", Number = "6220", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Silverware", Number = "6215", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Supplies Dining Room and Kitchen", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["Romano's Macaroni Grill"].Accounts.Add(new Account() { Name = "Uniforms", Number = "6245" });

	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - BAKERY", Number = "5106" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - BEER", Number = "5261" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - CHEESE", Number = "5113" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - DAIRY", Number = "5105" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - DESSERT", Number = "5107" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - DRESSINGS & SALSAS", Number = "5110" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - LIQUOR", Number = "5263" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - MEAT", Number = "5101" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - N/A BEVERAGES", Number = "5210" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - OTHER FOOD", Number = "5114" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - PASTA", Number = "5111" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - POULTRY", Number = "5102" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - PRODUCE", Number = "5104" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - SEAFOOD", Number = "5103" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - SOUPS", Number = "5108" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - WINE", Number = "5262" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - SHORTENING", Number = "5109" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "COGS - OIL", Number = "5112" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "BAR EXPENSE", Number = "6255" });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Flatware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Culture Club", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Cleaning Supplies", Number = "6223", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Entertainment", Number = "6280", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Prep/Bar", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Equipment", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "China/Tableware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Bar Expense", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Plateware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Cooking Supplies", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Dinning Room", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Dish/Janitorial/Hostess", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Glassware", Number = "6212", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Menu", Number = "6256", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Office Supplies", Number = "6220", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Silverware", Number = "6215", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Supplies Dining Room and Kitchen", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["On The Border"].Accounts.Add(new Account() { Name = "Uniforms", Number = "6245" });

	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - BAKERY", Number = "5106" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - BEER", Number = "5261" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - CHEESE", Number = "5113" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - DAIRY", Number = "5105" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - DESSERTS", Number = "5107" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - DRESSINGS & SALSA", Number = "5110" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - LIQUOR", Number = "5263" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - MEAT", Number = "5101" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - NON-ALCOHOLIC", Number = "5210" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - OTHER FOOD", Number = "5114" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - PASTA", Number = "5111" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - POULTRY", Number = "5102" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - PRODUCE", Number = "5104" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - SEAFOOD", Number = "5103" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - SOUPS", Number = "5108" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - WINE", Number = "5262" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - SHORTENING", Number = "5109" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - OIL", Number = "5112" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "COGS - RICE", Number = "510A" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "BAR EXPENSES", Number = "6255" });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Flatware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Culture Club", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Cleaning Supplies", Number = "6223", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Entertainment", Number = "6280", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Prep/Bar", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Equipment", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "China/Tableware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Bar Expense", Number = "6255", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Plateware", Number = "6210", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Cooking Supplies", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Dinning Room", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Dish/Janitorial/Hostess", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Glassware", Number = "6212", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Menu", Number = "6256", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Office Supplies", Number = "6220", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Silverware", Number = "6215", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Supplies Dining Room and Kitchen", Number = "6225", IsTaxable = true });
	  _chartOfAccountsDictionary["PF Chang's China Bistro"].Accounts.Add(new Account() { Name = "Uniforms", Number = "6245" });
	}

	public Account FindAccount(string concept, string accountName)
	{
	  if (!_chartOfAccountsDictionary.Keys.Contains(concept)) return null;
	  var account = _chartOfAccountsDictionary[concept].Accounts.SingleOrDefault(a => a.Name == accountName);
	  return account;
	}
  }
}

