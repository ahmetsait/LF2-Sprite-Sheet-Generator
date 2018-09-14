using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LF2.Sprite_Sheet_Generator
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.CurrentCulture = CultureInfo.InvariantCulture;
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.Run(new MainForm());
		}
	}
}
