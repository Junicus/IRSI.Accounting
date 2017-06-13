using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.StockTransfer.Models
{
  public class StockTransferLineItemData
  {
	public string ItemName { get; set; }
	public string Account { get; set; }
	public decimal UnitAmount { get; set; }
	public string Unit { get; set; }
	public decimal UnitCost { get; set; }
	public decimal Total { get; set; }
  }
}
