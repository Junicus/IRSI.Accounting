using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.Accounting.Common.MVVM.DialogService
{
  public interface IFolderBrowserDialogService
  {
	string SelectedPath { get; }
	DialogResponse ShowFolderBrowserDialog();
  }
}
