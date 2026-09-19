using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCI
{
	public class about : Form
	{
		private IContainer components = null;

		private LinkLabel linkLabel1;

		private Panel panel1;

		public about()
		{
			this.InitializeComponent();
		}

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
			this.linkLabel1 = new LinkLabel();
			this.panel1 = new Panel();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new Font("Segoe UI", 11.25f);
			this.linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
			this.linkLabel1.LinkColor = Color.FromArgb(128, 128, 255);
			this.linkLabel1.Location = new Point(8, 19);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new Size(287, 80);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Developed by\r\n\r\nLord of Destruction - Core/Wizard/Design\r\nGreenberet - Wizard";
			this.linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
			this.linkLabel1.VisitedLinkColor = Color.FromArgb(128, 128, 255);
			this.panel1.BackColor = Color.White;
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Location = new Point(-2, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(305, 123);
			this.panel1.TabIndex = 1;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(192, 192, 255);
			base.ClientSize = new Size(299, 170);
			base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "about";
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Corona Bytes .NET";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
