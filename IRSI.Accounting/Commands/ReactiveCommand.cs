﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IRSI.Accounting.Services;
using NLog;

namespace IRSI.Accounting.Commands
{
  public class ReactiveCommand : ReactiveCommand<object>
  {
	public ReactiveCommand(IObservable<bool> canExecute) : base(canExecute.StartWith(false))
	{
	}

	public new static ReactiveCommand<object> Create()
	{
	  return ReactiveCommand<object>.Create(Observable.Return(true).StartWith(true));
	}

	public new static ReactiveCommand<object> Create(IObservable<bool> canExecute)
	{
	  return ReactiveCommand<object>.Create(canExecute);
	}
  }

  public class ReactiveCommand<T> : IObservable<T>, ICommand, IDisposable
  {
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private readonly IDisposable _canDisposable;
	private readonly List<EventHandler> _eventHandlers;
	private readonly Subject<T> _execute;

	private bool _currentCanExecute;

	protected ReactiveCommand(IObservable<bool> canExecute)
	{
	  _eventHandlers = new List<EventHandler>();
	  _canDisposable = canExecute.Subscribe(x =>
	  {
		_currentCanExecute = x;
		CommandManager.InvalidateRequerySuggested();
	  });
	  _execute = new Subject<T>();
	}

	public virtual void Execute(object parameter)
	{
	  var typedParameter = parameter is T ? (T)parameter : default(T);
	  if (CanExecute(typedParameter))
	  {
		_execute.OnNext(typedParameter);
	  }
	}

	public virtual bool CanExecute(object parameter)
	{
	  return _currentCanExecute;
	}

	public event EventHandler CanExecuteChanged
	{
	  add
	  {
		_eventHandlers.Add(value);
		CommandManager.RequerySuggested += value;
	  }
	  remove
	  {
		_eventHandlers.Remove(value);
		CommandManager.RequerySuggested -= value;
	  }
	}

	public void Dispose()
	{
	  using (Duration.Measure(Logger, "Dispose - " + GetType().Name))
	  {
		_eventHandlers.ForEach(x => CommandManager.RequerySuggested -= x);
		_eventHandlers.Clear();

		_canDisposable.Dispose();

		_execute.OnCompleted();
		_execute.Dispose();
	  }
	}

	public IDisposable Subscribe(IObserver<T> observer)
	{
	  return _execute.Subscribe(observer.OnNext, observer.OnError, observer.OnCompleted);
	}

	public static ReactiveCommand<T> Create()
	{
	  return new ReactiveCommand<T>(Observable.Return(true));
	}

	public static ReactiveCommand<T> Create(IObservable<bool> canExecute)
	{
	  return new ReactiveCommand<T>(canExecute);
	}
  }
}
