using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace IRSI.Accounting.Modules.InventoryExtension.Models
{
  public class InventoryExtensionItem : BindableBase
  {
	private string _store;
	private string _accountNumber;
	private string _accountName;
	private decimal _amount;
	private decimal _tax;

	public string Store
	{
	  get => _store;
	  set => SetProperty<string>(ref _store, value, nameof(Store));
	}

	public string AccountNumber
	{
	  get => _accountNumber;
	  set => SetProperty<string>(ref _accountNumber, value, nameof(AccountNumber));
	}

	public string AccountName
	{
	  get => _accountName;
	  set => SetProperty<string>(ref _accountName, value, nameof(AccountName));
	}

	public decimal Amount
	{
	  get => _amount;
	  set => SetProperty<decimal>(ref _amount, value, nameof(Amount));
	}

	public decimal Tax
	{
	  get => _tax;
	  set => SetProperty<decimal>(ref _tax, value, nameof(Tax));
	}
  }
}
