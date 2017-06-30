using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.InventoryExtension.Services
{
  public class InventoryExtensionFileReader : IInventoryExtensionFileReader
  {
	public IEnumerable<string> ReadFile(string filename)
	{
	  if (File.Exists(filename))
		return File.ReadAllLines(filename);
	  return new List<string>();
	}
  }
}
