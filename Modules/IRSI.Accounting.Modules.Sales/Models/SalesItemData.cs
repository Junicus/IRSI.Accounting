using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace IRSI.Accounting.Modules.Sales.Models
{
  public class SalesItemData : BindableBase
  {
	private string _store;
	private string _storeNumber;
	private string _accountNumber;
	private string _accountName;
	private decimal _debit;
	private decimal _credit;
	private decimal _amount;

	public string Store
	{
	  get => _store;
	  set => SetProperty<string>(ref _store, value, nameof(Store));
	}

	public string StoreNumber
	{
	  get => _storeNumber;
	  set => SetProperty<string>(ref _storeNumber, value, nameof(StoreNumber));
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

	public decimal Debit
	{
	  get => _debit;
	  set => SetProperty<decimal>(ref _debit, value, nameof(Debit));
	}

	public decimal Credit
	{
	  get => _credit;
	  set => SetProperty<decimal>(ref _credit, value, nameof(Credit));
	}

	public decimal Amount
	{
	  get => _amount;
	  set => SetProperty<decimal>(ref _amount, value, nameof(Amount));
	}
  }
}
