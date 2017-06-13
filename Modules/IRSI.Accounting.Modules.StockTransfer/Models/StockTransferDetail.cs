using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.StockTransfer.Models
{
  public class StockTransferDetail
  {
	public string Description { get; set; }
	public string Account { get; set; }
	public decimal UnitAmount { get; set; }
	public string Unit { get; set; }
  }
}
