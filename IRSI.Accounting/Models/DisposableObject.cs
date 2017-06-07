using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Services;
using NLog;

namespace IRSI.Accounting.Models
{
  public abstract class DisposableObject : IDisposable
  {
	protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private readonly CompositeDisposable _disposable;

	protected DisposableObject()
	{
	  _disposable = new CompositeDisposable();
	}

	public void Dispose()
	{
	  using (Duration.Measure(Logger, "Dispose - " + GetType().FullName))
	  {
		_disposable.Dispose();
	  }
	}

	public static implicit operator CompositeDisposable(DisposableObject disposable)
	{
	  return disposable._disposable;
	}
  }
}
