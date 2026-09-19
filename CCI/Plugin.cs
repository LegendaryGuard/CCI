using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CCI
{
	internal class Plugin : ListViewItem
	{
		public readonly PluginStyle Style;

		public readonly string Folder;

		public readonly string FileWithExt;

		public readonly string Prefix;

		public bool CommitAfterCompile = false;

		public Plugin(string name, PluginStyle style, string folder, string file)
		{
			base.Text = name;
			this.Style = style;
			base.Name = name;
			this.Folder = folder;
			this.FileWithExt = file;
			switch (this.Style)
			{
			case PluginStyle.Core:
				base.ForeColor = Color.FromArgb(0, 200, 50);
				this.Prefix = "CORE";
				break;
			case PluginStyle.Plugin:
				base.ForeColor = Color.FromArgb(30, 30, 240);
				this.Prefix = "ETC";
				break;
			case PluginStyle.Extension:
				base.ForeColor = Color.FromArgb(200, 30, 30);
				this.Prefix = "CX";
				break;
			}
			base.SubItems.Add(this.Prefix);
		}

		public bool Commit()
		{
			bool result;
			try
			{
				RegistryKey currentUser = Registry.CurrentUser;
				RegistryKey registryKey = currentUser.OpenSubKey("Software\\Valve\\Steam");
				string text = registryKey.GetValue("ModInstallPath") as string;
				text = text + "\\esf\\core\\plugins\\" + this.Prefix + "\\";
				string str = base.Name.Replace(".sma", "").Replace(".core", "");
				string sourceFileName = string.Concat(new string[]
				{
					Application.StartupPath,
					"\\",
					this.Folder,
					"\\",
					base.Name,
					".amxx"
				});
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				File.Copy(sourceFileName, text + str + ".amxx", true);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
