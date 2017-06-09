using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsFolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.FolderBrowse
{
  public class FolderBrowserDialog : IDisposable
  {
	private readonly IFolderBrowserDialog _folderBrowserDialog;
	private WinFormsFolderBrowserDialog _concreteFolderBrowserDialog;

	public FolderBrowserDialog(IFolderBrowserDialog folderBrowserDialog)
	{
	  Contract.Requires(folderBrowserDialog != null);

	  this._folderBrowserDialog = folderBrowserDialog;

	  _concreteFolderBrowserDialog = new WinFormsFolderBrowserDialog
	  {
		Description = folderBrowserDialog.Description,
		SelectedPath = folderBrowserDialog.SelectedPath,
		ShowNewFolderButton = folderBrowserDialog.ShowNewFolderButton
	  };
	}

	public DialogResponse ShowDialog(IWin32Window owner)
	{
	  Contract.Requires(owner != null);
	  DialogResponse result = DialogHelpers.GetResponse(_concreteFolderBrowserDialog.ShowDialog(owner));
	  _folderBrowserDialog.SelectedPath = _concreteFolderBrowserDialog.SelectedPath;
	  return result;
	}

	public DialogResponse ShowDialog()
	{
	  DialogResponse result = DialogHelpers.GetResponse(_concreteFolderBrowserDialog.ShowDialog());
	  _folderBrowserDialog.SelectedPath = _concreteFolderBrowserDialog.SelectedPath;
	  return result;
	}

	public void Dispose()
	{
	  Dispose(true);
	  GC.SuppressFinalize(this);
	}

	~FolderBrowserDialog()
	{
	  Dispose(false);
	}

	protected virtual void Dispose(bool disposing)
	{
	  if (disposing)
	  {
		if (_concreteFolderBrowserDialog != null)
		{
		  _concreteFolderBrowserDialog.Dispose();
		  _concreteFolderBrowserDialog = null;
		}
	  }
	}
  }
}
