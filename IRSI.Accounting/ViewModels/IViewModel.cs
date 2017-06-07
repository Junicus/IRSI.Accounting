﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSI.Accounting.ViewModels
{
  public interface IViewModel : INotifyPropertyChanged, IDisposable
  {
	IDisposable SuspendNotifications();
  }
}
