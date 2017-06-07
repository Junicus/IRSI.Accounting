using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Disposables;
using IRSI.Accounting.Models;
using System.ComponentModel;
using System.Linq.Expressions;
using IRSI.Accounting.Extensions;
using IRSI.Accounting.Helpers;

namespace IRSI.Accounting.ViewModels
{
  public abstract class BaseViewModel : DisposableObject, IViewModel
  {
	private static readonly PropertyChangedEventArgs EmptyEventArgs = new PropertyChangedEventArgs(string.Empty);

	private static readonly IDictionary<string, PropertyChangedEventArgs> ChangedProperties = new Dictionary<string, PropertyChangedEventArgs>();

	private SuspendedNotifications _suspendedNotifications;

	public event PropertyChangedEventHandler PropertyChanged;

	public IDisposable SuspendNotifications()
	{
	  if (_suspendedNotifications == null)
	  {
		_suspendedNotifications = new SuspendedNotifications(this);
	  }
	  return _suspendedNotifications.AddRef();
	}

	protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
	{
	  OnPropertyChanged(ExpressionHelpers.Name(expression));
	}

	protected virtual void OnPropertyChanged()
	{
	  OnPropertyChanged(null);
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
	  if (_suspendedNotifications != null)
	  {
		_suspendedNotifications.Add(propertyName);
	  }
	  else
	  {
		var handler = PropertyChanged;
		if (handler != null)
		{
		  if (propertyName == null)
		  {
			handler(this, EmptyEventArgs);
		  }
		  else
		  {
			if (!ChangedProperties.TryGetValue(propertyName, out PropertyChangedEventArgs args))
			{
			  args = new PropertyChangedEventArgs(propertyName);
			  ChangedProperties.Add(propertyName, args);
			}
			handler(this, args);
		  }
		}
	  }
	}

	protected virtual bool SetPropertyAndNotify<T>(ref T existingValue, T newValue, Expression<Func<T>> expression)
	{
	  if (EqualityComparer<T>.Default.Equals(existingValue, newValue))
	  {
		return false;
	  }

	  existingValue = newValue;
	  OnPropertyChanged(expression);

	  return true;
	}

	private sealed class SuspendedNotifications : IDisposable
	{
	  private readonly HashSet<string> _properties = new HashSet<string>();
	  private readonly BaseViewModel _target;
	  private int _refCount;

	  public SuspendedNotifications(BaseViewModel target)
	  {
		_target = target;
	  }

	  public void Dispose()
	  {
		_target._suspendedNotifications = null;
		_properties.ForEach(x => _target.OnPropertyChanged(x));
	  }

	  public void Add(string propertyName)
	  {
		_properties.Add(propertyName);
	  }

	  public IDisposable AddRef()
	  {
		++_refCount;
		return Disposable.Create(() =>
		{
		  if (--_refCount == 0)
		  {
			Dispose();
		  }
		});
	  }
	}
  }
}
