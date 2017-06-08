using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IRSI.Accounting.MVVM;
using IRSI.Accounting.Views;

namespace IRSI.Accounting.Services
{
  public class DialogService : IDialogService
  {
	public void ShowInfo(string title, string message)
	{
	  MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
	}

	public MessageBoxResult ShowWarning(string title, string message)
	{
	  return MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
	}

	public void ShowError(string title, string message)
	{
	  MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
	}

	public bool ShowViewModel(string title, ViewModelBase viewModel)
	{
	  var win = new DialogWindow(viewModel) { Title = title };
	  win.ShowDialog();
	  return win.CloseResult;
	}
  }
}
