using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.ViewModels
{
  public interface ICloseable
  {
	IObservable<bool> Close { get; }
  }
}
