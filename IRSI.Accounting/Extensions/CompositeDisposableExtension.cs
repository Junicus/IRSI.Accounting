using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Extensions
{
  public static class CompositeDisposableExtension
  {
	public static T DisposeWith<T>(this T instance, CompositeDisposable disposable) where T : IDisposable
	{
	  disposable.Add(instance);
	  return instance;
	}
  }
}
