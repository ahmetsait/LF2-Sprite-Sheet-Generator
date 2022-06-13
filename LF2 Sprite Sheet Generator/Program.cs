using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LF2.Sprite_Sheet_Generator
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.CurrentCulture = CultureInfo.InvariantCulture;
				Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
				Application.Run(new MainForm());
			}
			catch (Exception ex)
			{
				string info = ex.ToString();
				using (var file = File.AppendText("crash_log.txt"))
				{
					file.Write(info);
					file.Write("\r\n\r\n");
				}
				MessageBox.Show(info, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw;
			}
		}

		public const int DesignDpi = 120;
	}
}
