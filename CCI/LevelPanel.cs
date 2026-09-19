using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCI
{
	public class LevelPanel : MyControl
	{
		private IContainer components = null;

		internal GroupBox groupBox4;

		internal ListView listWeapon;

		internal GroupBox groupBox5;

		internal NumericUpDown AuraSkin;

		internal CheckBox cbLightning;

		internal CheckBox cbGlow;

		internal Label label40;

		internal TextBox txtAura;

		internal GroupBox groupBox6;

		internal Label label41;

		internal Label label42;

		internal Label label43;

		internal Label label44;

		internal Label label45;

		internal TextBox txtName;

		internal CheckBox cbTeleportSwoop;

		internal CheckBox cbTeleportCharge;

		internal CheckBox cbNoDescend;

		internal CheckBox cbNoAscend;

		internal Label label46;

		internal Label label47;

		internal Label label48;

		internal Label label49;

		internal Label label50;

		internal Label label51;

		internal Label label52;

		internal Label label53;

		internal TextBox txtModel;

		internal ToolTip toolTipLevel;

		internal Button btnGlowColor;

		internal ComboBox AuraRenderMode;

		internal Label label1;

		internal Button btnChargeColor;

		internal Label label2;

		internal Label label3;

		internal Label label4;

		internal Label label5;

		internal Button btnAuraColor;

		internal Label label6;

		internal NumericUpDown LgtTorso;

		internal NumericUpDown LgtHead;

		internal NumericUpDown LgtFeets;

		internal CheckBox cbHypermode;

		internal CheckBox cbTeleSense;

		private GroupBox groupBox1;

		internal CheckBox cbSwoopSense;

		internal NumericUpDown Booster;

		internal NumericUpDown KiRate;

		internal NumericUpDown PowerLevel;

		internal NumericUpDown PerfectPowerLevel;

		internal NumericUpDown PowerLevelMultiplier;

		internal NumericUpDown Speed;

		internal NumericUpDown LgtRange;

		internal NumericUpDown AuraOpacityMax;

		internal NumericUpDown Health;

		internal NumericUpDown AscendTime;

		internal NumericUpDown PerfectAscendTime;

		internal NumericUpDown GlowWidth;

		internal NumericUpDown TeleportKi;

		internal NumericUpDown TeleportRange;

		internal Label label8;

		internal NumericUpDown MeleeSense;

		internal Label label9;

		internal NumericUpDown StrongMelee;

		internal Label labelAttack;

		internal Label labelDefense;

		private GroupBox groupBox2;

		internal TrackBar trackAttack;

		internal TrackBar trackDefense;

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
			ListViewItem listViewItem = new ListViewItem(new string[]
			{
				"Melee"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem2 = new ListViewItem(new string[]
			{
				"Sword"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem3 = new ListViewItem(new string[]
			{
				"ShieldAttack"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem4 = new ListViewItem(new string[]
			{
				"SolarFlare"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem5 = new ListViewItem(new string[]
			{
				"KiBlast"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem6 = new ListViewItem(new string[]
			{
				"Renzoku"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem7 = new ListViewItem(new string[]
			{
				"ScatterShot"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem8 = new ListViewItem(new string[]
			{
				"Regeneration"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem9 = new ListViewItem(new string[]
			{
				"CandyLaser"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem10 = new ListViewItem(new string[]
			{
				"EyeLaser"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem11 = new ListViewItem(new string[]
			{
				"FingerLaser"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem12 = new ListViewItem(new string[]
			{
				"FriezaDeathBall"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem13 = new ListViewItem(new string[]
			{
				"SpiritBomb"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem14 = new ListViewItem(new string[]
			{
				"FriezaDisc"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem15 = new ListViewItem(new string[]
			{
				"KrillinDisc"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem16 = new ListViewItem(new string[]
			{
				"BurningAttack"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem17 = new ListViewItem(new string[]
			{
				"FinalFlash"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem18 = new ListViewItem(new string[]
			{
				"Gallitgun"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem19 = new ListViewItem(new string[]
			{
				"GenericBeam"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem20 = new ListViewItem(new string[]
			{
				"Kamehameha"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem21 = new ListViewItem(new string[]
			{
				"Masenko"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem22 = new ListViewItem(new string[]
			{
				"MouthBlast"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem23 = new ListViewItem(new string[]
			{
				"PowerBeam"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem24 = new ListViewItem(new string[]
			{
				"ScatterBeam"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem25 = new ListViewItem(new string[]
			{
				"SpecialBeamCannon"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem26 = new ListViewItem(new string[]
			{
				"RockControl"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem27 = new ListViewItem(new string[]
			{
				"BigbangAttack"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem28 = new ListViewItem(new string[]
			{
				"KameTorpedo"
			}, -1, SystemColors.Desktop, Color.Empty, null);
			ListViewItem listViewItem29 = new ListViewItem(new string[]
			{
				"FinishingBuster"
			}, -1, SystemColors.Desktop, Color.Empty, null);
            ListViewItem listViewItem30 = new ListViewItem(new string[]
			{
				"KaioKen"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem31 = new ListViewItem(new string[]
			{
				"DragonFist"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem32 = new ListViewItem(new string[]
			{
				"BuuDeathBall"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem33 = new ListViewItem(new string[]
			{
				"BuuGenocideBlast"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem34 = new ListViewItem(new string[]
			{
				"WolffangFist"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem35 = new ListViewItem(new string[]
			{
				"Shield"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem36 = new ListViewItem(new string[]
			{
				"SuperGhostKamikazeAttack"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem37 = new ListViewItem(new string[]
			{
				"GogetaSoulPunisher"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem38 = new ListViewItem(new string[]
			{
				"Tornado"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem39 = new ListViewItem(new string[]
			{
				"SpiritSword"
			}, -1, SystemColors.Highlight, Color.Empty, null);
            ListViewItem listViewItem40 = new ListViewItem(new string[]
			{
				"UltimateSacrifice"
			}, -1, SystemColors.Highlight, Color.Empty, null);
			this.groupBox4 = new GroupBox();
			this.listWeapon = new ListView();
			this.groupBox5 = new GroupBox();
			this.GlowWidth = new NumericUpDown();
			this.AuraOpacityMax = new NumericUpDown();
			this.LgtRange = new NumericUpDown();
			this.LgtFeets = new NumericUpDown();
			this.LgtTorso = new NumericUpDown();
			this.LgtHead = new NumericUpDown();
			this.label6 = new Label();
			this.btnAuraColor = new Button();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.btnChargeColor = new Button();
			this.label1 = new Label();
			this.AuraRenderMode = new ComboBox();
			this.btnGlowColor = new Button();
			this.AuraSkin = new NumericUpDown();
			this.cbLightning = new CheckBox();
			this.cbGlow = new CheckBox();
			this.label40 = new Label();
			this.txtAura = new TextBox();
			this.Speed = new NumericUpDown();
			this.groupBox6 = new GroupBox();
			this.TeleportKi = new NumericUpDown();
			this.TeleportRange = new NumericUpDown();
			this.PerfectAscendTime = new NumericUpDown();
			this.AscendTime = new NumericUpDown();
			this.Health = new NumericUpDown();
			this.PowerLevelMultiplier = new NumericUpDown();
			this.PerfectPowerLevel = new NumericUpDown();
			this.PowerLevel = new NumericUpDown();
			this.KiRate = new NumericUpDown();
			this.Booster = new NumericUpDown();
			this.label41 = new Label();
			this.label42 = new Label();
			this.label43 = new Label();
			this.label44 = new Label();
			this.label45 = new Label();
			this.txtName = new TextBox();
			this.cbNoDescend = new CheckBox();
			this.cbNoAscend = new CheckBox();
			this.label46 = new Label();
			this.label47 = new Label();
			this.label48 = new Label();
			this.label49 = new Label();
			this.label50 = new Label();
			this.label51 = new Label();
			this.label52 = new Label();
			this.label53 = new Label();
			this.txtModel = new TextBox();
			this.labelDefense = new Label();
			this.labelAttack = new Label();
			this.trackDefense = new TrackBar();
			this.trackAttack = new TrackBar();
			this.cbHypermode = new CheckBox();
			this.cbTeleSense = new CheckBox();
			this.cbTeleportSwoop = new CheckBox();
			this.cbTeleportCharge = new CheckBox();
			this.toolTipLevel = new ToolTip(this.components);
			this.cbSwoopSense = new CheckBox();
			this.label9 = new Label();
			this.label8 = new Label();
			this.groupBox1 = new GroupBox();
			this.StrongMelee = new NumericUpDown();
			this.MeleeSense = new NumericUpDown();
			this.groupBox2 = new GroupBox();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((ISupportInitialize)this.GlowWidth).BeginInit();
			((ISupportInitialize)this.AuraOpacityMax).BeginInit();
			((ISupportInitialize)this.LgtRange).BeginInit();
			((ISupportInitialize)this.LgtFeets).BeginInit();
			((ISupportInitialize)this.LgtTorso).BeginInit();
			((ISupportInitialize)this.LgtHead).BeginInit();
			((ISupportInitialize)this.AuraSkin).BeginInit();
			((ISupportInitialize)this.Speed).BeginInit();
			this.groupBox6.SuspendLayout();
			((ISupportInitialize)this.TeleportKi).BeginInit();
			((ISupportInitialize)this.TeleportRange).BeginInit();
			((ISupportInitialize)this.PerfectAscendTime).BeginInit();
			((ISupportInitialize)this.AscendTime).BeginInit();
			((ISupportInitialize)this.Health).BeginInit();
			((ISupportInitialize)this.PowerLevelMultiplier).BeginInit();
			((ISupportInitialize)this.PerfectPowerLevel).BeginInit();
			((ISupportInitialize)this.PowerLevel).BeginInit();
			((ISupportInitialize)this.KiRate).BeginInit();
			((ISupportInitialize)this.Booster).BeginInit();
			((ISupportInitialize)this.trackDefense).BeginInit();
			((ISupportInitialize)this.trackAttack).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.StrongMelee).BeginInit();
			((ISupportInitialize)this.MeleeSense).BeginInit();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.groupBox4.Controls.Add(this.listWeapon);
			this.groupBox4.ForeColor = Color.FromArgb(128, 128, 255);
			this.groupBox4.Location = new Point(3, 359);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(500, 196);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Attacks";
			this.listWeapon.BackColor = Color.WhiteSmoke;
			this.listWeapon.BorderStyle = BorderStyle.None;
			this.listWeapon.CheckBoxes = true;
			listViewItem.Checked = true;
			listViewItem.StateImageIndex = 1;
			listViewItem2.StateImageIndex = 0;
			listViewItem3.StateImageIndex = 0;
			listViewItem4.StateImageIndex = 0;
			listViewItem5.StateImageIndex = 0;
			listViewItem6.StateImageIndex = 0;
			listViewItem7.StateImageIndex = 0;
			listViewItem8.StateImageIndex = 0;
			listViewItem9.StateImageIndex = 0;
			listViewItem10.StateImageIndex = 0;
			listViewItem11.StateImageIndex = 0;
			listViewItem12.StateImageIndex = 0;
			listViewItem13.StateImageIndex = 0;
			listViewItem14.StateImageIndex = 0;
			listViewItem15.StateImageIndex = 0;
			listViewItem16.StateImageIndex = 0;
			listViewItem17.StateImageIndex = 0;
			listViewItem18.StateImageIndex = 0;
			listViewItem19.StateImageIndex = 0;
			listViewItem20.StateImageIndex = 0;
			listViewItem21.StateImageIndex = 0;
			listViewItem22.StateImageIndex = 0;
			listViewItem23.StateImageIndex = 0;
			listViewItem24.StateImageIndex = 0;
			listViewItem25.StateImageIndex = 0;
			listViewItem26.StateImageIndex = 0;
			listViewItem27.StateImageIndex = 0;
			listViewItem28.StateImageIndex = 0;
            listViewItem29.StateImageIndex = 0;
            listViewItem30.StateImageIndex = 0;
            listViewItem31.StateImageIndex = 0;
            listViewItem32.StateImageIndex = 0;
            listViewItem33.StateImageIndex = 0;
            listViewItem34.StateImageIndex = 0;
            listViewItem35.StateImageIndex = 0;
            listViewItem36.StateImageIndex = 0;
            listViewItem37.StateImageIndex = 0;
            listViewItem38.StateImageIndex = 0;
            listViewItem39.StateImageIndex = 0;
            listViewItem40.StateImageIndex = 0;
			this.listWeapon.Items.AddRange(new ListViewItem[]
			{
				listViewItem,
				listViewItem2,
				listViewItem3,
				listViewItem4,
				listViewItem5,
				listViewItem6,
				listViewItem7,
				listViewItem8,
				listViewItem9,
				listViewItem10,
				listViewItem11,
				listViewItem12,
				listViewItem13,
				listViewItem14,
				listViewItem15,
				listViewItem16,
				listViewItem17,
				listViewItem18,
				listViewItem19,
				listViewItem20,
				listViewItem21,
				listViewItem22,
				listViewItem23,
				listViewItem24,
				listViewItem25,
				listViewItem26,
				listViewItem27,
				listViewItem28,
				listViewItem29,
				listViewItem30,
                listViewItem31,
				listViewItem32,
                listViewItem33,
                listViewItem34,
                listViewItem35,
                listViewItem36,
                listViewItem37,
                listViewItem38,
                listViewItem39,
                listViewItem40
			});
			this.listWeapon.LabelEdit = true;
			this.listWeapon.LabelWrap = false;
			this.listWeapon.Location = new Point(11, 19);
			this.listWeapon.Name = "listWeapon";
			this.listWeapon.Scrollable = true;
			this.listWeapon.Size = new Size(474, 171);
			this.listWeapon.TabIndex = 0;
			this.listWeapon.TileSize = new Size(1, 1);
			this.listWeapon.UseCompatibleStateImageBehavior = false;
			this.listWeapon.View = View.List;
			this.groupBox5.Controls.Add(this.GlowWidth);
			this.groupBox5.Controls.Add(this.AuraOpacityMax);
			this.groupBox5.Controls.Add(this.LgtRange);
			this.groupBox5.Controls.Add(this.LgtFeets);
			this.groupBox5.Controls.Add(this.LgtTorso);
			this.groupBox5.Controls.Add(this.LgtHead);
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.btnAuraColor);
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.btnChargeColor);
			this.groupBox5.Controls.Add(this.label1);
			this.groupBox5.Controls.Add(this.AuraRenderMode);
			this.groupBox5.Controls.Add(this.btnGlowColor);
			this.groupBox5.Controls.Add(this.AuraSkin);
			this.groupBox5.Controls.Add(this.cbLightning);
			this.groupBox5.Controls.Add(this.cbGlow);
			this.groupBox5.Controls.Add(this.label40);
			this.groupBox5.Controls.Add(this.txtAura);
			this.groupBox5.ForeColor = Color.FromArgb(128, 128, 255);
			this.groupBox5.Location = new Point(249, 3);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(254, 190);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Effects";
			this.GlowWidth.BackColor = Color.WhiteSmoke;
			this.GlowWidth.Enabled = false;
			this.GlowWidth.Location = new Point(200, 19);
			NumericUpDown arg_EB8_0 = this.GlowWidth;
			int[] array = new int[4];
			array[0] = 255;
			arg_EB8_0.Maximum = new decimal(array);
			this.GlowWidth.Name = "GlowWidth";
			this.GlowWidth.Size = new Size(39, 20);
			this.GlowWidth.TabIndex = 57;
			NumericUpDown arg_F0C_0 = this.GlowWidth;
			array = new int[4];
			array[0] = 2;
			arg_F0C_0.Value = new decimal(array);
			this.AuraOpacityMax.BackColor = Color.WhiteSmoke;
			this.AuraOpacityMax.DecimalPlaces = 1;
			this.AuraOpacityMax.Location = new Point(48, 119);
			NumericUpDown arg_F63_0 = this.AuraOpacityMax;
			array = new int[4];
			array[0] = 255;
			arg_F63_0.Maximum = new decimal(array);
			this.AuraOpacityMax.Name = "AuraOpacityMax";
			this.AuraOpacityMax.Size = new Size(47, 20);
			this.AuraOpacityMax.TabIndex = 56;
			this.toolTipLevel.SetToolTip(this.AuraOpacityMax, "Aura/Trail Opacity");
			NumericUpDown arg_FCF_0 = this.AuraOpacityMax;
			array = new int[4];
			array[0] = 50;
			arg_FCF_0.Value = new decimal(array);
			this.LgtRange.BackColor = Color.WhiteSmoke;
			this.LgtRange.Enabled = false;
			this.LgtRange.Location = new Point(200, 75);
			NumericUpDown arg_1026_0 = this.LgtRange;
			array = new int[4];
			array[0] = 15;
			arg_1026_0.Maximum = new decimal(array);
			NumericUpDown arg_1046_0 = this.LgtRange;
			array = new int[4];
			array[0] = 1;
			arg_1046_0.Minimum = new decimal(array);
			this.LgtRange.Name = "LgtRange";
			this.LgtRange.Size = new Size(40, 20);
			this.LgtRange.TabIndex = 55;
			NumericUpDown arg_109A_0 = this.LgtRange;
			array = new int[4];
			array[0] = 7;
			arg_109A_0.Value = new decimal(array);
			this.LgtFeets.BackColor = Color.WhiteSmoke;
			this.LgtFeets.Enabled = false;
			this.LgtFeets.Location = new Point(94, 75);
			NumericUpDown arg_10ED_0 = this.LgtFeets;
			array = new int[4];
			array[0] = 5;
			arg_10ED_0.Maximum = new decimal(array);
			NumericUpDown arg_110D_0 = this.LgtFeets;
			array = new int[4];
			array[0] = 1;
			arg_110D_0.Minimum = new decimal(array);
			this.LgtFeets.Name = "LgtFeets";
			this.LgtFeets.Size = new Size(40, 20);
			this.LgtFeets.TabIndex = 47;
			NumericUpDown arg_1161_0 = this.LgtFeets;
			array = new int[4];
			array[0] = 1;
			arg_1161_0.Value = new decimal(array);
			this.LgtTorso.BackColor = Color.WhiteSmoke;
			this.LgtTorso.Enabled = false;
			this.LgtTorso.Location = new Point(200, 56);
			NumericUpDown arg_11B7_0 = this.LgtTorso;
			array = new int[4];
			array[0] = 5;
			arg_11B7_0.Maximum = new decimal(array);
			NumericUpDown arg_11D7_0 = this.LgtTorso;
			array = new int[4];
			array[0] = 1;
			arg_11D7_0.Minimum = new decimal(array);
			this.LgtTorso.Name = "LgtTorso";
			this.LgtTorso.Size = new Size(40, 20);
			this.LgtTorso.TabIndex = 46;
			NumericUpDown arg_122B_0 = this.LgtTorso;
			array = new int[4];
			array[0] = 1;
			arg_122B_0.Value = new decimal(array);
			this.LgtHead.BackColor = Color.WhiteSmoke;
			this.LgtHead.Enabled = false;
			this.LgtHead.Location = new Point(94, 56);
			NumericUpDown arg_127E_0 = this.LgtHead;
			array = new int[4];
			array[0] = 5;
			arg_127E_0.Maximum = new decimal(array);
			NumericUpDown arg_129E_0 = this.LgtHead;
			array = new int[4];
			array[0] = 1;
			arg_129E_0.Minimum = new decimal(array);
			this.LgtHead.Name = "LgtHead";
			this.LgtHead.Size = new Size(40, 20);
			this.LgtHead.TabIndex = 45;
			NumericUpDown arg_12F2_0 = this.LgtHead;
			array = new int[4];
			array[0] = 1;
			arg_12F2_0.Value = new decimal(array);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(152, 22);
			this.label6.Name = "label6";
			this.label6.Size = new Size(35, 13);
			this.label6.TabIndex = 43;
			this.label6.Text = "Width";
			this.btnAuraColor.BackColor = Color.White;
			this.btnAuraColor.FlatStyle = FlatStyle.Flat;
			this.btnAuraColor.Location = new Point(201, 133);
			this.btnAuraColor.Name = "btnAuraColor";
			this.btnAuraColor.Size = new Size(19, 17);
			this.btnAuraColor.TabIndex = 42;
			this.toolTipLevel.SetToolTip(this.btnAuraColor, "Aura Trail Color");
			this.btnAuraColor.UseVisualStyleBackColor = false;
			this.btnAuraColor.Click += new EventHandler(this.btnAuraColor_Click);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(151, 78);
			this.label4.Name = "label4";
			this.label4.Size = new Size(39, 13);
			this.label4.TabIndex = 40;
			this.label4.Text = "Range";
			this.toolTipLevel.SetToolTip(this.label4, "Range of lightning");
			this.label5.AutoSize = true;
			this.label5.Location = new Point(151, 59);
			this.label5.Name = "label5";
			this.label5.Size = new Size(34, 13);
			this.label5.TabIndex = 38;
			this.label5.Text = "Torso";
            this.toolTipLevel.SetToolTip(this.label5, "Scale of Sprite");
			this.label3.AutoSize = true;
			this.label3.Location = new Point(49, 77);
			this.label3.Name = "label3";
			this.label3.Size = new Size(28, 13);
			this.label3.TabIndex = 36;
			this.label3.Text = "Feet";
            this.toolTipLevel.SetToolTip(this.label3, "Scale of Sprite");
			this.label2.AutoSize = true;
			this.label2.Location = new Point(49, 59);
			this.label2.Name = "label2";
			this.label2.Size = new Size(33, 13);
			this.label2.TabIndex = 34;
			this.label2.Text = "Head";
            this.toolTipLevel.SetToolTip(this.label2, "Scale of Sprite");
			this.btnChargeColor.BackColor = Color.White;
			this.btnChargeColor.FlatStyle = FlatStyle.Flat;
			this.btnChargeColor.Location = new Point(86, 168);
			this.btnChargeColor.Name = "btnChargeColor";
			this.btnChargeColor.Size = new Size(19, 17);
			this.btnChargeColor.TabIndex = 32;
			this.btnChargeColor.UseVisualStyleBackColor = false;
			this.btnChargeColor.Click += new EventHandler(this.btnChargeColor_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 168);
			this.label1.Name = "label1";
			this.label1.Size = new Size(68, 13);
			this.label1.TabIndex = 31;
			this.label1.Text = "Charge Color";
			this.toolTipLevel.SetToolTip(this.label1, "Powerup Color");
			this.AuraRenderMode.AutoCompleteCustomSource.AddRange(new string[]
			{
				"kRenderNormal",
				"kRenderTransColor",
				"kRenderTransTexture",
				"kRenderGlow",
				"kRenderTransAlpha",
				"kRenderTransAdd"
			});
			this.AuraRenderMode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.AuraRenderMode.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.AuraRenderMode.BackColor = Color.WhiteSmoke;
			this.AuraRenderMode.FormattingEnabled = true;
			this.AuraRenderMode.Items.AddRange(new object[]
			{
				"kRenderNormal",
				"kRenderTransColor",
				"kRenderTransTexture",
				"kRenderGlow",
				"kRenderTransAlpha",
				"kRenderTransAdd"
			});
			this.AuraRenderMode.Location = new Point(47, 138);
			this.AuraRenderMode.Name = "AuraRenderMode";
			this.AuraRenderMode.Size = new Size(130, 21);
			this.AuraRenderMode.TabIndex = 30;
			this.AuraRenderMode.Text = "kRenderTransAdd";
			this.toolTipLevel.SetToolTip(this.AuraRenderMode, "Aura Render Mode");
			this.btnGlowColor.BackColor = Color.White;
			this.btnGlowColor.Enabled = false;
			this.btnGlowColor.FlatStyle = FlatStyle.Flat;
			this.btnGlowColor.Location = new Point(115, 18);
			this.btnGlowColor.Name = "btnGlowColor";
			this.btnGlowColor.Size = new Size(19, 17);
			this.btnGlowColor.TabIndex = 29;
			this.btnGlowColor.UseVisualStyleBackColor = false;
			this.btnGlowColor.Click += new EventHandler(this.btnGlowColor_Click);
			this.AuraSkin.BackColor = Color.WhiteSmoke;
			this.AuraSkin.Location = new Point(137, 119);
			NumericUpDown arg_194B_0 = this.AuraSkin;
			array = new int[4];
			array[0] = 10;
			arg_194B_0.Maximum = new decimal(array);
			this.AuraSkin.Name = "AuraSkin";
			this.AuraSkin.Size = new Size(40, 20);
			this.AuraSkin.TabIndex = 26;
			this.toolTipLevel.SetToolTip(this.AuraSkin, "Aura skin index\n( Hint: Use HLMV to find out the color for your aura )\n\nDefault Index\n0: White\n1: Green\n2: Purple\n3: Red\n4: Yellow");
			this.cbLightning.AutoSize = true;
			this.cbLightning.Location = new Point(9, 36);
			this.cbLightning.Name = "cbLightning";
			this.cbLightning.Size = new Size(69, 17);
			this.cbLightning.TabIndex = 2;
			this.cbLightning.Text = "Lightning";
			this.toolTipLevel.SetToolTip(this.cbLightning, "Character Lightning FX");
			this.cbLightning.UseVisualStyleBackColor = true;
			this.cbLightning.CheckedChanged += new EventHandler(this.cbLightning_CheckedChanged);
			this.cbGlow.AutoSize = true;
			this.cbGlow.Location = new Point(9, 19);
			this.cbGlow.Name = "cbGlow";
			this.cbGlow.Size = new Size(50, 17);
			this.cbGlow.TabIndex = 0;
			this.cbGlow.Text = "Glow";
			this.toolTipLevel.SetToolTip(this.cbGlow, "Character Glow FX");
			this.cbGlow.UseVisualStyleBackColor = true;
			this.cbGlow.CheckedChanged += new EventHandler(this.cbGlow_CheckedChanged);
			this.label40.AutoSize = true;
			this.label40.Location = new Point(12, 103);
			this.label40.Name = "label40";
			this.label40.Size = new Size(29, 13);
			this.label40.TabIndex = 19;
			this.label40.Text = "Aura";
			this.txtAura.BackColor = Color.WhiteSmoke;
			this.txtAura.Location = new Point(47, 100);
			this.txtAura.MaxLength = 64;
			this.txtAura.Name = "txtAura";
			this.txtAura.Size = new Size(193, 20);
			this.txtAura.TabIndex = 20;
			this.txtAura.Text = "models/evolution/Auras/shape_01.mdl";
			this.toolTipLevel.SetToolTip(this.txtAura, "The path of the aura model");
			this.Speed.BackColor = Color.WhiteSmoke;
			NumericUpDown arg_1C06_0 = this.Speed;
			array = new int[4];
			array[0] = 50;
			arg_1C06_0.Increment = new decimal(array);
			this.Speed.Location = new Point(128, 151);
			NumericUpDown arg_1C45_0 = this.Speed;
			array = new int[4];
			array[0] = 1000;
			arg_1C45_0.Maximum = new decimal(array);
			this.Speed.Name = "Speed";
			this.Speed.Size = new Size(94, 20);
			this.Speed.TabIndex = 54;
			NumericUpDown arg_1C9D_0 = this.Speed;
			array = new int[4];
			array[0] = 400;
			arg_1C9D_0.Value = new decimal(array);
			this.groupBox6.Controls.Add(this.TeleportKi);
			this.groupBox6.Controls.Add(this.TeleportRange);
			this.groupBox6.Controls.Add(this.PerfectAscendTime);
			this.groupBox6.Controls.Add(this.AscendTime);
			this.groupBox6.Controls.Add(this.Health);
			this.groupBox6.Controls.Add(this.PowerLevelMultiplier);
			this.groupBox6.Controls.Add(this.PerfectPowerLevel);
			this.groupBox6.Controls.Add(this.Speed);
			this.groupBox6.Controls.Add(this.PowerLevel);
			this.groupBox6.Controls.Add(this.KiRate);
			this.groupBox6.Controls.Add(this.Booster);
			this.groupBox6.Controls.Add(this.label41);
			this.groupBox6.Controls.Add(this.label42);
			this.groupBox6.Controls.Add(this.label43);
			this.groupBox6.Controls.Add(this.label44);
			this.groupBox6.Controls.Add(this.label45);
			this.groupBox6.Controls.Add(this.txtName);
			this.groupBox6.Controls.Add(this.cbNoDescend);
			this.groupBox6.Controls.Add(this.cbNoAscend);
			this.groupBox6.Controls.Add(this.label46);
			this.groupBox6.Controls.Add(this.label47);
			this.groupBox6.Controls.Add(this.label48);
			this.groupBox6.Controls.Add(this.label49);
			this.groupBox6.Controls.Add(this.label50);
			this.groupBox6.Controls.Add(this.label51);
			this.groupBox6.Controls.Add(this.label52);
			this.groupBox6.Controls.Add(this.label53);
			this.groupBox6.Controls.Add(this.txtModel);
			this.groupBox6.ForeColor = Color.FromArgb(128, 128, 255);
			this.groupBox6.Location = new Point(3, 3);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(240, 350);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Main";
			this.TeleportKi.BackColor = Color.WhiteSmoke;
			NumericUpDown arg_1FDD_0 = this.TeleportKi;
			array = new int[4];
			array[0] = 50;
			arg_1FDD_0.Increment = new decimal(array);
			this.TeleportKi.Location = new Point(128, 275);
			NumericUpDown arg_201C_0 = this.TeleportKi;
			array = new int[4];
			array[0] = 1000;
			arg_201C_0.Maximum = new decimal(array);
			this.TeleportKi.Name = "TeleportKi";
			this.TeleportKi.Size = new Size(94, 20);
			this.TeleportKi.TabIndex = 59;
			NumericUpDown arg_2071_0 = this.TeleportKi;
			array = new int[4];
			array[0] = 100;
			arg_2071_0.Value = new decimal(array);
			this.TeleportRange.BackColor = Color.WhiteSmoke;
			NumericUpDown arg_20A3_0 = this.TeleportRange;
			array = new int[4];
			array[0] = 50;
			arg_20A3_0.Increment = new decimal(array);
			this.TeleportRange.Location = new Point(128, 256);
			NumericUpDown arg_20E2_0 = this.TeleportRange;
			array = new int[4];
			array[0] = 5000;
			arg_20E2_0.Maximum = new decimal(array);
			NumericUpDown arg_2103_0 = this.TeleportRange;
			array = new int[4];
			array[0] = 100;
			arg_2103_0.Minimum = new decimal(array);
			this.TeleportRange.Name = "TeleportRange";
			this.TeleportRange.Size = new Size(94, 20);
			this.TeleportRange.TabIndex = 58;
			NumericUpDown arg_215B_0 = this.TeleportRange;
			array = new int[4];
			array[0] = 200;
			arg_215B_0.Value = new decimal(array);
			this.PerfectAscendTime.BackColor = Color.WhiteSmoke;
			this.PerfectAscendTime.DecimalPlaces = 1;
			this.PerfectAscendTime.Increment = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.PerfectAscendTime.Location = new Point(128, 75);
			NumericUpDown arg_21DB_0 = this.PerfectAscendTime;
			array = new int[4];
			array[0] = 10;
			arg_21DB_0.Maximum = new decimal(array);
			NumericUpDown arg_21FB_0 = this.PerfectAscendTime;
			array = new int[4];
			array[0] = 1;
			arg_21FB_0.Minimum = new decimal(array);
			this.PerfectAscendTime.Name = "PerfectAscendTime";
			this.PerfectAscendTime.Size = new Size(94, 20);
			this.PerfectAscendTime.TabIndex = 57;
			this.PerfectAscendTime.Value = new decimal(new int[]
			{
				15,
				0,
				0,
				65536
			});
			this.AscendTime.BackColor = Color.WhiteSmoke;
			this.AscendTime.DecimalPlaces = 1;
			this.AscendTime.Increment = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.AscendTime.Location = new Point(128, 56);
			NumericUpDown arg_22D9_0 = this.AscendTime;
			array = new int[4];
			array[0] = 60;
			arg_22D9_0.Maximum = new decimal(array);
			NumericUpDown arg_22F9_0 = this.AscendTime;
			array = new int[4];
			array[0] = 1;
			arg_22F9_0.Minimum = new decimal(array);
			this.AscendTime.Name = "AscendTime";
			this.AscendTime.Size = new Size(94, 20);
			this.AscendTime.TabIndex = 56;
			NumericUpDown arg_234E_0 = this.AscendTime;
			array = new int[4];
			array[0] = 10;
			arg_234E_0.Value = new decimal(array);
			this.Health.BackColor = Color.WhiteSmoke;
			NumericUpDown arg_237F_0 = this.Health;
			array = new int[4];
			array[0] = 5;
			arg_237F_0.Increment = new decimal(array);
			this.Health.Location = new Point(128, 170);
			NumericUpDown arg_23BE_0 = this.Health;
			array = new int[4];
			array[0] = 255;
			arg_23BE_0.Maximum = new decimal(array);
			NumericUpDown arg_23DF_0 = this.Health;
			array = new int[4];
			array[0] = 10;
			arg_23DF_0.Minimum = new decimal(array);
			this.Health.Name = "Health";
			this.Health.Size = new Size(94, 20);
			this.Health.TabIndex = 55;
			NumericUpDown arg_2434_0 = this.Health;
			array = new int[4];
			array[0] = 100;
			arg_2434_0.Value = new decimal(array);
			this.PowerLevelMultiplier.BackColor = Color.WhiteSmoke;
			this.PowerLevelMultiplier.DecimalPlaces = 1;
			this.PowerLevelMultiplier.Increment = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.PowerLevelMultiplier.Location = new Point(128, 132);
			NumericUpDown arg_24B7_0 = this.PowerLevelMultiplier;
			array = new int[4];
			array[0] = 10;
			arg_24B7_0.Maximum = new decimal(array);
			this.PowerLevelMultiplier.Minimum = new decimal(new int[]
			{
				10,
				0,
				0,
				65536
			});
			this.PowerLevelMultiplier.Name = "PowerLevelMultiplier";
			this.PowerLevelMultiplier.Size = new Size(94, 20);
			this.PowerLevelMultiplier.TabIndex = 53;
			this.PowerLevelMultiplier.Value = new decimal(new int[]
			{
				10,
				0,
				0,
				65536
			});
			this.PerfectPowerLevel.BackColor = Color.WhiteSmoke;
			NumericUpDown arg_2574_0 = this.PerfectPowerLevel;
			array = new int[4];
			array[0] = 100000;
			arg_2574_0.Increment = new decimal(array);
			this.PerfectPowerLevel.Location = new Point(128, 113);
			NumericUpDown arg_25B0_0 = this.PerfectPowerLevel;
			array = new int[4];
			array[0] = 999999999;
			arg_25B0_0.Maximum = new decimal(array);
			NumericUpDown arg_25D0_0 = this.PerfectPowerLevel;
			array = new int[4];
			array[0] = 1;
			arg_25D0_0.Minimum = new decimal(array);
			this.PerfectPowerLevel.Name = "PerfectPowerLevel";
			this.PerfectPowerLevel.Size = new Size(94, 20);
			this.PerfectPowerLevel.TabIndex = 52;
			this.PerfectPowerLevel.ThousandsSeparator = true;
			NumericUpDown arg_2635_0 = this.PerfectPowerLevel;
			array = new int[4];
			array[0] = 1500000;
			arg_2635_0.Value = new decimal(array);
			this.PowerLevel.BackColor = Color.WhiteSmoke;
			NumericUpDown arg_266A_0 = this.PowerLevel;
			array = new int[4];
			array[0] = 100000;
			arg_266A_0.Increment = new decimal(array);
			this.PowerLevel.Location = new Point(128, 94);
			NumericUpDown arg_26A6_0 = this.PowerLevel;
			array = new int[4];
			array[0] = 999999999;
			arg_26A6_0.Maximum = new decimal(array);
			NumericUpDown arg_26C6_0 = this.PowerLevel;
			array = new int[4];
			array[0] = 1;
			arg_26C6_0.Minimum = new decimal(array);
			this.PowerLevel.Name = "PowerLevel";
			this.PowerLevel.Size = new Size(94, 20);
			this.PowerLevel.TabIndex = 51;
			this.PowerLevel.ThousandsSeparator = true;
			NumericUpDown arg_272B_0 = this.PowerLevel;
			array = new int[4];
			array[0] = 1000000;
			arg_272B_0.Value = new decimal(array);
			this.KiRate.BackColor = Color.WhiteSmoke;
			this.KiRate.DecimalPlaces = 1;
			this.KiRate.Location = new Point(128, 294);
			NumericUpDown arg_2785_0 = this.KiRate;
			array = new int[4];
			array[0] = 30;
			arg_2785_0.Maximum = new decimal(array);
			this.KiRate.Minimum = new decimal(new int[]
			{
				30,
				0,
				0,
				-2147483648
			});
			this.KiRate.Name = "KiRate";
			this.KiRate.Size = new Size(94, 20);
			this.KiRate.TabIndex = 50;
			this.Booster.BackColor = Color.WhiteSmoke;
			this.Booster.DecimalPlaces = 1;
			this.Booster.Location = new Point(128, 313);
			NumericUpDown arg_283D_0 = this.Booster;
			array = new int[4];
			array[0] = 10;
			arg_283D_0.Maximum = new decimal(array);
			NumericUpDown arg_285D_0 = this.Booster;
			array = new int[4];
			array[0] = 1;
			arg_285D_0.Minimum = new decimal(array);
			this.Booster.Name = "Booster";
			this.Booster.Size = new Size(94, 20);
			this.Booster.TabIndex = 48;
			NumericUpDown arg_28B1_0 = this.Booster;
			array = new int[4];
			array[0] = 1;
			arg_28B1_0.Value = new decimal(array);
			this.label41.AutoSize = true;
			this.label41.Location = new Point(8, 315);
			this.label41.Name = "label41";
			this.label41.Size = new Size(43, 13);
			this.label41.TabIndex = 49;
			this.label41.Text = "Booster";
			this.toolTipLevel.SetToolTip(this.label41, "Boost Speed Multiplier");
			this.label42.AutoSize = true;
			this.label42.Location = new Point(8, 296);
			this.label42.Name = "label42";
			this.label42.Size = new Size(42, 13);
			this.label42.TabIndex = 47;
			this.label42.Text = "KI Rate";
			this.toolTipLevel.SetToolTip(this.label42, "How much KI per 0.1s add/remove");
			this.label43.AutoSize = true;
			this.label43.Location = new Point(7, 277);
			this.label43.Name = "label43";
			this.label43.Size = new Size(82, 13);
			this.label43.TabIndex = 45;
			this.label43.Text = "Telepor KI Cost";
			this.toolTipLevel.SetToolTip(this.label43, "How much KI one teleport removes");
			this.label44.AutoSize = true;
			this.label44.Location = new Point(7, 258);
			this.label44.Name = "label44";
			this.label44.Size = new Size(81, 13);
			this.label44.TabIndex = 43;
			this.label44.Text = "Teleport Range";
			this.toolTipLevel.SetToolTip(this.label44, "Teleport range in Half-Life units");
			this.label45.AutoSize = true;
			this.label45.Location = new Point(7, 19);
			this.label45.Name = "label45";
			this.label45.Size = new Size(35, 13);
			this.label45.TabIndex = 41;
			this.label45.Text = "Class Level Nmae";
			this.txtName.BackColor = Color.WhiteSmoke;
			this.txtName.Location = new Point(128, 16);
			this.txtName.MaxLength = 32;
			this.txtName.Name = "txtName";
			this.txtName.Size = new Size(94, 20);
			this.txtName.TabIndex = 42;
			this.txtName.Text = "Saiya-jin";
			this.cbNoDescend.AutoSize = true;
			this.cbNoDescend.Location = new Point(128, 216);
			this.cbNoDescend.Name = "cbNoDescend";
			this.cbNoDescend.Size = new Size(86, 17);
			this.cbNoDescend.TabIndex = 38;
			this.cbNoDescend.Text = "No Descend";
			this.toolTipLevel.SetToolTip(this.cbNoDescend, "Locks Descend");
			this.cbNoDescend.UseVisualStyleBackColor = true;
			this.cbNoAscend.AutoSize = true;
			this.cbNoAscend.Location = new Point(9, 216);
			this.cbNoAscend.Name = "cbNoAscend";
			this.cbNoAscend.Size = new Size(79, 17);
			this.cbNoAscend.TabIndex = 37;
			this.cbNoAscend.Text = "No Ascend";
			this.toolTipLevel.SetToolTip(this.cbNoAscend, "Lock Ascend");
			this.cbNoAscend.UseVisualStyleBackColor = true;
			this.label46.AutoSize = true;
			this.label46.Location = new Point(7, 172);
			this.label46.Name = "label46";
			this.label46.Size = new Size(38, 13);
			this.label46.TabIndex = 35;
			this.label46.Text = "Health";
			this.label47.AutoSize = true;
			this.label47.Location = new Point(7, 153);
			this.label47.Name = "label47";
			this.label47.Size = new Size(38, 13);
			this.label47.TabIndex = 33;
			this.label47.Text = "Speed";
			this.label48.AutoSize = true;
			this.label48.Location = new Point(7, 134);
			this.label48.Name = "label48";
			this.label48.Size = new Size(110, 13);
			this.label48.TabIndex = 31;
			this.label48.Text = "PowerLevel Multiplier";
            this.toolTipLevel.SetToolTip(this.label48, "Multiply PL after finishing transformation\r\n > Invalid at the Normal State");
			this.label49.AutoSize = true;
			this.label49.Location = new Point(7, 115);
			this.label49.Name = "label49";
			this.label49.Size = new Size(103, 13);
			this.label49.TabIndex = 29;
			this.label49.Text = "Perfect PowerLevel";
            this.toolTipLevel.SetToolTip(this.label49, "PL required for short transformation\r\n > Invalid at the Normal State");
			this.label50.AutoSize = true;
			this.label50.Location = new Point(7, 96);
			this.label50.Name = "label50";
			this.label50.Size = new Size(66, 13);
			this.label50.TabIndex = 27;
			this.label50.Text = "PowerLevel";
			this.toolTipLevel.SetToolTip(this.label50, "This is the primary PL at the Normal State\r\nAt other states it means how much PL is required to transform to this state");
			this.label51.AutoSize = true;
			this.label51.Location = new Point(7, 77);
			this.label51.Name = "label51";
			this.label51.Size = new Size(106, 13);
			this.label51.TabIndex = 25;
			this.label51.Text = "Perfect Ascend Time";
            this.toolTipLevel.SetToolTip(this.label51, "How long the Perfect Transformation is (Second)\r\n > Invalid at the Normal State");
			this.label52.AutoSize = true;
			this.label52.Location = new Point(8, 58);
			this.label52.Name = "label52";
			this.label52.Size = new Size(69, 13);
			this.label52.TabIndex = 23;
			this.label52.Text = "Ascend Time";
            this.toolTipLevel.SetToolTip(this.label52, "How long the Transformation is (Second)\r\n > Invalid at the Normal State");
			this.label53.AutoSize = true;
			this.label53.Location = new Point(7, 39);
			this.label53.Name = "label53";
			this.label53.Size = new Size(36, 13);
			this.label53.TabIndex = 21;
			this.label53.Text = "Model";
			this.toolTipLevel.SetToolTip(this.label53, "See \"/esf/models/player/\"");
			this.txtModel.BackColor = Color.WhiteSmoke;
			this.txtModel.Location = new Point(128, 36);
			this.txtModel.MaxLength = 22;
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new Size(94, 20);
			this.txtModel.TabIndex = 22;
			this.txtModel.Text = "ecx.goku-ts";
			this.labelDefense.AutoSize = true;
			this.labelDefense.Location = new Point(37, 43);
			this.labelDefense.Name = "labelDefense";
			this.labelDefense.Size = new Size(45, 13);
			this.labelDefense.TabIndex = 63;
			this.labelDefense.Text = "DEF 0%";
			this.toolTipLevel.SetToolTip(this.labelDefense, "Reduce Damage");
			this.labelAttack.AutoSize = true;
			this.labelAttack.Location = new Point(37, 22);
			this.labelAttack.Name = "labelAttack";
			this.labelAttack.Size = new Size(57, 13);
			this.labelAttack.TabIndex = 62;
			this.labelAttack.Text = "ATK 100%";
			this.toolTipLevel.SetToolTip(this.labelAttack, "Attack Value Multiplier");
			this.trackDefense.AutoSize = false;
			this.trackDefense.Location = new Point(120, 41);
			this.trackDefense.Maximum = 100;
			this.trackDefense.Name = "trackDefense";
			this.trackDefense.Size = new Size(119, 23);
			this.trackDefense.TabIndex = 61;
			this.trackDefense.TickStyle = TickStyle.None;
			this.trackDefense.ValueChanged += new EventHandler(this.trackDefense_ValueChanged);
			this.trackAttack.AutoSize = false;
			this.trackAttack.Location = new Point(120, 19);
			this.trackAttack.Maximum = 500;
			this.trackAttack.Name = "trackAttack";
			this.trackAttack.Size = new Size(125, 23);
			this.trackAttack.TabIndex = 60;
			this.trackAttack.TickStyle = TickStyle.None;
			this.trackAttack.Value = 100;
			this.trackAttack.ValueChanged += new EventHandler(this.trackAttack_ValueChanged);
			this.cbHypermode.AutoSize = true;
			this.cbHypermode.Location = new Point(128, 14);
			this.cbHypermode.Name = "cbHypermode";
			this.cbHypermode.Size = new Size(80, 17);
			this.cbHypermode.TabIndex = 52;
			this.cbHypermode.Text = "Hyper Mode";
            this.toolTipLevel.SetToolTip(this.cbHypermode, "Teleport behind enemy in teleport range");
			this.cbHypermode.UseVisualStyleBackColor = true;
			this.cbTeleSense.AutoSize = true;
			this.cbTeleSense.Location = new Point(9, 30);
			this.cbTeleSense.Name = "cbTeleSense";
			this.cbTeleSense.Size = new Size(98, 17);
			this.cbTeleSense.TabIndex = 51;
			this.cbTeleSense.Text = "Teleport Sense";
            this.toolTipLevel.SetToolTip(this.cbTeleSense, "Teleport around player if locked on");
			this.cbTeleSense.UseVisualStyleBackColor = true;
			this.cbTeleportSwoop.AutoSize = true;
			this.cbTeleportSwoop.Location = new Point(9, 61);
			this.cbTeleportSwoop.Name = "cbTeleportSwoop";
			this.cbTeleportSwoop.Size = new Size(101, 17);
			this.cbTeleportSwoop.TabIndex = 40;
			this.cbTeleportSwoop.Text = "Teleport Swoop";
			this.toolTipLevel.SetToolTip(this.cbTeleportSwoop, "Teleport while swooping");
			this.cbTeleportSwoop.UseVisualStyleBackColor = true;
			this.cbTeleportCharge.AutoSize = true;
			this.cbTeleportCharge.Location = new Point(9, 14);
			this.cbTeleportCharge.Name = "cbTeleportCharge";
			this.cbTeleportCharge.Size = new Size(102, 17);
			this.cbTeleportCharge.TabIndex = 39;
			this.cbTeleportCharge.Text = "Teleport Charge";
			this.toolTipLevel.SetToolTip(this.cbTeleportCharge, "So you can teleport while charging an attack");
			this.cbTeleportCharge.UseVisualStyleBackColor = true;
			this.toolTipLevel.BackColor = SystemColors.Desktop;
			this.toolTipLevel.ForeColor = SystemColors.MenuBar;
			this.toolTipLevel.ToolTipIcon = ToolTipIcon.Info;
			this.toolTipLevel.ToolTipTitle = "Description";
			this.cbSwoopSense.AutoSize = true;
			this.cbSwoopSense.Location = new Point(9, 46);
			this.cbSwoopSense.Name = "cbSwoopSense";
			this.cbSwoopSense.Size = new Size(92, 17);
			this.cbSwoopSense.TabIndex = 53;
			this.cbSwoopSense.Text = "Swoop Sense";
			this.toolTipLevel.SetToolTip(this.cbSwoopSense, "Right-click while swooping at the next enemy");
			this.cbSwoopSense.UseVisualStyleBackColor = true;
			this.label9.AutoSize = true;
			this.label9.Location = new Point(182, 60);
			this.label9.Name = "label9";
			this.label9.Size = new Size(70, 13);
			this.label9.TabIndex = 62;
			this.label9.Text = "Strong Melee";
			this.toolTipLevel.SetToolTip(this.label9, "Make it harder to read your movements");
			this.label8.AutoSize = true;
			this.label8.Location = new Point(183, 38);
			this.label8.Name = "label8";
			this.label8.Size = new Size(69, 13);
			this.label8.TabIndex = 60;
			this.label8.Text = "Melee Sense";
            this.toolTipLevel.SetToolTip(this.label8, "Read enemy movements");
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.StrongMelee);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.MeleeSense);
			this.groupBox1.Controls.Add(this.cbSwoopSense);
			this.groupBox1.Controls.Add(this.cbHypermode);
			this.groupBox1.Controls.Add(this.cbTeleportCharge);
			this.groupBox1.Controls.Add(this.cbTeleSense);
			this.groupBox1.Controls.Add(this.cbTeleportSwoop);
			this.groupBox1.ForeColor = Color.FromArgb(128, 128, 255);
			this.groupBox1.Location = new Point(249, 267);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(254, 86);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Skills";
			this.StrongMelee.BackColor = Color.WhiteSmoke;
			this.StrongMelee.Location = new Point(128, 56);
			NumericUpDown arg_38B3_0 = this.StrongMelee;
			array = new int[4];
			array[0] = 5;
			arg_38B3_0.Maximum = new decimal(array);
			this.StrongMelee.Minimum = new decimal(new int[]
			{
				5,
				0,
				0,
				-2147483648
			});
			this.StrongMelee.Name = "StrongMelee";
			this.StrongMelee.Size = new Size(49, 20);
			this.StrongMelee.TabIndex = 61;
			this.MeleeSense.BackColor = Color.WhiteSmoke;
			this.MeleeSense.Location = new Point(128, 37);
			NumericUpDown arg_3959_0 = this.MeleeSense;
			array = new int[4];
			array[0] = 5;
			arg_3959_0.Maximum = new decimal(array);
			this.MeleeSense.Minimum = new decimal(new int[]
			{
				5,
				0,
				0,
				-2147483648
			});
			this.MeleeSense.Name = "MeleeSense";
			this.MeleeSense.Size = new Size(49, 20);
			this.MeleeSense.TabIndex = 59;
			this.groupBox2.BackColor = Color.WhiteSmoke;
			this.groupBox2.Controls.Add(this.labelDefense);
			this.groupBox2.Controls.Add(this.labelAttack);
			this.groupBox2.Controls.Add(this.trackAttack);
			this.groupBox2.Controls.Add(this.trackDefense);
			this.groupBox2.ForeColor = Color.FromArgb(128, 128, 255);
			this.groupBox2.Location = new Point(249, 194);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(254, 67);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Damage Modifier";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.WhiteSmoke;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.groupBox6);
			base.Name = "LevelPanel";
			base.Size = new Size(509, 561);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((ISupportInitialize)this.GlowWidth).EndInit();
			((ISupportInitialize)this.AuraOpacityMax).EndInit();
			((ISupportInitialize)this.LgtRange).EndInit();
			((ISupportInitialize)this.LgtFeets).EndInit();
			((ISupportInitialize)this.LgtTorso).EndInit();
			((ISupportInitialize)this.LgtHead).EndInit();
			((ISupportInitialize)this.AuraSkin).EndInit();
			((ISupportInitialize)this.Speed).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((ISupportInitialize)this.TeleportKi).EndInit();
			((ISupportInitialize)this.TeleportRange).EndInit();
			((ISupportInitialize)this.PerfectAscendTime).EndInit();
			((ISupportInitialize)this.AscendTime).EndInit();
			((ISupportInitialize)this.Health).EndInit();
			((ISupportInitialize)this.PowerLevelMultiplier).EndInit();
			((ISupportInitialize)this.PerfectPowerLevel).EndInit();
			((ISupportInitialize)this.PowerLevel).EndInit();
			((ISupportInitialize)this.KiRate).EndInit();
			((ISupportInitialize)this.Booster).EndInit();
			((ISupportInitialize)this.trackDefense).EndInit();
			((ISupportInitialize)this.trackAttack).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.StrongMelee).EndInit();
			((ISupportInitialize)this.MeleeSense).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}

		public LevelPanel()
		{
			this.InitializeComponent();
		}

		private void btnGlowColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = this.btnGlowColor.BackColor;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				this.btnGlowColor.BackColor = colorDialog.Color;
			}
		}

		private void btnChargeColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = this.btnChargeColor.BackColor;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				this.btnChargeColor.BackColor = colorDialog.Color;
			}
		}

		private void btnAuraColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = this.btnAuraColor.BackColor;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				this.btnAuraColor.BackColor = colorDialog.Color;
			}
		}

		private void cbGlow_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cbGlow.Checked)
			{
				this.btnGlowColor.Enabled = true;
				this.GlowWidth.Enabled = true;
			}
			else
			{
				this.btnGlowColor.Enabled = false;
				this.GlowWidth.Enabled = false;
			}
		}

		private void cbLightning_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cbLightning.Checked)
			{
				this.LgtFeets.Enabled = true;
				this.LgtTorso.Enabled = true;
				this.LgtHead.Enabled = true;
				this.LgtRange.Enabled = true;
			}
			else
			{
				this.LgtFeets.Enabled = false;
				this.LgtTorso.Enabled = false;
				this.LgtHead.Enabled = false;
				this.LgtRange.Enabled = false;
			}
		}

		private void trackAttack_ValueChanged(object sender, EventArgs e)
		{
			this.labelAttack.Text = "ATK " + this.trackAttack.Value + "%";
		}

		private void trackDefense_ValueChanged(object sender, EventArgs e)
		{
			this.labelDefense.Text = "DEF " + this.trackDefense.Value + "%";
		}
	}
}
