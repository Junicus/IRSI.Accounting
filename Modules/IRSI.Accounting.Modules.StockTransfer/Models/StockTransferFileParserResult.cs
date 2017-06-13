using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.StockTransfer.Models
{
  public class StockTransferFileParseResult
  {
	public int Period { get; set; }
	public int Year { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }


	public List<StockTransfer> TransferIns { get; set; }
	public List<StockTransfer> TransferOuts { get; set; }

	public decimal TotalTransferIn { get; set; }
	public decimal TotalTransferOut { get; set; }
	public decimal NetTransfers { get; set; }
  }
}
