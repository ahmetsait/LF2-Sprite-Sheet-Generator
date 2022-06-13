using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LF2.Sprite_Sheet_Generator
{
	public partial class Form_CreateGrid : Form
	{
		public Form_CreateGrid()
		{
			InitializeComponent();
		}

		public Bitmap grid = null;

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void button_Create_Click(object sender, EventArgs e)
		{
			int w, h, row, col;
			if (int.TryParse(textBox_Width.Text, out w) &&
				int.TryParse(textBox_Height.Text, out h) &&
				int.TryParse(textBox_Row.Text, out row) &&
				int.TryParse(textBox_Column.Text, out col))
			{
				Bitmap result = new Bitmap((w + 1) * col, (h + 1) * row, PixelFormat.Format24bppRgb);
				using (Graphics g = Graphics.FromImage(result))
				{
					g.Clear(Color.Black);
					for (int i = 0; i < col; i++)
					{
						int x = (w + 1) * (i + 1) - 1;
						g.DrawLine(Pens.LimeGreen, x, 0, x, result.Height);
					}
					for (int i = 0; i < row; i++)
					{
						int y = (h + 1) * (i + 1) - 1;
						g.DrawLine(Pens.LimeGreen, 0, y, result.Width, y);
					}
				}
				grid = result;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
