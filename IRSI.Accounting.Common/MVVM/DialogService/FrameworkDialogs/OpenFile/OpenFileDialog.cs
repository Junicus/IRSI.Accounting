using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsOpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.OpenFile
{
  public class OpenFileDialog : IDisposable
  {
	private readonly IOpenFileDialog _openFileDialog;
	private WinFormsOpenFileDialog _concreteOpenFileDialog;

	public OpenFileDialog(IOpenFileDialog openFileDialog)
	{
	  Contract.Requires(openFileDialog != null);

	  this._openFileDialog = openFileDialog;

	  _concreteOpenFileDialog = new WinFormsOpenFileDialog()
	  {
		AddExtension = openFileDialog.AddExtension,
		CheckFileExists = openFileDialog.CheckFileExists,
		CheckPathExists = openFileDialog.CheckPathExists,
		DefaultExt = openFileDialog.DefaultExt,
		FileName = openFileDialog.FileName,
		Filter = openFileDialog.Filter,
		InitialDirectory = openFileDialog.InitialDirectory,
		Multiselect = openFileDialog.Multiselect,
		Title = openFileDialog.Title
	  };
	}

	public DialogResponse ShowDialog(IWin32Window owner)
	{
	  Contract.Requires(owner != null);
	  DialogResponse result = DialogHelpers.GetResponse(_concreteOpenFileDialog.ShowDialog(owner));
	  _openFileDialog.FileName = _concreteOpenFileDialog.FileName;
	  _openFileDialog.FileNames = _concreteOpenFileDialog.FileNames;
	  return result;
	}

	public DialogResponse ShowDialog()
	{
	  DialogResponse result = DialogHelpers.GetResponse(_concreteOpenFileDialog.ShowDialog());
	  _openFileDialog.FileName = _concreteOpenFileDialog.FileName;
	  _openFileDialog.FileNames = _concreteOpenFileDialog.FileNames;
	  return result;
	}

	public void Dispose()
	{
	  Dispose(true);
	  GC.SuppressFinalize(this);
	}

	~OpenFileDialog()
	{
	  Dispose(false);
	}

	protected virtual void Dispose(bool disposing)
	{
	  if (disposing)
	  {
		if (_concreteOpenFileDialog != null)
		{
		  _concreteOpenFileDialog.Dispose();
		  _concreteOpenFileDialog = null;
		}
	  }
	}
  }
}
