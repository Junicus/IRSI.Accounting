﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Modules.StockTransfer.Models;

namespace IRSI.Accounting.Modules.StockTransfer.ViewModels
{
  public class StockTransferInOutPairViewModel
  {
	public StockTransferItemData TransferIn { get; set; }
	public StockTransferItemData TransferOut { get; set; }
  }
}
