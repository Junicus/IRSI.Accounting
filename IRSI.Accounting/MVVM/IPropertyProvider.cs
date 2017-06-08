using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public interface IPropertyProvider<T> : IDisposable
  {
	IPropertySubject<K> CreateProperty<K>(Expression<Func<T, K>> expression);
	IPropertySubject<K> CreateProperty<K>(Expression<Func<T, K>> expression, K value);
	IPropertySubject<K> CreateProperty<K>(Expression<Func<T, K>> expression, IObservable<K> value);
	ICommandObserver<K> CreateCommand<K>(Expression<Func<T, K>> expression);
	ICommandObserver<K> CreateCommand<K>(Expression<Func<T, K>> expression, bool isEnabled);
	ICommandObserver<K> CreateCommand<K>(Expression<Func<T, K>> expression, IObservable<bool> isEnabled);
  }
}
