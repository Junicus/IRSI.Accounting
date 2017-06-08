using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public class ViewModelBase : INotifyPropertyChanged, IDisposable
  {
	private readonly CompositeDisposable _disposable = new CompositeDisposable();
	public event PropertyChangedEventHandler PropertyChanged;

	public void OnPropertyChanged(string propertyName)
	{
	  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public void ShouldDispose(IDisposable disposable)
	{
	  _disposable.Add(disposable);
	}

	public void Dispose()
	{
	  _disposable.Dispose();
	}
  }
}
