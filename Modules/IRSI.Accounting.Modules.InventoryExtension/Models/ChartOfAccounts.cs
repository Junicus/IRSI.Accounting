using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.InventoryExtension.Models
{
  public class ChartOfAccounts
  {
	public ICollection<Account> Accounts { get; set; }

	public ChartOfAccounts()
	{
	  Accounts = new List<Account>();
	}
  }
}
