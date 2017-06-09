using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace IRSI.Accounting.Common.MVVM.DialogService
{
  public class DialogHelpers
  {
	public static MessageBoxButton GetButton(DialogButton button)
	{
	  switch (button)
	  {
		case DialogButton.OK: return MessageBoxButton.OK;
		case DialogButton.OKCancel: return MessageBoxButton.OKCancel;
		case DialogButton.YesNo: return MessageBoxButton.YesNo;
		case DialogButton.YesNoCancel: return MessageBoxButton.YesNoCancel;
	  }
	  throw new ArgumentOutOfRangeException("button", "Invalid button");
	}

	public static MessageBoxImage GetImage(DialogImage image)
	{
	  switch (image)
	  {
		case DialogImage.Asterisk: return MessageBoxImage.Asterisk;
		case DialogImage.Error: return MessageBoxImage.Error;
		case DialogImage.Exclamation: return MessageBoxImage.Exclamation;
		case DialogImage.Hand: return MessageBoxImage.Hand;
		case DialogImage.Information: return MessageBoxImage.Information;
		case DialogImage.None: return MessageBoxImage.None;
		case DialogImage.Question: return MessageBoxImage.Question;
		case DialogImage.Stop: return MessageBoxImage.Stop;
		case DialogImage.Warning: return MessageBoxImage.Warning;
	  }
	  throw new ArgumentOutOfRangeException("image", "Invalid image");
	}

	public static DialogResponse GetResponse(MessageBoxResult result)
	{
	  switch (result)
	  {
		case MessageBoxResult.Cancel: return DialogResponse.Cancel;
		case MessageBoxResult.No: return DialogResponse.No;
		case MessageBoxResult.None: return DialogResponse.None;
		case MessageBoxResult.OK: return DialogResponse.OK;
		case MessageBoxResult.Yes: return DialogResponse.Yes;
	  }
	  throw new ArgumentOutOfRangeException("result", "Invalid result");
	}

	public static DialogResponse GetResponse(DialogResult result)
	{
	  switch (result)
	  {
		case DialogResult.Abort: return DialogResponse.Abort;
		case DialogResult.Cancel: return DialogResponse.Cancel;
		case DialogResult.Ignore: return DialogResponse.Cancel;
		case DialogResult.No: return DialogResponse.No;
		case DialogResult.None: return DialogResponse.None;
		case DialogResult.OK: return DialogResponse.OK;
		case DialogResult.Retry: return DialogResponse.Retry;
		case DialogResult.Yes: return DialogResponse.Yes;
	  }
	  throw new ArgumentOutOfRangeException("result", "Invalid Result");
	}
  }
}
