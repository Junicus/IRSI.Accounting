using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public interface ISchedulers
  {
	IScheduler Dispatcher { get; }
	IScheduler NewThread { get; }
	IScheduler NewTask { get; }
	IScheduler ThreadPool { get; }
	IScheduler Timer { get; }
  }
}
