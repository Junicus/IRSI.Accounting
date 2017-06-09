using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.OpenFile
{
  public class OpenFileDialogViewModel : FileDialogViewModel, IOpenFileDialog
  {
	public bool Multiselect { get; set; }
  }
}
