using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.PlatformServices;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public class Schedulers : ISchedulers
  {
	public IScheduler Dispatcher => CurrentThreadScheduler.Instance;

	public IScheduler NewThread => NewThreadScheduler.Default;

	public IScheduler NewTask => ThreadPoolScheduler.Instance;

	public IScheduler ThreadPool => ThreadPoolScheduler.Instance;

	public IScheduler Timer => Scheduler.Immediate;
  }
}
