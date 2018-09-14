using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LF2.Sprite_Sheet_Generator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			splitContainer.SplitterDistance = 800;
			Application.ThreadException += Application_ThreadException;
		}

		private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			ShowException(e.Exception);
		}

		float[] opacityList = { 0f, 0.10f, 0.25f, 0.50f, 0.75f, 0.90f, 1.00f };

		private void MainForm_Load(object sender, EventArgs e)
		{
			toolStripComboBox_Opacity.SelectedIndex = 3;
			templateBox.ScaleFit();
			templateBox_OffsetChanged(templateBox, e);
		}
		
		public void ShowException(Exception ex, string title = null, IWin32Window owner = null)
		{
			MessageBox.Show(owner ?? this, ex.ToString(), title ?? "Unhandled Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm about = new AboutForm();
			about.ShowDialog(this);
		}

		private void toolStripButton_Transparency_CheckedChanged(object sender, EventArgs e)
		{
			templateBox.GuideTransparency = toolStripButton_Transparency.Checked;
		}

		private void toolStripMenuItem_ChessBoard_Click(object sender, EventArgs e)
		{
			templateBox.BackgroundImage = Properties.Resources.check;
			toolStripMenuItem_ChessBoard.Checked = true;
			toolStripMenuItem_Color.Checked = false;
		}

		private void toolStripMenuItem_Color_Click(object sender, EventArgs e)
		{
			templateBox.BackgroundImage = null;
			toolStripMenuItem_Color.Checked = true;
			toolStripMenuItem_ChessBoard.Checked = false;
		}

		private void toolStripMenuItem_AdjustColor_Click(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				templateBox.BackColor = colorDialog.Color;
				templateBox.BackgroundImage = null;
				toolStripMenuItem_Color.Checked = true;
				toolStripMenuItem_ChessBoard.Checked = false;
				using (Graphics g = Graphics.FromImage(toolStripMenuItem_Color.Image))
					g.Clear(templateBox.BackColor);
				toolStripMenuItem_Color.Invalidate();
			}
		}
		
		private void toolStripButton_Move_Click(object sender, EventArgs e)
		{
			templateBox.EditMode = EditMode.Move;
			toolStripButton_Move.Checked = true;
			toolStripButton_Rotate.Checked = false;
			toolStripButton_Sclale.Checked = false;
		}

		private void toolStripButton_Rotate_Click(object sender, EventArgs e)
		{
			templateBox.EditMode = EditMode.Rotate;
			toolStripButton_Move.Checked = false;
			toolStripButton_Rotate.Checked = true;
			toolStripButton_Sclale.Checked = false;
		}

		private void toolStripButton_Sclale_Click(object sender, EventArgs e)
		{
			templateBox.EditMode = EditMode.Scale;
			toolStripButton_Move.Checked = false;
			toolStripButton_Rotate.Checked = false;
			toolStripButton_Sclale.Checked = true;
		}

		private void toolStripButton_ScaleFit_Click(object sender, EventArgs e)
		{
			templateBox.ScaleFit();
		}

		private void toolStripButton_Scale1_Click(object sender, EventArgs e)
		{
			templateBox.Zoom = 1;
		}

		private void toolStripButton_Scale2_Click(object sender, EventArgs e)
		{
			templateBox.Zoom = 2;
		}

		private void toolStripSplitButton_GuideImage_Click(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog_Image.FileName))
			{
				templateBox.GuideImage = Image.FromFile(openFileDialog_Image.FileName);
				templateBox.ScaleFit();
			}
		}

		private void toolStripComboBox_Opacity_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (toolStripComboBox_Opacity.SelectedIndex >= 0)
			{
				templateBox.GuideImageAlpha = opacityList[toolStripComboBox_Opacity.SelectedIndex];
			}
		}

		private void templateBox_ZoomChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel_Zoom.Text = templateBox.Zoom.ToString("F2");
		}

		private void templateBox_OffsetChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel_Offset.Text = templateBox.Offset.X.ToString("F2") + ", " + templateBox.Offset.Y.ToString("F2");
			statusStrip.Refresh();
		}

		private void button_AddSprite_Click(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					foreach (string file in openFileDialog_Image.FileNames)
					{
						string name = Path.GetFileNameWithoutExtension(file);
						Image img = Image.FromFile(file);

						for (Form_Rename fr = new Form_Rename(name); templateBox.Sprites.ContainsKey(name); )
						{
							if (fr.ShowDialog(this) == DialogResult.OK)
								name = fr.textBox.Text.Trim();
						}
						listBox_SpriteParts.Items.Add(name);
						templateBox.Sprites.Add(name, img);
					}
				}
				catch (Exception ex)
				{
					ShowException(ex, "Error Importing Sprites", this);
				}
			}
		}
		
		private void button_RemoveSprite_Click(object sender, EventArgs e)
		{
			if (listBox_SpriteParts.SelectedIndex >= 0)
			{
				templateBox.Sprites.Remove(listBox_SpriteParts.SelectedItem as string);
				listBox_SpriteParts.Items.RemoveAt(listBox_SpriteParts.SelectedIndex);
			}
		}

		private void button_MoveUp_Click(object sender, EventArgs e)
		{
			if (listBox_SpriteParts.SelectedIndex >= 0)
			{
				int index = listBox_SpriteParts.SelectedIndex, newIndex = (index - 1).Clamp(0, listBox_SpriteParts.Items.Count - 1);
				object item = listBox_SpriteParts.SelectedItem;
				if (newIndex != index)
				{
					var temp = listBox_SpriteParts.Items[newIndex];
					listBox_SpriteParts.Items[newIndex] = listBox_SpriteParts.Items[index];
					listBox_SpriteParts.Items[index] = temp;
					listBox_SpriteParts.SelectedIndex = newIndex;
					listBox_SpriteParts.Refresh();
				}
			}
		}

		private void button_MoveDown_Click(object sender, EventArgs e)
		{
			if (listBox_SpriteParts.SelectedIndex >= 0)
			{
				int index = listBox_SpriteParts.SelectedIndex, newIndex = (index + 1).Clamp(0, listBox_SpriteParts.Items.Count - 1);
				object item = listBox_SpriteParts.SelectedItem;
				if (newIndex != index)
				{
					var temp = listBox_SpriteParts.Items[newIndex];
					listBox_SpriteParts.Items[newIndex] = listBox_SpriteParts.Items[index];
					listBox_SpriteParts.Items[index] = temp;
					listBox_SpriteParts.SelectedIndex = newIndex;
					listBox_SpriteParts.Refresh();
				}
			}
		}

		private void listBox_SpriteParts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox_SpriteParts.SelectedIndex >= 0)
			{
				drawBox_SpritePart.Image = templateBox.Sprites[listBox_SpriteParts.SelectedItem as string];
				drawBox_SpritePart.Refresh();
			}
		}

		private void checkBox_SpritePartsTransparency_CheckedChanged(object sender, EventArgs e)
		{
			templateBox.Transparency = drawBox_SpritePart.Trancparency = checkBox_SpritePartsTransparency.Checked;
		}

		private void button_Rename_Click(object sender, EventArgs e)
		{
			if (listBox_SpriteParts.SelectedIndex >= 0)
			{
				string name = (string)listBox_SpriteParts.SelectedItem, newName;
				Form_Rename fr = new Form_Rename(name);
				do
				{
					if (fr.ShowDialog(this) == DialogResult.OK)
						newName = fr.textBox.Text.Trim();
					else
						return;
				}
				while (templateBox.Sprites.ContainsKey(newName));
				templateBox.Sprites[newName] = templateBox.Sprites[name];
				templateBox.Sprites.Remove(name);
			}
		}

		private void listBox_SpriteParts_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listBox_SpriteParts.SelectedIndex >= 0)
			{
				templateBox.Renders.Add(new Render(
					(string)listBox_SpriteParts.SelectedItem,
					new Transform() { Position = templateBox.Offset, Scale = 1, Rotation = 0 }
				));
			}
		}
	}
}
