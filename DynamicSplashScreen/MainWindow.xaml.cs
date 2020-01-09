using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynamicSplashScreen
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded( object sender, RoutedEventArgs e )
		{
			App.SplashScreen.SetText( "Loading main window" );
			for( int i = 0; i < 5; i++ )
			{
				Thread.Sleep( 750 );
				App.SplashScreen.SetText( $"Loading DLL {i}" );
			}

			App.SplashScreen.SetText( "Done!" );
			App.SplashScreen.Shutdown();
			// window.app.mainwindow is now the splash screen
			var w = App.Current.MainWindow;
		}
	}
}
