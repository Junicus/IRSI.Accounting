using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Common.Models;

namespace IRSI.Accounting.Data
{
  public interface IStoresRepository
  {
	IEnumerable<Store> GetStores();
	Store GetStoreByInsightName(string insightName);
  }
}
