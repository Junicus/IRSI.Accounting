using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using IRSI.Accounting.Modules.Sales.Models;

namespace IRSI.Accounting.Modules.Sales.Views.Converters
{
  public class CreditSumConverter : IValueConverter
  {
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
	  var items = value as IEnumerable<object>;
	  if (items == null)
		return 0;
	  var salesItems = from i in items
					   select ((SalesItemData)i);
	  var sum = salesItems.Sum(i => i.Credit);
	  return sum;
	}

	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
	  throw new NotImplementedException();
	}
  }
}
