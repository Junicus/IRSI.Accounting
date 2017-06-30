using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.InventoryExtension.Services
{
  public interface IInventoryExtensionFileReader
  {
	IEnumerable<string> ReadFile(string filename);
  }
}
