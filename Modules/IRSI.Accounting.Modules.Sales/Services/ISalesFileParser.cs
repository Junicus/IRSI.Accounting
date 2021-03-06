﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Modules.Sales.Models;

namespace IRSI.Accounting.Modules.Sales.Services
{
  public interface ISalesFileParser
  {
	Task<IEnumerable<SalesItemData>> ParseFileAsync(string filePath);
  }
}
