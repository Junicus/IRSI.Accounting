using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.Sales.Models
{
  public class AccountConfig
  {
	public string Concept { get; set; }
	public string AccountName { get; set; }
	public string AccountNumber { get; set; }
	public CostCenterTypes CostCenterType { get; set; }
	public SignTypes SignType { get; set; }
	public int Column { get; set; }
  }
}
