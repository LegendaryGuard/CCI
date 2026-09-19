using System;
using System.Drawing;

namespace CCI
{
	public class RGB
	{
		public byte r;

		public byte g;

		public byte b;

		public Color Color
		{
			get
			{
				return Color.FromArgb((int)this.r, (int)this.g, (int)this.b);
			}
		}

		public RGB()
		{
		}

		public RGB(Color c)
		{
			this.r = c.R;
			this.g = c.G;
			this.b = c.B;
		}
	}
}
