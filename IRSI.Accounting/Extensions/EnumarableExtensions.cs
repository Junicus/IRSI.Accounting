using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Extensions
{
  public static class EnumarableExtensions
  {
	public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
	{
	  foreach (var item in enumerable)
	  {
		action(item);
	  }
	  return enumerable;
	}
  }
}
