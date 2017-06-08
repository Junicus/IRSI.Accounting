using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IRSI.Accounting.Modules.InventoryExtension.ViewModels;
using Prism.Mvvm;

namespace IRSI.Accounting.Modules.InventoryExtension.Views
{
  /// <summary>
  /// Interaction logic for InventoryExtensionModuleView.xaml
  /// </summary>
  public partial class InventoryExtensionModuleView : RibbonButton
  {
	public InventoryExtensionModuleView(IInventoryExtensionModuleViewModel viewModel)
	{
	  InitializeComponent();
	  this.DataContext = viewModel;
	}
  }
}
