using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Modules.StockTransfer.Models;

namespace IRSI.Accounting.Modules.StockTransfer.Services
{
  public interface IStockTransferFileParser
  {
	Task<StockTransferResult> ParseFileAsync(string filePath, string concept);
  }
}
