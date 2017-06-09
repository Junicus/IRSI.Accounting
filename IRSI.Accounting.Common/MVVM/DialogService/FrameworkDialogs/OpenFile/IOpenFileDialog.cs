using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.OpenFile
{
  public interface IOpenFileDialog : IFileDialog
  {
	bool Multiselect { get; set; }
  }
}
