using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.FolderBrowse;
using IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.OpenFile;

namespace IRSI.Accounting.Common.MVVM.DialogService
{
  public class DialogService : IDialogService
  {
	public DialogResponse ShowOpenFileDialog(IOpenFileDialog openFileDialog)
	{
	  OpenFileDialog dialog = new OpenFileDialog(openFileDialog);
	  return dialog.ShowDialog();
	}

	public DialogResponse ShowFolderBrowserDialog(IFolderBrowserDialog folderBrowserDialog)
	{
	  FolderBrowserDialog dialog = new FolderBrowserDialog(folderBrowserDialog);
	  return dialog.ShowDialog();
	}
  }
}
