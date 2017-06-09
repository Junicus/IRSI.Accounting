using System.Collections.Generic;

namespace IRSI.Accounting.Common.Models
{
  public class Concept
  {
	public int Id { get; set; }
	public string Number { get; set; }
	public string Name { get; set; }

	public virtual ICollection<Store> Stores { get; set; }
  }
}