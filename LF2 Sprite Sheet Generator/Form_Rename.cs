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
	public partial class Form_Rename : Form
	{
		public Form_Rename(string oldName)
		{
			InitializeComponent();
			textBox.Text = old = oldName;
		}

		private readonly string old;

		private void Form_Rename_Shown(object sender, EventArgs e)
		{
			textBox.SelectAll();
			textBox.Select();
		}
		
		private void button_Ok_Click(object sender, EventArgs e)
		{
			if (textBox.Text != old && !string.IsNullOrWhiteSpace(textBox.Text))
				this.DialogResult = DialogResult.OK;
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
