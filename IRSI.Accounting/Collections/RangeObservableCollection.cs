using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using IRSI.Accounting.Extensions;

namespace IRSI.Accounting.Collections
{
  public sealed class RangeObservableCollection<T> : ObservableCollection<T>
  {
	private bool _suppressNotifications;
	public override event NotifyCollectionChangedEventHandler CollectionChanged;

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
	  if (!_suppressNotifications)
	  {
		var handlers = CollectionChanged;
		if (handlers != null)
		{
		  foreach (var handler in handlers.GetInvocationList().Cast<NotifyCollectionChangedEventHandler>())
		  {
			if (handler.Target is CollectionView)
			{
			  ((CollectionView)handler.Target).Refresh();
			}
			else
			{
			  handler(this, e);
			}
		  }
		}
	  }
	}

	public void AddRange(IEnumerable<T> items)
	{
	  _suppressNotifications = true;

	  var array = items.ToArray();
	  array.ForEach(Add);

	  _suppressNotifications = false;
	  OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, array, array.Length));
	}
  }
}
