using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using WindowInteropHelper = System.Windows.Interop.WindowInteropHelper;

namespace IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs
{
  public class WindowWrapper : IWin32Window
  {
	public WindowWrapper(Window window)
	{
	  Handle = new WindowInteropHelper(window).Handle;
	}

	public IntPtr Handle { get; private set; }
  }
}
