using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Modules.InventoryExtension.Models
{
  public class Account
  {
	public int Id { get; set; }
	public string Number { get; set; }
	public string Name { get; set; }
	public bool IsTaxable { get; set; }
  }
}
