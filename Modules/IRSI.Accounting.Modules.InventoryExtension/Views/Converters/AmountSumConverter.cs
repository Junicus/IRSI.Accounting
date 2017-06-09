using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using IRSI.Accounting.Modules.InventoryExtension.Models;

namespace IRSI.Accounting.Modules.InventoryExtension.Views.Converters
{
  public class AmountSumConverter : IValueConverter
  {
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
	  var items = value as IEnumerable<object>;
	  if (items == null) return 0;
	  return items.Cast<InventoryExtensionItem>().Select(i => i.Amount + i.Tax).Sum();
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
	  throw new NotImplementedException();
	}
  }
}
