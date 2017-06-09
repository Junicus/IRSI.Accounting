using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IRSI.Accounting.Common.MVVM.DialogService
{
  public class FolderBrowserDialogService : IFolderBrowserDialogService
  {
	private string _selectedPath;

	public string SelectedPath
	{
	  get { return _selectedPath; }
	}

	public DialogResponse ShowFolderBrowserDialog()
	{
	  var dialog = new FolderBrowserDialog();
	  var result = dialog.ShowDialog();
	  if (result == DialogResult.OK)
	  {
		_selectedPath = dialog.SelectedPath;
	  }
	  return DialogHelpers.GetResponse(result);
	}
  }
}
