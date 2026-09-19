using System;
using System.Drawing;
using System.Windows.Forms;

namespace CCI
{
	internal class Console : RichTextBox
	{
		public void Print(Color color, string msg)
		{
			base.SelectionColor = color;
			this.SelectedText = msg;
			base.ScrollToCaret();
		}

		public void PrintLine(Color color, string msg)
		{
			base.SelectionColor = color;
			this.SelectedText = msg + "\n";
			base.ScrollToCaret();
		}
	}
}
