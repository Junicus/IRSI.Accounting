using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public interface IMessageBus
  {
	IDisposable Subscribe<T>(Action<T> action);
	void Publish<T>(T item);
  }
}
