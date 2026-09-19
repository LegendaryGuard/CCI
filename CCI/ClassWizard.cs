using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CCI
{
	public class ClassWizard : Form
	{
		internal MyControl[] list = new MyControl[9];

		internal LevelPanel[] levels = new LevelPanel[8];

		internal ClassPanel classPanel;

		private int currPos = 0;

		private string path;

        private readonly string gpl = "/*" + Environment.NewLine + "** << Evolution Class Extension >>" + Environment.NewLine + "**" + Environment.NewLine + "** \tCopyright (C) 2005 - 2007 Corona Bytes .NET" + Environment.NewLine + "**" + Environment.NewLine + "** This program is free software; you can redistribute it and/or" + Environment.NewLine + "** modify it under the terms of the GNU General Public License" + Environment.NewLine + "** as published by the Free Software Foundation; either version 2" + Environment.NewLine + "** of the License, or (at your option) any later version." + Environment.NewLine + "**" + Environment.NewLine + "** This program is distributed in the hope that it will be useful," + Environment.NewLine + "** but WITHOUT ANY WARRANTY; without even the implied warranty of" + Environment.NewLine + "** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the" + Environment.NewLine + "** GNU General Public License for more details." + Environment.NewLine + "**" + Environment.NewLine + "** You should have received a copy of the GNU General Public License" + Environment.NewLine + "** along with this program; if not, write to the Free Software" + Environment.NewLine + "** Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA." + Environment.NewLine + "**" + Environment.NewLine + "**" + Environment.NewLine + "**" + Environment.NewLine + "*/" + Environment.NewLine + Environment.NewLine;

		private IContainer components = null;

		private Button btnClose;

		private Button btnBuild;

		private Button btnNext;

		private Button btnPrev;

		private Label lblPosition;

		private MyControl currControl;

		private Button btnExport;

		private Button btnImport;

		private Panel panel1;

		private Panel panel2;

		public ClassWizard()
		{
			this.InitializeComponent();
			this.list[0] = (this.classPanel = new ClassPanel());
			this.list[0].Visible = false;
			for (int i = 1; i < 9; i++)
			{
				this.list[i] = new LevelPanel();
				this.list[i].Visible = false;
				this.levels[i - 1] = (LevelPanel)this.list[i];
			}
			MyControl[] array = this.list;
			for (int j = 0; j < array.Length; j++)
			{
				MyControl myControl = array[j];
				myControl.Location = new Point(this.currControl.Location.X, this.currControl.Location.Y);
				base.Controls.Add(myControl);
			}
			this.setCurrControl(0);
		}

		private void setCurrControl(int i)
		{
			this.btnPrev.Enabled = true;
			this.btnNext.Enabled = true;
			if (i >= 0 && i <= 8)
			{
				if (i >= (this.list[0] as ClassPanel).levels.Value)
				{
					this.btnNext.Enabled = false;
					if (i > (this.list[0] as ClassPanel).levels.Value)
					{
						return;
					}
				}
				if (i == 0)
				{
					this.lblPosition.Text = "Main Information";
					this.btnPrev.Enabled = false;
				}
                else if (i == 1)
                {
                    this.lblPosition.Text = "Normal State";
                }
                else
				{
					this.lblPosition.Text = "SSJ " + (i - 1);
				}
				this.currControl.Visible = false;
				this.currControl = this.list[i];
				this.currPos = i;
				this.currControl.Visible = true;
			}
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			this.setCurrControl(this.currPos + 1);
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			this.setCurrControl(this.currPos - 1);
		}

		private void btnBuild_Click(object sender, EventArgs e)
		{
			try
			{
				this.Basics();
				this.CreateClassExtension();
				this.CreateSound();
				this.CreateWeapon();
				this.CreateCharge();
				this.CreateFX();
				base.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void Basics()
		{
			if (((ClassPanel)this.list[0]).txtName.Text == string.Empty)
			{
				throw new Exception("Class Extention Name missing!");
			}
			this.path = Application.StartupPath + "\\" + this.classPanel.txtName.Text + "\\";
			if (Directory.Exists(this.path))
			{
				if (MessageBox.Show("Directory \"" + this.classPanel.txtName.Text + "\" already exists!\n\rReplace?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					throw new Exception("Abort!");
				}
				Directory.Delete(this.path, true);
			}
			Directory.CreateDirectory(this.path);
			Serializer serializer = new Serializer(this.classPanel, this.levels);
			serializer.Save(this.path + this.classPanel.txtName.Text + ".cxi");
		}

		public void CreateClassExtension()
		{
            using (StreamWriter streamWriter = new StreamWriter(this.path + ".ClassExtension.core", false, System.Text.Encoding.Default))
			{
                streamWriter.Write(this.gpl);
				streamWriter.WriteLine("new const CX_Plugin[]\t= \t\"CX.{0}\";", this.classPanel.txtName.Text);
				streamWriter.WriteLine("new const CX_Version[]\t=\t\"1.0\";", this.classPanel.txtVersion.Text);
                streamWriter.WriteLine("new const CX_Author[]\t=\t\"{0}\";" + Environment.NewLine, this.classPanel.txtAuthor.Text);
				streamWriter.WriteLine("#define MOD_SOUND \t{0}", this.classPanel.cbSound.Checked ? 1 : 0);
				streamWriter.WriteLine("#define MOD_CHARGE \t{0}", this.classPanel.cbCharge.Checked ? 1 : 0);
                streamWriter.WriteLine("#define MOD_WEAPON\t{0}", this.classPanel.cbWeapon.Checked ? 1 : 0);
                if (this.classPanel.cbDefaultStepSound.Checked) streamWriter.WriteLine(Environment.NewLine + "new Float: __float_StepSound_Delay[ 33 ];");
                streamWriter.WriteLine(Environment.NewLine + "// << Implement CX Interface >>" + Environment.NewLine);
                streamWriter.WriteLine("#include <xtension/class/main>");
                if (this.classPanel.cbFusion.Checked) streamWriter.WriteLine("#include <xtension/fusion>");
                streamWriter.WriteLine(Environment.NewLine +  "PluginInit ()");
                streamWriter.WriteLine("\tregister_plugin( CX_Plugin, CX_Version, CX_Author );" + Environment.NewLine);
                streamWriter.WriteLine("public @ClassCreation ()// Character Base");
				streamWriter.WriteLine("{");
				streamWriter.WriteLine("\tcreateClass( { MOD_SOUND, MOD_CHARGE, MOD_WEAPON },");
                streamWriter.WriteLine("\t\t\t\t\"{0}\", {1}, {2}, \"{3}\", \"{4}\" );", new object[]
				{
					this.classPanel.txtName.Text,
					this.classPanel.cbDescendClass.Checked ? "true" : "false",
					this.classPanel.cbFusion.Checked ? "true" : "false",
					this.classPanel.txtDescription.Text.Replace("\r\n", "\\n"),
					this.classPanel.txtName.Text + "/c_intro.wav"
				});
				this.CreateLevels(streamWriter);
                streamWriter.WriteLine("}");
                this.WriteFktECX_FusionClassCreation(streamWriter);
				this.WriteFktECX_CanEatCandy(streamWriter);
				this.WriteFktECX_WeaponUpdate(streamWriter);
				this.WriteFktECX_initTransformation(streamWriter);
				this.WriteFktECX_finishTransformation(streamWriter);
                this.WriteFktECX_cancelTransformation(streamWriter);
                this.WriteFktECX_StepSound(streamWriter);
                this.WriteFktplugin_precache(streamWriter);
			}
		}

		private string FormatFloat(decimal d)
		{
			return d.ToString("F1").Replace(',', '.');
		}

		private string FormatFloat(float f)
		{
			return f.ToString("F1").Replace(',', '.');
		}

		private void CreateLevels(StreamWriter sw)
		{
			for (int i = 0; i < this.classPanel.levels.Value; i++)
			{
				LevelPanel levelPanel = this.levels[i];
				sw.WriteLine(Environment.NewLine + "\t// {0}", levelPanel.txtName.Text);
				sw.WriteLine("\taddClassLevel( \"{0}\", \"{1}\", {2}, {3}, {4}, {5}, {6}, ", new object[]
				{
					levelPanel.txtName.Text,
					levelPanel.txtModel.Text,
					this.FormatFloat(levelPanel.AscendTime.Value),
					this.FormatFloat(levelPanel.PerfectAscendTime.Value),
					(int)levelPanel.PowerLevel.Value,
					(int)levelPanel.PerfectPowerLevel.Value,
					this.FormatFloat(levelPanel.PowerLevelMultiplier.Value)
				});
				sw.WriteLine("\t\t\t\t\t{0}, {1}, bool:{12} {2}, {3} {13}, {4}, {12} {5}, {10} {13}, {12} {6}, {7}, {8}, {9}, {14}, {15}, {16} {13}, {11}, {17}, {18} );", new object[]
				{
					(int)levelPanel.Speed.Value,
					(int)levelPanel.Health.Value,
					levelPanel.cbNoAscend.Checked ? "true" : "false",
					levelPanel.cbNoDescend.Checked ? "true" : "false",
					this.FormatFloat(levelPanel.KiRate.Value),
					(int)levelPanel.TeleportRange.Value,
					levelPanel.cbTeleportCharge.Checked ? "1" : "0",
					levelPanel.cbTeleportSwoop.Checked ? "1" : "0",
					levelPanel.cbTeleSense.Checked ? "1" : "0",
					levelPanel.cbHypermode.Checked ? "1" : "0",
					(int)levelPanel.TeleportKi.Value,
					this.FormatFloat(levelPanel.Booster.Value),
					"{",
					"}",
					levelPanel.cbSwoopSense.Checked ? "1" : "0",
					(int)levelPanel.MeleeSense.Value,
					(int)levelPanel.StrongMelee.Value,
					"Float:{ " + this.FormatFloat((float)levelPanel.trackAttack.Value),
					this.FormatFloat((float)levelPanel.trackDefense.Value) + " }"
				});
				sw.WriteLine("\taddClassEffect( \"{0}\", Float:{7} {1}.0, {2}.0, {3}.0, {4} {8}, {5}, {6},", new object[]
				{
					levelPanel.txtAura.Text,
					float.Parse("" + levelPanel.btnAuraColor.BackColor.R),
					float.Parse("" + levelPanel.btnAuraColor.BackColor.G),
					float.Parse("" + levelPanel.btnAuraColor.BackColor.B),
					this.FormatFloat(levelPanel.AuraOpacityMax.Value),
					(int)levelPanel.AuraSkin.Value,
					levelPanel.AuraRenderMode.Text,
					"{",
					"}"
				});
				sw.WriteLine("\t\t\t\t\t{11} {0}, {1}, {2} {12}, {11} {3}, {4}, {5}, {6} {12}, Float:{11} {7}.0, {8}.0, {9}.0, {10}.0 {12} );", new object[]
				{
					levelPanel.btnChargeColor.BackColor.R,
					levelPanel.btnChargeColor.BackColor.G,
					levelPanel.btnChargeColor.BackColor.B,
					levelPanel.cbLightning.Checked ? levelPanel.LgtHead.Value : 0m,
					levelPanel.cbLightning.Checked ? levelPanel.LgtTorso.Value : 0m,
					levelPanel.cbLightning.Checked ? levelPanel.LgtFeets.Value : 0m,
					levelPanel.cbLightning.Checked ? ((int)levelPanel.LgtRange.Value) : 0,
					levelPanel.cbGlow.Checked ? float.Parse("" + levelPanel.btnGlowColor.BackColor.R) : 0f,
					levelPanel.cbGlow.Checked ? float.Parse("" + levelPanel.btnGlowColor.BackColor.G) : 0f,
					levelPanel.cbGlow.Checked ? float.Parse("" + levelPanel.btnGlowColor.BackColor.B) : 0f,
					levelPanel.cbGlow.Checked ? ((int)levelPanel.GlowWidth.Value) : 0,
					"{",
					"}"
				});
			}
		}

		private void WriteFktECX_WeaponUpdate(StreamWriter sw)
		{
			sw.WriteLine(Environment.NewLine + "public @ClassWeaponUpdate ( Client, Level )// Attacks");
			sw.WriteLine("{");
			sw.WriteLine("\tswitch ( Level )");
			sw.WriteLine("\t{");
			for (int i = 0; i < this.classPanel.levels.Value; i++)
			{
				LevelPanel levelPanel = this.levels[i];
				sw.WriteLine("\t\tcase {0}: // {1}", i, levelPanel.txtName.Text);
				sw.WriteLine("\t\t{");
				foreach (ListViewItem listViewItem in this.levels[i].listWeapon.CheckedItems)
				{
					string text = listViewItem.Text;
					if (text.Equals("Melee"))
					{
                        text = "\"weapon_melee\", true";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
					}
					if (text.Equals("Sword"))
					{
                        text = "\"weapon_sword\", true";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("ShieldAttack"))
                    {
                        text = "\"weapon_shieldattack\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("SolarFlare"))
                    {
                        text = "\"weapon_solarflare\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("KiBlast"))
                    {
                        text = "\"weapon_kiblast\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("Renzoku"))
                    {
                        text = "\"weapon_renzoku\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("ScatterShot"))
                    {
                        text = "\"weapon_scattershot\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("Regeneration"))
                    {
                        text = "\"weapon_regeneration\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("CandyLaser"))
                    {
                        text = "\"weapon_candy\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("EyeLaser"))
                    {
                        text = "\"weapon_eyelaser\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("FingerLaser"))
                    {
                        text = "\"weapon_fingerlaser\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("FriezaDeathBall"))
                    {
                        text = "\"weapon_deathball\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("SpiritBomb"))
                    {
                        text = "\"weapon_spiritbomb\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("FriezaDisc"))
                    {
                        text = "\"weapon_friezadisc\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("KrillinDisc"))
                    {
                        text = "\"weapon_destructodisc\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("BurningAttack"))
                    {
                        text = "\"weapon_burningattack\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("FinalFlash"))
                    {
                        text = "\"weapon_finalflash\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("Gallitgun"))
                    {
                        text = "\"weapon_gallitgun\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("GenericBeam"))
                    {
                        text = "\"weapon_genericbeam\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("Kamehameha"))
                    {
                        text = "\"weapon_kamehameha\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("Masenko"))
                    {
                        text = "\"weapon_masenko\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("MouthBlast"))
                    {
                        text = "\"weapon_mouthblast\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("PowerBeam"))
                    {
                        text = "\"weapon_powerbeam\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("ScatterBeam"))
                    {
                        text = "\"weapon_scatterbeam\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("SpecialBeamCannon"))
                    {
                        text = "\"weapon_specialbeamcannon\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("RockControl"))
                    {
                        text = "\"weapon_telekinesis\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("BigbangAttack"))
                    {
                        text = "\"weapon_bigbang\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("KameTorpedo"))
                    {
                        text = "\"weapon_kametorpedo\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("FinishingBuster"))
                    {
                        text = "\"weapon_finishingbuster\", false";
                        sw.WriteLine("\t\t\taddClassItem( Client, {0} );", text);
                    }
                    if (text.Equals("KaioKen"))
                    {
                        text = "\"Kaioken\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("DragonFist"))
                    {
                        text = "\"Dragonfist\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("BuuDeathBall"))
                    {
                        text = "\"buudeathball\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("BuuGenocideBlast"))
                    {
                        text = "\"genocide\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("WolffangFist"))
                    {
                        text = "\"Wolffangfist\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("Shield"))
                    {
                        text = "\"shield\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("SuperGhostKamikazeAttack"))
                    {
                        text = "\"SGKA\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("GogetaSoulPunisher"))
                    {
                        text = "\"soulpunisher\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("Tornado"))
                    {
                        text = "\"tornado\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("SpiritSword"))
                    {
                        text = "\"Spirit Sword\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
                    if (text.Equals("UltimateSacrifice"))
                    {
                        text = "\"UltimateSacrifice\"";
                        sw.WriteLine("\t\t\taddClassSpecial( Client, {0} );", text);
                    }
				}
				sw.WriteLine("\t\t}");
			}
			sw.WriteLine("\t}" + Environment.NewLine + "}" + Environment.NewLine);
		}

		private void WriteFktplugin_precache(StreamWriter sw)
		{
			LinkedList<string> linkedList = new LinkedList<string>();
			for (int i = 0; i < this.classPanel.levels.Value; i++)
			{
				LevelPanel levelPanel = this.levels[i];
				string value = string.Concat(new string[]
				{
					"models/player/",
					levelPanel.txtModel.Text,
					"/",
					levelPanel.txtModel.Text,
					".mdl"
				});
				if (!linkedList.Contains(value))
				{
					linkedList.AddLast(value);
				}
				string value2 = levelPanel.txtAura.Text.Replace("\\", "/");
				if (!linkedList.Contains(value2))
				{
					linkedList.AddLast(value2);
				}
			}
			sw.WriteLine("PluginPreCache ()// Precache");
			sw.WriteLine("{");

            if (this.classPanel.cbDefaultStepSound.Checked)
            {
                sw.WriteLine("\tprecache_sound( \"common/npc_step1.wav\" )");
                sw.WriteLine("\tprecache_sound( \"common/npc_step2.wav\" )");
                sw.WriteLine("\tprecache_sound( \"common/npc_step3.wav\" )");
                sw.WriteLine("\tprecache_sound( \"common/npc_step4.wav\" )" + Environment.NewLine);
            }

            if (this.classPanel.cbDefaultFX.Checked
                    || this.classPanel.cbDefaultFX2.Checked
                    || this.classPanel.cbDefaultFX3.Checked
                    || this.classPanel.cbDefaultFX4.Checked
                    || this.classPanel.cbDefaultFX5.Checked
                    || this.classPanel.cbDefaultFX6.Checked
                    || this.classPanel.cbDefaultFX7.Checked)
                sw.WriteLine("\tprecache_sound( \"krillin/pscream.wav\" )" + Environment.NewLine);

			foreach (string current in linkedList)
			{
				sw.WriteLine("\tprecache_model( \"{0}\" );", current);
			}

			sw.WriteLine("}");
		}

        private void WriteFktECX_FusionClassCreation(StreamWriter sw)
        {
            if (this.classPanel.cbFusion.Checked)
            {
                sw.WriteLine(Environment.NewLine + "public @FusionClassCreation ()// Fusion");
                sw.WriteLine("{");
                sw.WriteLine("\t// You need to call \"addFusion\" here, see CCI Fusion Special document for details");
                sw.WriteLine("}");
            }
        }

        private void WriteFktECX_StepSound(StreamWriter sw)
        {
            if (this.classPanel.cbDefaultStepSound.Checked || this.classPanel.cbSwoopTime.Checked || this.classPanel.cbStealth.Checked)
            {
                sw.WriteLine(Environment.NewLine + "public client_PostThink( Client )");
                sw.WriteLine("{");
                sw.WriteLine("\tif( getCXbyName( \"{0}\" ) == getClientDATAc( Client, cliClass ) )", this.classPanel.txtName.Text);
                sw.WriteLine("\t{");

                if (this.classPanel.cbDefaultStepSound.Checked)
                {
                    sw.WriteLine("\t\t/* Step Sound */");
                    sw.WriteLine("\t\tif( getClientRunning( Client ) )");
                    sw.WriteLine("\t\t{");
                    sw.WriteLine("\t\t\tif( __float_StepSound_Delay[ Client ] <= get_gametime() )");
                    sw.WriteLine("\t\t\t{");
                    sw.WriteLine("\t\t\t\t__float_StepSound_Delay[ Client ] = get_gametime() + 0.450_000;");
                    sw.WriteLine("\t\t\t\tswitch( random_num( 1, 4 ) )");
                    sw.WriteLine("\t\t\t\t{");
                    sw.WriteLine("\t\t\t\t\tcase 1: emit_sound( Client, CHAN_VOICE, \"common/npc_step1.wav\", 0.300_000, ATTN_NORM, 0, PITCH_NORM );");
                    sw.WriteLine("\t\t\t\t\tcase 2: emit_sound( Client, CHAN_VOICE, \"common/npc_step2.wav\", 0.300_000, ATTN_NORM, 0, PITCH_NORM );");
                    sw.WriteLine("\t\t\t\t\tcase 3: emit_sound( Client, CHAN_VOICE, \"common/npc_step3.wav\", 0.300_000, ATTN_NORM, 0, PITCH_NORM );");
                    sw.WriteLine("\t\t\t\t\tcase 4: emit_sound( Client, CHAN_VOICE, \"common/npc_step4.wav\", 0.300_000, ATTN_NORM, 0, PITCH_NORM );");
                    sw.WriteLine("\t\t\t\t}");
                    sw.WriteLine("\t\t\t}");
                    sw.WriteLine("\t\t}");
                }

                if (this.classPanel.cbSwoopTime.Checked) sw.WriteLine("\t\tsetClientSWOOPTIME( Client, 999.999_999 );// Set Swoop Time");
                if (this.classPanel.cbStealth.Checked) sw.WriteLine("\t\tset_rendering( Client, kRenderFxNone, 0, 0, 0, kRenderTransAlpha, 100 );// Render settings");

                sw.WriteLine("\t}");
                sw.WriteLine("}");
            }
        }

		private void WriteFktECX_initTransformation(StreamWriter sw)
		{
			if (this.classPanel.levels.Value != 1)
			{
                sw.WriteLine(Environment.NewLine + "public @ClassInitiateTransformation ( Client, Level, bool:Perfect )// Transformation Begin");
				sw.WriteLine("{");
				sw.WriteLine("\tif ( Perfect )");
				sw.WriteLine("\t{");
				sw.WriteLine("\t\tswitch ( Level )");
				sw.WriteLine("\t\t{");
				for (int i = 1; i < this.classPanel.levels.Value; i++)
				{
					sw.WriteLine("\t\t\tcase {0}:" + Environment.NewLine + "\t\t\t{1}", i, "{");

                    /* Transformation FX */
                    if(i == 1)
                    {
                    if(this.classPanel.cbDefaultFX.Checked)
                        sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, true );");
                    }
                    if (i == 2)
                    {
                        if (this.classPanel.cbDefaultFX2.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, true );");
                    }
                    if (i == 3)
                    {
                        if (this.classPanel.cbDefaultFX3.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, true );");
                    }
                    if (i == 4)
                    {
                        if (this.classPanel.cbDefaultFX4.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, true );");
                    }
                    if (i == 5)
                    {
                        if (this.classPanel.cbDefaultFX5.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, true );");
                    }
                    if (i == 6)
                    {
                        if (this.classPanel.cbDefaultFX6.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, true );");
                    }
                    if (i == 7)
                    {
                        if (this.classPanel.cbDefaultFX7.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, true );");
                    }
                    /* End */

                    sw.WriteLine("\t\t\t}");
				}
				sw.WriteLine("\t\t}");
				sw.WriteLine("\t}");
				sw.WriteLine("\telse" + Environment.NewLine + "\t{");
				sw.WriteLine("\t\tswitch ( Level )");
				sw.WriteLine("\t\t{");
                for (int i = 1; i < this.classPanel.levels.Value; i++)
                {
                    sw.WriteLine("\t\t\tcase {0}:" + Environment.NewLine + "\t\t\t{1}", i, "{");

                    /* Transformation FX */
                    if (i == 1)
                    {
                        if (this.classPanel.cbDefaultFX.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, false );");
                    }
                    if (i == 2)
                    {
                        if (this.classPanel.cbDefaultFX2.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, false );");
                    }
                    if (i == 3)
                    {
                        if (this.classPanel.cbDefaultFX3.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, false );");
                    }
                    if (i == 4)
                    {
                        if (this.classPanel.cbDefaultFX4.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, false );");
                    }
                    if (i == 5)
                    {
                        if (this.classPanel.cbDefaultFX5.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, false );");
                    }
                    if (i == 6)
                    {
                        if (this.classPanel.cbDefaultFX6.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, false );");
                    }
                    if (i == 7)
                    {
                        if (this.classPanel.cbDefaultFX7.Checked)
                            sw.WriteLine("\t\t\t\t@ClassTransformationDefaultFX( Client, Level, false );");
                    }
                    /* End */

                    sw.WriteLine("\t\t\t}");
                }
				sw.WriteLine("\t\t}");
				sw.WriteLine("\t}");
				sw.WriteLine("}");
			}
		}

		private void WriteFktECX_finishTransformation(StreamWriter sw)
		{
			if (this.classPanel.levels.Value != 1)
			{
				sw.WriteLine(Environment.NewLine + "public @ClassFinishTransformation ( Client, Level )// Transformation Finished");
                sw.WriteLine("{");

                if (this.classPanel.cbDefaultFX.Checked
                    || this.classPanel.cbDefaultFX2.Checked
                    || this.classPanel.cbDefaultFX3.Checked
                    || this.classPanel.cbDefaultFX4.Checked
                    || this.classPanel.cbDefaultFX5.Checked
                    || this.classPanel.cbDefaultFX6.Checked
                    || this.classPanel.cbDefaultFX7.Checked)
                {
                    sw.WriteLine("\tAddFx( Client, \"fxBlow\" );");
                    sw.WriteLine("\tAddFx( Client, \"fxPowerWave\", \"sprites/white.spr\", 180, 145, 120, 30, 250 );");
                    sw.WriteLine(Environment.NewLine + "\tRemFx( Client, \"fxPowerup\", 0 );");
                    sw.WriteLine("\tRemFx( Client, \"fxModelEntity\", 0 );");
                    sw.WriteLine("\tRemFx( Client, \"fxSpriteEntity\", 0 );");
                    sw.WriteLine("\tRemFx( Client, \"fxLgtField\", 0 );");
                }

                sw.WriteLine("}");
			}
		}

		private void WriteFktECX_cancelTransformation(StreamWriter sw)
		{
			if (this.classPanel.levels.Value != 1)
			{
				sw.WriteLine(Environment.NewLine + "public @ClassCancelTransformation ( Client, Level )// Transformation Cancelled");
                sw.WriteLine("{");

                if (this.classPanel.cbDefaultFX.Checked
                    || this.classPanel.cbDefaultFX2.Checked
                    || this.classPanel.cbDefaultFX3.Checked
                    || this.classPanel.cbDefaultFX4.Checked
                    || this.classPanel.cbDefaultFX5.Checked
                    || this.classPanel.cbDefaultFX6.Checked
                    || this.classPanel.cbDefaultFX7.Checked)
                {
                    sw.WriteLine("\tRemFx( Client, \"fxPowerup\", 0 );");
                    sw.WriteLine("\tRemFx( Client, \"fxModelEntity\", 0 );");
                    sw.WriteLine("\tRemFx( Client, \"fxSpriteEntity\", 0 );");
                    sw.WriteLine("\tRemFx( Client, \"fxLgtField\", 0 );");
                }

				sw.WriteLine("}");
			}
		}

		private void WriteFktECX_CanEatCandy(StreamWriter sw)
		{
			if (this.classPanel.cbCanEatCandy.Checked)
			{
				sw.WriteLine(Environment.NewLine + "public bool:@ClassCandyEat ( Client )// If the character can eat Sensu Bean");
				sw.WriteLine("\treturn true;");
			}
		}

		public void CreateSound()
		{
			if (this.classPanel.cbSound.Checked)
			{
                using (StreamWriter streamWriter = new StreamWriter(this.path + "MOD.Sound.core", false, System.Text.Encoding.Default))
				{
                    streamWriter.WriteLine("/* You could replace the sound paths of the character here */" + Environment.NewLine);
					streamWriter.WriteLine("new MOD_SOUND_CORE[][][] =");
					streamWriter.WriteLine("{");
                    streamWriter.WriteLine("\t{" + Environment.NewLine + "\t\t\"*/death.wav\",");
					for (int i = 0; i < this.classPanel.levels.Value - 1; i++)
					{
                        streamWriter.WriteLine("\t\t\"" + this.classPanel.txtName.Text + "/death.wav" + "\",");
					}
					streamWriter.WriteLine("\t\t\"" + this.classPanel.txtName.Text + "/death.wav" + "\"");
					streamWriter.WriteLine("\t}");
                    streamWriter.WriteLine("}");
				}
			}
		}

		public void CreateWeapon()
		{
			if (this.classPanel.cbWeapon.Checked)
			{
                using (StreamWriter streamWriter = new StreamWriter(this.path + "MOD.Weapon.core", false, System.Text.Encoding.Default))
				{
                    streamWriter.WriteLine("/* See CCI Tutorial document for details */" + Environment.NewLine);
					streamWriter.WriteLine("stock MOD_Weapon_PreCache ()// Precache" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
                    streamWriter.WriteLine("public @IconUpdate ( Client, Level )// Weapon Icon Update" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
                    streamWriter.WriteLine("public @BaseWeaponCreation ( Client, BaseWeapon, const Name [], const CX_Name[] )" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
                    streamWriter.WriteLine("\t// >> Called when an attack is shot out");
					streamWriter.WriteLine("public @WeaponAdjust ( Client, Weapon, const Class[], PowerLevel, Charge )" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
                    streamWriter.WriteLine("\t// >> Ball Attacks like SpiritBomb, DeathBall...");
					streamWriter.WriteLine("public @WeaponBall ( Client, Weapon )" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
					streamWriter.WriteLine("\t// >> Blast Attacks like Bigbang, Renzoku...( The difference between BallAttacks and BlastAttacks is BlastAttacks don't have any sprite while charging )");
					streamWriter.WriteLine("public @WeaponBlast ( Client, Weapon, const Class[], Size )" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
					streamWriter.WriteLine("\t// >> Beam Attacks like Kamehameha, FinalFlash...");
					streamWriter.WriteLine("public @WeaponBeam ( Client, Weapon, const Class[], Size )" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
					streamWriter.WriteLine("\t// >> This is only for SpecialBeamCannon");
                    streamWriter.WriteLine("public @WeaponSBC ( Client, Weapon, const Class[] )" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
					streamWriter.WriteLine("\t// >> Character Death Task");
                    streamWriter.WriteLine("public @WeaponDeath ( Client, Killer, const Weapon[] )" + Environment.NewLine + "{" + Environment.NewLine + "}" + Environment.NewLine);
				}
			}
		}

		public void CreateCharge()
		{
			if (this.classPanel.cbCharge.Checked)
			{
                using (StreamWriter streamWriter = new StreamWriter(this.path + "MOD.Charge.core", false, System.Text.Encoding.Default))
				{
					streamWriter.WriteLine("ModChargeInit ()// Attack Charge Sprites Alter");
					streamWriter.WriteLine("{");
					streamWriter.WriteLine("\t//alterCharge( 0, \"genericbeam\", \"sprites/w_gb_b_s.spr\", 0.3 );");
					streamWriter.WriteLine("}");
				}
			}
		}

		public void CreateFX()
		{
            using (StreamWriter streamWriter = new StreamWriter(this.path + "FX.core", false, System.Text.Encoding.Default))
            {
                if (this.classPanel.cbDefaultStepSound.Checked)
                {
                    streamWriter.WriteLine("stock bool: getClientRunning( Client )");
                    streamWriter.WriteLine("{");
                    streamWriter.WriteLine("\tif(pev( Client, pev_sequence ) ==  3");
                    streamWriter.WriteLine("\t|| pev( Client, pev_sequence ) ==  4");
                    streamWriter.WriteLine("\t|| pev( Client, pev_sequence ) ==  5");
                    streamWriter.WriteLine("\t|| pev( Client, pev_sequence ) ==  6)");
                    streamWriter.WriteLine("\t\treturn true;");
                    streamWriter.WriteLine("\treturn false;");
                    streamWriter.WriteLine("}" + Environment.NewLine);
                }

                if (this.classPanel.cbDefaultFX.Checked
                    || this.classPanel.cbDefaultFX2.Checked
                    || this.classPanel.cbDefaultFX3.Checked
                    || this.classPanel.cbDefaultFX4.Checked
                    || this.classPanel.cbDefaultFX5.Checked
                    || this.classPanel.cbDefaultFX6.Checked
                    || this.classPanel.cbDefaultFX7.Checked)
                {
                    LevelPanel levelPanel = this.levels[0];
                    LevelPanel levelPanel1 = this.levels[1];
                    LevelPanel levelPanel2 = this.levels[2];
                    LevelPanel levelPanel3 = this.levels[3];
                    LevelPanel levelPanel4 = this.levels[4];
                    LevelPanel levelPanel5 = this.levels[5];
                    LevelPanel levelPanel6 = this.levels[6];
                    LevelPanel levelPanel7 = this.levels[7];
                    
                    streamWriter.WriteLine("@ClassTransformationDefaultFX( Client, Level, bool: Perfect )");
                    streamWriter.WriteLine("{");
                    streamWriter.WriteLine("\tif( Perfect )");
                    streamWriter.WriteLine("\t{");
                    streamWriter.WriteLine("\t\tAddFx( Client, \"fxBlow\" );");
                    streamWriter.WriteLine("\t\tAddFx( Client, \"fxPowerWave\", \"sprites/white.spr\", 180, 145, 120, 30, 250 );");
                    streamWriter.WriteLine("\t\tAddFx( Client, \"fxPowerup\", 0, 0, 0 ); emit_sound( Client, CHAN_WEAPON, \"krillin/pscream.wav\", 1.0, ATTN_NORM, 0, PITCH_NORM );");
                    streamWriter.WriteLine("\t\temit_sound( Client, CHAN_STATIC, \"krillin/pscream.wav\", 1.0, ATTN_NORM, 0, PITCH_NORM );");
                    streamWriter.WriteLine(Environment.NewLine + "\t\tswitch( Level )");
                    streamWriter.WriteLine("\t\t{");
                    streamWriter.WriteLine("\t\t\tcase 1: AddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel1.txtAura.Text, (int)levelPanel1.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\tcase 2: AddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel2.txtAura.Text, (int)levelPanel2.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\tcase 3: AddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel3.txtAura.Text, (int)levelPanel3.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\tcase 4: AddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel4.txtAura.Text, (int)levelPanel4.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\tcase 5: AddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel5.txtAura.Text, (int)levelPanel5.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\tcase 6: AddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel6.txtAura.Text, (int)levelPanel6.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\tcase 7: AddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel7.txtAura.Text, (int)levelPanel7.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t}");
                    streamWriter.WriteLine("\t}");
                    streamWriter.WriteLine("\telse");
                    streamWriter.WriteLine("\t{");
                    streamWriter.WriteLine("\t\tswitch( Level )");
                    streamWriter.WriteLine("\t\t{");
                    streamWriter.WriteLine("\t\t\tcase 1:");
                    streamWriter.WriteLine("\t\t\t{");
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel.txtAura.Text, (int)levelPanel.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\t}");
                    streamWriter.WriteLine("\t\t\tcase 2:");
                    streamWriter.WriteLine("\t\t\t{");
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel1.txtAura.Text, (int)levelPanel1.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxSpriteRays\", \"sprites/xsmoke1.spr\", {0}, 15, 0, {1}, {2}, {3}, 255, 25, 350, 0, 25);", levelPanel1.AscendTime.Value * 10, levelPanel1.btnChargeColor.BackColor.R, levelPanel1.btnChargeColor.BackColor.G, levelPanel1.btnChargeColor.BackColor.B);
                    streamWriter.WriteLine("\t\t\t}");
                    streamWriter.WriteLine("\t\t\tcase 3:");
                    streamWriter.WriteLine("\t\t\t{");
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel2.txtAura.Text, (int)levelPanel2.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxLightning\",\"sprites/lgtning.spr\", {0}, 50, 150, {1}, {2}, {3}, 250, 10, 100, 0 );", levelPanel2.AscendTime.Value * 10, levelPanel2.btnChargeColor.BackColor.R, levelPanel2.btnChargeColor.BackColor.G, levelPanel2.btnChargeColor.BackColor.B);
                    streamWriter.WriteLine("\t\t\t}");
                    streamWriter.WriteLine("\t\t\tcase 4:");
                    streamWriter.WriteLine("\t\t\t{");
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel3.txtAura.Text, (int)levelPanel3.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxSpriteEntity\", \"sprites/ecx.aura.ssj3.spr\", 0, 0, 255.0, 255, 255, 255, 10.0, 0.3, 0, 0 );");
                    streamWriter.WriteLine("\t\t\t}");
                    streamWriter.WriteLine("\t\t\tcase 5:");
                    streamWriter.WriteLine("\t\t\t{");
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel4.txtAura.Text, (int)levelPanel4.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxLgtField\", 0.1, 1, 255, 200, 20 );");
                    streamWriter.WriteLine("\t\t\t}");
                    streamWriter.WriteLine("\t\t\tcase 6:");
                    streamWriter.WriteLine("\t\t\t{");
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel5.txtAura.Text, (int)levelPanel5.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxLightning\",\"sprites/lgtning.spr\", {0}, 50, 150, {1}, {2}, {3}, 250, 10, 100, 0 );", levelPanel5.AscendTime.Value * 10, levelPanel5.btnChargeColor.BackColor.R, levelPanel5.btnChargeColor.BackColor.G, levelPanel5.btnChargeColor.BackColor.B);
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxLgtField\", 0.1, 1, 255, 200, 20 );");
                    streamWriter.WriteLine("\t\t\t}");
                    streamWriter.WriteLine("\t\t\tcase 7:");
                    streamWriter.WriteLine("\t\t\t{");
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxModelEntity\", \"{0}\", 0, 0, 80.0, 0, 0, 0, 1.0, 0.3, 0, {1} );", levelPanel6.txtAura.Text, (int)levelPanel6.AuraSkin.Value);
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxLightning\",\"sprites/lgtning.spr\", {0}, 50, 150, {1}, {2}, {3}, 250, 10, 100, 0 );", levelPanel6.AscendTime.Value * 10, levelPanel6.btnChargeColor.BackColor.R, levelPanel6.btnChargeColor.BackColor.G, levelPanel6.btnChargeColor.BackColor.B);
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxLgtField\", 0.1, 1, 255, 200, 20 );");
                    streamWriter.WriteLine("\t\t\t\tAddFx( Client, \"fxScreenShake\", 50.0, {0}, 5.0 );", this.FormatFloat(levelPanel.AscendTime.Value));
                    streamWriter.WriteLine("\t\t\t}");
                    streamWriter.WriteLine("\t\t}" + Environment.NewLine);
                    streamWriter.WriteLine("\t\tAddFx( Client, \"fxPowerup\", 0, 0, 0 );");
                    streamWriter.WriteLine("\t}");
                    streamWriter.WriteLine("}");
                }
			}
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = Application.StartupPath;
				saveFileDialog.Filter = "Class Xtension Information (*.cxi) | *.cxi";
				saveFileDialog.DefaultExt = "cxi";
				saveFileDialog.AddExtension = true;
				saveFileDialog.FileName = this.classPanel.txtName.Text + ".cxi";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					Serializer serializer = new Serializer(this.classPanel, this.levels);
					serializer.Save(saveFileDialog.FileName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Concat(new object[]
				{
					"Message: ",
					ex.Message,
					"\r\nInternal Exception: ",
					ex.InnerException
				}));
			}
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = Application.StartupPath;
				openFileDialog.Filter = "Class Xtension Information (*.cxi) | *.cxi";
				openFileDialog.DefaultExt = "cxi";
				openFileDialog.CheckFileExists = true;
				openFileDialog.Multiselect = false;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					Serializer.Load(openFileDialog.FileName, this.classPanel, this.levels);
				}
				if (this.currPos >= this.classPanel.levels.Value)
				{
					this.setCurrControl(this.classPanel.levels.Value);
				}
				else
				{
					this.setCurrControl(this.currPos);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Concat(new object[]
				{
					"Message: ",
					ex.Message,
					"\r\nInternal Exception: ",
					ex.InnerException
				}));
			}
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ClassWizard));
			this.btnClose = new Button();
			this.btnBuild = new Button();
			this.btnNext = new Button();
			this.btnPrev = new Button();
			this.lblPosition = new Label();
			this.btnExport = new Button();
			this.btnImport = new Button();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.currControl = new MyControl();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.btnClose.DialogResult = DialogResult.Cancel;
			this.btnClose.Location = new Point(24, 22);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new Size(75, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnBuild.Location = new Point(458, 22);
			this.btnBuild.Name = "btnBuild";
			this.btnBuild.Size = new Size(75, 23);
			this.btnBuild.TabIndex = 2;
			this.btnBuild.Text = "Create";
			this.btnBuild.UseVisualStyleBackColor = true;
			this.btnBuild.Click += new EventHandler(this.btnBuild_Click);
			this.btnNext.Location = new Point(351, 22);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new Size(75, 23);
			this.btnNext.TabIndex = 3;
			this.btnNext.Text = ">>";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new EventHandler(this.btnNext_Click);
			this.btnPrev.Location = new Point(129, 22);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new Size(75, 23);
			this.btnPrev.TabIndex = 4;
			this.btnPrev.Text = "<<";
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new EventHandler(this.btnPrev_Click);
			this.lblPosition.AutoSize = true;
			this.lblPosition.Font = new Font("Arial Black", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblPosition.ForeColor = Color.FromArgb(128, 128, 255);
			this.lblPosition.Location = new Point(230, 0);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new Size(56, 23);
			this.lblPosition.TabIndex = 5;
			this.lblPosition.Text = "Main";
			this.lblPosition.TextAlign = ContentAlignment.MiddleCenter;
			this.btnExport.Location = new Point(241, 39);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new Size(75, 23);
			this.btnExport.TabIndex = 7;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new EventHandler(this.btnExport_Click);
			this.btnImport.Location = new Point(241, 10);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new Size(75, 23);
			this.btnImport.TabIndex = 8;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new EventHandler(this.btnImport_Click);
			this.panel1.BackColor = Color.Gainsboro;
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnImport);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnExport);
			this.panel1.Controls.Add(this.btnBuild);
			this.panel1.Controls.Add(this.btnNext);
			this.panel1.Controls.Add(this.btnPrev);
			this.panel1.Location = new Point(-2, 700);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(560, 74);
			this.panel1.TabIndex = 9;
			this.panel2.BackColor = Color.Gainsboro;
			this.panel2.BorderStyle = BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.lblPosition);
			this.panel2.Location = new Point(-2, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(560, 26);
			this.panel2.TabIndex = 10;
			this.currControl.BackColor = Color.WhiteSmoke;
			this.currControl.Location = new Point(23, 25);
			this.currControl.Name = "currControl";
			this.currControl.Size = new Size(509, 533);
			this.currControl.TabIndex = 6;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.WhiteSmoke;
			base.ClientSize = new Size(556, 772);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.currControl);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ClassWizard";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Class Xtension Wizard";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
