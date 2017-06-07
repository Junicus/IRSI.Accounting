using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.ViewModels
{
  public interface IAddResourceViewModel : ICloseableViewModel
  {
	string Path { get; set; }
	string Json { get; set; }
	IObservable<Unit> Added { get; }
  }
}
