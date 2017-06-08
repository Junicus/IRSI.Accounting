using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public class PropertyProviderFactory : IPropertyProviderFactory
  {
	private readonly ISchedulers _schedulers;

	public PropertyProviderFactory(ISchedulers schedulers)
	{
	  _schedulers = schedulers;
	}

	public IPropertyProvider<T> Create<T>(ViewModelBase viewModelBase)
	{
	  return new PropertyProvider<T>(viewModelBase, _schedulers);
	}
  }
}
