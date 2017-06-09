using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.FolderBrowse
{
  public class FolderBrowserDialogViewModel : IFolderBrowserDialog
  {
	public string Description { get; set; }
	public string SelectedPath { get; set; }
	public bool ShowNewFolderButton { get; set; }
  }
}
