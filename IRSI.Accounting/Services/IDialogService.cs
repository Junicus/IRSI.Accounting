using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IRSI.Accounting.MVVM;

namespace IRSI.Accounting.Services
{
  public interface IDialogService
  {
	void ShowInfo(string title, string message);
	MessageBoxResult ShowWarning(string title, string message);
	void ShowError(string title, string message);
	bool ShowViewModel(string title, ViewModelBase viewModel);
  }
}
