using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Extensions;
using IRSI.Accounting.Models;
using IRSI.Accounting.ViewModels;
using NLog;

namespace IRSI.Accounting.Services
{
  public class OverlayService : DisposableObject, IOverlayService
  {
	private readonly Subject<OverlayViewModel> _show;

	public OverlayService()
	{
	  using (Duration.Measure(Logger, "Constructor - " + GetType().Name))
	  {
		_show = new Subject<OverlayViewModel>()
		  .DisposeWith(this);
	  }
	}

	public IObservable<OverlayViewModel> Show => _show;

	public void Post(string header, BaseViewModel viewModel, IDisposable lifetime)
	{
	  _show.OnNext(new OverlayViewModel(header, viewModel, lifetime));
	}
  }
}
