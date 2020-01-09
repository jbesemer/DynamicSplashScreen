using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DynamicSplashScreen
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static ISplashScreen SplashScreen;

		protected override void OnStartup( StartupEventArgs e )
		{
			var splashScreenThread = new SplashScreenThread<SplashScreenWindow>();
			SplashScreen = splashScreenThread.Start(); // returns after splash window is created
			var w = App.Current.MainWindow;

			// continue with normal startup
			base.OnStartup( e );
		}
	}
}
