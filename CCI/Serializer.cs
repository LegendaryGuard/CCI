using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CCI
{
	[XmlRoot("Class", Namespace = "", IsNullable = false)]
	public class Serializer
	{
		public string Name;

		public string Author;

		public string Version;

		public string Description;

		public int Levels;

		public bool ModSound;

		public bool ModCharge;

		public bool ModWeapon;

		public bool Descend;

		public bool Fusion;

		public bool Candy;

		public List<Level> LevelInfo = new List<Level>(8);

		public void Save(string file)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Serializer));
			TextWriter textWriter = new StreamWriter(file);
			xmlSerializer.Serialize(textWriter, this);
			textWriter.Close();
		}

		public static void Load(string file, ClassPanel c, LevelPanel[] levels)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Serializer));
			TextReader textReader = new StreamReader(file);
			Serializer serializer = (Serializer)xmlSerializer.Deserialize(textReader);
			textReader.Close();
			c.txtName.Text = serializer.Name;
			c.txtAuthor.Text = serializer.Author;
			c.txtVersion.Text = serializer.Version;
			c.txtDescription.Text = serializer.Description;
			c.levels.Value = serializer.Levels;
			c.cbSound.Checked = serializer.ModSound;
			c.cbCharge.Checked = serializer.ModCharge;
			c.cbWeapon.Checked = serializer.ModWeapon;
			c.cbDescendClass.Checked = serializer.Descend;
			c.cbFusion.Checked = serializer.Fusion;
			c.cbCanEatCandy.Checked = serializer.Candy;
			int num = 0;
			foreach (Level current in serializer.LevelInfo)
			{
				LevelPanel levelPanel = levels[num];
				levelPanel.txtName.Text = current.Name;
				levelPanel.txtModel.Text = current.Model;
				levelPanel.AscendTime.Value = (decimal)current.AscendTime;
				levelPanel.PerfectAscendTime.Value = (decimal)current.PerfectAscendTime;
				levelPanel.PowerLevel.Value = current.PowerLevel;
				levelPanel.PerfectPowerLevel.Value = current.PerfectPowerLevel;
				levelPanel.PowerLevelMultiplier.Value = (decimal)current.PowerLevelMultiplier;
				levelPanel.Speed.Value = current.Speed;
				levelPanel.Health.Value = current.Health;
				levelPanel.trackAttack.Value = current.Attack;
				levelPanel.trackDefense.Value = current.Defense;
				levelPanel.cbNoAscend.Checked = current.LockAscend;
				levelPanel.cbNoDescend.Checked = current.LockDescend;
				levelPanel.TeleportRange.Value = current.TeleportRange;
				levelPanel.TeleportKi.Value = current.TeleportKi;
				levelPanel.KiRate.Value = (decimal)current.KiRate;
				levelPanel.Booster.Value = (decimal)current.Booster;
				levelPanel.cbGlow.Checked = current.EnableGlow;
				levelPanel.btnGlowColor.BackColor = current.GlowColor.Color;
				levelPanel.GlowWidth.Value = current.GlowRange;
				levelPanel.cbLightning.Checked = current.EnableLightning;
				levelPanel.LgtHead.Value = current.LightningHead;
				levelPanel.LgtTorso.Value = current.LightningTorso;
				levelPanel.LgtFeets.Value = current.LightningFeet;
				levelPanel.LgtRange.Value = current.LightningRange;
				levelPanel.txtAura.Text = current.AuraModel;
				levelPanel.AuraRenderMode.Text = current.AuraRenderMode;
				levelPanel.AuraOpacityMax.Value = (decimal)current.AuraOpacity;
				levelPanel.AuraSkin.Value = current.AuraSkin;
				levelPanel.btnAuraColor.BackColor = current.AuraColor.Color;
				levelPanel.btnChargeColor.BackColor = current.ChargeColor.Color;
				levelPanel.cbHypermode.Checked = current.SkillHypermode;
				levelPanel.MeleeSense.Value = current.SkillMeleeSense;
				levelPanel.StrongMelee.Value = current.SkillStrongMelee;
				levelPanel.cbSwoopSense.Checked = current.SkillSwoopSense;
				levelPanel.cbTeleportCharge.Checked = current.SkillTeleportCharge;
				levelPanel.cbTeleSense.Checked = current.SkillTeleportSense;
				levelPanel.cbTeleportSwoop.Checked = current.SkillTeleportSwoop;
				foreach (ListViewItem listViewItem in levelPanel.listWeapon.Items)
				{
					listViewItem.Checked = current.WeaponList.Contains(listViewItem.Text);
				}
				num++;
			}
		}

		public Serializer()
		{
		}

		public Serializer(ClassPanel c, LevelPanel[] levels)
		{
			this.Name = c.txtName.Text;
			this.Author = c.txtAuthor.Text;
			this.Version = c.txtVersion.Text;
			this.Description = c.txtDescription.Text;
			this.Levels = c.levels.Value;
			this.ModSound = c.cbSound.Checked;
			this.ModCharge = c.cbCharge.Checked;
			this.ModWeapon = c.cbWeapon.Checked;
			this.Descend = c.cbDescendClass.Checked;
			this.Fusion = c.cbFusion.Checked;
			this.Candy = c.cbCanEatCandy.Checked;
			int num = 0;
			for (int i = 0; i < levels.Length; i++)
			{
				LevelPanel l = levels[i];
				if (num >= this.Levels)
				{
					break;
				}
				this.LevelInfo.Add(new Level(l));
				num++;
			}
		}
	}
}
