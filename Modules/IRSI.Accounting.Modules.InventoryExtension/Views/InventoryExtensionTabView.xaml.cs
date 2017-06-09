using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using Prism.Regions;

namespace IRSI.Accounting.Modules.InventoryExtension.Views
{
  /// <summary>
  /// Interaction logic for InventoryExtensionTabView.xaml
  /// </summary>
  [Export("InventoryExtensionTabView")]
  public partial class InventoryExtensionTabView : RibbonTab, IRegionMemberLifetime
  {
	public InventoryExtensionTabView(IInventoryExtensionTabViewModel viewModel)
	{
	  InitializeComponent();
	  this.DataContext = viewModel;
	}

	public bool KeepAlive => false;
  }
}
