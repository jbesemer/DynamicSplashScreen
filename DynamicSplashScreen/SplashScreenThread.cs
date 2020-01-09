using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace DynamicSplashScreen
{
	public class SplashScreenThread<T> 
		where T : Window, ISplashScreen, new()
	{
		private T SplashScreen;
		private ManualResetEvent ResetSplashCreated;
		private Thread SplashThread;

		public SplashScreenThread()
		{
			ResetSplashCreated = new ManualResetEvent( false );

			// Create a new thread for the splash screen to run on
			SplashThread = new Thread( ShowSplash );
			SplashThread.SetApartmentState( ApartmentState.STA );
			SplashThread.IsBackground = true;
			SplashThread.Name = "Splash Screen";
		}

		public ISplashScreen Start()
		{
			SplashThread.Start();

			// Wait for the blocker to be signaled before continuing. 
			ResetSplashCreated.WaitOne();

			return SplashScreen;
		}

		private void ShowSplash()
		{
			// Create the window and show it
			SplashScreen = new T();
			SplashScreen.Show();
			// window.app.mainwindow is now the splash screen

			// Now that the window is created, allow the rest of the startup to run
			ResetSplashCreated.Set();
			System.Windows.Threading.Dispatcher.Run();
		}
	}
}
