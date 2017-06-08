using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IRSI.Accounting.MVVM
{
  public interface ICommandObserver<T> : ICommand
  {
	IObservable<T> OnExecute { get; }
	IObserver<bool> SetCanExecute { get; }
  }
}
