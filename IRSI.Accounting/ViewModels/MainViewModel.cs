using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using IRSI.Accounting.Collections;
using IRSI.Accounting.Commands;
using IRSI.Accounting.Models;
using IRSI.Accounting.Services;

namespace IRSI.Accounting.ViewModels
{
  public sealed class MainViewModel : BaseViewModel, IMainViewModel
  {
	private static readonly Metadata[] EmptyMetadatas = new Metadata[0];

	private readonly Func<IEnumerable<Metadata>, IAddResourceViewModel> _addResourceFactory;
	private readonly Func<Metadata, IMetadataViewModel> _metadataFactory;

	private readonly ListCollectionView _collectionView;
	private readonly IMessageService _messageService;
	private readonly RangeObservableCollection<IMetadataViewModel> _metadata;


	public ReactiveCommand<object> RefreshCommand => throw new NotImplementedException();

	public IDiagnosticsViewModel Diagnostics => throw new NotImplementedException();
  }
}
