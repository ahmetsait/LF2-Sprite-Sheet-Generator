namespace LF2.Sprite_Sheet_Generator
{
	partial class Form_Preview
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Preview));
			this.templateBox = new LF2.Sprite_Sheet_Generator.TemplateBox();
			this.SuspendLayout();
			// 
			// templateBox
			// 
			this.templateBox.BackgroundImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.check;
			this.templateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateBox.GuideImageAlpha = 1F;
			this.templateBox.Location = new System.Drawing.Point(0, 0);
			this.templateBox.Name = "templateBox";
			this.templateBox.Offset = ((System.Drawing.PointF)(resources.GetObject("templateBox.Offset")));
			this.templateBox.SelectionColor = System.Drawing.Color.Transparent;
			this.templateBox.Size = new System.Drawing.Size(282, 253);
			this.templateBox.TabIndex = 0;
			this.templateBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.templateBox_MouseDown);
			// 
			// Form_Preview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(282, 253);
			this.Controls.Add(this.templateBox);
			this.DoubleBuffered = true;
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "Form_Preview";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preview";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Preview_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private TemplateBox templateBox;
	}
}