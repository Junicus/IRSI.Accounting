using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Modules.InventoryExtension.Models;

namespace IRSI.Accounting.Modules.InventoryExtension.Services
{
  public interface IInventoryExtensionParser
  {
	IEnumerable<InventoryExtensionItem> ParseFile(string filename);
  }
}
