using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSplashScreen
{
	public interface ISplashScreen
	{
		void SetText( string message );
		void Shutdown();
	}
}
