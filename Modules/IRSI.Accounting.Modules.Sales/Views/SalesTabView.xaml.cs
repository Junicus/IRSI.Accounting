﻿using System;
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
using IRSI.Accounting.Modules.Sales.ViewModels;

namespace IRSI.Accounting.Modules.Sales.Views
{
  /// <summary>
  /// Interaction logic for SalesTabView.xaml
  /// </summary>
  public partial class SalesTabView : RibbonTab
  {
	public SalesTabView(ISalesTabViewModel viewModel)
	{
	  InitializeComponent();
	  this.DataContext = viewModel;
	}
  }
}
