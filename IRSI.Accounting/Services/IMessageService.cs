using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSI.Accounting.Models;
using IRSI.Accounting.ViewModels;

namespace IRSI.Accounting.Services
{
  public interface IMessageService :IService
  {
	IObservable<Message> Show { get; }
	void Post(string header, ICloseableViewModel viewModel);
  }
}
