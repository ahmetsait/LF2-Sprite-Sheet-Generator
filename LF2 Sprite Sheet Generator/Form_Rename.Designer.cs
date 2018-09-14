namespace LF2.Sprite_Sheet_Generator
{
	partial class Form_Rename
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
			this.button_Ok = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.panel = new System.Windows.Forms.Panel();
			this.textBox = new System.Windows.Forms.TextBox();
			this.label_Name = new System.Windows.Forms.Label();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_Ok
			// 
			this.button_Ok.Location = new System.Drawing.Point(3, 4);
			this.button_Ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_Ok.Name = "button_Ok";
			this.button_Ok.Size = new System.Drawing.Size(80, 30);
			this.button_Ok.TabIndex = 2;
			this.button_Ok.Text = "OK";
			this.button_Ok.UseVisualStyleBackColor = true;
			this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(89, 4);
			this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(80, 30);
			this.button_Cancel.TabIndex = 3;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// panel
			// 
			this.panel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.panel.AutoSize = true;
			this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel.Controls.Add(this.button_Ok);
			this.panel.Controls.Add(this.button_Cancel);
			this.panel.Location = new System.Drawing.Point(55, 70);
			this.panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(172, 38);
			this.panel.TabIndex = 1;
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.Location = new System.Drawing.Point(12, 33);
			this.textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(258, 27);
			this.textBox.TabIndex = 1;
			// 
			// label_Name
			// 
			this.label_Name.AutoSize = true;
			this.label_Name.Location = new System.Drawing.Point(12, 9);
			this.label_Name.Name = "label_Name";
			this.label_Name.Size = new System.Drawing.Size(49, 20);
			this.label_Name.TabIndex = 2;
			this.label_Name.Text = "Name";
			// 
			// Form_Rename
			// 
			this.AcceptButton = this.button_Ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(282, 121);
			this.Controls.Add(this.label_Name);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.panel);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_Rename";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Rename";
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_Ok;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Panel panel;
		public System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Label label_Name;
	}
}