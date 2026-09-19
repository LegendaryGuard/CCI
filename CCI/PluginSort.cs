using System;
using System.Collections;
using System.Windows.Forms;

namespace CCI
{
	internal class PluginSort : IComparer
	{
		private int ColumnToSort;

		private SortOrder OrderOfSort;

		private CaseInsensitiveComparer ObjectCompare;

		public int SortColumn
		{
			get
			{
				return this.ColumnToSort;
			}
			set
			{
				this.ColumnToSort = value;
			}
		}

		public SortOrder Order
		{
			get
			{
				return this.OrderOfSort;
			}
			set
			{
				this.OrderOfSort = value;
			}
		}

		public PluginSort()
		{
			this.ColumnToSort = 0;
			this.OrderOfSort = SortOrder.Ascending;
			this.ObjectCompare = new CaseInsensitiveComparer();
		}

		public int Compare(object x, object y)
		{
			ListViewItem listViewItem = (ListViewItem)x;
			ListViewItem listViewItem2 = (ListViewItem)y;
			int num = this.ObjectCompare.Compare(listViewItem.SubItems[this.ColumnToSort].Text, listViewItem2.SubItems[this.ColumnToSort].Text);
			Plugin plugin = x as Plugin;
			Plugin plugin2 = y as Plugin;
			int result;
			if (this.OrderOfSort == SortOrder.Ascending && plugin.Prefix == plugin2.Prefix)
			{
				result = num;
			}
			else if (this.OrderOfSort == SortOrder.Descending && plugin.Prefix == plugin2.Prefix)
			{
				result = -num;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}
}
