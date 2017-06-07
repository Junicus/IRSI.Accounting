using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.Models
{
  public sealed class Message
  {
	public Message(string header, ICloseableViewModel viewModel)
	{
	  Header = header;
	  ViewModel = viewModel;
	}

	public string Header { get; private set; }
	public ICloseableViewModel ViewModel { get; private set; }
  }
}
