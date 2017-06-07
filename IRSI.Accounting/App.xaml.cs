using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using IRSI.Accounting.Resources.Views;
using NLog;

namespace IRSI.Accounting
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
	private readonly CompositeDisposable _disposable;

	public App()
	{
	  AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
	  Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
	  TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

	  _disposable = new CompositeDisposable();
	}

	protected override void OnStartup(StartupEventArgs e)
	{
	  using (Services.Duration.Measure(Logger, "OnStartup - " + GetType().Name))
	  {
		Logger.Info("Starting");

		var dispatcherThreadInfo = $"Dispatcher managed thread identifier = {Thread.CurrentThread.ManagedThreadId}";
		Debug.WriteLine(dispatcherThreadInfo);
		Logger.Info(dispatcherThreadInfo);

		Logger.Info($"WPF rendering capability (tier) = {RenderCapability.Tier / 0x10000}");
		RenderCapability.TierChanged += (s, a) => Logger.Info($"WPF rendering capability (tier) ={RenderCapability.Tier / 0x10000}");

		base.OnStartup(e);

		BootStrapper.Start();
		_disposable.Add(Disposable.Create(BootStrapper.Stop));

		//get few services

		var window = new MainWindow();
		window.DataContext = BootStrapper.RootView;

		window.Closed += (s, a) => HandleWindowClose();
		Current.Exit += (s, a) => HandleExit();

		window.Show();

		Logger.Info("Started");
	  }
	}

	private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
	  Logger.Info("Unhandled app domain exception");
	  HandleException(e.ExceptionObject as Exception);
	}

	private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
	{
	  Logger.Info("Unhandled task exception");
	  e.SetObserved();
	  HandleException(e.Exception);
	}

	private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
	{
	  Logger.Info("Unhandled dispatcher thread exception");
	  e.Handled = true;
	  HandleException(e.Exception);
	}

	private static void HandleException(Exception exception)
	{
	  Logger.Error(exception);
	}

	private void HandleWindowClose()
	{
	  Logger.Info("Window closed");
	  _disposable.Dispose();
	}

	private static void HandleExit()
	{
	  Logger.Info("App Closing");
	  LogManager.Flush();
	}
  }
}
