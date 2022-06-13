using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

using OpenTK;
using Gr = OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using NX;
using NX.Graphics;

namespace LF2.Sprite_Sheet_Generator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			// HACK: Visual Studio violently crashes when GLControl is used inside designer
			this.templateBox = new LF2.Sprite_Sheet_Generator.TemplateBox();
			this.splitContainer.Panel1.Controls.Add(this.templateBox);
			this.templateBox.Name = nameof(templateBox);
			this.templateBox.AllowDrop = true;
			this.templateBox.BackColor = System.Drawing.Color.Black;
			this.templateBox.BackgroundChessBoard = true;
			this.templateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateBox.GuideImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.dev_temp;
			this.templateBox.Location = new System.Drawing.Point(0, 0);
			this.templateBox.MissingImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.broken_img;
			this.templateBox.ShowCoordinateSystem = true;
			this.templateBox.TabIndex = 0;
			this.templateBox.SelectionChanged += new System.EventHandler(this.templateBox_SelectionChanged);
			this.templateBox.EditModeChanged += new System.EventHandler(this.templateBox_EditModeChanged);
			this.templateBox.ZoomChanged += new System.EventHandler(this.templateBox_ZoomChanged);
			this.templateBox.OffsetChanged += new System.EventHandler(this.templateBox_OffsetChanged);
			this.templateBox.TransformEdit += new System.EventHandler(this.templateBox_SelectionChanged);
			this.templateBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.templateBox_DragDrop);
			this.templateBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.templateBox_DragEnter);

			foreach (float opacity in opacityList)
				toolStripComboBox_Opacity.Items.Add(opacity * 100 + "%");
			toolStripComboBox_Opacity.SelectedIndex = 2;

			Application.ThreadException += Application_ThreadException;
		}

		private TemplateBox templateBox;

		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			ShowException(e.Exception);
		}

		float[] opacityList = { 1.00f, 0.90f, 0.75f, 0.50f, 0.25f, 0.10f, 0f };

		private void MainForm_Load(object sender, EventArgs e)
		{
			templateBox.ScaleFit();
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
			templateBox.BackgroundChessBoard = true;
			toolStripMenuItem_ChessBoard.Checked = true;
			toolStripMenuItem_Color.Checked = false;
		}

		private void toolStripMenuItem_Color_Click(object sender, EventArgs e)
		{
			templateBox.BackgroundChessBoard = false;
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

		public void AdjustGuideImage(Bitmap guide)
		{
			templateBox.GuideImage = guide;
			templateBox.ScaleFit();
		}

		private void toolStripMenuItem_LoadFromFile_Click(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog_Image.FileName))
				AdjustGuideImage(new Bitmap(openFileDialog_Image.FileName));
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
			toolStripStatusLabel_Zoom.Text = templateBox.Zoom.ToString("0.00");
		}

		private void templateBox_OffsetChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel_Offset.Text = templateBox.Offset.X.ToString("0.00") + " , " + templateBox.Offset.Y.ToString("0.00");
			statusStrip.Refresh();
		}

		string[] imageFilter = { ".bmp", ".dib", ".png", ".jpg", ".jpeg", ".jpe", ".jfif", ".gif", ".emf", ".tif", ".tiff", ".wmf" };

		public void AddSymbol(string file)
		{
			try
			{
				if (imageFilter.Any((ext) => file.EndsWith(ext)))
				{
					string name = GetUniqueSymbolName(Path.GetFileNameWithoutExtension(file));
					Bitmap img = new Bitmap(file);

					listBox_Symbols.Items.Add(name);
					templateBox.Sprites.Add(name, Tuple.Create(img, img.LoadTextureGL()));
				}
			}
			catch (Exception ex)
			{
				ShowException(ex, "Error Importing Sprite: '" + file + '\'', this);
			}
		}

		public void AddSymbols(string[] files)
		{
			foreach (string file in files)
				AddSymbol(file);
			templateBox.Invalidate();
		}

		public string GetUniqueSymbolName(string name)
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

		private void button_AddSymbol_Click(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog(this) == DialogResult.OK)
			{
				AddSymbols(openFileDialog_Image.FileNames);
			}
		}
		
		private void button_RemoveSymbol_Click(object sender, EventArgs e)
		{
			if (listBox_Symbols.SelectedIndex >= 0)
			{
				var index = listBox_Symbols.SelectedIndex;
				templateBox.Sprites.Remove(listBox_Symbols.SelectedItem as string);
				listBox_Symbols.Items.RemoveAt(listBox_Symbols.SelectedIndex);
				if (listBox_Symbols.Items.Count > 0)
					listBox_Symbols.SelectedIndex = index.Clamp(0, listBox_Symbols.Items.Count - 1);
				templateBox.Invalidate();
			}
		}

		private void button_MoveUp_Click(object sender, EventArgs e)
		{
			if (listBox_Symbols.SelectedIndex >= 0)
			{
				int index = listBox_Symbols.SelectedIndex, newIndex = (index - 1).Clamp(0, listBox_Symbols.Items.Count - 1);
				object item = listBox_Symbols.SelectedItem;
				if (newIndex != index)
				{
					var temp = listBox_Symbols.Items[newIndex];
					listBox_Symbols.Items[newIndex] = listBox_Symbols.Items[index];
					listBox_Symbols.Items[index] = temp;
					listBox_Symbols.SelectedIndex = newIndex;
					listBox_Symbols.Refresh();
				}
			}
		}

		private void button_MoveDown_Click(object sender, EventArgs e)
		{
			if (listBox_Symbols.SelectedIndex >= 0)
			{
				int index = listBox_Symbols.SelectedIndex, newIndex = (index + 1).Clamp(0, listBox_Symbols.Items.Count - 1);
				object item = listBox_Symbols.SelectedItem;
				if (newIndex != index)
				{
					var temp = listBox_Symbols.Items[newIndex];
					listBox_Symbols.Items[newIndex] = listBox_Symbols.Items[index];
					listBox_Symbols.Items[index] = temp;
					listBox_Symbols.SelectedIndex = newIndex;
					listBox_Symbols.Refresh();
				}
			}
		}

		private void listBox_Symbols_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox_Symbols.SelectedIndex >= 0)
			{
				drawBox_Symbol.Image = templateBox.Sprites[listBox_Symbols.SelectedItem as string].Item1;
				drawBox_Symbol.Refresh();
			}
		}

		private void checkBox_SymbolsTransparency_CheckedChanged(object sender, EventArgs e)
		{
			//templateBox.Transparency = drawBox_Symbol.Trancparency = checkBox_RenderTransparency.Checked;
		}

		private void button_RenameSymbol_Click(object sender, EventArgs e)
		{
			if (listBox_Symbols.SelectedIndex >= 0)
			{
				string name = (string)listBox_Symbols.SelectedItem, newName;
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
				listBox_Symbols.SelectedItem = newName;
				templateBox.Invalidate();
			}
		}

		private void AddRender()
		{
			if (listBox_Symbols.SelectedIndex >= 0)
			{
				templateBox.AddRender(
					(string)listBox_Symbols.SelectedItem,
					new Transform() { Location = templateBox.Offset, Scale = 1, Rotation = 0 }
				);
				templateBox.Refresh();
			}
		}

		private void listBox_Symbols_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		private void listBox_Symbols_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			AddSymbols(files);
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
				templateBox.GuideImage = new Bitmap(selected);
			}
			if ((selected = files.FirstOrDefault((file) => file.EndsWith(".xml"))) != null)
			{
				LoadTemplate(selected);
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

		private void toolStripButton_BringToFront_Click(object sender, EventArgs e)
		{
			templateBox.BringSelectionToFront();
		}

		private void toolStripButton_SendToBack_Click(object sender, EventArgs e)
		{
			templateBox.SendSelectionToBack();
		}

		static int editingTransform = 0;
		public bool Editing { get { return editingTransform > 0; } }
		// So much for a simple RAII
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
				groupBox_Render.Text = "Object";
				using (var trap = new EditingScope())
				{
					textBox_RenderSymbol.Clear();
					textBox_RenderPosition.Clear();
					textBox_RenderRotation.Clear();
					textBox_RenderScale.Clear();
				}
			}
			else if (indices.Length == 1)
			{
				groupBox_Render.Text = "Object";
				var render = templateBox.Renders[indices[0]];
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
				groupBox_Render.Text = '(' + indices.Length.ToString() + ") Objects";
				bool sym = true, pos = true, rot = true, sca = true;
				string symbolName = templateBox.Renders[indices[0]].symbolName;
				Transform transform = templateBox.Renders[indices[0]].transform;
				for (int i = 1; i < indices.Length && (sym || pos || rot || sca); i++)
				{
					if (templateBox.Renders[indices[i]].symbolName != symbolName)
						sym = false;
					if (templateBox.Renders[indices[i]].transform.Location != transform.Location)
						pos = false;
					if (templateBox.Renders[indices[i]].transform.Rotation != transform.Rotation)
						rot = false;
					if (templateBox.Renders[indices[i]].transform.Scale != transform.Scale)
						sca = false;
				}
				using (var trap = new EditingScope())
				{
					if (sym)
						textBox_RenderSymbol.Text = symbolName;
					else
						textBox_RenderSymbol.Clear();
					if (pos)
						textBox_RenderPosition.Text = transform.X.ToString("0.##") + " , " + transform.Y.ToString("0.##");
					else
						textBox_RenderPosition.Clear();
					if (rot)
						textBox_RenderRotation.Text = transform.Rotation.ToString("0.####");
					else
						textBox_RenderRotation.Clear();
					if (sca)
						textBox_RenderScale.Text = transform.Scale.ToString("0.####");
					else
						textBox_RenderScale.Clear();
				}
			}
			textBox_RenderSymbol.Refresh();
			textBox_RenderPosition.Refresh();
			textBox_RenderRotation.Refresh();
			textBox_RenderScale.Refresh();
		}

		private void UpdateRenderSymbol()
		{
			if (Editing)
				return;

			string symbolName = textBox_RenderSymbol.Text.Trim();
			foreach (int index in templateBox.SelectedRenders)
				templateBox.Renders[index].symbolName = symbolName;
			templateBox.Invalidate();
		}

		private void UpdateRenderPosition()
		{
			if (Editing)
				return;
			float x, y;
			string[] parts = textBox_RenderPosition.Text.Split(',');
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

		private void UpdateRenderRotation()
		{
			if (Editing)
				return;
			float r;
			if (!float.TryParse(textBox_RenderRotation.Text.Trim(), out r))
				return;
			PointF midPoint = templateBox.GetMidPointOfSelection();
			foreach (int index in templateBox.SelectedRenders)
			{
				Transform transform = templateBox.Renders[index].transform;
				templateBox.Renders[index].transform.Location = transform.Location.RotateRelativeTo(midPoint, (float)Extensions.Degree2Radian(r - transform.Rotation));
				templateBox.Renders[index].transform.Rotation = r;
			}
			templateBox.Invalidate();
		}

		private void UpdateRenderScale()
		{
			if (Editing)
				return;
			float s;
			if (!float.TryParse(textBox_RenderScale.Text.Trim(), out s))
				return;
			PointF midPoint = templateBox.GetMidPointOfSelection();
			foreach (int index in templateBox.SelectedRenders)
			{
				Transform transform = templateBox.Renders[index].transform;
				if (s != 0 && transform.Scale != 0)
					templateBox.Renders[index].transform.Location = transform.Location.ScaleRelativeTo(midPoint, s / transform.Scale);
				templateBox.Renders[index].transform.Scale = s;
			}
			templateBox.Invalidate();
		}


		private void textBox_RenderSymbol_KeyDown(object sender, KeyEventArgs e) => UpdateRenderSymbol();

		private void textBox_RenderPosition_KeyDown(object sender, KeyEventArgs e) => UpdateRenderPosition();

		private void textBox_RenderRotation_KeyDown(object sender, KeyEventArgs e) => UpdateRenderRotation();

		private void textBox_RenderScale_KeyDown(object sender, KeyEventArgs e) => UpdateRenderScale();


		private void textBox_RenderSymbol_TextChanged(object sender, EventArgs e) => UpdateRenderSymbol();

		private void textBox_RenderPosition_TextChanged(object sender, EventArgs e) => UpdateRenderPosition();

		private void textBox_RenderRotation_TextChanged(object sender, EventArgs e) => UpdateRenderRotation();

		private void textBox_RenderScale_TextChanged(object sender, EventArgs e) => UpdateRenderScale();


		private void listBox_Symbols_DoubleClick(object sender, EventArgs e)
		{
			AddRender();
		}
		
		private void trackBar_AlphaCut_Scroll(object sender, EventArgs e)
		{
			var color = templateBox.HighPassFilter;
			color.A = trackBar_AlphaCut.Value / 255f;
			templateBox.HighPassFilter = color;
			label_AlphaCut.Text = trackBar_AlphaCut.Value.ToString();
			label_AlphaCut.Refresh();
		}

		private void trackBar_Transparency_Scroll(object sender, EventArgs e)
		{
			var color = templateBox.HighPassFilter;
			color.R = color.G = color.B = trackBar_Transparency.Value / 255f;
			templateBox.HighPassFilter = color;
			label_Transparency.Text = trackBar_Transparency.Value.ToString();
			label_Transparency.Refresh();
		}

		public void LoadTemplate(string fileName)
		{
			using (FileStream settings = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				XmlSerializer xs = new XmlSerializer(typeof(Render[]));
				templateBox.LoadTemplate((Render[])xs.Deserialize(settings));
			}
		}

		public void SaveTemplate(string fileName)
		{
			using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				XmlSerializer xs = new XmlSerializer(typeof(Render[]));
				xs.Serialize(fs, templateBox.Renders.ToArray());
			}
		}

		private void button_LoadTemplate_Click(object sender, EventArgs e)
		{
			if (openFileDialog_Template.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					LoadTemplate(openFileDialog_Template.FileName);
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
					SaveTemplate(saveFileDialog_Template.FileName);
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
					templateBox.ScaleFit();
				}
			}
		}
	}
}
