using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.StockTransfer.Models
{
  public class StockTransfer
  {
	public int From { get; set; }
	public int To { get; set; }
	public DateTime TransferDate { get; set; }
	public List<StockTransferDetail> Items { get; set; }
	public decimal TransferTotal { get; set; }
  }
}
