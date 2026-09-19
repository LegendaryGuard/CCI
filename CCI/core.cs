using CCI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CCI
{
	public class core : Form
	{
		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private SplitContainer splitContainer1;

		private ListView plugins;

		private ColumnHeader colplugs;

		private ColumnHeader colgrp;

		private Console console;

		private Process process;

		private ToolStrip toolStripPlugin;

		private ToolStripDropDownButton toolStripDropDownPluginSelection;

		private ToolStripMenuItem allToolStripMenuItem1;

		private ToolStripMenuItem noneToolStripMenuItem1;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton toolStripButtonPluginInit;

		private ToolStripButton toolStripButtonPluginAbort;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton toolStripButtonCreateCX;

		private ProgressBar statusBar;

		private ToolStripButton toolStripButtonCommit;

		private ToolStripLabel toolStripLabelCR;

		private ToolStripButton toolStripButtonAbout;

		private ToolStripButton toolStripButtonRefresh;

		private ToolStripComboBox txtFilter;

		private static Color C_NAME = Color.FromArgb(100, 100, 200);

		private static Color C_ERROR = Color.FromArgb(255, 10, 10);

		private static Color C_WARNING = Color.FromArgb(200, 60, 60);

		private static Color C_COMPILE = Color.FromArgb(150, 150, 150);

		private static Color C_UPDATE = Color.FromArgb(150, 150, 150);

		private static Color C_DEFAULT = Color.FromArgb(150, 150, 150);

		private static int ValidCompiles = 0;

		private static int FailedCompiles = 0;

		private static TimeSpan Duration = TimeSpan.Zero;

		private PluginSort pluginsSort;

		private Settings settings = new Settings();

		private Queue<Plugin> pluginQueue = new Queue<Plugin>();

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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(core));
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.splitContainer1 = new SplitContainer();
			this.plugins = new ListView();
			this.colplugs = new ColumnHeader();
			this.colgrp = new ColumnHeader();
			this.console = new Console();
			this.toolStripPlugin = new ToolStrip();
			this.toolStripDropDownPluginSelection = new ToolStripDropDownButton();
			this.allToolStripMenuItem1 = new ToolStripMenuItem();
			this.noneToolStripMenuItem1 = new ToolStripMenuItem();
			this.toolStripButtonRefresh = new ToolStripButton();
			this.txtFilter = new ToolStripComboBox();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.toolStripButtonPluginInit = new ToolStripButton();
			this.toolStripButtonPluginAbort = new ToolStripButton();
			this.toolStripButtonCommit = new ToolStripButton();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.toolStripButtonCreateCX = new ToolStripButton();
			this.toolStripButtonAbout = new ToolStripButton();
			this.toolStripLabelCR = new ToolStripLabel();
			this.statusBar = new ProgressBar();
			this.process = new Process();
			this.tableLayoutPanel1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStripPlugin.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.toolStripPlugin, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.statusBar, 0, 2);
			this.tableLayoutPanel1.Dock = DockStyle.Fill;
			this.tableLayoutPanel1.Location = new Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel1.Size = new Size(750, 446);
			this.tableLayoutPanel1.TabIndex = 7;
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.Location = new Point(3, 34);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.plugins);
			this.splitContainer1.Panel2.Controls.Add(this.console);
			this.splitContainer1.Size = new Size(744, 380);
			this.splitContainer1.SplitterDistance = 248;
			this.splitContainer1.TabIndex = 7;
			this.plugins.BackColor = SystemColors.Control;
			this.plugins.BorderStyle = BorderStyle.FixedSingle;
			this.plugins.CheckBoxes = true;
			this.plugins.Columns.AddRange(new ColumnHeader[]
			{
				this.colplugs,
				this.colgrp
			});
			this.plugins.Dock = DockStyle.Fill;
			this.plugins.FullRowSelect = true;
			this.plugins.Location = new Point(0, 0);
			this.plugins.Name = "plugins";
			this.plugins.ShowItemToolTips = true;
			this.plugins.Size = new Size(248, 380);
			this.plugins.Sorting = SortOrder.Ascending;
			this.plugins.TabIndex = 2;
			this.plugins.UseCompatibleStateImageBehavior = false;
			this.plugins.View = View.Details;
			this.plugins.MouseUp += new MouseEventHandler(this.plugins_MouseUp);
			this.colplugs.Text = "Plugins";
			this.colplugs.Width = 149;
			this.colgrp.Text = "Directory";
			this.colgrp.Width = 79;
			this.console.BackColor = Color.White;
			this.console.BorderStyle = BorderStyle.FixedSingle;
			this.console.Dock = DockStyle.Fill;
			this.console.Font = new Font("Courier New", 10f, FontStyle.Bold, GraphicsUnit.Point, 177);
			this.console.Location = new Point(0, 0);
			this.console.Name = "console";
			this.console.ReadOnly = true;
			this.console.ScrollBars = RichTextBoxScrollBars.Vertical;
			this.console.Size = new Size(492, 380);
			this.console.TabIndex = 3;
			this.console.Text = "";
			this.toolStripPlugin.ImageScalingSize = new Size(24, 24);
			this.toolStripPlugin.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripDropDownPluginSelection,
				this.toolStripButtonRefresh,
				this.txtFilter,
				this.toolStripSeparator1,
				this.toolStripButtonPluginInit,
				this.toolStripButtonPluginAbort,
				this.toolStripButtonCommit,
				this.toolStripSeparator2,
				this.toolStripButtonCreateCX,
				this.toolStripButtonAbout,
				this.toolStripLabelCR
			});
			this.toolStripPlugin.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStripPlugin.Location = new Point(0, 0);
			this.toolStripPlugin.Name = "toolStripPlugin";
			this.toolStripPlugin.RenderMode = ToolStripRenderMode.Professional;
			this.toolStripPlugin.Size = new Size(750, 31);
			this.toolStripPlugin.TabIndex = 4;
			this.toolStripPlugin.Text = "toolStrip1";
			this.toolStripDropDownPluginSelection.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownPluginSelection.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.allToolStripMenuItem1,
				this.noneToolStripMenuItem1
			});
			this.toolStripDropDownPluginSelection.Image = (Image)componentResourceManager.GetObject("toolStripDropDownPluginSelection.Image");
			this.toolStripDropDownPluginSelection.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownPluginSelection.Name = "toolStripDropDownPluginSelection";
			this.toolStripDropDownPluginSelection.Size = new Size(37, 28);
			this.toolStripDropDownPluginSelection.Text = "Selection";
			this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
			this.allToolStripMenuItem1.Size = new Size(152, 22);
			this.allToolStripMenuItem1.Text = "All";
			this.allToolStripMenuItem1.Click += new EventHandler(this.allToolStripMenuItem1_Click);
			this.noneToolStripMenuItem1.Name = "noneToolStripMenuItem1";
			this.noneToolStripMenuItem1.Size = new Size(152, 22);
			this.noneToolStripMenuItem1.Text = "None";
			this.noneToolStripMenuItem1.Click += new EventHandler(this.noneToolStripMenuItem1_Click);
			this.toolStripButtonRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonRefresh.Image = (Image)componentResourceManager.GetObject("toolStripButtonRefresh.Image");
			this.toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
			this.toolStripButtonRefresh.Size = new Size(28, 28);
			this.toolStripButtonRefresh.Text = "toolStripButton1";
			this.toolStripButtonRefresh.ToolTipText = "Refresh";
			this.toolStripButtonRefresh.Click += new EventHandler(this.toolStripButtonRefresh_Click);
			this.txtFilter.Items.AddRange(new object[]
			{
				"",
				"SX"
			});
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new Size(75, 31);
			this.txtFilter.ToolTipText = "Plugin Filter";
			this.txtFilter.TextChanged += new EventHandler(this.txtFilter_TextChanged);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(6, 31);
			this.toolStripButtonPluginInit.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonPluginInit.Image = (Image)componentResourceManager.GetObject("toolStripButtonPluginInit.Image");
			this.toolStripButtonPluginInit.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonPluginInit.Name = "toolStripButtonPluginInit";
			this.toolStripButtonPluginInit.Size = new Size(28, 28);
			this.toolStripButtonPluginInit.Text = "Initiate";
			this.toolStripButtonPluginInit.ToolTipText = "Compile selected plugins";
			this.toolStripButtonPluginInit.Click += new EventHandler(this.toolStripButtonPluginInit_Click);
			this.toolStripButtonPluginAbort.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonPluginAbort.Enabled = false;
			this.toolStripButtonPluginAbort.Image = (Image)componentResourceManager.GetObject("toolStripButtonPluginAbort.Image");
			this.toolStripButtonPluginAbort.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonPluginAbort.Name = "toolStripButtonPluginAbort";
			this.toolStripButtonPluginAbort.Size = new Size(28, 28);
			this.toolStripButtonPluginAbort.Text = "Abort";
            this.toolStripButtonPluginAbort.ToolTipText = "Terminate current task";
			this.toolStripButtonPluginAbort.Click += new EventHandler(this.toolStripButtonPluginAbort_Click);
			this.toolStripButtonCommit.Checked = true;
			this.toolStripButtonCommit.CheckOnClick = true;
			this.toolStripButtonCommit.CheckState = CheckState.Checked;
			this.toolStripButtonCommit.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonCommit.Image = (Image)componentResourceManager.GetObject("toolStripButtonCommit.Image");
			this.toolStripButtonCommit.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonCommit.Name = "toolStripButtonCommit";
			this.toolStripButtonCommit.Size = new Size(28, 28);
            this.toolStripButtonCommit.Text = "Commit to ESF Directory( Only available to Steam )";
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(6, 31);
			this.toolStripButtonCreateCX.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonCreateCX.Image = (Image)componentResourceManager.GetObject("toolStripButtonCreateCX.Image");
			this.toolStripButtonCreateCX.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonCreateCX.Name = "toolStripButtonCreateCX";
			this.toolStripButtonCreateCX.Size = new Size(28, 28);
			this.toolStripButtonCreateCX.Text = "Class Extension Wizard";
			this.toolStripButtonCreateCX.Click += new EventHandler(this.toolStripButtonCreateCX_Click);
			this.toolStripButtonAbout.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButtonAbout.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonAbout.Image = (Image)componentResourceManager.GetObject("toolStripButtonAbout.Image");
			this.toolStripButtonAbout.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonAbout.Name = "toolStripButtonAbout";
			this.toolStripButtonAbout.Size = new Size(28, 28);
			this.toolStripButtonAbout.Text = "toolStripButton1";
			this.toolStripButtonAbout.ToolTipText = "About";
			this.toolStripButtonAbout.Click += new EventHandler(this.toolStripButtonAbout_Click);
			this.toolStripLabelCR.Alignment = ToolStripItemAlignment.Right;
			this.toolStripLabelCR.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripLabelCR.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStripLabelCR.ForeColor = Color.Red;
			this.toolStripLabelCR.IsLink = true;
			this.toolStripLabelCR.LinkBehavior = LinkBehavior.NeverUnderline;
			this.toolStripLabelCR.LinkColor = Color.FromArgb(128, 128, 255);
			this.toolStripLabelCR.Name = "toolStripLabelCR";
			this.toolStripLabelCR.Size = new Size(256, 28);
			this.toolStripLabelCR.Text = "(c)   Corona Bytes .NET   2005 - 2007";
			this.toolStripLabelCR.VisitedLinkColor = Color.FromArgb(128, 128, 255);
			this.toolStripLabelCR.Click += new EventHandler(this.toolStripLabelCR_Click);
			this.statusBar.BackColor = Color.Black;
			this.statusBar.Dock = DockStyle.Bottom;
			this.statusBar.ForeColor = Color.Red;
			this.statusBar.Location = new Point(3, 420);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new Size(744, 23);
			this.statusBar.TabIndex = 8;
			this.process.EnableRaisingEvents = true;
			this.process.StartInfo.CreateNoWindow = true;
			this.process.StartInfo.Domain = "";
			this.process.StartInfo.LoadUserProfile = false;
			this.process.StartInfo.Password = null;
			this.process.StartInfo.RedirectStandardError = true;
			this.process.StartInfo.RedirectStandardOutput = true;
			this.process.StartInfo.StandardErrorEncoding = null;
			this.process.StartInfo.StandardOutputEncoding = null;
			this.process.StartInfo.UserName = "";
			this.process.StartInfo.UseShellExecute = false;
			this.process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			this.process.SynchronizingObject = this;
			this.process.Exited += new EventHandler(this.process_Exited);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.ClientSize = new Size(750, 446);
			base.Controls.Add(this.tableLayoutPanel1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "core";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Corona Bytes .NET Compiler Interface v2.0[English Edition]";
			base.FormClosing += new FormClosingEventHandler(this.core_FormClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.toolStripPlugin.ResumeLayout(false);
			this.toolStripPlugin.PerformLayout();
			base.ResumeLayout(false);
		}

		public core()
		{
			this.InitializeComponent();
			this.LoadPlugins(false);
			this.pluginsSort = new PluginSort();
			this.plugins.ListViewItemSorter = this.pluginsSort;
			this.settings.Reload();
		}

		private void LoadPlugins(bool refresh)
		{
			this.console.Clear();
            this.plugins.Items.Clear();
			this.process.StartInfo.FileName = Application.StartupPath + "/.Nexus/amxxpc.exe";
			DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
			this.plugins.BeginUpdate();
			DirectoryInfo[] directories = directoryInfo.GetDirectories("*" + this.txtFilter.Text + "*");
			for (int i = 0; i < directories.Length; i++)
			{
				DirectoryInfo directoryInfo2 = directories[i];
				if (directoryInfo2.Name[0] != '.')
				{
					if (File.Exists(directoryInfo2.ToString() + "\\." + directoryInfo2.ToString() + ".core"))
					{
						this.plugins.Items.Add(new Plugin(directoryInfo2.Name, PluginStyle.Core, directoryInfo2.Name, "." + directoryInfo2.Name + ".core"));
					}
					else if (File.Exists(directoryInfo2.ToString() + "\\.ClassExtension.core"))
					{
						this.plugins.Items.Add(new Plugin(directoryInfo2.Name, PluginStyle.Extension, directoryInfo2.Name, ".ClassExtension.core"));
					}
                }
			}
			directoryInfo = new DirectoryInfo(Application.StartupPath + "\\.Plugins");
			if (directoryInfo.Exists)
			{
				FileInfo[] files = directoryInfo.GetFiles("*" + this.txtFilter.Text + "*");
				for (int i = 0; i < files.Length; i++)
				{
					FileInfo fileInfo = files[i];
					if (fileInfo.Extension == ".core" || fileInfo.Extension == ".sma")
					{
						this.plugins.Items.Add(new Plugin(fileInfo.Name, PluginStyle.Plugin, ".Plugins", fileInfo.Name));
					}
				}
			}
			this.plugins.EndUpdate();
			string[] array = this.settings.Selection.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string b = array[i];
				foreach (ListViewItem listViewItem in this.plugins.Items)
				{
					if (listViewItem.Name == b)
					{
						listViewItem.Checked = true;
					}
				}
			}
		}

		private void core_FormClosing(object sender, FormClosingEventArgs e)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + "\\.Release");
			if (directoryInfo.Exists)
			{
				try
				{
					directoryInfo.Delete(true);
				}
				catch
				{
				}
				try
				{
					directoryInfo.Delete();
				}
				catch
				{
				}
			}
			DirectoryInfo directoryInfo2 = new DirectoryInfo(Application.StartupPath);
			DirectoryInfo[] directories = directoryInfo2.GetDirectories();
			for (int i = 0; i < directories.Length; i++)
			{
				DirectoryInfo directoryInfo3 = directories[i];
				if (directoryInfo3.Name[0] != '.' || directoryInfo3.Name.Equals(".Plugins"))
				{
					FileInfo[] files = directoryInfo3.GetFiles();
					for (int j = 0; j < files.Length; j++)
					{
						FileInfo fileInfo = files[j];
						if (fileInfo.ToString().EndsWith(".amxx") || fileInfo.ToString().EndsWith(".amx") || fileInfo.ToString().EndsWith(".log") || fileInfo.ToString().EndsWith(".tmp") || fileInfo.ToString().EndsWith(".asm"))
						{
							try
							{
								fileInfo.Delete();
							}
							catch (Exception)
							{
							}
						}
					}
				}
			}
			string text = "";
			foreach (ListViewItem listViewItem in this.plugins.CheckedItems)
			{
				text = text + listViewItem.Name + ';';
			}
			this.settings.Selection = text;
			this.settings.Save();
		}

		private void process_Exited(object sender, EventArgs e)
		{
			string input = this.process.StandardOutput.ReadToEnd();
			if (this.pluginQueue.Count > 0)
			{
				Plugin plugin = this.pluginQueue.Dequeue();
				Regex regex = new Regex("\\n");
				string[] array = regex.Split(input);
				if (array[array.Length - 3].Contains("Error"))
				{
					for (int i = 3; i < array.Length - 4; i++)
					{
						if (array[i].Length >= 2)
						{
							Color color = default(Color);
							int num = array[i].IndexOf(" : ");
							if (num >= 0)
							{
								string text = array[i].Substring(num, 10);
								if (text.Contains("error") || text.Contains("fatal"))
								{
									color = core.C_ERROR;
								}
								else
								{
									color = core.C_WARNING;
								}
							}
							this.console.Print(color, array[i]);
						}
					}
					core.FailedCompiles++;
				}
				else if (array[array.Length - 3].Contains("Warning"))
				{
					for (int i = 3; i < array.Length - 9; i++)
					{
						if (array[i].Length >= 2)
						{
							this.console.Print(core.C_WARNING, array[i]);
						}
					}
					core.FailedCompiles++;
				}
				else if (array[array.Length - 2].Contains("Done"))
				{
					this.console.Print(core.C_DEFAULT, "     Compile: ");
					this.console.Print(Color.DarkGreen, "success\n");
					core.ValidCompiles++;
					if (plugin.CommitAfterCompile)
					{
						if (plugin.Commit())
						{
							this.console.Print(core.C_DEFAULT, "     Update: ");
							this.console.Print(Color.DarkGreen, "success\n");
						}
						else
						{
							this.console.Print(core.C_DEFAULT, "     Update: ");
							this.console.Print(Color.Red, "failure\n");
						}
					}
				}
				else
				{
					this.console.Print(core.C_ERROR, "GOD SEEMS TO HATE YA ^^\n");
					core.FailedCompiles++;
				}
				this.statusBar.Value++;
				TimeSpan t = this.process.ExitTime - this.process.StartTime;
				core.Duration += t;
				this.console.Print(core.C_COMPILE, "     Time: " + t.TotalSeconds + " Seconds\n\n");
				if (this.pluginQueue.Count > 0)
				{
					this.CompilePlugin(this.pluginQueue.Peek());
				}
				else
				{
					this.console.Print(Color.Red, " << ");
					this.console.Print(core.C_DEFAULT, "Summary");
					this.console.Print(Color.Red, " >>\n");
					this.console.Print(core.C_DEFAULT, "     Success: ");
					this.console.Print((core.ValidCompiles == 0) ? core.C_DEFAULT : Color.DarkGreen, core.ValidCompiles + "\n");
					this.console.Print(core.C_DEFAULT, "     Failure: ");
					this.console.Print((core.FailedCompiles == 0) ? core.C_DEFAULT : Color.DarkRed, core.FailedCompiles + "\n");
					this.console.Print(core.C_DEFAULT, "     Time: ");
					this.console.Print(Color.DarkRed, core.Duration.TotalSeconds.ToString());
					this.console.Print(core.C_DEFAULT, " Seconds\n");
					this.toolStripButtonPluginAbort.Enabled = false;
					this.toolStripButtonPluginInit.Enabled = true;
					this.toolStripButtonRefresh.Enabled = true;
					this.txtFilter.Enabled = true;
					this.toolStripButtonCreateCX.Enabled = true;
				}
			}
		}

		private void CompilePlugin(Plugin plugin)
		{
			this.process.StartInfo.WorkingDirectory = Application.StartupPath + "\\" + plugin.Folder;
			string text = plugin.FileWithExt + " ";
			text += " -i../.Nexus/include/amxx/ ";
			text = text + " -o\"" + plugin.Name + "\".amxx ";
			text = text + " -D\"" + plugin.Name + "\"";
			this.process.StartInfo.Arguments = text;
			this.console.Print(core.C_DEFAULT, " << ");
			this.console.Print(core.C_NAME, plugin.Text);
			this.console.Print(core.C_DEFAULT, " >>\n");
			this.WriteReVision(plugin);
			if (!this.process.Start())
			{
			}
		}

		private void WriteReVision(Plugin plugin)
		{
			string text = Application.StartupPath + "\\" + plugin.Folder + "\\.svn\\entries";
			if (!File.Exists(text))
			{
				text = Application.StartupPath + "\\" + plugin.Folder + "\\_svn\\entries";
				if (!File.Exists(text))
				{
					return;
				}
			}
			StreamReader streamReader = new StreamReader(text);
			string input = streamReader.ReadToEnd();
			streamReader.Close();
			Regex regex = new Regex("\\n");
			string[] array = regex.Split(input);
			if (array.GetLength(0) >= 13)
			{
				string text2 = array[10];
				string text3 = array[11];
				this.console.Print(core.C_DEFAULT, string.Concat(new string[]
				{
					"    ReVision > ",
					text2,
					" > ",
					text3,
					"\n"
				}));
				text = Application.StartupPath + "\\" + plugin.Folder + "\\ReVision.tmp";
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				using (StreamWriter streamWriter = new StreamWriter(text))
				{
					FileInfo fileInfo = new FileInfo(text);
					fileInfo.Attributes = (FileAttributes.Hidden | FileAttributes.Temporary);
					streamWriter.Write("#define REVISION_ID " + text2 + "\n");
					streamWriter.Write("#define REVISION_AUTHOR \"" + text3 + "\"\n");
					streamWriter.Write(string.Concat(new object[]
					{
						"#define COMPILE_DATE \"",
						DateTime.Now.Day,
						".",
						DateTime.Now.Month,
						".",
						DateTime.Now.Year,
						"\"\n"
					}));
					streamWriter.Write(string.Concat(new object[]
					{
						"#define COMPILE_TIME \"",
						DateTime.Now.Hour,
						":",
						DateTime.Now.Minute,
						":",
						DateTime.Now.Second,
						"\"\n"
					}));
				}
			}
		}

		private void Reset()
		{
			core.ValidCompiles = 0;
			core.FailedCompiles = 0;
			core.Duration = TimeSpan.Zero;
			this.console.Clear();
			this.pluginQueue.Clear();
			this.statusBar.Value = 0;
			this.toolStripButtonPluginAbort.Enabled = false;
			this.toolStripButtonPluginInit.Enabled = true;
			this.txtFilter.Enabled = true;
			this.toolStripButtonCreateCX.Enabled = true;
		}

		private void allToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			foreach (Plugin plugin in this.plugins.Items)
			{
				plugin.Checked = true;
			}
		}

		private void noneToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			foreach (Plugin plugin in this.plugins.Items)
			{
				plugin.Checked = false;
			}
		}

		private void toolStripButtonPluginInit_Click(object sender, EventArgs e)
		{
			this.Reset();
			if (this.plugins.CheckedItems.Count > 0)
			{
				foreach (Plugin plugin in this.plugins.CheckedItems)
				{
					plugin.CommitAfterCompile = this.toolStripButtonCommit.Checked;
					this.pluginQueue.Enqueue(plugin);
				}
				this.statusBar.Value = 0;
				this.statusBar.Maximum = this.pluginQueue.Count;
				this.toolStripButtonPluginAbort.Enabled = true;
				this.toolStripButtonPluginInit.Enabled = false;
				this.toolStripButtonRefresh.Enabled = false;
				this.txtFilter.Enabled = false;
				this.toolStripButtonCreateCX.Enabled = false;
				this.CompilePlugin(this.pluginQueue.Peek());
			}
		}

		private void toolStripButtonPluginAbort_Click(object sender, EventArgs e)
		{
			if (!this.process.HasExited)
			{
				this.process.Kill();
			}
			this.pluginQueue.Clear();
            this.console.Print(Color.Red, "\n TERMINATED ^^");
			this.toolStripButtonPluginAbort.Enabled = false;
			this.toolStripButtonPluginInit.Enabled = true;
			this.toolStripButtonRefresh.Enabled = true;
			this.txtFilter.Enabled = true;
			this.toolStripButtonCreateCX.Enabled = true;
		}

		private void plugins_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == this.pluginsSort.SortColumn)
			{
				if (this.pluginsSort.Order == SortOrder.Ascending)
				{
					this.pluginsSort.Order = SortOrder.Descending;
				}
				else
				{
					this.pluginsSort.Order = SortOrder.Ascending;
				}
			}
			else
			{
				this.pluginsSort.SortColumn = e.Column;
				this.pluginsSort.Order = SortOrder.Ascending;
			}
			this.plugins.Sort();
		}

		private void toolStripButtonCreateCX_Click(object sender, EventArgs e)
		{
			ClassWizard classWizard = new ClassWizard();
			try
			{
				classWizard.ShowDialog(this);
				this.LoadPlugins(true);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not create the new ECX", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				MessageBox.Show(string.Concat(new object[]
				{
					"Message: ",
					ex.Message,
					"\r\nInternal Exception: ",
					ex.InnerException
				}));
				try
				{
					Directory.Delete(Application.StartupPath + "\\" + classWizard.classPanel.txtName);
				}
				catch
				{
				}
			}
		}

		private void toolStripButtonClipboard_Click(object sender, EventArgs e)
		{
			string text = "";
			foreach (Plugin plugin in this.plugins.Items)
			{
				if (plugin.Checked)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						plugin.Prefix,
						(plugin.Prefix.Length < 1) ? "" : ".",
						plugin.Name.Replace(".sma", "").Replace(".core", ""),
						".amxx\r\n"
					});
				}
			}
			if (text.Length > 2)
			{
				Clipboard.SetDataObject(text.Remove(text.Length - 2), true);
			}
		}

		private void toolStripButtonAbout_Click(object sender, EventArgs e)
		{
			about about = new about();
			about.ShowDialog(this);
		}

		private void toolStripLabelCR_Click(object sender, EventArgs e)
		{
			Process.Start("http://corona-bytes.net");
		}

		private void toolStripButtonRefresh_Click(object sender, EventArgs e)
		{
			this.LoadPlugins(true);
		}

		private void plugins_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Right)
				{
					Plugin plugin = (Plugin)this.plugins.SelectedItems[0];
					switch (plugin.Style)
					{
					case PluginStyle.Core:
						Process.Start(Application.StartupPath + "\\" + plugin.Folder);
						break;
					case PluginStyle.Plugin:
						Process.Start(string.Concat(new string[]
						{
							Application.StartupPath,
							"\\",
							plugin.Folder,
							"\\",
							plugin.FileWithExt
						}));
						break;
					case PluginStyle.Extension:
						Process.Start(string.Concat(new string[]
						{
							Application.StartupPath,
							"\\",
							plugin.Folder,
							"\\",
							plugin.FileWithExt
						}));
						break;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
			this.LoadPlugins(true);
		}
	}
}
