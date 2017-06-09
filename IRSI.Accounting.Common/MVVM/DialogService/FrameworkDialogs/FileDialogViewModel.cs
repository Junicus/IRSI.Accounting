using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs
{
  public class FileDialogViewModel : IFileDialog
  {
	public bool AddExtension { get; set; }
	public bool CheckFileExists { get; set; }
	public bool CheckPathExists { get; set; }
	public string DefaultExt { get; set; }
	public string FileName { get; set; }
	public string[] FileNames { get; set; }
	public string Filter { get; set; }
	public string InitialDirectory { get; set; }
	public string Title { get; set; }
  }
}
