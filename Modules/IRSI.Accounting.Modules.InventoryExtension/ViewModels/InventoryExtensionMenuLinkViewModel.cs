using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Autofac.Features.Indexed;
using IRSI.Accounting.Common.MVVM.DialogService;
using IRSI.Accounting.Data;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using IRSI.Accounting.Modules.InventoryExtension.Services;
using NLog;
using Prism.Commands;
using Prism.Mvvm;

namespace IRSI.Accounting.Modules.InventoryExtension.ViewModels
{
  public class InventoryExtensionMenuLinkViewModel : BindableBase, IInventoryExtensionViewModel
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	private readonly IInventoryExtensionParser _parser;
	private readonly IFolderBrowserDialogService _folderBrowserService;
	private readonly IGLRepository _glRepository;

	private ICommand _browseFile;
	private ICommand _exportData;

	private string _sourceFolder;
	private DateTime _periodEnd;
	private ObservableCollection<InventoryExtensionItem> _items;
	private bool _isBusy;

	public InventoryExtensionMenuLinkViewModel(
	  IIndex<string, IInventoryExtensionParser> parsers,
	  IFolderBrowserDialogService folderBrowserService,
	  IGLRepository glRepository)
	{
	  _parser = parsers["MenuLinkParser"];
	  _folderBrowserService = folderBrowserService;
	  _glRepository = glRepository;
	  _periodEnd = DateTime.Now;
	  _items = new ObservableCollection<InventoryExtensionItem>();

	  _browseFile = new DelegateCommand(async () =>
	  {
		log.Debug("Browse Folders");
		if (_folderBrowserService.ShowFolderBrowserDialog() == DialogResponse.OK)
		{
		  SourceFolder = _folderBrowserService.SelectedPath;
		  log.Debug("Browsed to " + SourceFolder);
		  var filenames = Directory.GetFiles(SourceFolder);
		  if (_items.Any())
		  {
			_items.Clear();
		  }

		  IsBusy = true;
		  log.Debug("Calling ReadFilesAsync");
		  var readitems = await ReadFilesAsync(filenames);
		  var sortreadItems = from i in readitems
							  orderby i.Store ascending
							  orderby i.AccountNumber ascending
							  select i;
		  IsBusy = false;
		  foreach (var item in sortreadItems)
		  {
			Items.Add(item);
		  }
			((DelegateCommand)_exportData).RaiseCanExecuteChanged();
		}
	  });

	  _exportData = new DelegateCommand(async () =>
	  {
		IsBusy = true;
		await Task.Factory.StartNew(() =>
		{
		  _glRepository.ClearHeaders();
		  _glRepository.ClearDetails();
		  _glRepository.SaveChanges();

		  _glRepository.GetData();

		  var storeSort = from i in _items
						  orderby i.Store ascending
						  orderby i.AccountNumber ascending
						  select i;

		  var storeGroups = from i in storeSort
							group i by i.Store into g
							orderby g.Key ascending
							select new { Store = g.Key, Items = g };

		  foreach (var group in storeGroups)
		  {
			var totalAmount = group.Items.Sum(a => a.Amount);
			var headerEntry = _glRepository.AddNewHeader("GL", "JE",
				"Inventory: " + group.Store,
				Convert.ToDouble(totalAmount),
				Convert.ToDouble(totalAmount), _periodEnd);

			foreach (var item in group.Items)
			{
			  _glRepository.AddNewDetail(headerEntry.ToString(),
				  item.AccountNumber, Convert.ToDouble(-1 * item.Amount), "INVENTORY EXTENSION");
			}
			_glRepository.AddNewDetail(headerEntry.ToString(), "1310", Convert.ToDouble(totalAmount), group.Store);
		  }
		  _glRepository.SaveChanges();
		});
		IsBusy = false;
	  }, () =>
	  {
		return Items.Any();
	  });

	  IsBusy = false;
	}

	public ICommand BrowseFile
	{
	  get => _browseFile;
	  set => SetProperty<ICommand>(ref _browseFile, value, nameof(BrowseFile));
	}

	public ICommand ExportData
	{
	  get => _exportData;
	  set => SetProperty<ICommand>(ref _exportData, value, nameof(ExportData));
	}

	public string SourceFolder
	{
	  get => _sourceFolder;
	  set => SetProperty<string>(ref _sourceFolder, value, nameof(SourceFolder));
	}

	public DateTime PeriodEnd
	{
	  get => _periodEnd;
	  set => SetProperty<DateTime>(ref _periodEnd, value, nameof(PeriodEnd));
	}

	public bool IsBusy
	{
	  get => _isBusy;
	  set => SetProperty<bool>(ref _isBusy, value, nameof(IsBusy));
	}

	public ObservableCollection<InventoryExtensionItem> Items
	{
	  get => _items;
	  set => SetProperty<ObservableCollection<InventoryExtensionItem>>(ref _items, value, nameof(Items));
	}

	public async Task<IEnumerable<InventoryExtensionItem>> ReadFilesAsync(string[] filenames)
	{
	  var retval = new List<InventoryExtensionItem>();
	  await Task.Factory.StartNew(() =>
	  {
		foreach (var filename in filenames)
		{
		  var tempItems = _parser.ParseFile(filename);
		  foreach (var item in tempItems)
			retval.Add(item);
		}
	  });
	  return retval;
	}
  }
}
