using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IRSI.Accounting.MVVM;
using IRSI.Accounting.ViewModels;

namespace IRSI.Accounting.Views
{
  /// <summary>
  /// Interaction logic for DialogWindow.xaml
  /// </summary>
  public partial class DialogWindow : Window
  {
	public DialogWindow(ViewModelBase viewModel)
	{
	  InitializeComponent();
	  DataContext = viewModel;

	  var closeable = viewModel as ICloseable;
	  if (closeable != null)
	  {
		closeable.Close.ObserveOnDispatcher().Subscribe(r =>
		{
		  CloseResult = r;
		  Close();
		});
	  }
	}

	public bool CloseResult { get; private set; }
  }
}
