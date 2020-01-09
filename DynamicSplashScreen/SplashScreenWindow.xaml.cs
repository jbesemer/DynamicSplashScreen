using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DynamicSplashScreen
{
	/// <summary>
	/// Interaction logic for SplashScreenWindow.xaml
	/// </summary>
	public partial class SplashScreenWindow : Window, ISplashScreen
	{
		public SplashScreenWindow()
		{
			InitializeComponent();
		}

		public void SetText( string message )
		{
			Dispatcher.Invoke( (Action)delegate ()
			 {
				 this.UpdateMessageTextBox.Text = message;
			 } );
		}

		public void Shutdown()
		{
			Dispatcher.InvokeShutdown();
		}

		private void Button_Click( object sender, RoutedEventArgs e )
		{
			var w = Application.Current.MainWindow;
		}
	}
}
