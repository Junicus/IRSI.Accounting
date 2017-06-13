using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.StockTransfer.Models
{
  public class StockTransferResult
  {
	public List<StockTransferItemData> TransferIns { get; set; }
	public List<StockTransferItemData> TransferOuts { get; set; }
  }
}
