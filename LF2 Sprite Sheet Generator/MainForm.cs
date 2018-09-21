using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LF2.Sprite_Sheet_Generator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			Application.ThreadException += Application_ThreadException;
		}

		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
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

		public Control GetMostInnerActiveControl()
		{
			Control c = this.ActiveControl;
			while (c is ContainerControl)
				c = ((ContainerControl)c).ActiveControl;
			return c;
		}

		protected override bool ProcessCmdKey(ref Message message, Keys keys)
		{
			if (keys == (Keys.D | Keys.Control))
			{
				templateBox.DuplicateSelection();
			}
			if (GetMostInnerActiveControl() != textBox_RenderSymbol)
			{
				switch (keys)
				{
					case Keys.G:
						templateBox.EditMode = EditMode.Move;
						return true;
					case Keys.R:
						templateBox.EditMode = EditMode.Rotate;
						return true;
					case Keys.S:
						templateBox.EditMode = EditMode.Scale;
						return true;
					case Keys.Delete:
						templateBox.DeleteSelection();
						return true;
				}
			}
			return base.ProcessCmdKey(ref message, keys);
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
		}

		private void toolStripButton_Rotate_Click(object sender, EventArgs e)
		{
			templateBox.EditMode = EditMode.Rotate;
		}

		private void toolStripButton_Scale_Click(object sender, EventArgs e)
		{
			templateBox.EditMode = EditMode.Scale;
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

		private void toolStripButton_Scale4_Click(object sender, EventArgs e)
		{
			templateBox.Zoom = 4;
		}

		public void AdjustGuideImage(Image guide)
		{
			templateBox.GuideImage = guide;
			templateBox.ScaleFit();
		}

		private void toolStripSplitButton_GuideImage_Click(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog_Image.FileName))
				AdjustGuideImage(Image.FromFile(openFileDialog_Image.FileName));
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
			toolStripStatusLabel_Zoom.Text = templateBox.Zoom.ToString("0.##");
		}

		private void templateBox_OffsetChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel_Offset.Text = templateBox.Offset.X.ToString("0.##") + " , " + templateBox.Offset.Y.ToString("0.##");
			statusStrip.Refresh();
		}

		string[] imageFilter = { ".bmp", ".dib", ".png", ".jpg", ".jpeg", ".jpe", ".jfif", ".gif", ".emf", ".tif", ".tiff", ".wmf" };

		public void AddSprite(string file)
		{
			try
			{
				if (imageFilter.Any((ext) => file.EndsWith(ext)))
				{
					string name = GetUniqueSpriteName(Path.GetFileNameWithoutExtension(file));
					Image img = Image.FromFile(file);

					listBox_SpriteParts.Items.Add(name);
					templateBox.Sprites.Add(name, img);
				}
			}
			catch (Exception ex)
			{
				ShowException(ex, "Error Importing Sprite: '" + file + '\'', this);
			}
		}

		public void AddSprites(string[] files)
		{
			foreach (string file in files)
				AddSprite(file);
			templateBox.Invalidate();
		}

		public string GetUniqueSpriteName(string name)
		{
			if (!templateBox.Sprites.ContainsKey(name))
				return name;
			else
			{
				int i;
				for (i = 2; templateBox.Sprites.ContainsKey(name + '_' + i); i++) ;
				return name + '_' + i;
			}
		}

		private void button_AddSprite_Click(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog(this) == DialogResult.OK)
			{
				AddSprites(openFileDialog_Image.FileNames);
			}
		}
		
		private void button_RemoveSprite_Click(object sender, EventArgs e)
		{
			if (listBox_SpriteParts.SelectedIndex >= 0)
			{
				var index = listBox_SpriteParts.SelectedIndex;
				templateBox.Sprites.Remove(listBox_SpriteParts.SelectedItem as string);
				listBox_SpriteParts.Items.RemoveAt(listBox_SpriteParts.SelectedIndex);
				if (listBox_SpriteParts.Items.Count > 0)
					listBox_SpriteParts.SelectedIndex = index.Clamp(0, listBox_SpriteParts.Items.Count - 1);
				templateBox.Invalidate();
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
				listBox_SpriteParts.SelectedItem = newName;
				templateBox.Invalidate();
			}
		}

		private void AddRender()
		{
			if (listBox_SpriteParts.SelectedIndex >= 0)
			{
				templateBox.AddRender(
					(string)listBox_SpriteParts.SelectedItem,
					new Transform() { Location = templateBox.Offset, Scale = 1, Rotation = 0 }
				);
				templateBox.Refresh();
			}
		}

		private void listBox_SpriteParts_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			
		}

		private void listBox_SpriteParts_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		private void listBox_SpriteParts_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			AddSprites(files);
		}

		private void templateBox_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		private void templateBox_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			string selected;
			if ((selected = files.FirstOrDefault((file) => imageFilter.Any((ext) => file.EndsWith(ext)))) != null)
			{
				var img = templateBox.GuideImage;
				templateBox.GuideImage = null;
				img.Dispose();
				templateBox.GuideImage = Image.FromFile(selected);
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void templateBox_EditModeChanged(object sender, EventArgs e)
		{
			switch (templateBox.EditMode)
			{
				case EditMode.Move:
					toolStripButton_Move.Checked = true;
					toolStripButton_Rotate.Checked = false;
					toolStripButton_Scale.Checked = false;
					break;
				case EditMode.Rotate:
					toolStripButton_Move.Checked = false;
					toolStripButton_Rotate.Checked = true;
					toolStripButton_Scale.Checked = false;
					break;
				case EditMode.Scale:
					toolStripButton_Move.Checked = false;
					toolStripButton_Rotate.Checked = false;
					toolStripButton_Scale.Checked = true;
					break;
			}
		}

		private void betterToolStripButton_BringToFront_Click(object sender, EventArgs e)
		{
			templateBox.BringSelectionToFront();
		}

		private void betterToolStripButton_SendToBack_Click(object sender, EventArgs e)
		{
			templateBox.SendSelectionToBack();
		}

		static int editingTransform = 0;
		public bool Editing { get { return editingTransform > 0; } }
		// This kinda ugly hack but works
		class EditingScope : IDisposable
		{
			public EditingScope()
			{
				editingTransform++;
			}

			private bool disposed = false; // To detect redundant calls

			protected virtual void Dispose(bool disposing)
			{
				if (!disposed)
				{
					if (disposing)
					{
						// TODO: dispose managed state (managed objects).
					}

					editingTransform--;
					// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
					// TODO: set large fields to null.

					disposed = true;
				}
			}

			// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
			// ~EditingTrap() {
			//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			//   Dispose(false);
			// }

			// This code added to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
				Dispose(true);
				// TODO: uncomment the following line if the finalizer is overridden above.
				// GC.SuppressFinalize(this);
			}
		}

		private void templateBox_SelectionChanged(object sender, EventArgs e)
		{
			int[] indices = templateBox.SelectedRenders.ToArray();
			Array.Sort(indices);
			if (indices.Length == 0)
			{
				groupBox_Object.Text = "None";
				using (var trap = new EditingScope())
				{
					textBox_ObjectPosition.Clear();
					textBox_ObjectRotation.Clear();
					textBox_ObjectScale.Clear();
				}
			}
			else if (indices.Length == 1)
			{
				var render = templateBox.Renders[indices[0]];
				groupBox_Object.Text = render.spriteName;
				using (var trap = new EditingScope())
				{
					textBox_RenderSymbol.Text = render.symbolName;
					textBox_RenderPosition.Text = render.transform.X.ToString("0.##") + " , " + render.transform.Y.ToString("0.##");
					textBox_RenderRotation.Text = render.transform.Rotation.ToString("0.####");
					textBox_RenderScale.Text = render.transform.Scale.ToString("0.####");
				}
			}
			else if (indices.Length > 1)
			{
				groupBox_Object.Text = '(' + indices.Length.ToString() + ") Objects";
				bool pos = true, rot = true, sca = true;
				Transform transform = templateBox.Renders[indices[0]].transform;
				for (int i = 1; i < indices.Length && (pos || rot || sca); i++)
				{
					if (templateBox.Renders[indices[i]].transform.Location != transform.Location)
						pos = false;
					if (templateBox.Renders[indices[i]].transform.Rotation != transform.Rotation)
						rot = false;
					if (templateBox.Renders[indices[i]].transform.Scale != transform.Scale)
						sca = false;
				}
				using (var trap = new EditingScope())
				{
					if (pos)
						textBox_RenderPosition.Text = transform.X.ToString("0.##") + " , " + transform.Y.ToString("0.##");
					else
						textBox_ObjectPosition.Clear();
					if (rot)
						textBox_ObjectRotation.Text = transform.Rotation.ToString("F2");
					else
						textBox_ObjectRotation.Clear();
					if (sca)
						textBox_ObjectScale.Text = transform.Scale.ToString("F2");
					else
						textBox_ObjectScale.Clear();
				}
			}
			textBox_ObjectPosition.Refresh();
			textBox_ObjectRotation.Refresh();
			textBox_ObjectScale.Refresh();
		}

		private void textBox_ObjectPosition_TextChanged(object sender, EventArgs e)
		{
			if (Editing)
				return;
			float x, y;
			string[] parts = textBox_ObjectPosition.Text.Split(',');
			if (parts.Length != 2
				|| !float.TryParse(parts[0].Trim(), out x)
				|| !float.TryParse(parts[1].Trim(), out y))
				return;
			foreach (int index in templateBox.SelectedRenders)
			{
				templateBox.Renders[index].transform.Location = new PointF(x, y);
			}
			templateBox.Invalidate();
		}

		private void textBox_ObjectRotation_TextChanged(object sender, EventArgs e)
		{
			if (Editing)
				return;
			float r;
			if (!float.TryParse(textBox_ObjectRotation.Text.Trim(), out r))
				return;
			foreach (int index in templateBox.SelectedRenders)
			{
				templateBox.Renders[index].transform.Location = templateBox.Renders[index].transform.Location.RotateRelativeTo(templateBox.GetMidPointOfSelection(), r);
				templateBox.Renders[index].transform.Rotation = r;
			}
			templateBox.Invalidate();
		}

		private void textBox_ObjectScale_TextChanged(object sender, EventArgs e)
		{
			if (Editing)
				return;
			float s;
			if (!float.TryParse(textBox_ObjectScale.Text.Trim(), out s))
				return;
			foreach (int index in templateBox.SelectedRenders)
			{
				templateBox.Renders[index].transform.Location = templateBox.Renders[index].transform.Location.ScaleRelativeTo(templateBox.GetMidPointOfSelection(), s);
				templateBox.Renders[index].transform.Scale = s;
			}
			templateBox.Invalidate();
		}

		private void listBox_SpriteParts_DoubleClick(object sender, EventArgs e)
		{
			AddRender();
		}

		private void button_Delete_Click(object sender, EventArgs e)
		{
			templateBox.DeleteSelection();
		}
		
		private void trackBar_AlphaCut_Scroll(object sender, EventArgs e)
		{
			label_AlphaCut.Text = trackBar_AlphaCut.Value.ToString();
			label_AlphaCut.Refresh();
		}

		private void trackBar_Transparency_Scroll(object sender, EventArgs e)
		{
			label_Transparency.Text = trackBar_Transparency.Value.ToString();
			label_Transparency.Refresh();
		}

		private void button_LoadTemplate_Click(object sender, EventArgs e)
		{
			if (openFileDialog_Template.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					using (FileStream settings = new FileStream(openFileDialog_Template.FileName, FileMode.Open, FileAccess.Read))
					{
						XmlSerializer xs = new XmlSerializer(typeof(Render[]));
						templateBox.LoadTemplate((Render[])xs.Deserialize(settings));
					}
				}
				catch (Exception ex)
				{
					ShowException(ex, "Error Loading Template: '" + openFileDialog_Template.FileName + '\'', this);
				}
			}
		}

		private void button_SaveTemplate_Click(object sender, EventArgs e)
		{
			if (saveFileDialog_Template.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					using (FileStream fs = new FileStream(saveFileDialog_Template.FileName, FileMode.Create, FileAccess.Write))
					{
						XmlSerializer xs = new XmlSerializer(typeof(Render[]));
						xs.Serialize(fs, templateBox.Renders.ToArray());
					}
				}
				catch (Exception ex)
				{
					ShowException(ex, "Error Saving Template: '" + saveFileDialog_Template.FileName + '\'', this);
				}
			}
		}

		private void button_PreviewSprite_Click(object sender, EventArgs e)
		{
			using (Form_Preview fp = new Form_Preview(templateBox
					.RenderFinalImage(trackBar_AlphaCut.Value, trackBar_Transparency.Value, checkBox_RenderGuide.Checked, checkBox_AlphaChannel.Checked)))
			{
				fp.ShowDialog(this);
			}
		}

		private void button_SaveSprite_Click(object sender, EventArgs e)
		{
			if (saveFileDialog_Sprite.ShowDialog(this) == DialogResult.OK)
			{
				templateBox
					.RenderFinalImage(trackBar_AlphaCut.Value, trackBar_Transparency.Value, checkBox_RenderGuide.Checked, checkBox_AlphaChannel.Checked)
					.Save(saveFileDialog_Sprite.FileName, ImageFormat.Bmp);
			}
		}

		private void toolStripMenuItem_CreateEmptyGrid_Click(object sender, EventArgs e)
		{
			using (Form_CreateGrid fcg = new Form_CreateGrid())
			{
				if (fcg.ShowDialog(this) == DialogResult.OK)
				{
					templateBox.GuideImage = fcg.grid;
				}
			}
		}
	}
}
