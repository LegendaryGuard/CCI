using CCI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCI
{
	public class ClassPanel : MyControl
	{
		private IContainer components = null;

		internal GroupBox groupBox3;

		internal TextBox txtVersion;

		internal TextBox txtDescription;

		internal Label label1;

		internal Label label5;

		internal TextBox txtName;

		internal Label label2;

		internal Label label3;

		internal TextBox txtAuthor;

		internal CheckBox cbFusion;

		internal CheckBox cbDescendClass;

		internal CheckBox cbSound;

		internal CheckBox cbCharge;

		internal CheckBox cbWeapon;

		private ToolTip toolTipClass;

		internal CheckBox cbCanEatCandy;

		private Panel panel1;

		private Label lblLevel;

		internal TrackBar levels;

        /* Transformation FX & Step Sound */
        internal CheckBox cbDefaultFX;
        internal CheckBox cbDefaultFX2;
        internal CheckBox cbDefaultFX3;
        internal CheckBox cbDefaultFX4;
        internal CheckBox cbDefaultFX5;
        internal CheckBox cbDefaultFX6;
        internal CheckBox cbDefaultFX7;
        internal CheckBox cbDefaultStepSound;

        /* Swoop Time & Stealth */
        internal CheckBox cbSwoopTime;
        internal CheckBox cbStealth;
        /* End */

		public ClassPanel()
		{
			this.InitializeComponent();
		}

		private void levels_ValueChanged(object sender, EventArgs e)
		{
            this.lblLevel.Text = "Support " + (this.levels.Value - 1) + " Transformations";

            /* Transformation FX */
            if (this.levels.Value >= 2) this.cbDefaultFX.Enabled = true; else this.cbDefaultFX.Enabled = false;
            if (this.levels.Value >= 3) this.cbDefaultFX2.Enabled = true; else this.cbDefaultFX2.Enabled = false;
            if (this.levels.Value >= 4) this.cbDefaultFX3.Enabled = true; else this.cbDefaultFX3.Enabled = false;
            if (this.levels.Value >= 5) this.cbDefaultFX4.Enabled = true; else this.cbDefaultFX4.Enabled = false;
            if (this.levels.Value >= 6) this.cbDefaultFX5.Enabled = true; else this.cbDefaultFX5.Enabled = false;
            if (this.levels.Value >= 7) this.cbDefaultFX6.Enabled = true; else this.cbDefaultFX6.Enabled = false;
            if (this.levels.Value >= 8) this.cbDefaultFX7.Enabled = true; else this.cbDefaultFX7.Enabled = false;
            /* End */
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
			this.components = new Container();
			this.groupBox3 = new GroupBox();
			this.lblLevel = new Label();
			this.levels = new TrackBar();
			this.cbFusion = new CheckBox();
			this.cbDescendClass = new CheckBox();
			this.cbCharge = new CheckBox();
			this.cbCanEatCandy = new CheckBox();
			this.cbSound = new CheckBox();
			this.cbWeapon = new CheckBox();
			this.txtVersion = new TextBox();
			this.txtDescription = new TextBox();
			this.label1 = new Label();
			this.label5 = new Label();
			this.txtName = new TextBox();
			this.label2 = new Label();
			this.label3 = new Label();
            this.txtAuthor = new TextBox();

            /* Transformation FX & Step Sound */
            this.cbDefaultFX = new CheckBox();
            this.cbDefaultFX2 = new CheckBox();
            this.cbDefaultFX3 = new CheckBox();
            this.cbDefaultFX4 = new CheckBox();
            this.cbDefaultFX5 = new CheckBox();
            this.cbDefaultFX6 = new CheckBox();
            this.cbDefaultFX7 = new CheckBox();
            this.cbDefaultStepSound = new CheckBox();

            /* Swoop Time & Stealth */
            this.cbSwoopTime = new CheckBox();
            this.cbStealth = new CheckBox();
            /* End */

			this.toolTipClass = new ToolTip(this.components);
			this.panel1 = new Panel();
			this.groupBox3.SuspendLayout();
			((ISupportInitialize)this.levels).BeginInit();
			base.SuspendLayout();
			this.groupBox3.Controls.Add(this.lblLevel);
			this.groupBox3.Controls.Add(this.levels);
			this.groupBox3.Controls.Add(this.cbFusion);
			this.groupBox3.Controls.Add(this.cbDescendClass);
			this.groupBox3.Controls.Add(this.cbCharge);
			this.groupBox3.Controls.Add(this.cbCanEatCandy);
			this.groupBox3.Controls.Add(this.cbSound);
			this.groupBox3.Controls.Add(this.cbWeapon);
			this.groupBox3.Controls.Add(this.txtVersion);
			this.groupBox3.Controls.Add(this.txtDescription);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.txtName);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtAuthor);

            /* Transformation FX & Step Sound */
            this.groupBox3.Controls.Add(this.cbDefaultFX);
            this.groupBox3.Controls.Add(this.cbDefaultFX2);
            this.groupBox3.Controls.Add(this.cbDefaultFX3);
            this.groupBox3.Controls.Add(this.cbDefaultFX4);
            this.groupBox3.Controls.Add(this.cbDefaultFX5);
            this.groupBox3.Controls.Add(this.cbDefaultFX6);
            this.groupBox3.Controls.Add(this.cbDefaultFX7);
            this.groupBox3.Controls.Add(this.cbDefaultStepSound);

            /* Swoop Time & Stealth */
            this.groupBox3.Controls.Add(this.cbSwoopTime);
            this.groupBox3.Controls.Add(this.cbStealth);
            /* End */

			this.groupBox3.ForeColor = Color.FromArgb(128, 128, 255);
			this.groupBox3.Location = new Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(500, 410);
			this.groupBox3.TabIndex = 30;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Main";
			this.lblLevel.AutoSize = true;
			this.lblLevel.Font = new Font("Arial Black", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblLevel.ForeColor = Color.FromArgb(128, 128, 255);
			this.lblLevel.Location = new Point(290, 107);
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new Size(121, 18);
			this.lblLevel.TabIndex = 29;
			this.lblLevel.Text = "Support 0 Transformation";
			this.lblLevel.TextAlign = ContentAlignment.MiddleCenter;
			this.levels.LargeChange = 1;
			this.levels.Location = new Point(283, 128);
			this.levels.Maximum = 8;
			this.levels.Minimum = 1;
			this.levels.Name = "levels";
			this.levels.Size = new Size(211, 45);
			this.levels.TabIndex = 28;
			this.levels.Value = 1;
			this.levels.ValueChanged += new EventHandler(this.levels_ValueChanged);
			this.cbFusion.AutoSize = true;
			this.cbFusion.Location = new Point(140, 123);
			this.cbFusion.Name = "cbFusion";
			this.cbFusion.Size = new Size(57, 17);
			this.cbFusion.TabIndex = 1;
			this.cbFusion.Text = "Fusion";
			this.toolTipClass.SetToolTip(this.cbFusion, "Set the Class as a Fusion Character");
			this.cbFusion.UseVisualStyleBackColor = true;
			this.cbDescendClass.AutoSize = true;
			this.cbDescendClass.Location = new Point(140, 100);
			this.cbDescendClass.Name = "cbDescendClass";
			this.cbDescendClass.Size = new Size(97, 17);
			this.cbDescendClass.TabIndex = 0;
			this.cbDescendClass.Text = "Enable Descend";
			this.toolTipClass.SetToolTip(this.cbDescendClass, "Class can descend\n( Override on per Level Base with Ascend/Descend Lock )");
			this.cbDescendClass.UseVisualStyleBackColor = true;
			this.cbCharge.AutoSize = true;
			this.cbCharge.Location = new Point(9, 146);
			this.cbCharge.Name = "cbCharge";
			this.cbCharge.Size = new Size(60, 17);
			this.cbCharge.TabIndex = 10;
			this.cbCharge.Text = "Charge Extension";
            this.toolTipClass.SetToolTip(this.cbCharge, "This option creates MOD.Charge.core for replacing Charge Sprites");
			this.cbCharge.UseVisualStyleBackColor = true;
			this.cbCanEatCandy.AutoSize = true;
			this.cbCanEatCandy.Location = new Point(140, 146);
			this.cbCanEatCandy.Name = "cbCanEatCandy";
			this.cbCanEatCandy.Size = new Size(96, 17);
			this.cbCanEatCandy.TabIndex = 27;
			this.cbCanEatCandy.Text = "Can eat Sensu Bean";
			this.cbCanEatCandy.UseVisualStyleBackColor = true;
			this.cbSound.AutoSize = true;
			this.cbSound.ForeColor = Color.FromArgb(128, 128, 255);
			this.cbSound.Location = new Point(9, 100);
			this.cbSound.Name = "cbSound";
			this.cbSound.Size = new Size(57, 17);
			this.cbSound.TabIndex = 8;
			this.cbSound.Text = "Sound Extension";
            this.toolTipClass.SetToolTip(this.cbSound, "This option creates MOD.Sound.core for replacing the sounds of the character");
			this.cbSound.UseVisualStyleBackColor = true;
			this.cbWeapon.AutoSize = true;
			this.cbWeapon.Location = new Point(9, 123);
			this.cbWeapon.Name = "cbWeapon";
			this.cbWeapon.Size = new Size(67, 17);
			this.cbWeapon.TabIndex = 9;
			this.cbWeapon.Text = "Weapon Extension";
            this.toolTipClass.SetToolTip(this.cbWeapon, "This option creates MOD.Weapon.core in order to add effects for attacks\n( Weapon Icon, Beam Speed, Explosions etc... )");
			this.cbWeapon.UseVisualStyleBackColor = true;
			this.txtVersion.BackColor = Color.WhiteSmoke;
			this.txtVersion.Location = new Point(78, 38);
			this.txtVersion.MaxLength = 8;
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.Size = new Size(93, 20);
			this.txtVersion.TabIndex = 20;
			this.txtVersion.Text = "1.0";
			this.txtDescription.BackColor = Color.WhiteSmoke;
			this.txtDescription.ForeColor = Color.Black;
			this.txtDescription.Location = new Point(283, 19);
			this.txtDescription.MaxLength = 255;
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new Size(211, 59);
			this.txtDescription.TabIndex = 26;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "Name";
			this.toolTipClass.SetToolTip(this.label1, "The name of the character");
			this.label5.AutoSize = true;
			this.label5.Location = new Point(210, 22);
			this.label5.Name = "label5";
			this.label5.Size = new Size(60, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Description";
			this.toolTipClass.SetToolTip(this.label5, "Provide a short text for the character");
			this.txtName.BackColor = Color.WhiteSmoke;
			this.txtName.Location = new Point(78, 19);
			this.txtName.MaxLength = 31;
			this.txtName.Name = "txtName";
			this.txtName.Size = new Size(93, 20);
			this.txtName.TabIndex = 18;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(6, 43);
			this.label2.Name = "label2";
			this.label2.Size = new Size(42, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Version";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(6, 61);
			this.label3.Name = "label3";
			this.label3.Size = new Size(38, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Author";
			this.txtAuthor.BackColor = Color.WhiteSmoke;
			this.txtAuthor.Location = new Point(78, 58);
			this.txtAuthor.MaxLength = 16;
			this.txtAuthor.Name = "txtAuthor";
			this.txtAuthor.Size = new Size(93, 20);
			this.txtAuthor.TabIndex = 22;
			this.toolTipClass.BackColor = SystemColors.Desktop;
			this.toolTipClass.ForeColor = SystemColors.MenuBar;
			this.toolTipClass.ToolTipIcon = ToolTipIcon.Info;
			this.toolTipClass.ToolTipTitle = "Description";
			this.panel1.BackgroundImage = Resources.wizard;
			this.panel1.Location = new Point(4, 415);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(500, 245);
            this.panel1.TabIndex = 31;

            /* Transformation FX & Step Sound */
            this.cbDefaultFX.Enabled = false;
            this.cbDefaultFX.AutoSize = true;
            this.cbDefaultFX.Location = new Point(9, 200);
            this.cbDefaultFX.Name = "cbDefaultFX";
            this.cbDefaultFX.Size = new Size(57, 17);
            this.cbDefaultFX.TabIndex = 1;
            this.cbDefaultFX.Text = "Use default transformation FX when transforming to SSJ1";
            this.cbDefaultFX.UseVisualStyleBackColor = true;

            this.cbDefaultFX2.Enabled = false;
            this.cbDefaultFX2.AutoSize = true;
            this.cbDefaultFX2.Location = new Point(9, 230);
            this.cbDefaultFX2.Name = "cbDefaultFX2";
            this.cbDefaultFX2.Size = new Size(57, 17);
            this.cbDefaultFX2.TabIndex = 1;
            this.cbDefaultFX2.Text = "Use default transformation FX when transforming to SSJ2";
            this.cbDefaultFX2.UseVisualStyleBackColor = true;

            this.cbDefaultFX3.Enabled = false;
            this.cbDefaultFX3.AutoSize = true;
            this.cbDefaultFX3.Location = new Point(9, 260);
            this.cbDefaultFX3.Name = "cbDefaultFX3";
            this.cbDefaultFX3.Size = new Size(57, 17);
            this.cbDefaultFX3.TabIndex = 1;
            this.cbDefaultFX3.Text = "Use default transformation FX when transforming to SSJ3";
            this.cbDefaultFX3.UseVisualStyleBackColor = true;

            this.cbDefaultFX4.Enabled = false;
            this.cbDefaultFX4.AutoSize = true;
            this.cbDefaultFX4.Location = new Point(9, 290);
            this.cbDefaultFX4.Name = "cbDefaultFX4";
            this.cbDefaultFX4.Size = new Size(57, 17);
            this.cbDefaultFX4.TabIndex = 1;
            this.cbDefaultFX4.Text = "Use default transformation FX when transforming to SSJ4";
            this.cbDefaultFX4.UseVisualStyleBackColor = true;

            this.cbDefaultFX5.Enabled = false;
            this.cbDefaultFX5.AutoSize = true;
            this.cbDefaultFX5.Location = new Point(9, 320);
            this.cbDefaultFX5.Name = "cbDefaultFX5";
            this.cbDefaultFX5.Size = new Size(57, 17);
            this.cbDefaultFX5.TabIndex = 1;
            this.cbDefaultFX5.Text = "Use default transformation FX when transforming to SSJ5";
            this.cbDefaultFX5.UseVisualStyleBackColor = true;

            this.cbDefaultFX6.Enabled = false;
            this.cbDefaultFX6.AutoSize = true;
            this.cbDefaultFX6.Location = new Point(9, 350);
            this.cbDefaultFX6.Name = "cbDefaultFX6";
            this.cbDefaultFX6.Size = new Size(57, 17);
            this.cbDefaultFX6.TabIndex = 1;
            this.cbDefaultFX6.Text = "Use default transformation FX when transforming to SSJ6";
            this.cbDefaultFX6.UseVisualStyleBackColor = true;

            this.cbDefaultFX7.Enabled = false;
            this.cbDefaultFX7.AutoSize = true;
            this.cbDefaultFX7.Location = new Point(9, 380);
            this.cbDefaultFX7.Name = "cbDefaultFX7";
            this.cbDefaultFX7.Size = new Size(57, 17);
            this.cbDefaultFX7.TabIndex = 1;
            this.cbDefaultFX7.Text = "Use default transformation FX when transforming to SSJ7";
            this.cbDefaultFX7.UseVisualStyleBackColor = true;

            this.cbDefaultStepSound.Enabled = true;
            this.cbDefaultStepSound.AutoSize = true;
            this.cbDefaultStepSound.Location = new Point(9, 175);
            this.cbDefaultStepSound.Name = "cbDefaultStepSound";
            this.cbDefaultStepSound.Size = new Size(57, 17);
            this.cbDefaultStepSound.TabIndex = 1;
            this.cbDefaultStepSound.Text = "StepSound";
            this.toolTipClass.SetToolTip(this.cbDefaultStepSound, "Enable the default Half-Life Step Sound");
            this.cbDefaultStepSound.UseVisualStyleBackColor = true;
            
            /* Swoop Time & Stealth */
            this.cbSwoopTime.Enabled = true;
            this.cbSwoopTime.AutoSize = true;
            this.cbSwoopTime.Location = new Point(283, 175);
            this.cbSwoopTime.Name = "cbDefaultSwoopTime";
            this.cbSwoopTime.Size = new Size(57, 17);
            this.cbSwoopTime.TabIndex = 1;
            this.cbSwoopTime.Text = "Infinite Swoop Time";
            this.toolTipClass.SetToolTip(this.cbSwoopTime, "The character can swooping as long as the player wants");
            this.cbSwoopTime.UseVisualStyleBackColor = true;

            this.cbStealth.Enabled = true;
            this.cbStealth.AutoSize = true;
            this.cbStealth.Location = new Point(140, 175);
            this.cbStealth.Name = "cbDefaultStealth";
            this.cbStealth.Size = new Size(57, 17);
            this.cbStealth.TabIndex = 1;
            this.cbStealth.Text = "Stealth";
            this.toolTipClass.SetToolTip(this.cbStealth, "Make the character semitransparent to make other players difficult to find you");
            this.cbStealth.UseVisualStyleBackColor = true;
            /* End */

			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.WhiteSmoke;
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.groupBox3);
			base.Name = "ClassPanel";
			base.Size = new Size(509, 665);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((ISupportInitialize)this.levels).EndInit();
			base.ResumeLayout(false);
		}
	}
}
