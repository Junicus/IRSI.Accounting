using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public class PropertySubject<T> : IPropertySubject<T>
  {
	private readonly Subject<T> _subject = new Subject<T>();
	private T _value;

	public T Value { get => _value; set => SetValue(value); }

	private void SetValue(T value)
	{
	  _value = value;
	  _subject.OnNext(value);
	}

	public void OnCompleted()
	{
	  _subject.OnCompleted();
	}

	public void OnError(Exception error)
	{
	  _subject.OnError(error);
	}

	public void OnNext(T value)
	{
	  SetValue(value);
	}

	public IDisposable Subscribe(IObserver<T> observer)
	{
	  return _subject.Subscribe(observer);
	}
  }
}
