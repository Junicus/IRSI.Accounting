using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.ViewModels;

namespace IRSI.Accounting.Services
{
  public interface IOverlayService : IService
  {
	IObservable<OverlayViewModel> Show { get; }
	void Post(string header, BaseViewModel viewModel, IDisposable lifetime);
  }
}
