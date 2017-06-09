using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs
{
  public interface IFileDialog
  {
	bool AddExtension { get; set; }
	bool CheckFileExists { get; set; }
	bool CheckPathExists { get; set; }
	string DefaultExt { get; set; }
	string FileName { get; set; }
	string[] FileNames { get; set; }
	string Filter { get; set; }
	string InitialDirectory { get; set; }
	string Title { get; set; }
  }
}
