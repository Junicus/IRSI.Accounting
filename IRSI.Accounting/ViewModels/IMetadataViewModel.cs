using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Commands;
using IRSI.Accounting.Models;

namespace IRSI.Accounting.ViewModels
{
  public interface IMetadataViewModel : ITransientViewModel
  {
	Uri Url { get; }
	bool Editable { get; }
	Metadata Metadata { get; }
	ReactiveCommand<object> ModifyCommand { get; }
	ReactiveCommand<object> DeleteCommand { get; }
	IObservable<Unit> Deleted { get; }
  }
}
