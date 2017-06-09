using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.FolderBrowse;
using IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.OpenFile;

namespace IRSI.Accounting.Common.MVVM.DialogService
{
  public interface IDialogService
  {
	DialogResponse ShowOpenFileDialog(IOpenFileDialog openFileDialog);
	DialogResponse ShowFolderBrowserDialog(IFolderBrowserDialog folderBrowserDialog);
  }
}
