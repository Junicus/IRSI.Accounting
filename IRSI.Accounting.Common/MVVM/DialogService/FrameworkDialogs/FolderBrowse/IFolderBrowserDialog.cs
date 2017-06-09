using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.FolderBrowse
{
  public interface IFolderBrowserDialog
  {
	string Description { get; set; }
	string SelectedPath { get; set; }
	bool ShowNewFolderButton { get; set; }
  }
}
