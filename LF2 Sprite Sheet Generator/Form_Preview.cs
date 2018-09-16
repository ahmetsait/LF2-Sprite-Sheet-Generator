using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LF2.Sprite_Sheet_Generator
{
	public partial class Form_Preview : Form
	{
		public Form_Preview(Image image)
		{
			InitializeComponent();
			this.templateBox.GuideImage = image;
			var desktop = Screen.PrimaryScreen.WorkingArea.Size;
			this.ClientSize = image.Size;
			if (this.Width > desktop.Width)
				this.Width = desktop.Width;
			if (this.Height > desktop.Height)
				this.Height = desktop.Height;
			templateBox.Offset = new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
			templateBox.Zoom = 1;
		}
		
		private void Form_Preview_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Close();
		}

		private void templateBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				templateBox.GuideTransparency = !templateBox.GuideTransparency;
			else if (e.Button == MouseButtons.Right)
				templateBox.Zoom = 1;
		}
	}
}
