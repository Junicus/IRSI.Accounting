﻿using System;
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
using IRSI.Accounting.Modules.StockTransfer.ViewModels;

namespace IRSI.Accounting.Modules.StockTransfer.Views
{
  /// <summary>
  /// Interaction logic for ImportStockTransferView.xaml
  /// </summary>
  public partial class ImportStockTransferView : UserControl
  {
	public ImportStockTransferView(IImportStockTransferViewModel viewModel)
	{
	  InitializeComponent();
	  this.DataContext = viewModel;
	}
  }
}
