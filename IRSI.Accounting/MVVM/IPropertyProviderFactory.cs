using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.MVVM
{
  public interface IPropertyProviderFactory
  {
	IPropertyProvider<T> Create<T>(ViewModelBase viewModelBase);
  }
}
