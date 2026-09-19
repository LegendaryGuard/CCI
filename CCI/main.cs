using System;
using System.Windows.Forms;

namespace CCI
{
	internal static class main
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new core());
		}
	}
}
