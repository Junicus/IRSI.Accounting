using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
  public class InventoryExtensionIslandWideViewModel : BindableBase, IInventoryExtensionViewModel
  {
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	private readonly IFolderBrowserDialogService _folderBrowserServer;
	private readonly IGLRepository _glRepository;
	private readonly IInventoryExtensionParser _parser;

	private ICommand _browseFile;
	private ICommand _exportData;

	private string _sourceFolder;
	private DateTime _periodDate;
	private ObservableCollection<InventoryExtensionItem> _items;
	private bool _isBusy;

	public InventoryExtensionIslandWideViewModel(
		IIndex<string, IInventoryExtensionParser> parsers,
		IFolderBrowserDialogService folderBrowserService,
		IGLRepository glRepository)
	{
	  _folderBrowserServer = folderBrowserService;
	  _glRepository = glRepository;
	  _parser = parsers["IslandWideParser"];
	  _periodDate = DateTime.Now;

	  _items = new ObservableCollection<InventoryExtensionItem>();

	  _browseFile = new DelegateCommand(async () =>
	  {
		if (_folderBrowserServer.ShowFolderBrowserDialog() == DialogResponse.OK)
		{
		  SourceFolder = _folderBrowserServer.SelectedPath;
		  var filenames = Directory.GetFiles(SourceFolder, "*.xls");
		  if (_items.Any())
		  {
			_items.Clear();
		  }

		  IsBusy = true;
		  log.Debug("Calling ReadFilesAsync");
		  var readitems = await ReadFilesAsync(filenames);
		  IsBusy = false;
		  foreach (var item in readitems)
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

		  var storeGroups = from i in _items
							group i by i.Store into g
							select new { Store = g.Key, Items = g };

		  var conceptGroup = from i in _items
							 group i by i.Store.Substring(0, 1) into g
							 select new { Concept = g.Key, Items = g };

		  foreach (var group in storeGroups)
		  {
			var totalAmount = group.Items.Sum(a => a.Amount);
			var totalTax = group.Items.Sum(t => t.Tax);

			var headerEntry = _glRepository.AddNewHeader("GL", "JE",
				"Dispatch: " + group.Store,
				Convert.ToDouble(totalAmount + totalTax),
				Convert.ToDouble(totalAmount + totalTax), _periodDate);

			foreach (var item in group.Items)
			{
			  _glRepository.AddNewDetail(headerEntry.ToString(),
				  item.AccountNumber,
				  Convert.ToDouble(item.Amount)
				  + Convert.ToDouble(item.Tax),
				  "WAREHOUSE DISPATCH");
			}
			_glRepository.AddNewDetail(headerEntry.ToString(),
				"1360-099", Convert.ToDouble(-1 * totalAmount), group.Store);

			var conceptString = group.Store.Substring(0, 1);
			int conceptId;
			if (int.TryParse(conceptString, out conceptId))
			{
			  var costCenter = conceptId * 100;
			  _glRepository.AddNewDetail(headerEntry.ToString(),
				  "2324-" + costCenter.ToString(), Convert.ToDouble(-1 * totalTax), "IVU IW - " + group.Store.Split(' ')[0]);
			}
		  }
		  _glRepository.SaveChanges();
		});
		IsBusy = false;
	  }, () =>
	  {
		return Items.Any();
	  });
	}

	public ICommand BrowseFile
	{
	  get { return _browseFile; }
	  set
	  {
		SetProperty<ICommand>(ref _browseFile, value, "BrowseFile");
	  }
	}

	public ICommand ExportData
	{
	  get { return _exportData; }
	  set
	  {
		SetProperty<ICommand>(ref _exportData, value, "ExportData");
	  }
	}

	public string SourceFolder
	{
	  get { return _sourceFolder; }
	  set
	  {
		SetProperty<string>(ref _sourceFolder, value, "SourceFolder");
	  }
	}

	public DateTime PeriodDate
	{
	  get { return _periodDate; }
	  set
	  {
		SetProperty<DateTime>(ref _periodDate, value, "PeriodDate");
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

	public ObservableCollection<InventoryExtensionItem> Items
	{
	  get { return _items; }
	  set
	  {
		SetProperty<ObservableCollection<InventoryExtensionItem>>(ref _items, value, "Items");
	  }
	}

	private async Task<IEnumerable<InventoryExtensionItem>> ReadFilesAsync(string[] filenames)
	{
	  log.Debug("ReadFileAsync Called");
	  var retval = new List<InventoryExtensionItem>();
	  await Task.Factory.StartNew(() =>
	  {
		foreach (var filename in filenames)
		{
		  var items = _parser.ParseFile(filename);
		  foreach (var item in items)
		  {
			log.Debug("Reading " + filename);
			retval.Add(item);
		  }
		}
	  });
	  return retval.AsEnumerable();
	}
  }
}
