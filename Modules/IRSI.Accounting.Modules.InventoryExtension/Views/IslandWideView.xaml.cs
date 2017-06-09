using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autofac.Features.AttributeFilters;
using Autofac.Features.Indexed;
using IRSI.Accounting.Modules.InventoryExtension.ViewModels;
using Prism.Regions;

namespace IRSI.Accounting.Modules.InventoryExtension.Views
{
  /// <summary>
  /// Interaction logic for IslandWideView.xaml
  /// </summary>
  public partial class IslandWideView : UserControl, IRegionMemberLifetime
  {
	public IslandWideView(IIndex<string, IInventoryExtensionViewModel> viewModels)
	{
	  InitializeComponent();
	  this.DataContext = viewModels["IslandWideViewModel"];
	}

	public bool KeepAlive => true;
  }
}
