using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace LF2.Sprite_Sheet_Generator
{
	public class BetterToolStripMenuItem : ToolStripMenuItem
	{
		InterpolationMode interpolation;
		[DefaultValue(InterpolationMode.Default)]
		public InterpolationMode Interpolation
		{
			get { return interpolation; }
			set
			{
				InterpolationMode old = interpolation;
				interpolation = value;
				base.Invalidate();

				if (old != value && InterpolationChanged != null)
				{
					InterpolationChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler InterpolationChanged;
		
		[EditorBrowsable]
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = interpolation;
			base.OnPaint(e);
		}
	}
}
