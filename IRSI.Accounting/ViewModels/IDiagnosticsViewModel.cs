using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.ViewModels
{
  public interface IDiagnosticsViewModel
  {
	string Cpu { get; }
	string ManagedMemory { get; }
	string TotalMemory { get; }
  }
}
