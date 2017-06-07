using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.ViewModels
{
  public interface ICloseableViewModel : IViewModel
  {
	IObservable<Unit> Closed { get; }
	IObservable<Unit> Denied { get; }
	IObservable<Unit> Confirmed { get; }
  }
}
