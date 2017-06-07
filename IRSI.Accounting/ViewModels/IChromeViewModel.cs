using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Commands;

namespace IRSI.Accounting.ViewModels
{
  public interface IChromeViewModel : IViewModel
  {
	IMainViewModel Main { get; }
	ReactiveCommand<object> CloseOverlayCommand { get; }
	bool HasOverlay { get; }
	string OverlayHeader { get; }
	BaseViewModel Overlay { get; }
  }
}
