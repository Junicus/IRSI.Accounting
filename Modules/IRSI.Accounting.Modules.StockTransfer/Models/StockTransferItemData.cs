using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.StockTransfer.Models
{
  public class StockTransferItemData
  {
	public StockTransferItemData()
	{
	  Lines = new List<StockTransferLineItemData>();
	}

	public string From { get; set; }
	public string To { get; set; }
	public DateTime TransferDate { get; set; }
	public decimal TransferTotal
	{
	  get
	  {
		var total = Lines.Sum(t => t.Total);
		return total;
	  }
	}

	public List<StockTransferLineItemData> Lines { get; set; }
  }
}
