namespace LF2.Sprite_Sheet_Generator
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Object = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Position = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Rotation = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Scale = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Offset = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Zoom = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.toolBox = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_Move = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Rotate = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Sclale = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_ScaleFit = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Scale1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Scale2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.checkBox_SpritePartsTransparency = new System.Windows.Forms.CheckBox();
			this.listBox_SpriteParts = new System.Windows.Forms.ListBox();
			this.button_Rename = new System.Windows.Forms.Button();
			this.button_RemoveSprite = new System.Windows.Forms.Button();
			this.button_MoveDown = new System.Windows.Forms.Button();
			this.button_AddSprite = new System.Windows.Forms.Button();
			this.button_MoveUp = new System.Windows.Forms.Button();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.openFileDialog_Image = new System.Windows.Forms.OpenFileDialog();
			this.templateBox = new LF2.Sprite_Sheet_Generator.TemplateBox();
			this.drawBox_SpritePart = new LF2.Sprite_Sheet_Generator.DrawBox();
			this.toolStripButton_Transparency = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripButton_BackgroundStyle = new LF2.Sprite_Sheet_Generator.BetterToolStripDropDownButton();
			this.toolStripMenuItem_ChessBoard = new LF2.Sprite_Sheet_Generator.BetterToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem_Color = new LF2.Sprite_Sheet_Generator.BetterToolStripMenuItem();
			this.toolStripMenuItem_AdjustColor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSplitButton_GuideImage = new LF2.Sprite_Sheet_Generator.BetterToolStripSplitButton();
			this.toolStripMenuItem_CreateEmptyGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripComboBox_Opacity = new System.Windows.Forms.ToolStripComboBox();
			this.statusStrip.SuspendLayout();
			this.toolBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel_Object,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_Position,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_Rotation,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel_Scale,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel_Offset,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel_Zoom});
			this.statusStrip.Location = new System.Drawing.Point(0, 646);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.statusStrip.Size = new System.Drawing.Size(1262, 27);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 0;
			// 
			// toolStripStatusLabel5
			// 
			this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			this.toolStripStatusLabel5.Size = new System.Drawing.Size(56, 22);
			this.toolStripStatusLabel5.Text = "Object:";
			// 
			// toolStripStatusLabel_Object
			// 
			this.toolStripStatusLabel_Object.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.toolStripStatusLabel_Object.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.toolStripStatusLabel_Object.Name = "toolStripStatusLabel_Object";
			this.toolStripStatusLabel_Object.Size = new System.Drawing.Size(44, 22);
			this.toolStripStatusLabel_Object.Text = "None";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 22);
			this.toolStripStatusLabel1.Text = "    Position:";
			// 
			// toolStripStatusLabel_Position
			// 
			this.toolStripStatusLabel_Position.Name = "toolStripStatusLabel_Position";
			this.toolStripStatusLabel_Position.Size = new System.Drawing.Size(32, 22);
			this.toolStripStatusLabel_Position.Text = "0, 0";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(85, 22);
			this.toolStripStatusLabel2.Text = "    Rotation:";
			// 
			// toolStripStatusLabel_Rotation
			// 
			this.toolStripStatusLabel_Rotation.Name = "toolStripStatusLabel_Rotation";
			this.toolStripStatusLabel_Rotation.Size = new System.Drawing.Size(17, 22);
			this.toolStripStatusLabel_Rotation.Text = "0";
			// 
			// toolStripStatusLabel6
			// 
			this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
			this.toolStripStatusLabel6.Size = new System.Drawing.Size(63, 22);
			this.toolStripStatusLabel6.Text = "    Scale:";
			// 
			// toolStripStatusLabel_Scale
			// 
			this.toolStripStatusLabel_Scale.Name = "toolStripStatusLabel_Scale";
			this.toolStripStatusLabel_Scale.Size = new System.Drawing.Size(17, 22);
			this.toolStripStatusLabel_Scale.Text = "0";
			// 
			// toolStripStatusLabel4
			// 
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			this.toolStripStatusLabel4.Size = new System.Drawing.Size(736, 22);
			this.toolStripStatusLabel4.Spring = true;
			this.toolStripStatusLabel4.Text = "Offset:";
			this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripStatusLabel_Offset
			// 
			this.toolStripStatusLabel_Offset.Name = "toolStripStatusLabel_Offset";
			this.toolStripStatusLabel_Offset.Size = new System.Drawing.Size(32, 22);
			this.toolStripStatusLabel_Offset.Text = "0, 0";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 22);
			this.toolStripStatusLabel3.Text = "    Zoom:";
			// 
			// toolStripStatusLabel_Zoom
			// 
			this.toolStripStatusLabel_Zoom.Name = "toolStripStatusLabel_Zoom";
			this.toolStripStatusLabel_Zoom.Size = new System.Drawing.Size(17, 22);
			this.toolStripStatusLabel_Zoom.Text = "1";
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1262, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// toolBox
			// 
			this.toolBox.ImageScalingSize = new System.Drawing.Size(22, 22);
			this.toolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Move,
            this.toolStripButton_Rotate,
            this.toolStripButton_Sclale,
            this.toolStripSeparator2,
            this.toolStripButton_ScaleFit,
            this.toolStripButton_Scale1,
            this.toolStripButton_Scale2,
            this.toolStripSeparator3,
            this.toolStripButton_Transparency,
            this.toolStripButton_BackgroundStyle,
            this.toolStripSplitButton_GuideImage});
			this.toolBox.Location = new System.Drawing.Point(0, 24);
			this.toolBox.Name = "toolBox";
			this.toolBox.Size = new System.Drawing.Size(1262, 29);
			this.toolBox.TabIndex = 3;
			// 
			// toolStripButton_Move
			// 
			this.toolStripButton_Move.Checked = true;
			this.toolStripButton_Move.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton_Move.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Move.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Move.Image")));
			this.toolStripButton_Move.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Move.Name = "toolStripButton_Move";
			this.toolStripButton_Move.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Move.ToolTipText = "Move Tool (G)";
			this.toolStripButton_Move.Click += new System.EventHandler(this.toolStripButton_Move_Click);
			// 
			// toolStripButton_Rotate
			// 
			this.toolStripButton_Rotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Rotate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Rotate.Image")));
			this.toolStripButton_Rotate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Rotate.Name = "toolStripButton_Rotate";
			this.toolStripButton_Rotate.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Rotate.ToolTipText = "Rotate Tool (R)";
			this.toolStripButton_Rotate.Click += new System.EventHandler(this.toolStripButton_Rotate_Click);
			// 
			// toolStripButton_Sclale
			// 
			this.toolStripButton_Sclale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Sclale.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Sclale.Image")));
			this.toolStripButton_Sclale.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Sclale.Name = "toolStripButton_Sclale";
			this.toolStripButton_Sclale.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Sclale.ToolTipText = "Scale Tool (S)";
			this.toolStripButton_Sclale.Click += new System.EventHandler(this.toolStripButton_Sclale_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
			// 
			// toolStripButton_ScaleFit
			// 
			this.toolStripButton_ScaleFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_ScaleFit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ScaleFit.Image")));
			this.toolStripButton_ScaleFit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_ScaleFit.Name = "toolStripButton_ScaleFit";
			this.toolStripButton_ScaleFit.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_ScaleFit.ToolTipText = "Fit Image to Panel";
			this.toolStripButton_ScaleFit.Click += new System.EventHandler(this.toolStripButton_ScaleFit_Click);
			// 
			// toolStripButton_Scale1
			// 
			this.toolStripButton_Scale1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Scale1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Scale1.Image")));
			this.toolStripButton_Scale1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Scale1.Name = "toolStripButton_Scale1";
			this.toolStripButton_Scale1.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Scale1.ToolTipText = "Scale 1:1";
			this.toolStripButton_Scale1.Click += new System.EventHandler(this.toolStripButton_Scale1_Click);
			// 
			// toolStripButton_Scale2
			// 
			this.toolStripButton_Scale2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Scale2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Scale2.Image")));
			this.toolStripButton_Scale2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Scale2.Name = "toolStripButton_Scale2";
			this.toolStripButton_Scale2.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Scale2.ToolTipText = "Scale 1:2";
			this.toolStripButton_Scale2.Click += new System.EventHandler(this.toolStripButton_Scale2_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
			// 
			// splitContainer
			// 
			this.splitContainer.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 53);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer.Panel1.Controls.Add(this.templateBox);
			this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer.Panel2.Controls.Add(this.drawBox_SpritePart);
			this.splitContainer.Panel2.Controls.Add(this.checkBox_SpritePartsTransparency);
			this.splitContainer.Panel2.Controls.Add(this.listBox_SpriteParts);
			this.splitContainer.Panel2.Controls.Add(this.button_Rename);
			this.splitContainer.Panel2.Controls.Add(this.button_RemoveSprite);
			this.splitContainer.Panel2.Controls.Add(this.button_MoveDown);
			this.splitContainer.Panel2.Controls.Add(this.button_AddSprite);
			this.splitContainer.Panel2.Controls.Add(this.button_MoveUp);
			this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer.Size = new System.Drawing.Size(1262, 593);
			this.splitContainer.SplitterDistance = 792;
			this.splitContainer.SplitterWidth = 8;
			this.splitContainer.TabIndex = 4;
			this.splitContainer.TabStop = false;
			// 
			// checkBox_SpritePartsTransparency
			// 
			this.checkBox_SpritePartsTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_SpritePartsTransparency.AutoSize = true;
			this.checkBox_SpritePartsTransparency.Checked = true;
			this.checkBox_SpritePartsTransparency.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_SpritePartsTransparency.Location = new System.Drawing.Point(270, 179);
			this.checkBox_SpritePartsTransparency.Name = "checkBox_SpritePartsTransparency";
			this.checkBox_SpritePartsTransparency.Size = new System.Drawing.Size(189, 24);
			this.checkBox_SpritePartsTransparency.TabIndex = 1;
			this.checkBox_SpritePartsTransparency.Text = "Transparent black pixels";
			this.checkBox_SpritePartsTransparency.UseVisualStyleBackColor = true;
			this.checkBox_SpritePartsTransparency.CheckedChanged += new System.EventHandler(this.checkBox_SpritePartsTransparency_CheckedChanged);
			// 
			// listBox_SpriteParts
			// 
			this.listBox_SpriteParts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox_SpriteParts.FormattingEnabled = true;
			this.listBox_SpriteParts.ItemHeight = 20;
			this.listBox_SpriteParts.Location = new System.Drawing.Point(3, 3);
			this.listBox_SpriteParts.Name = "listBox_SpriteParts";
			this.listBox_SpriteParts.Size = new System.Drawing.Size(236, 164);
			this.listBox_SpriteParts.TabIndex = 0;
			this.listBox_SpriteParts.SelectedIndexChanged += new System.EventHandler(this.listBox_SpriteParts_SelectedIndexChanged);
			this.listBox_SpriteParts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_SpriteParts_MouseDoubleClick);
			// 
			// button_Rename
			// 
			this.button_Rename.Location = new System.Drawing.Point(3, 173);
			this.button_Rename.Name = "button_Rename";
			this.button_Rename.Size = new System.Drawing.Size(80, 30);
			this.button_Rename.TabIndex = 3;
			this.button_Rename.Text = "Rename";
			this.button_Rename.UseVisualStyleBackColor = true;
			this.button_Rename.Click += new System.EventHandler(this.button_Rename_Click);
			// 
			// button_RemoveSprite
			// 
			this.button_RemoveSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_RemoveSprite.AutoSize = true;
			this.button_RemoveSprite.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_RemoveSprite.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button_RemoveSprite.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.minus;
			this.button_RemoveSprite.Location = new System.Drawing.Point(245, 47);
			this.button_RemoveSprite.Name = "button_RemoveSprite";
			this.button_RemoveSprite.Size = new System.Drawing.Size(38, 38);
			this.button_RemoveSprite.TabIndex = 3;
			this.button_RemoveSprite.UseVisualStyleBackColor = false;
			this.button_RemoveSprite.Click += new System.EventHandler(this.button_RemoveSprite_Click);
			// 
			// button_MoveDown
			// 
			this.button_MoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_MoveDown.AutoSize = true;
			this.button_MoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_MoveDown.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button_MoveDown.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.down;
			this.button_MoveDown.Location = new System.Drawing.Point(245, 135);
			this.button_MoveDown.Name = "button_MoveDown";
			this.button_MoveDown.Size = new System.Drawing.Size(38, 38);
			this.button_MoveDown.TabIndex = 3;
			this.button_MoveDown.UseVisualStyleBackColor = false;
			this.button_MoveDown.Click += new System.EventHandler(this.button_MoveDown_Click);
			// 
			// button_AddSprite
			// 
			this.button_AddSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_AddSprite.AutoSize = true;
			this.button_AddSprite.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_AddSprite.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button_AddSprite.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.plus;
			this.button_AddSprite.Location = new System.Drawing.Point(245, 3);
			this.button_AddSprite.Name = "button_AddSprite";
			this.button_AddSprite.Size = new System.Drawing.Size(38, 38);
			this.button_AddSprite.TabIndex = 3;
			this.button_AddSprite.UseVisualStyleBackColor = false;
			this.button_AddSprite.Click += new System.EventHandler(this.button_AddSprite_Click);
			// 
			// button_MoveUp
			// 
			this.button_MoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_MoveUp.AutoSize = true;
			this.button_MoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_MoveUp.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button_MoveUp.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.up;
			this.button_MoveUp.Location = new System.Drawing.Point(245, 91);
			this.button_MoveUp.Name = "button_MoveUp";
			this.button_MoveUp.Size = new System.Drawing.Size(38, 38);
			this.button_MoveUp.TabIndex = 3;
			this.button_MoveUp.UseVisualStyleBackColor = false;
			this.button_MoveUp.Click += new System.EventHandler(this.button_MoveUp_Click);
			// 
			// colorDialog
			// 
			this.colorDialog.FullOpen = true;
			// 
			// openFileDialog_Image
			// 
			this.openFileDialog_Image.Filter = "Image Files (*.bmp;*.dib;*.png;*jpg;*.jpeg;*.jpe;*.jfif;*.gif;*emf;*.tif;*.tiff;*" +
    ".wmf)|*.bmp;*.dib;*.png;*jpg;*.jpeg;*.jpe;*.jfif;*.gif;*emf;*.tif;*.tiff;*.wmf";
			this.openFileDialog_Image.Multiselect = true;
			this.openFileDialog_Image.ReadOnlyChecked = true;
			this.openFileDialog_Image.RestoreDirectory = true;
			this.openFileDialog_Image.Title = "Open Image...";
			// 
			// templateBox
			// 
			this.templateBox.AllowDrop = true;
			this.templateBox.BackColor = System.Drawing.Color.Black;
			this.templateBox.BackgroundImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.check;
			this.templateBox.ControlKey = false;
			this.templateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateBox.GuideImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.dev_temp;
			this.templateBox.Location = new System.Drawing.Point(0, 0);
			this.templateBox.MissingImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.broken_img;
			this.templateBox.Name = "templateBox";
			this.templateBox.Offset = ((System.Drawing.PointF)(resources.GetObject("templateBox.Offset")));
			this.templateBox.ShiftKey = false;
			this.templateBox.ShowCoordinateSystem = true;
			this.templateBox.Size = new System.Drawing.Size(792, 593);
			this.templateBox.Smoothing = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			this.templateBox.TabIndex = 0;
			this.templateBox.ZoomChanged += new System.EventHandler(this.templateBox_ZoomChanged);
			this.templateBox.OffsetChanged += new System.EventHandler(this.templateBox_OffsetChanged);
			// 
			// drawBox_SpritePart
			// 
			this.drawBox_SpritePart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.drawBox_SpritePart.BackgroundImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.check;
			this.drawBox_SpritePart.BackgroundInterpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.drawBox_SpritePart.ControlKey = false;
			this.drawBox_SpritePart.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.drawBox_SpritePart.Location = new System.Drawing.Point(289, 3);
			this.drawBox_SpritePart.MultiRectangleMode = false;
			this.drawBox_SpritePart.Name = "drawBox_SpritePart";
			this.drawBox_SpritePart.OneRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.drawBox_SpritePart.PictureMode = LF2.Sprite_Sheet_Generator.PictureMode.ShrinkOnly;
			this.drawBox_SpritePart.Rectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.drawBox_SpritePart.Rectangles = ((System.Collections.Generic.List<System.Drawing.Rectangle>)(resources.GetObject("drawBox_SpritePart.Rectangles")));
			this.drawBox_SpritePart.ShiftKey = false;
			this.drawBox_SpritePart.Size = new System.Drawing.Size(170, 170);
			this.drawBox_SpritePart.TabIndex = 2;
			this.drawBox_SpritePart.TabStop = false;
			this.drawBox_SpritePart.Trancparency = true;
			// 
			// toolStripButton_Transparency
			// 
			this.toolStripButton_Transparency.CheckOnClick = true;
			this.toolStripButton_Transparency.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Transparency.Image")));
			this.toolStripButton_Transparency.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Transparency.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.toolStripButton_Transparency.Name = "toolStripButton_Transparency";
			this.toolStripButton_Transparency.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Transparency.ToolTipText = "Transparent black pixels on guide image";
			this.toolStripButton_Transparency.CheckedChanged += new System.EventHandler(this.toolStripButton_Transparency_CheckedChanged);
			// 
			// toolStripButton_BackgroundStyle
			// 
			this.toolStripButton_BackgroundStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ChessBoard,
            this.toolStripSeparator4,
            this.toolStripMenuItem_Color,
            this.toolStripMenuItem_AdjustColor});
			this.toolStripButton_BackgroundStyle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_BackgroundStyle.Image")));
			this.toolStripButton_BackgroundStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_BackgroundStyle.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.toolStripButton_BackgroundStyle.Name = "toolStripButton_BackgroundStyle";
			this.toolStripButton_BackgroundStyle.Size = new System.Drawing.Size(36, 26);
			this.toolStripButton_BackgroundStyle.ToolTipText = "Background Style";
			// 
			// toolStripMenuItem_ChessBoard
			// 
			this.toolStripMenuItem_ChessBoard.Checked = true;
			this.toolStripMenuItem_ChessBoard.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem_ChessBoard.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.check;
			this.toolStripMenuItem_ChessBoard.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.toolStripMenuItem_ChessBoard.Name = "toolStripMenuItem_ChessBoard";
			this.toolStripMenuItem_ChessBoard.Size = new System.Drawing.Size(175, 26);
			this.toolStripMenuItem_ChessBoard.Text = "Chess &Board";
			this.toolStripMenuItem_ChessBoard.Click += new System.EventHandler(this.toolStripMenuItem_ChessBoard_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(172, 6);
			// 
			// toolStripMenuItem_Color
			// 
			this.toolStripMenuItem_Color.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.ColorBlack;
			this.toolStripMenuItem_Color.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.toolStripMenuItem_Color.Name = "toolStripMenuItem_Color";
			this.toolStripMenuItem_Color.Size = new System.Drawing.Size(175, 26);
			this.toolStripMenuItem_Color.Text = "&Color";
			this.toolStripMenuItem_Color.Click += new System.EventHandler(this.toolStripMenuItem_Color_Click);
			// 
			// toolStripMenuItem_AdjustColor
			// 
			this.toolStripMenuItem_AdjustColor.Name = "toolStripMenuItem_AdjustColor";
			this.toolStripMenuItem_AdjustColor.Size = new System.Drawing.Size(175, 26);
			this.toolStripMenuItem_AdjustColor.Text = "&Adjust Color...";
			this.toolStripMenuItem_AdjustColor.Click += new System.EventHandler(this.toolStripMenuItem_AdjustColor_Click);
			// 
			// toolStripSplitButton_GuideImage
			// 
			this.toolStripSplitButton_GuideImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_GuideImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_CreateEmptyGrid,
            this.toolStripSeparator1,
            this.opacityToolStripMenuItem,
            this.toolStripComboBox_Opacity});
			this.toolStripSplitButton_GuideImage.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.template_head;
			this.toolStripSplitButton_GuideImage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton_GuideImage.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.toolStripSplitButton_GuideImage.Name = "toolStripSplitButton_GuideImage";
			this.toolStripSplitButton_GuideImage.Size = new System.Drawing.Size(41, 26);
			this.toolStripSplitButton_GuideImage.ToolTipText = "Adjust Guide Image...";
			this.toolStripSplitButton_GuideImage.ButtonClick += new System.EventHandler(this.toolStripSplitButton_GuideImage_Click);
			// 
			// toolStripMenuItem_CreateEmptyGrid
			// 
			this.toolStripMenuItem_CreateEmptyGrid.Name = "toolStripMenuItem_CreateEmptyGrid";
			this.toolStripMenuItem_CreateEmptyGrid.Size = new System.Drawing.Size(214, 26);
			this.toolStripMenuItem_CreateEmptyGrid.Text = "Create &Empty Grid...";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
			// 
			// opacityToolStripMenuItem
			// 
			this.opacityToolStripMenuItem.Enabled = false;
			this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
			this.opacityToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
			this.opacityToolStripMenuItem.Text = "Opacity:";
			// 
			// toolStripComboBox_Opacity
			// 
			this.toolStripComboBox_Opacity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolStripComboBox_Opacity.Items.AddRange(new object[] {
            "0%",
            "10%",
            "25%",
            "50%",
            "75%",
            "90%",
            "100%"});
			this.toolStripComboBox_Opacity.Name = "toolStripComboBox_Opacity";
			this.toolStripComboBox_Opacity.Size = new System.Drawing.Size(121, 28);
			this.toolStripComboBox_Opacity.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_Opacity_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 673);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.toolBox);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LF2 Sprite Sheet Generator";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolBox.ResumeLayout(false);
			this.toolBox.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStrip toolBox;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.ToolStripButton toolStripButton_Move;
		private System.Windows.Forms.ToolStripButton toolStripButton_Sclale;
		private System.Windows.Forms.ToolStripButton toolStripButton_Rotate;
		private System.Windows.Forms.ToolStripButton toolStripButton_ScaleFit;
		private System.Windows.Forms.ToolStripButton toolStripButton_Scale1;
		private System.Windows.Forms.ToolStripButton toolStripButton_Scale2;
		private TemplateBox templateBox;
		private BetterToolStripDropDownButton toolStripButton_BackgroundStyle;
		private BetterToolStripMenuItem toolStripMenuItem_ChessBoard;
		private BetterToolStripMenuItem toolStripMenuItem_Color;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AdjustColor;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.CheckBox checkBox_SpritePartsTransparency;
		private System.Windows.Forms.ListBox listBox_SpriteParts;
		private BetterToolStripButton toolStripButton_Transparency;
		private DrawBox drawBox_SpritePart;
		private System.Windows.Forms.OpenFileDialog openFileDialog_Image;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Object;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Position;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Rotation;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Scale;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Offset;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Zoom;
		private BetterToolStripSplitButton toolStripSplitButton_GuideImage;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CreateEmptyGrid;
		private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Opacity;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.Button button_MoveDown;
		private System.Windows.Forms.Button button_MoveUp;
		private System.Windows.Forms.Button button_RemoveSprite;
		private System.Windows.Forms.Button button_AddSprite;
		private System.Windows.Forms.Button button_Rename;
	}
}

