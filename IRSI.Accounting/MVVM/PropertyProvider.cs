using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public class PropertyProvider<T> : IPropertyProvider<T>
  {
	private readonly ViewModelBase _viewModel;
	private readonly ISchedulers _schedulers;
	private readonly CompositeDisposable _disposable = new CompositeDisposable();

	public PropertyProvider(ViewModelBase viewModel, ISchedulers schedulers)
	{
	  _viewModel = viewModel;
	  _schedulers = schedulers;
	  _viewModel.ShouldDispose(_disposable);
	}

	private PropertySubject<K> GetProperty<K>(Expression<Func<T, K>> expression)
	{
	  var propertyName = ((MemberExpression)expression.Body).Member.Name;
	  var propertySubject = new PropertySubject<K>();

	  _disposable.Add(propertySubject.ObserveOn(_schedulers.Dispatcher).Subscribe(v => _viewModel.OnPropertyChanged(propertyName)));
	  return propertySubject;
	}

	public IPropertySubject<K> CreateProperty<K>(Expression<Func<T, K>> expression)
	{
	  return GetProperty(expression);
	}

	public IPropertySubject<K> CreateProperty<K>(Expression<Func<T, K>> expression, K value)
	{
	  var propertySubject = GetProperty(expression);
	  propertySubject.Value = value;
	  return propertySubject;
	}

	public IPropertySubject<K> CreateProperty<K>(Expression<Func<T, K>> expression, IObservable<K> value)
	{
	  var propertySubject = GetProperty(expression);
	  _disposable.Add(value.Subscribe(v => propertySubject.Value = v));
	  return propertySubject;
	}

	public ICommandObserver<K> CreateCommand<K>(Expression<Func<T, K>> expression)
	{
	  return new CommandObserver<K>(true);
	}

	public ICommandObserver<K> CreateCommand<K>(Expression<Func<T, K>> expression, bool isEnabled)
	{
	  return new CommandObserver<K>(isEnabled);
	}

	public ICommandObserver<K> CreateCommand<K>(Expression<Func<T, K>> expression, IObservable<bool> isEnabled)
	{
	  var cmd = new CommandObserver<K>(true);
	  _disposable.Add(isEnabled.Subscribe(cmd.SetCanExecute));
	  return cmd;
	}

	public void Dispose()
	{
	  if (!_disposable.IsDisposed)
		_disposable.Dispose();
	}
  }
}
