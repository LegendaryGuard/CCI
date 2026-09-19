using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CCI
{
	public class Level
	{
		public string Name;

		public string Model;

		public float AscendTime;

		public float PerfectAscendTime;

		public int PowerLevel;

		public int PerfectPowerLevel;

		public float PowerLevelMultiplier;

		public int Speed;

		public int Health;

		public bool LockAscend;

		public bool LockDescend;

		public int TeleportRange;

		public int TeleportKi;

		public float KiRate;

		public float Booster;

		public int Attack;

		public int Defense;

		public bool EnableGlow;

		public RGB GlowColor;

		public byte GlowRange;

		public bool EnableLightning;

		public byte LightningHead;

		public byte LightningTorso;

		public byte LightningFeet;

		public byte LightningRange;

		public string AuraModel;

		public string AuraRenderMode;

		public float AuraOpacity;

		public byte AuraSkin;

		public RGB AuraColor;

		public RGB ChargeColor;

		public bool SkillTeleportCharge;

		public bool SkillTeleportSwoop;

		public bool SkillTeleportSense;

		public bool SkillHypermode;

		public bool SkillSwoopSense;

		public byte SkillMeleeSense;

		public byte SkillStrongMelee;

		public List<string> WeaponList = new List<string>();

		public Level()
		{
		}

		public Level(LevelPanel l)
		{
			this.Name = l.txtName.Text;
			this.Model = l.txtModel.Text;
			this.AscendTime = (float)l.AscendTime.Value;
			this.PerfectAscendTime = (float)l.PerfectAscendTime.Value;
			this.PowerLevel = (int)l.PowerLevel.Value;
			this.PerfectPowerLevel = (int)l.PerfectPowerLevel.Value;
			this.PowerLevelMultiplier = (float)l.PowerLevelMultiplier.Value;
			this.Speed = (int)l.Speed.Value;
			this.Health = (int)l.Health.Value;
			this.Attack = l.trackAttack.Value;
			this.Defense = l.trackDefense.Value;
			this.LockAscend = l.cbNoAscend.Checked;
			this.LockDescend = l.cbNoDescend.Checked;
			this.TeleportRange = (int)l.TeleportRange.Value;
			this.TeleportKi = (int)l.TeleportKi.Value;
			this.KiRate = (float)l.KiRate.Value;
			this.Booster = (float)l.Booster.Value;
			this.EnableGlow = l.cbGlow.Checked;
			this.GlowColor = new RGB(l.btnGlowColor.BackColor);
			this.GlowRange = (byte)l.GlowWidth.Value;
			this.EnableLightning = l.cbLightning.Checked;
			this.LightningHead = (byte)l.LgtHead.Value;
			this.LightningTorso = (byte)l.LgtTorso.Value;
			this.LightningFeet = (byte)l.LgtFeets.Value;
			this.LightningRange = (byte)l.LgtRange.Value;
			this.AuraModel = l.txtAura.Text;
			this.AuraRenderMode = l.AuraRenderMode.Text;
			this.AuraOpacity = (float)l.AuraOpacityMax.Value;
			this.AuraSkin = (byte)l.AuraSkin.Value;
			this.AuraColor = new RGB(l.btnAuraColor.BackColor);
			this.ChargeColor = new RGB(l.btnChargeColor.BackColor);
			this.SkillHypermode = l.cbHypermode.Checked;
			this.SkillMeleeSense = (byte)l.MeleeSense.Value;
			this.SkillStrongMelee = (byte)l.StrongMelee.Value;
			this.SkillSwoopSense = l.cbSwoopSense.Checked;
			this.SkillTeleportCharge = l.cbTeleportCharge.Checked;
			this.SkillTeleportSense = l.cbTeleSense.Checked;
			this.SkillTeleportSwoop = l.cbTeleportSwoop.Checked;
			foreach (ListViewItem listViewItem in l.listWeapon.CheckedItems)
			{
				this.WeaponList.Add(listViewItem.Text);
			}
		}
	}
}
