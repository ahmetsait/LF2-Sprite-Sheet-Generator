namespace LF2.Sprite_Sheet_Generator
{
	partial class Form_CreateGrid
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
			this.button_Create = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.panel = new System.Windows.Forms.Panel();
			this.textBox_Width = new System.Windows.Forms.TextBox();
			this.textBox_Height = new System.Windows.Forms.TextBox();
			this.textBox_Row = new System.Windows.Forms.TextBox();
			this.textBox_Column = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_Create
			// 
			this.button_Create.Location = new System.Drawing.Point(3, 4);
			this.button_Create.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_Create.Name = "button_Create";
			this.button_Create.Size = new System.Drawing.Size(80, 30);
			this.button_Create.TabIndex = 0;
			this.button_Create.TabStop = false;
			this.button_Create.Text = "Create";
			this.button_Create.UseVisualStyleBackColor = true;
			this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(89, 4);
			this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(80, 30);
			this.button_Cancel.TabIndex = 0;
			this.button_Cancel.TabStop = false;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// panel
			// 
			this.panel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.panel.AutoSize = true;
			this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel.Controls.Add(this.button_Create);
			this.panel.Controls.Add(this.button_Cancel);
			this.panel.Location = new System.Drawing.Point(55, 148);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(172, 38);
			this.panel.TabIndex = 1;
			// 
			// textBox_Width
			// 
			this.textBox_Width.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Width.Location = new System.Drawing.Point(144, 12);
			this.textBox_Width.Name = "textBox_Width";
			this.textBox_Width.Size = new System.Drawing.Size(126, 27);
			this.textBox_Width.TabIndex = 1;
			this.textBox_Width.Text = "79";
			// 
			// textBox_Height
			// 
			this.textBox_Height.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Height.Location = new System.Drawing.Point(144, 45);
			this.textBox_Height.Name = "textBox_Height";
			this.textBox_Height.Size = new System.Drawing.Size(126, 27);
			this.textBox_Height.TabIndex = 2;
			this.textBox_Height.Text = "79";
			// 
			// textBox_Row
			// 
			this.textBox_Row.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Row.Location = new System.Drawing.Point(144, 78);
			this.textBox_Row.Name = "textBox_Row";
			this.textBox_Row.Size = new System.Drawing.Size(126, 27);
			this.textBox_Row.TabIndex = 3;
			// 
			// textBox_Column
			// 
			this.textBox_Column.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Column.Location = new System.Drawing.Point(144, 111);
			this.textBox_Column.Name = "textBox_Column";
			this.textBox_Column.Size = new System.Drawing.Size(126, 27);
			this.textBox_Column.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(57, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Cell Width:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(52, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Cell Height:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(54, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Row Count:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(106, 20);
			this.label4.TabIndex = 3;
			this.label4.Text = "Column Count:";
			// 
			// Form_CreateGrid
			// 
			this.AcceptButton = this.button_Create;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(282, 198);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_Column);
			this.Controls.Add(this.textBox_Height);
			this.Controls.Add(this.textBox_Row);
			this.Controls.Add(this.textBox_Width);
			this.Controls.Add(this.panel);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_CreateGrid";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Grid Settings";
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_Create;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.TextBox textBox_Width;
		private System.Windows.Forms.TextBox textBox_Height;
		private System.Windows.Forms.TextBox textBox_Row;
		private System.Windows.Forms.TextBox textBox_Column;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}