using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Commands;

namespace IRSI.Accounting.ViewModels
{
  public interface IMainViewModel : IViewModel
  {
	ReactiveCommand<object> RefreshCommand { get; }
	IDiagnosticsViewModel Diagnostics { get; }
  }
}
