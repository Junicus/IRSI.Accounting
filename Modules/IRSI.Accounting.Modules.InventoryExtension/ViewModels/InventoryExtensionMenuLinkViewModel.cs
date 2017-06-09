using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac.Features.Indexed;
using IRSI.Accounting.Modules.InventoryExtension.Models;
using IRSI.Accounting.Modules.InventoryExtension.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace IRSI.Accounting.Modules.InventoryExtension.ViewModels
{
  public class InventoryExtensionMenuLinkViewModel : BindableBase, IInventoryExtensionViewModel
  {
	private IIndex<string, IInventoryExtensionParser> _parsers;
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
		if(_folderBrowserService.ShowFolderBrowserDialog() == DialogResult.OK)
		{

		}
	  });

	  _exportData = new DelegateCommand(async () =>
	  {

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
		foreach(var filename in filenames)
		{
		  var tempItems = _parser.ParseFile(filename);
		  foreach(var item in tempItems)
		  {
			retval.Add(item);
		  }
		}
	  });
	  return retval;
	}
  }
}
