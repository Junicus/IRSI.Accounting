using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IRSI.Accounting.Common.MVVM.DialogService;
using IRSI.Accounting.Common.MVVM.DialogService.FrameworkDialogs.OpenFile;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.Sales.Models;
using IRSI.Accounting.Modules.Sales.Services;
using NLog;
using Prism.Commands;
using Prism.Mvvm;

namespace IRSI.Accounting.Modules.Sales.ViewModels
{
  public class ImportSalesAlohaViewModel : BindableBase, IImportSalesAlohaViewModel
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	private readonly ISalesFileParser _fileParser;
	private readonly IDialogService _dialogService;
	private readonly IGLRepository _glRepository;

	private string _filePath;
	private ObservableCollection<SalesItemData> _items;
	private DateTime _periodEnd;
	private ICommand _selectImportFile;
	private ICommand _exportSales;

	private bool _isBusy;

	public ImportSalesAlohaViewModel(ISalesFileParser fileParser, IDialogService dialogService, IGLRepository glRepository)
	{
	  _fileParser = fileParser;
	  _dialogService = dialogService;
	  _glRepository = glRepository;
	  _items = new ObservableCollection<SalesItemData>();
	  _periodEnd = DateTime.Now;

	  _selectImportFile = new DelegateCommand(async () =>
	  {
		var openFileDialogViewModel = new OpenFileDialogViewModel();
		openFileDialogViewModel.Title = "Open export file...";
		openFileDialogViewModel.Filter = "Tab Delimited File (*.txt)|*.txt|All Files (*.*)|*.*";
		openFileDialogViewModel.CheckFileExists = true;
		openFileDialogViewModel.CheckPathExists = true;
		openFileDialogViewModel.DefaultExt = ".txt";

		_items.Clear();

		IsBusy = true;

		if (_dialogService.ShowOpenFileDialog(openFileDialogViewModel) == DialogResponse.OK)
		{
		  FilePath = openFileDialogViewModel.FileName;

		  try
		  {
			var results = await _fileParser.ParseFileAsync(FilePath);
			foreach (var item in results)
			{
			  Items.Add(item);
			}
			  ((DelegateCommand)_exportSales).RaiseCanExecuteChanged();
		  }
		  catch (Exception ex)
		  {
			log.Error(ex, "Error parsing sales file");
		  }
		}

		IsBusy = false;
	  });

	  _exportSales = new DelegateCommand(async () =>
	  {
		IsBusy = true;
		await Task.Factory.StartNew(() =>
		{
		  _glRepository.ClearHeaders();
		  _glRepository.ClearDetails();
		  _glRepository.SaveChanges();

		  _glRepository.GetData();

		  var storeGroups = from i in _items
							group i by i.Store into g
							select new { Store = g.Key, Items = g };

		  foreach (var group in storeGroups)
		  {
			var totalCredits = Math.Abs(group.Items.Sum(a => a.Credit));
			var totalDebits = Math.Abs(group.Items.Sum(a => a.Debit));

			var headerEntry = _glRepository.AddNewHeader("GL", "JE",
				"Sales: " + group.Store,
				Convert.ToDouble(totalDebits),
				Convert.ToDouble(totalCredits), _periodEnd);

			foreach (var item in group.Items)
			{
			  _glRepository.AddNewDetail(headerEntry.ToString(),
				  item.AccountNumber,
				  Convert.ToDouble(item.Amount),
				  "Sales " + item.StoreNumber + " - " + item.AccountName);
			}
		  }
		  _glRepository.SaveChanges();
		});
		IsBusy = false;
	  }, () =>
	  {
		return _items.Any();
	  });
	}

	public string FilePath
	{
	  get => _filePath;
	  set => SetProperty<string>(ref _filePath, value, nameof(FilePath));
	}

	public ObservableCollection<SalesItemData> Items
	{
	  get => _items;
	  set => SetProperty<ObservableCollection<SalesItemData>>(ref _items, value, nameof(Items));
	}

	public DateTime PeriodEnd
	{
	  get => _periodEnd;
	  set => SetProperty<DateTime>(ref _periodEnd, value, nameof(PeriodEnd));
	}

	public ICommand SelectImportFile
	{
	  get => _selectImportFile;
	  set => SetProperty<ICommand>(ref _selectImportFile, value, nameof(SelectImportFile));
	}

	public ICommand ExportSales
	{
	  get => _exportSales;
	  set => SetProperty<ICommand>(ref _exportSales, value, nameof(ExportSales));
	}

	public bool IsBusy
	{
	  get => _isBusy;
	  set => SetProperty<bool>(ref _isBusy, value, nameof(IsBusy));
	}
  }
}
