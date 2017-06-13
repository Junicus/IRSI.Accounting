using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IRSI.Accounting.Common.MVVM.DialogService;
using IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.OpenFile;
using IRSI.Accounting.Modules.StockTransfer.Services;
using NLog;
using Prism.Commands;
using Prism.Mvvm;

namespace IRSI.Accounting.Modules.StockTransfer.ViewModels
{
  public class ImportStockTransferViewModel : BindableBase, IImportStockTransferViewModel
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	private readonly IStockTransferFileParser _fileParser;
	private readonly IDialogService _dialogService;

	private string _filePath;
	private ObservableCollection<StockTransferInOutPairViewModel> _items;
	public decimal _totalTransferIn;
	public decimal _totalTransferOut;
	private DateTime _periodEnd;
	private ICommand _stockTransferImportFile;
	private ICommand _exportStockTransfer;
	private ICommand _readStockTransfers;
	private List<string> _concepts;
	private string _conceptSelected;

	private bool _isBusy;

	public ImportStockTransferViewModel(IStockTransferFileParser fileParser, IDialogService dialogService)
	{
	  _fileParser = fileParser;
	  _dialogService = dialogService;
	  _periodEnd = DateTime.Now;
	  _items = new ObservableCollection<StockTransferInOutPairViewModel>();
	  _concepts = new List<string>();
	  _concepts.Add("CGB");
	  _concepts.Add("RMG");
	  _concepts.Add("OTB");
	  _concepts.Add("PFC");

	  _conceptSelected = "CGB";

	  _stockTransferImportFile = new DelegateCommand(() =>
	  {
		var openFileDialogViewModel = new OpenFileDialogViewModel();
		openFileDialogViewModel.Title = "Open export file...";
		openFileDialogViewModel.Filter = "Tab Delimited File (*.txt)|*.txt|All Files (*.*)|*.*";
		openFileDialogViewModel.CheckFileExists = true;
		openFileDialogViewModel.CheckPathExists = true;
		openFileDialogViewModel.DefaultExt = "*.txt";

		IsBusy = true;

		if (_dialogService.ShowOpenFileDialog(openFileDialogViewModel) == DialogResponse.OK)
		{
		  FilePath = openFileDialogViewModel.FileName;
		}
		IsBusy = false;
	  });

	  _exportStockTransfer = new DelegateCommand(async () =>
	  {
		IsBusy = true;
		await Task.Factory.StartNew(() =>
		{
		});
		IsBusy = false;
	  }, () =>
	  {
		return _items.Any();
	  });

	  _readStockTransfers = new DelegateCommand(async () =>
	  {
		try
		{
		  _items.Clear();
		  TotalTransferIn = _items.Sum(t => t.TransferIn.TransferTotal);
		  TotalTransferOut = _items.Sum(t => t.TransferOut.TransferTotal);
		  var data = await _fileParser.ParseFileAsync(FilePath, ConceptSelected);
		  foreach (var tout in data.TransferOuts)
		  {
			var tinList = data.TransferIns.Where(t => t.From == tout.From && t.To == tout.To && t.TransferTotal == tout.TransferTotal);
			if (tinList.Count() == 1)
			{
			  var tin = tinList.First();
			  var pair = new StockTransferInOutPairViewModel()
			  {
				TransferOut = tout,
				TransferIn = tin,
			  };

			  _items.Add(pair);
			  TotalTransferIn = _items.Sum(t => t.TransferIn.TransferTotal);
			  TotalTransferOut = _items.Sum(t => t.TransferOut.TransferTotal);
			}
			else
			{
			  var t = tinList.Count();
			}
		  }

			((DelegateCommand)_exportStockTransfer).RaiseCanExecuteChanged();
		}
		catch (Exception ex)
		{
		  log.Error(ex, "Error parsing stock transfer file");
		}
	  }, () =>
	  {
		return !string.IsNullOrEmpty(FilePath) && !string.IsNullOrEmpty(ConceptSelected);
	  });
	}

	public string FilePath
	{
	  get { return _filePath; }
	  set
	  {
		SetProperty<string>(ref _filePath, value, "FilePath");
		((DelegateCommand)_readStockTransfers).RaiseCanExecuteChanged();
	  }
	}

	public ObservableCollection<StockTransferInOutPairViewModel> Items
	{
	  get { return _items; }
	  set
	  {
		SetProperty<ObservableCollection<StockTransferInOutPairViewModel>>(ref _items, value, "Items");
	  }
	}

	public DateTime PeriodEnd
	{
	  get { return _periodEnd; }
	  set
	  {
		SetProperty<DateTime>(ref _periodEnd, value, "PeriodEnd");
	  }
	}

	public ICommand SelectImportFile
	{
	  get { return _stockTransferImportFile; }
	  set
	  {
		SetProperty<ICommand>(ref _stockTransferImportFile, value, "SelectImportFile");
	  }
	}

	public ICommand ExportStockTransfer
	{
	  get { return _exportStockTransfer; }
	  set
	  {
		SetProperty<ICommand>(ref _exportStockTransfer, value, "ExportStockTransfer");
	  }
	}

	public ICommand ReadStockTransfer
	{
	  get { return _readStockTransfers; }
	  set
	  {
		SetProperty<ICommand>(ref _readStockTransfers, value, "ReadStockTransfer");
	  }
	}

	public bool IsBusy
	{
	  get { return _isBusy; }
	  set
	  {
		SetProperty<bool>(ref _isBusy, value, "IsBusy");
	  }
	}

	public string ConceptSelected
	{
	  get { return _conceptSelected; }
	  set
	  {
		SetProperty<string>(ref _conceptSelected, value, "ConceptSelected");
		((DelegateCommand)_readStockTransfers).RaiseCanExecuteChanged();
	  }
	}

	public List<string> Concepts
	{
	  get { return _concepts; }
	  set
	  {
		SetProperty<List<string>>(ref _concepts, value, "Concepts");
	  }
	}

	public decimal TotalTransferOut
	{
	  get { return _totalTransferOut; }
	  set
	  {
		SetProperty<decimal>(ref _totalTransferOut, value, "TotalTransferOut");
	  }
	}

	public decimal TotalTransferIn
	{
	  get { return _totalTransferIn; }
	  set
	  {
		SetProperty<decimal>(ref _totalTransferIn, value, "TotalTransferIn");
	  }
	}
  }
}
