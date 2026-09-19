using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCI
{
	public class MyControl : UserControl
	{
		private IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Window;
			base.Name = "MyControl";
			base.Size = new Size(509, 343);
			base.ResumeLayout(false);
		}

		public MyControl()
		{
			this.InitializeComponent();
		}
	}
}
