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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Offset = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Zoom = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolBox = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_Move = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripButton_Rotate = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripButton_Scale = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.betterToolStripButton_BringToFront = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.betterToolStripButton_SendToBack = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_ScaleFit = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripButton_Scale1 = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripButton_Scale2 = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripButton_Scale4 = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_Transparency = new LF2.Sprite_Sheet_Generator.BetterToolStripButton();
			this.toolStripDropDownButton_BackgroundStyle = new LF2.Sprite_Sheet_Generator.BetterToolStripDropDownButton();
			this.toolStripMenuItem_ChessBoard = new LF2.Sprite_Sheet_Generator.BetterToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem_Color = new LF2.Sprite_Sheet_Generator.BetterToolStripMenuItem();
			this.toolStripMenuItem_AdjustColor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton_GuideImage = new LF2.Sprite_Sheet_Generator.BetterToolStripDropDownButton();
			this.toolStripMenuItem_LoadFromFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_CreateEmptyGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripComboBox_Opacity = new System.Windows.Forms.ToolStripComboBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.templateBox = new LF2.Sprite_Sheet_Generator.TemplateBox();
			this.panel_ObjectProperties = new System.Windows.Forms.Panel();
			this.groupBox_Sprite = new System.Windows.Forms.GroupBox();
			this.checkBox_AlphaChannel = new System.Windows.Forms.CheckBox();
			this.checkBox_RenderGuide = new System.Windows.Forms.CheckBox();
			this.trackBar_Transparency = new System.Windows.Forms.TrackBar();
			this.trackBar_AlphaCut = new System.Windows.Forms.TrackBar();
			this.button_SaveSprite = new System.Windows.Forms.Button();
			this.label_Transparency = new System.Windows.Forms.Label();
			this.button_PreviewSprite = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label_AlphaCut = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox_Template = new System.Windows.Forms.GroupBox();
			this.button_SaveTemplate = new System.Windows.Forms.Button();
			this.button_LoadTemplate = new System.Windows.Forms.Button();
			this.groupBox_Render = new System.Windows.Forms.GroupBox();
			this.textBox_RenderSymbol = new System.Windows.Forms.TextBox();
			this.textBox_RenderPosition = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_RenderRotation = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_RenderScale = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.drawBox_Symbol = new LF2.Sprite_Sheet_Generator.DrawBox();
			this.checkBox_RenderTransparency = new System.Windows.Forms.CheckBox();
			this.listBox_Symbols = new System.Windows.Forms.ListBox();
			this.button_AddRender = new System.Windows.Forms.Button();
			this.button_RenameSymbol = new System.Windows.Forms.Button();
			this.button_RemoveSymbol = new System.Windows.Forms.Button();
			this.button_MoveDown = new System.Windows.Forms.Button();
			this.button_AddSymbol = new System.Windows.Forms.Button();
			this.button_MoveUp = new System.Windows.Forms.Button();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.openFileDialog_Image = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog_Sprite = new System.Windows.Forms.SaveFileDialog();
			this.saveFileDialog_Template = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog_Template = new System.Windows.Forms.OpenFileDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.statusStrip.SuspendLayout();
			this.toolBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel_ObjectProperties.SuspendLayout();
			this.groupBox_Sprite.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Transparency)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_AlphaCut)).BeginInit();
			this.groupBox_Template.SuspendLayout();
			this.groupBox_Render.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel_Offset,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel_Zoom});
			this.statusStrip.Location = new System.Drawing.Point(0, 648);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.statusStrip.Size = new System.Drawing.Size(1262, 25);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 0;
			// 
			// toolStripStatusLabel4
			// 
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			this.toolStripStatusLabel4.Size = new System.Drawing.Size(52, 20);
			this.toolStripStatusLabel4.Text = "Offset:";
			this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripStatusLabel_Offset
			// 
			this.toolStripStatusLabel_Offset.Name = "toolStripStatusLabel_Offset";
			this.toolStripStatusLabel_Offset.Size = new System.Drawing.Size(32, 20);
			this.toolStripStatusLabel_Offset.Text = "0, 0";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 20);
			this.toolStripStatusLabel3.Text = "    Zoom:";
			// 
			// toolStripStatusLabel_Zoom
			// 
			this.toolStripStatusLabel_Zoom.Name = "toolStripStatusLabel_Zoom";
			this.toolStripStatusLabel_Zoom.Size = new System.Drawing.Size(17, 20);
			this.toolStripStatusLabel_Zoom.Text = "1";
			// 
			// toolBox
			// 
			this.toolBox.ImageScalingSize = new System.Drawing.Size(22, 22);
			this.toolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Move,
            this.toolStripButton_Rotate,
            this.toolStripButton_Scale,
            this.toolStripSeparator5,
            this.betterToolStripButton_BringToFront,
            this.betterToolStripButton_SendToBack,
            this.toolStripSeparator2,
            this.toolStripButton_ScaleFit,
            this.toolStripButton_Scale1,
            this.toolStripButton_Scale2,
            this.toolStripButton_Scale4,
            this.toolStripSeparator3,
            this.toolStripButton_Transparency,
            this.toolStripDropDownButton_BackgroundStyle,
            this.toolStripDropDownButton_GuideImage});
			this.toolBox.Location = new System.Drawing.Point(0, 0);
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
			this.toolStripButton_Move.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
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
			this.toolStripButton_Rotate.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.toolStripButton_Rotate.Name = "toolStripButton_Rotate";
			this.toolStripButton_Rotate.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Rotate.ToolTipText = "Rotate Tool (R)";
			this.toolStripButton_Rotate.Click += new System.EventHandler(this.toolStripButton_Rotate_Click);
			// 
			// toolStripButton_Scale
			// 
			this.toolStripButton_Scale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Scale.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.scale_tool;
			this.toolStripButton_Scale.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Scale.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.toolStripButton_Scale.Name = "toolStripButton_Scale";
			this.toolStripButton_Scale.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Scale.ToolTipText = "Scale Tool (S)";
			this.toolStripButton_Scale.Click += new System.EventHandler(this.toolStripButton_Scale_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
			// 
			// betterToolStripButton_BringToFront
			// 
			this.betterToolStripButton_BringToFront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.betterToolStripButton_BringToFront.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.bringtofront;
			this.betterToolStripButton_BringToFront.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.betterToolStripButton_BringToFront.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.betterToolStripButton_BringToFront.Name = "betterToolStripButton_BringToFront";
			this.betterToolStripButton_BringToFront.Size = new System.Drawing.Size(26, 26);
			this.betterToolStripButton_BringToFront.Text = "Bring to Front";
			this.betterToolStripButton_BringToFront.Click += new System.EventHandler(this.toolStripButton_BringToFront_Click);
			// 
			// betterToolStripButton_SendToBack
			// 
			this.betterToolStripButton_SendToBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.betterToolStripButton_SendToBack.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.sendtoback;
			this.betterToolStripButton_SendToBack.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.betterToolStripButton_SendToBack.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.betterToolStripButton_SendToBack.Name = "betterToolStripButton_SendToBack";
			this.betterToolStripButton_SendToBack.Size = new System.Drawing.Size(26, 26);
			this.betterToolStripButton_SendToBack.Text = "Send to Back";
			this.betterToolStripButton_SendToBack.Click += new System.EventHandler(this.toolStripButton_SendToBack_Click);
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
			this.toolStripButton_ScaleFit.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
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
			this.toolStripButton_Scale1.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
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
			this.toolStripButton_Scale2.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.toolStripButton_Scale2.Name = "toolStripButton_Scale2";
			this.toolStripButton_Scale2.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Scale2.ToolTipText = "Scale 1:2";
			this.toolStripButton_Scale2.Click += new System.EventHandler(this.toolStripButton_Scale2_Click);
			// 
			// toolStripButton_Scale4
			// 
			this.toolStripButton_Scale4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Scale4.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.scale4;
			this.toolStripButton_Scale4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Scale4.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.toolStripButton_Scale4.Name = "toolStripButton_Scale4";
			this.toolStripButton_Scale4.Size = new System.Drawing.Size(26, 26);
			this.toolStripButton_Scale4.ToolTipText = "Scale 1:4";
			this.toolStripButton_Scale4.Click += new System.EventHandler(this.toolStripButton_Scale4_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
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
			// toolStripDropDownButton_BackgroundStyle
			// 
			this.toolStripDropDownButton_BackgroundStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ChessBoard,
            this.toolStripSeparator4,
            this.toolStripMenuItem_Color,
            this.toolStripMenuItem_AdjustColor});
			this.toolStripDropDownButton_BackgroundStyle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_BackgroundStyle.Image")));
			this.toolStripDropDownButton_BackgroundStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton_BackgroundStyle.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.toolStripDropDownButton_BackgroundStyle.Name = "toolStripDropDownButton_BackgroundStyle";
			this.toolStripDropDownButton_BackgroundStyle.Size = new System.Drawing.Size(36, 26);
			this.toolStripDropDownButton_BackgroundStyle.ToolTipText = "Background Style";
			// 
			// toolStripMenuItem_ChessBoard
			// 
			this.toolStripMenuItem_ChessBoard.Checked = true;
			this.toolStripMenuItem_ChessBoard.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem_ChessBoard.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.check;
			this.toolStripMenuItem_ChessBoard.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.toolStripMenuItem_ChessBoard.Name = "toolStripMenuItem_ChessBoard";
			this.toolStripMenuItem_ChessBoard.Size = new System.Drawing.Size(183, 28);
			this.toolStripMenuItem_ChessBoard.Text = "Chess &Board";
			this.toolStripMenuItem_ChessBoard.Click += new System.EventHandler(this.toolStripMenuItem_ChessBoard_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(180, 6);
			// 
			// toolStripMenuItem_Color
			// 
			this.toolStripMenuItem_Color.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.ColorBlack;
			this.toolStripMenuItem_Color.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.toolStripMenuItem_Color.Name = "toolStripMenuItem_Color";
			this.toolStripMenuItem_Color.Size = new System.Drawing.Size(183, 28);
			this.toolStripMenuItem_Color.Text = "&Color";
			this.toolStripMenuItem_Color.Click += new System.EventHandler(this.toolStripMenuItem_Color_Click);
			// 
			// toolStripMenuItem_AdjustColor
			// 
			this.toolStripMenuItem_AdjustColor.Name = "toolStripMenuItem_AdjustColor";
			this.toolStripMenuItem_AdjustColor.Size = new System.Drawing.Size(183, 28);
			this.toolStripMenuItem_AdjustColor.Text = "&Adjust Color...";
			this.toolStripMenuItem_AdjustColor.Click += new System.EventHandler(this.toolStripMenuItem_AdjustColor_Click);
			// 
			// toolStripDropDownButton_GuideImage
			// 
			this.toolStripDropDownButton_GuideImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_GuideImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_LoadFromFile,
            this.toolStripMenuItem_CreateEmptyGrid,
            this.toolStripSeparator1,
            this.opacityToolStripMenuItem,
            this.toolStripComboBox_Opacity});
			this.toolStripDropDownButton_GuideImage.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.template_head;
			this.toolStripDropDownButton_GuideImage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton_GuideImage.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.toolStripDropDownButton_GuideImage.Name = "toolStripDropDownButton_GuideImage";
			this.toolStripDropDownButton_GuideImage.Size = new System.Drawing.Size(36, 26);
			this.toolStripDropDownButton_GuideImage.ToolTipText = "Adjust Guide Image...";
			// 
			// toolStripMenuItem_LoadFromFile
			// 
			this.toolStripMenuItem_LoadFromFile.Name = "toolStripMenuItem_LoadFromFile";
			this.toolStripMenuItem_LoadFromFile.Size = new System.Drawing.Size(214, 26);
			this.toolStripMenuItem_LoadFromFile.Text = "Load From &File...";
			this.toolStripMenuItem_LoadFromFile.Click += new System.EventHandler(this.toolStripMenuItem_LoadFromFile_Click);
			// 
			// toolStripMenuItem_CreateEmptyGrid
			// 
			this.toolStripMenuItem_CreateEmptyGrid.Name = "toolStripMenuItem_CreateEmptyGrid";
			this.toolStripMenuItem_CreateEmptyGrid.Size = new System.Drawing.Size(214, 26);
			this.toolStripMenuItem_CreateEmptyGrid.Text = "Create &Empty Grid...";
			this.toolStripMenuItem_CreateEmptyGrid.Click += new System.EventHandler(this.toolStripMenuItem_CreateEmptyGrid_Click);
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
			// splitContainer
			// 
			this.splitContainer.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 29);
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
			this.splitContainer.Panel2.Controls.Add(this.panel_ObjectProperties);
			this.splitContainer.Panel2.Controls.Add(this.drawBox_Symbol);
			this.splitContainer.Panel2.Controls.Add(this.checkBox_RenderTransparency);
			this.splitContainer.Panel2.Controls.Add(this.listBox_Symbols);
			this.splitContainer.Panel2.Controls.Add(this.button_AddRender);
			this.splitContainer.Panel2.Controls.Add(this.button_RenameSymbol);
			this.splitContainer.Panel2.Controls.Add(this.button_RemoveSymbol);
			this.splitContainer.Panel2.Controls.Add(this.button_MoveDown);
			this.splitContainer.Panel2.Controls.Add(this.button_AddSymbol);
			this.splitContainer.Panel2.Controls.Add(this.button_MoveUp);
			this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer.Size = new System.Drawing.Size(1262, 619);
			this.splitContainer.SplitterDistance = 776;
			this.splitContainer.SplitterWidth = 8;
			this.splitContainer.TabIndex = 4;
			this.splitContainer.TabStop = false;
			// 
			// templateBox
			// 
			this.templateBox.AllowDrop = true;
			this.templateBox.BackColor = System.Drawing.Color.Black;
			this.templateBox.BackgroundImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.check;
			this.templateBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateBox.GuideImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.dev_temp;
			this.templateBox.Location = new System.Drawing.Point(0, 0);
			this.templateBox.MissingImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.broken_img;
			this.templateBox.Name = "templateBox";
			this.templateBox.Offset = ((System.Drawing.PointF)(resources.GetObject("templateBox.Offset")));
			this.templateBox.ShowCoordinateSystem = true;
			this.templateBox.Size = new System.Drawing.Size(776, 619);
			this.templateBox.Smoothing = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			this.templateBox.TabIndex = 0;
			this.templateBox.Transparency = true;
			this.templateBox.SelectionChanged += new System.EventHandler(this.templateBox_SelectionChanged);
			this.templateBox.EditModeChanged += new System.EventHandler(this.templateBox_EditModeChanged);
			this.templateBox.ZoomChanged += new System.EventHandler(this.templateBox_ZoomChanged);
			this.templateBox.OffsetChanged += new System.EventHandler(this.templateBox_OffsetChanged);
			this.templateBox.TransformEdit += new System.EventHandler(this.templateBox_SelectionChanged);
			this.templateBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.templateBox_DragDrop);
			this.templateBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.templateBox_DragEnter);
			// 
			// panel_ObjectProperties
			// 
			this.panel_ObjectProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_ObjectProperties.AutoScroll = true;
			this.panel_ObjectProperties.Controls.Add(this.groupBox_Sprite);
			this.panel_ObjectProperties.Controls.Add(this.groupBox_Template);
			this.panel_ObjectProperties.Controls.Add(this.groupBox_Render);
			this.panel_ObjectProperties.Location = new System.Drawing.Point(3, 209);
			this.panel_ObjectProperties.Name = "panel_ObjectProperties";
			this.panel_ObjectProperties.Size = new System.Drawing.Size(475, 407);
			this.panel_ObjectProperties.TabIndex = 4;
			// 
			// groupBox_Sprite
			// 
			this.groupBox_Sprite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_Sprite.Controls.Add(this.checkBox_AlphaChannel);
			this.groupBox_Sprite.Controls.Add(this.checkBox_RenderGuide);
			this.groupBox_Sprite.Controls.Add(this.trackBar_Transparency);
			this.groupBox_Sprite.Controls.Add(this.trackBar_AlphaCut);
			this.groupBox_Sprite.Controls.Add(this.button_SaveSprite);
			this.groupBox_Sprite.Controls.Add(this.label_Transparency);
			this.groupBox_Sprite.Controls.Add(this.button_PreviewSprite);
			this.groupBox_Sprite.Controls.Add(this.label5);
			this.groupBox_Sprite.Controls.Add(this.label_AlphaCut);
			this.groupBox_Sprite.Controls.Add(this.label2);
			this.groupBox_Sprite.ForeColor = System.Drawing.Color.Navy;
			this.groupBox_Sprite.Location = new System.Drawing.Point(3, 192);
			this.groupBox_Sprite.Name = "groupBox_Sprite";
			this.groupBox_Sprite.Size = new System.Drawing.Size(469, 212);
			this.groupBox_Sprite.TabIndex = 2;
			this.groupBox_Sprite.TabStop = false;
			this.groupBox_Sprite.Text = "Sprite Sheet";
			// 
			// checkBox_AlphaChannel
			// 
			this.checkBox_AlphaChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox_AlphaChannel.AutoSize = true;
			this.checkBox_AlphaChannel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.checkBox_AlphaChannel.Location = new System.Drawing.Point(6, 146);
			this.checkBox_AlphaChannel.Name = "checkBox_AlphaChannel";
			this.checkBox_AlphaChannel.Size = new System.Drawing.Size(302, 24);
			this.checkBox_AlphaChannel.TabIndex = 5;
			this.checkBox_AlphaChannel.TabStop = false;
			this.checkBox_AlphaChannel.Text = "Preserve alpha channel (LF2 incomptible)";
			this.toolTip.SetToolTip(this.checkBox_AlphaChannel, "Controls whether generated sprite sheet\r\nwill be 24bpp RGB or 32bpp ARGB");
			this.checkBox_AlphaChannel.UseVisualStyleBackColor = true;
			// 
			// checkBox_RenderGuide
			// 
			this.checkBox_RenderGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox_RenderGuide.AutoSize = true;
			this.checkBox_RenderGuide.ForeColor = System.Drawing.SystemColors.ControlText;
			this.checkBox_RenderGuide.Location = new System.Drawing.Point(6, 182);
			this.checkBox_RenderGuide.Name = "checkBox_RenderGuide";
			this.checkBox_RenderGuide.Size = new System.Drawing.Size(201, 24);
			this.checkBox_RenderGuide.TabIndex = 5;
			this.checkBox_RenderGuide.TabStop = false;
			this.checkBox_RenderGuide.Text = "Render onto guide image";
			this.checkBox_RenderGuide.UseVisualStyleBackColor = true;
			// 
			// trackBar_Transparency
			// 
			this.trackBar_Transparency.AutoSize = false;
			this.trackBar_Transparency.LargeChange = 8;
			this.trackBar_Transparency.Location = new System.Drawing.Point(153, 68);
			this.trackBar_Transparency.Maximum = 256;
			this.trackBar_Transparency.Name = "trackBar_Transparency";
			this.trackBar_Transparency.Size = new System.Drawing.Size(128, 36);
			this.trackBar_Transparency.TabIndex = 4;
			this.trackBar_Transparency.TabStop = false;
			this.trackBar_Transparency.TickFrequency = 64;
			this.trackBar_Transparency.Value = 1;
			this.trackBar_Transparency.Scroll += new System.EventHandler(this.trackBar_Transparency_Scroll);
			// 
			// trackBar_AlphaCut
			// 
			this.trackBar_AlphaCut.AutoSize = false;
			this.trackBar_AlphaCut.LargeChange = 64;
			this.trackBar_AlphaCut.Location = new System.Drawing.Point(153, 26);
			this.trackBar_AlphaCut.Maximum = 256;
			this.trackBar_AlphaCut.Name = "trackBar_AlphaCut";
			this.trackBar_AlphaCut.Size = new System.Drawing.Size(128, 36);
			this.trackBar_AlphaCut.SmallChange = 8;
			this.trackBar_AlphaCut.TabIndex = 4;
			this.trackBar_AlphaCut.TabStop = false;
			this.trackBar_AlphaCut.TickFrequency = 64;
			this.trackBar_AlphaCut.Scroll += new System.EventHandler(this.trackBar_AlphaCut_Scroll);
			// 
			// button_SaveSprite
			// 
			this.button_SaveSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_SaveSprite.AutoSize = true;
			this.button_SaveSprite.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_SaveSprite.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button_SaveSprite.Location = new System.Drawing.Point(326, 176);
			this.button_SaveSprite.Name = "button_SaveSprite";
			this.button_SaveSprite.Size = new System.Drawing.Size(134, 30);
			this.button_SaveSprite.TabIndex = 3;
			this.button_SaveSprite.TabStop = false;
			this.button_SaveSprite.Text = "Save Sprite Sheet";
			this.button_SaveSprite.UseVisualStyleBackColor = true;
			this.button_SaveSprite.Click += new System.EventHandler(this.button_SaveSprite_Click);
			// 
			// label_Transparency
			// 
			this.label_Transparency.AutoSize = true;
			this.label_Transparency.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label_Transparency.Location = new System.Drawing.Point(287, 68);
			this.label_Transparency.Name = "label_Transparency";
			this.label_Transparency.Size = new System.Drawing.Size(17, 20);
			this.label_Transparency.TabIndex = 1;
			this.label_Transparency.Text = "1";
			// 
			// button_PreviewSprite
			// 
			this.button_PreviewSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_PreviewSprite.AutoSize = true;
			this.button_PreviewSprite.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_PreviewSprite.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button_PreviewSprite.Location = new System.Drawing.Point(390, 140);
			this.button_PreviewSprite.Name = "button_PreviewSprite";
			this.button_PreviewSprite.Size = new System.Drawing.Size(70, 30);
			this.button_PreviewSprite.TabIndex = 3;
			this.button_PreviewSprite.TabStop = false;
			this.button_PreviewSprite.Text = "Preview";
			this.button_PreviewSprite.UseVisualStyleBackColor = true;
			this.button_PreviewSprite.Click += new System.EventHandler(this.button_PreviewSprite_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(7, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(140, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "Transparency range:";
			this.toolTip.SetToolTip(this.label5, "Pixels with lower luminance value than this setting will be completely invisible");
			// 
			// label_AlphaCut
			// 
			this.label_AlphaCut.AutoSize = true;
			this.label_AlphaCut.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label_AlphaCut.Location = new System.Drawing.Point(287, 26);
			this.label_AlphaCut.Name = "label_AlphaCut";
			this.label_AlphaCut.Size = new System.Drawing.Size(17, 20);
			this.label_AlphaCut.TabIndex = 1;
			this.label_AlphaCut.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(6, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Alpha cut threshold:";
			this.toolTip.SetToolTip(this.label2, "Pixels with lower alpha value than this setting will be completely invisible");
			// 
			// groupBox_Template
			// 
			this.groupBox_Template.AutoSize = true;
			this.groupBox_Template.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox_Template.Controls.Add(this.button_SaveTemplate);
			this.groupBox_Template.Controls.Add(this.button_LoadTemplate);
			this.groupBox_Template.ForeColor = System.Drawing.Color.Navy;
			this.groupBox_Template.Location = new System.Drawing.Point(244, 14);
			this.groupBox_Template.Name = "groupBox_Template";
			this.groupBox_Template.Size = new System.Drawing.Size(130, 118);
			this.groupBox_Template.TabIndex = 2;
			this.groupBox_Template.TabStop = false;
			this.groupBox_Template.Text = "Template";
			// 
			// button_SaveTemplate
			// 
			this.button_SaveTemplate.AutoSize = true;
			this.button_SaveTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_SaveTemplate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button_SaveTemplate.Location = new System.Drawing.Point(6, 62);
			this.button_SaveTemplate.Name = "button_SaveTemplate";
			this.button_SaveTemplate.Size = new System.Drawing.Size(116, 30);
			this.button_SaveTemplate.TabIndex = 3;
			this.button_SaveTemplate.TabStop = false;
			this.button_SaveTemplate.Text = "Save Template";
			this.button_SaveTemplate.UseVisualStyleBackColor = true;
			this.button_SaveTemplate.Click += new System.EventHandler(this.button_SaveTemplate_Click);
			// 
			// button_LoadTemplate
			// 
			this.button_LoadTemplate.AutoSize = true;
			this.button_LoadTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_LoadTemplate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button_LoadTemplate.Location = new System.Drawing.Point(6, 26);
			this.button_LoadTemplate.Name = "button_LoadTemplate";
			this.button_LoadTemplate.Size = new System.Drawing.Size(118, 30);
			this.button_LoadTemplate.TabIndex = 3;
			this.button_LoadTemplate.TabStop = false;
			this.button_LoadTemplate.Text = "Load Template";
			this.button_LoadTemplate.UseVisualStyleBackColor = true;
			this.button_LoadTemplate.Click += new System.EventHandler(this.button_LoadTemplate_Click);
			// 
			// groupBox_Render
			// 
			this.groupBox_Render.AutoSize = true;
			this.groupBox_Render.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox_Render.Controls.Add(this.textBox_RenderSymbol);
			this.groupBox_Render.Controls.Add(this.textBox_RenderPosition);
			this.groupBox_Render.Controls.Add(this.label4);
			this.groupBox_Render.Controls.Add(this.textBox_RenderRotation);
			this.groupBox_Render.Controls.Add(this.label3);
			this.groupBox_Render.Controls.Add(this.label6);
			this.groupBox_Render.Controls.Add(this.textBox_RenderScale);
			this.groupBox_Render.Controls.Add(this.label1);
			this.groupBox_Render.ForeColor = System.Drawing.Color.Navy;
			this.groupBox_Render.Location = new System.Drawing.Point(3, 3);
			this.groupBox_Render.Name = "groupBox_Render";
			this.groupBox_Render.Size = new System.Drawing.Size(235, 178);
			this.groupBox_Render.TabIndex = 2;
			this.groupBox_Render.TabStop = false;
			this.groupBox_Render.Text = "Object";
			// 
			// textBox_RenderSymbol
			// 
			this.textBox_RenderSymbol.Location = new System.Drawing.Point(81, 26);
			this.textBox_RenderSymbol.Name = "textBox_RenderSymbol";
			this.textBox_RenderSymbol.Size = new System.Drawing.Size(148, 27);
			this.textBox_RenderSymbol.TabIndex = 1;
			this.textBox_RenderSymbol.TabStop = false;
			this.textBox_RenderSymbol.TextChanged += new System.EventHandler(this.textBox_RenderSymbol_TextChanged);
			this.textBox_RenderSymbol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_RenderSymbol_KeyDown);
			// 
			// textBox_RenderPosition
			// 
			this.textBox_RenderPosition.Location = new System.Drawing.Point(81, 59);
			this.textBox_RenderPosition.Name = "textBox_RenderPosition";
			this.textBox_RenderPosition.Size = new System.Drawing.Size(148, 27);
			this.textBox_RenderPosition.TabIndex = 2;
			this.textBox_RenderPosition.TextChanged += new System.EventHandler(this.textBox_RenderPosition_TextChanged);
			this.textBox_RenderPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_RenderPosition_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(28, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 20);
			this.label4.TabIndex = 1;
			this.label4.Text = "Scale:";
			// 
			// textBox_RenderRotation
			// 
			this.textBox_RenderRotation.Location = new System.Drawing.Point(81, 92);
			this.textBox_RenderRotation.Name = "textBox_RenderRotation";
			this.textBox_RenderRotation.Size = new System.Drawing.Size(148, 27);
			this.textBox_RenderRotation.TabIndex = 3;
			this.textBox_RenderRotation.TextChanged += new System.EventHandler(this.textBox_RenderRotation_TextChanged);
			this.textBox_RenderRotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_RenderRotation_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(6, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Rotation:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(11, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 20);
			this.label6.TabIndex = 1;
			this.label6.Text = "Symbol:";
			// 
			// textBox_RenderScale
			// 
			this.textBox_RenderScale.Location = new System.Drawing.Point(81, 125);
			this.textBox_RenderScale.Name = "textBox_RenderScale";
			this.textBox_RenderScale.Size = new System.Drawing.Size(148, 27);
			this.textBox_RenderScale.TabIndex = 4;
			this.textBox_RenderScale.TextChanged += new System.EventHandler(this.textBox_RenderScale_TextChanged);
			this.textBox_RenderScale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_RenderScale_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(11, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Position:";
			// 
			// drawBox_Symbol
			// 
			this.drawBox_Symbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.drawBox_Symbol.BackgroundImage = global::LF2.Sprite_Sheet_Generator.Properties.Resources.check;
			this.drawBox_Symbol.BackgroundInterpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.drawBox_Symbol.ControlKey = false;
			this.drawBox_Symbol.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.drawBox_Symbol.Location = new System.Drawing.Point(303, 3);
			this.drawBox_Symbol.MultiRectangleMode = false;
			this.drawBox_Symbol.Name = "drawBox_Symbol";
			this.drawBox_Symbol.OneRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.drawBox_Symbol.PictureMode = LF2.Sprite_Sheet_Generator.PictureMode.ShrinkOnly;
			this.drawBox_Symbol.Rectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.drawBox_Symbol.Rectangles = ((System.Collections.Generic.List<System.Drawing.Rectangle>)(resources.GetObject("drawBox_Symbol.Rectangles")));
			this.drawBox_Symbol.ShiftKey = false;
			this.drawBox_Symbol.Size = new System.Drawing.Size(175, 170);
			this.drawBox_Symbol.TabIndex = 2;
			this.drawBox_Symbol.TabStop = false;
			this.drawBox_Symbol.Trancparency = true;
			// 
			// checkBox_RenderTransparency
			// 
			this.checkBox_RenderTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_RenderTransparency.AutoSize = true;
			this.checkBox_RenderTransparency.Checked = true;
			this.checkBox_RenderTransparency.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_RenderTransparency.Location = new System.Drawing.Point(289, 179);
			this.checkBox_RenderTransparency.Name = "checkBox_RenderTransparency";
			this.checkBox_RenderTransparency.Size = new System.Drawing.Size(189, 24);
			this.checkBox_RenderTransparency.TabIndex = 1;
			this.checkBox_RenderTransparency.TabStop = false;
			this.checkBox_RenderTransparency.Text = "Transparent black pixels";
			this.toolTip.SetToolTip(this.checkBox_RenderTransparency, "Controls whether black pixels will be invisible similar to LF2\r\nIn order to get t" +
        "he same effect while generating the sprite\r\nsheet set transparency range to 1");
			this.checkBox_RenderTransparency.UseVisualStyleBackColor = true;
			this.checkBox_RenderTransparency.CheckedChanged += new System.EventHandler(this.checkBox_SymbolsTransparency_CheckedChanged);
			// 
			// listBox_Symbols
			// 
			this.listBox_Symbols.AllowDrop = true;
			this.listBox_Symbols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox_Symbols.FormattingEnabled = true;
			this.listBox_Symbols.ItemHeight = 20;
			this.listBox_Symbols.Location = new System.Drawing.Point(3, 3);
			this.listBox_Symbols.Name = "listBox_Symbols";
			this.listBox_Symbols.Size = new System.Drawing.Size(250, 164);
			this.listBox_Symbols.TabIndex = 0;
			this.listBox_Symbols.TabStop = false;
			this.listBox_Symbols.SelectedIndexChanged += new System.EventHandler(this.listBox_Symbols_SelectedIndexChanged);
			this.listBox_Symbols.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_Symbols_DragDrop);
			this.listBox_Symbols.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_Symbols_DragEnter);
			this.listBox_Symbols.DoubleClick += new System.EventHandler(this.listBox_Symbols_DoubleClick);
			// 
			// button_AddRender
			// 
			this.button_AddRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_AddRender.Location = new System.Drawing.Point(3, 173);
			this.button_AddRender.Name = "button_AddRender";
			this.button_AddRender.Size = new System.Drawing.Size(142, 30);
			this.button_AddRender.TabIndex = 3;
			this.button_AddRender.TabStop = false;
			this.button_AddRender.Text = "< Add Symbol";
			this.toolTip.SetToolTip(this.button_AddRender, "Add selected symbol as an object");
			this.button_AddRender.UseVisualStyleBackColor = true;
			this.button_AddRender.Click += new System.EventHandler(this.listBox_Symbols_DoubleClick);
			// 
			// button_RenameSymbol
			// 
			this.button_RenameSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_RenameSymbol.Location = new System.Drawing.Point(173, 173);
			this.button_RenameSymbol.Name = "button_RenameSymbol";
			this.button_RenameSymbol.Size = new System.Drawing.Size(80, 30);
			this.button_RenameSymbol.TabIndex = 3;
			this.button_RenameSymbol.TabStop = false;
			this.button_RenameSymbol.Text = "Rename";
			this.toolTip.SetToolTip(this.button_RenameSymbol, "Rename selected symbol on the list\r\nIt will invalidate objects referring to this " +
        "symbol");
			this.button_RenameSymbol.UseVisualStyleBackColor = true;
			this.button_RenameSymbol.Click += new System.EventHandler(this.button_RenameSymbol_Click);
			// 
			// button_RemoveSymbol
			// 
			this.button_RemoveSymbol.AutoSize = true;
			this.button_RemoveSymbol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_RemoveSymbol.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button_RemoveSymbol.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.minus;
			this.button_RemoveSymbol.Location = new System.Drawing.Point(259, 47);
			this.button_RemoveSymbol.Name = "button_RemoveSymbol";
			this.button_RemoveSymbol.Size = new System.Drawing.Size(38, 38);
			this.button_RemoveSymbol.TabIndex = 3;
			this.button_RemoveSymbol.TabStop = false;
			this.toolTip.SetToolTip(this.button_RemoveSymbol, "Remove selected symbol\r\nIt will invalidate objects referring to the symbol");
			this.button_RemoveSymbol.UseVisualStyleBackColor = false;
			this.button_RemoveSymbol.Click += new System.EventHandler(this.button_RemoveSymbol_Click);
			// 
			// button_MoveDown
			// 
			this.button_MoveDown.AutoSize = true;
			this.button_MoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_MoveDown.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button_MoveDown.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.down;
			this.button_MoveDown.Location = new System.Drawing.Point(259, 135);
			this.button_MoveDown.Name = "button_MoveDown";
			this.button_MoveDown.Size = new System.Drawing.Size(38, 38);
			this.button_MoveDown.TabIndex = 3;
			this.button_MoveDown.TabStop = false;
			this.toolTip.SetToolTip(this.button_MoveDown, "Move symbol down on the list");
			this.button_MoveDown.UseVisualStyleBackColor = false;
			this.button_MoveDown.Click += new System.EventHandler(this.button_MoveDown_Click);
			// 
			// button_AddSymbol
			// 
			this.button_AddSymbol.AutoSize = true;
			this.button_AddSymbol.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_AddSymbol.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button_AddSymbol.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.plus;
			this.button_AddSymbol.Location = new System.Drawing.Point(259, 3);
			this.button_AddSymbol.Name = "button_AddSymbol";
			this.button_AddSymbol.Size = new System.Drawing.Size(38, 38);
			this.button_AddSymbol.TabIndex = 3;
			this.button_AddSymbol.TabStop = false;
			this.toolTip.SetToolTip(this.button_AddSymbol, "Add an image file as symbol");
			this.button_AddSymbol.UseVisualStyleBackColor = false;
			this.button_AddSymbol.Click += new System.EventHandler(this.button_AddSymbol_Click);
			// 
			// button_MoveUp
			// 
			this.button_MoveUp.AutoSize = true;
			this.button_MoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_MoveUp.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.button_MoveUp.Image = global::LF2.Sprite_Sheet_Generator.Properties.Resources.up;
			this.button_MoveUp.Location = new System.Drawing.Point(259, 91);
			this.button_MoveUp.Name = "button_MoveUp";
			this.button_MoveUp.Size = new System.Drawing.Size(38, 38);
			this.button_MoveUp.TabIndex = 3;
			this.button_MoveUp.TabStop = false;
			this.toolTip.SetToolTip(this.button_MoveUp, "Move symbol up on the list");
			this.button_MoveUp.UseVisualStyleBackColor = false;
			this.button_MoveUp.Click += new System.EventHandler(this.button_MoveUp_Click);
			// 
			// colorDialog
			// 
			this.colorDialog.FullOpen = true;
			// 
			// openFileDialog_Image
			// 
			this.openFileDialog_Image.Filter = "Image Files (*.bmp;*.dib;*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.emf;*.tif;*.tiff" +
    ";*.wmf)|*.bmp;*.dib;*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.emf;*.tif;*.tiff;*.w" +
    "mf";
			this.openFileDialog_Image.Multiselect = true;
			this.openFileDialog_Image.ReadOnlyChecked = true;
			this.openFileDialog_Image.RestoreDirectory = true;
			this.openFileDialog_Image.Title = "Open Image...";
			// 
			// saveFileDialog_Sprite
			// 
			this.saveFileDialog_Sprite.DefaultExt = "bmp";
			this.saveFileDialog_Sprite.Filter = "Bitmap Image (*.bmp)|*.bmp";
			this.saveFileDialog_Sprite.RestoreDirectory = true;
			// 
			// saveFileDialog_Template
			// 
			this.saveFileDialog_Template.DefaultExt = "xml";
			this.saveFileDialog_Template.Filter = "Sprite Sheet Template (*.xml)|*.xml";
			this.saveFileDialog_Template.RestoreDirectory = true;
			// 
			// openFileDialog_Template
			// 
			this.openFileDialog_Template.Filter = "Sprite Sheet Templates (*.xml)|*.xml";
			this.openFileDialog_Template.Multiselect = true;
			this.openFileDialog_Template.ReadOnlyChecked = true;
			this.openFileDialog_Template.RestoreDirectory = true;
			this.openFileDialog_Template.Title = "Open Image...";
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 10000;
			this.toolTip.InitialDelay = 500;
			this.toolTip.ReshowDelay = 100;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 673);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.toolBox);
			this.Controls.Add(this.statusStrip);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LF2 Sprite Sheet Generator";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolBox.ResumeLayout(false);
			this.toolBox.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel_ObjectProperties.ResumeLayout(false);
			this.panel_ObjectProperties.PerformLayout();
			this.groupBox_Sprite.ResumeLayout(false);
			this.groupBox_Sprite.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Transparency)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_AlphaCut)).EndInit();
			this.groupBox_Template.ResumeLayout(false);
			this.groupBox_Template.PerformLayout();
			this.groupBox_Render.ResumeLayout(false);
			this.groupBox_Render.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStrip toolBox;
		private System.Windows.Forms.SplitContainer splitContainer;
		private TemplateBox templateBox;
		private BetterToolStripDropDownButton toolStripDropDownButton_BackgroundStyle;
		private BetterToolStripMenuItem toolStripMenuItem_ChessBoard;
		private BetterToolStripMenuItem toolStripMenuItem_Color;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AdjustColor;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.CheckBox checkBox_RenderTransparency;
		private System.Windows.Forms.ListBox listBox_Symbols;
		private BetterToolStripButton toolStripButton_Transparency;
		private DrawBox drawBox_Symbol;
		private System.Windows.Forms.OpenFileDialog openFileDialog_Image;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Offset;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Zoom;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.Button button_MoveDown;
		private System.Windows.Forms.Button button_MoveUp;
		private System.Windows.Forms.Button button_RemoveSymbol;
		private System.Windows.Forms.Button button_AddSymbol;
		private System.Windows.Forms.Button button_RenameSymbol;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private BetterToolStripButton betterToolStripButton_BringToFront;
		private BetterToolStripButton betterToolStripButton_SendToBack;
		private BetterToolStripButton toolStripButton_Move;
		private BetterToolStripButton toolStripButton_Rotate;
		private BetterToolStripButton toolStripButton_Scale;
		private BetterToolStripButton toolStripButton_ScaleFit;
		private BetterToolStripButton toolStripButton_Scale1;
		private BetterToolStripButton toolStripButton_Scale2;
		private System.Windows.Forms.Panel panel_ObjectProperties;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_RenderScale;
		private System.Windows.Forms.TextBox textBox_RenderRotation;
		private System.Windows.Forms.TextBox textBox_RenderPosition;
		private System.Windows.Forms.Button button_AddRender;
		private System.Windows.Forms.GroupBox groupBox_Render;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Sprite;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_Template;
		private System.Windows.Forms.GroupBox groupBox_Sprite;
		private System.Windows.Forms.CheckBox checkBox_RenderGuide;
		private System.Windows.Forms.TrackBar trackBar_AlphaCut;
		private System.Windows.Forms.Button button_SaveSprite;
		private System.Windows.Forms.Button button_PreviewSprite;
		private System.Windows.Forms.GroupBox groupBox_Template;
		private System.Windows.Forms.Button button_SaveTemplate;
		private System.Windows.Forms.Button button_LoadTemplate;
		private System.Windows.Forms.Label label_AlphaCut;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar trackBar_Transparency;
		private System.Windows.Forms.Label label_Transparency;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.OpenFileDialog openFileDialog_Template;
		private System.Windows.Forms.CheckBox checkBox_AlphaChannel;
		private BetterToolStripButton toolStripButton_Scale4;
		private System.Windows.Forms.TextBox textBox_RenderSymbol;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolTip toolTip;
		private BetterToolStripDropDownButton toolStripDropDownButton_GuideImage;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CreateEmptyGrid;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Opacity;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LoadFromFile;
	}
}

