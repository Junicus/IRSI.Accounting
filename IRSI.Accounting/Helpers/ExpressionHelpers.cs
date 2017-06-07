using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Helpers
{
  public static class ExpressionHelpers
  {
	public static string Name<T>(Expression<Func<T>> expression)
	{
	  var lambda = expression as LambdaExpression;
	  var memberExpression = (MemberExpression)lambda.Body;
	  return memberExpression.Member.Name;
	}
  }
}
