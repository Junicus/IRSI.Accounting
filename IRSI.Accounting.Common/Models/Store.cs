using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Common.Models
{
  public class Store
  {
	public int Id { get; set; }
	public string Number { get; set; }
	public string Name { get; set; }
	public int ConceptId { get; set; }
	public string Account { get; set; }
	public string InsightName { get; set; }

	public virtual Concept Concept { get; set; }
  }
}
