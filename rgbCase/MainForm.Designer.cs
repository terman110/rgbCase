namespace rgbCase
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupConnection = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblBaud = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTab = new System.Windows.Forms.TabControl();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBrightness = new System.Windows.Forms.GroupBox();
            this.slideBrightness = new Cyotek.Windows.Forms.LightnessColorSlider();
            this.numBrightness = new System.Windows.Forms.NumericUpDown();
            this.groupMode = new System.Windows.Forms.GroupBox();
            this.panelParam = new System.Windows.Forms.Panel();
            this.comboMode = new System.Windows.Forms.ComboBox();
            this.groupColor = new System.Windows.Forms.GroupBox();
            this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendMode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModeP2 = new System.Windows.Forms.TextBox();
            this.txtModeP1 = new System.Windows.Forms.TextBox();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.timerHeartBeat = new System.Windows.Forms.Timer(this.components);
            this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
            this.barNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewPanel = new rgbCase.DoubleBufferPanel();
            this.groupConnection.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelTab.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.panelMaster.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBrightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).BeginInit();
            this.groupMode.SuspendLayout();
            this.groupColor.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupConnection
            // 
            this.groupConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupConnection.Controls.Add(this.tableLayoutPanel2);
            this.groupConnection.Location = new System.Drawing.Point(12, 12);
            this.groupConnection.Name = "groupConnection";
            this.groupConnection.Size = new System.Drawing.Size(550, 48);
            this.groupConnection.TabIndex = 0;
            this.groupConnection.TabStop = false;
            this.groupConnection.Text = "Connection";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.cmbPort, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbBaud, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDisconnect, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBaud, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPort, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnConnect, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 6, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(544, 29);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // cmbPort
            // 
            this.cmbPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(197, 3);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(109, 21);
            this.cmbPort.TabIndex = 0;
            // 
            // cmbBaud
            // 
            this.cmbBaud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Location = new System.Drawing.Point(350, 3);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(109, 21);
            this.cmbBaud.TabIndex = 1;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(84, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaud.Location = new System.Drawing.Point(312, 0);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(32, 29);
            this.lblBaud.TabIndex = 3;
            this.lblBaud.Text = "Baud";
            this.lblBaud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPort.Location = new System.Drawing.Point(165, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 29);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(3, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(466, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelTab
            // 
            this.panelTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTab.Controls.Add(this.tabControl);
            this.panelTab.Controls.Add(this.tabConsole);
            this.panelTab.Location = new System.Drawing.Point(12, 60);
            this.panelTab.Name = "panelTab";
            this.panelTab.SelectedIndex = 0;
            this.panelTab.Size = new System.Drawing.Size(550, 439);
            this.panelTab.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.panelMaster);
            this.tabControl.Location = new System.Drawing.Point(4, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl.Size = new System.Drawing.Size(542, 413);
            this.tabControl.TabIndex = 0;
            this.tabControl.Text = "Color Control";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // panelMaster
            // 
            this.panelMaster.Controls.Add(this.tableLayoutPanel1);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Enabled = false;
            this.panelMaster.Location = new System.Drawing.Point(3, 3);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(536, 407);
            this.panelMaster.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBrightness, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupMode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupColor, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 407);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // groupBrightness
            // 
            this.groupBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBrightness.Controls.Add(this.slideBrightness);
            this.groupBrightness.Controls.Add(this.numBrightness);
            this.groupBrightness.Location = new System.Drawing.Point(3, 3);
            this.groupBrightness.Name = "groupBrightness";
            this.groupBrightness.Size = new System.Drawing.Size(530, 47);
            this.groupBrightness.TabIndex = 16;
            this.groupBrightness.TabStop = false;
            this.groupBrightness.Text = "Brightness";
            // 
            // slideBrightness
            // 
            this.slideBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.slideBrightness.Color = System.Drawing.Color.White;
            this.slideBrightness.Location = new System.Drawing.Point(6, 19);
            this.slideBrightness.Name = "slideBrightness";
            this.slideBrightness.Size = new System.Drawing.Size(435, 20);
            this.slideBrightness.TabIndex = 14;
            this.slideBrightness.Value = 100F;
            this.slideBrightness.ValueChanged += new System.EventHandler(this.numBrightness_ValueChanged);
            // 
            // numBrightness
            // 
            this.numBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numBrightness.Location = new System.Drawing.Point(447, 19);
            this.numBrightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBrightness.Name = "numBrightness";
            this.numBrightness.Size = new System.Drawing.Size(77, 20);
            this.numBrightness.TabIndex = 15;
            this.numBrightness.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBrightness.ValueChanged += new System.EventHandler(this.numBrightness_ValueChanged);
            // 
            // groupMode
            // 
            this.groupMode.Controls.Add(this.panelParam);
            this.groupMode.Controls.Add(this.comboMode);
            this.groupMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMode.Location = new System.Drawing.Point(3, 293);
            this.groupMode.Name = "groupMode";
            this.groupMode.Size = new System.Drawing.Size(530, 111);
            this.groupMode.TabIndex = 17;
            this.groupMode.TabStop = false;
            this.groupMode.Text = "Mode";
            // 
            // panelParam
            // 
            this.panelParam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelParam.Location = new System.Drawing.Point(133, 19);
            this.panelParam.Margin = new System.Windows.Forms.Padding(0);
            this.panelParam.Name = "panelParam";
            this.panelParam.Size = new System.Drawing.Size(391, 86);
            this.panelParam.TabIndex = 1;
            // 
            // comboMode
            // 
            this.comboMode.FormattingEnabled = true;
            this.comboMode.Location = new System.Drawing.Point(6, 19);
            this.comboMode.Name = "comboMode";
            this.comboMode.Size = new System.Drawing.Size(121, 21);
            this.comboMode.TabIndex = 0;
            this.comboMode.SelectedIndexChanged += new System.EventHandler(this.comboMode_SelectedIndexChanged);
            // 
            // groupColor
            // 
            this.groupColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupColor.Controls.Add(this.colorWheel);
            this.groupColor.Controls.Add(this.colorGrid);
            this.groupColor.Controls.Add(this.screenColorPicker);
            this.groupColor.Controls.Add(this.colorEditor);
            this.groupColor.Location = new System.Drawing.Point(3, 56);
            this.groupColor.MinimumSize = new System.Drawing.Size(530, 231);
            this.groupColor.Name = "groupColor";
            this.groupColor.Size = new System.Drawing.Size(530, 231);
            this.groupColor.TabIndex = 13;
            this.groupColor.TabStop = false;
            this.groupColor.Text = "Select Color";
            // 
            // colorWheel
            // 
            this.colorWheel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel.Location = new System.Drawing.Point(6, 19);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new System.Drawing.Size(121, 128);
            this.colorWheel.TabIndex = 11;
            this.colorWheel.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // colorGrid
            // 
            this.colorGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorGrid.AutoAddColors = false;
            this.colorGrid.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
            this.colorGrid.EditMode = Cyotek.Windows.Forms.ColorEditingMode.Both;
            this.colorGrid.Location = new System.Drawing.Point(6, 153);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(0);
            this.colorGrid.Palette = Cyotek.Windows.Forms.ColorPalette.Paint;
            this.colorGrid.SelectedCellStyle = Cyotek.Windows.Forms.ColorGridSelectedCellStyle.Standard;
            this.colorGrid.ShowCustomColors = false;
            this.colorGrid.Size = new System.Drawing.Size(192, 72);
            this.colorGrid.Spacing = new System.Drawing.Size(0, 0);
            this.colorGrid.TabIndex = 12;
            this.colorGrid.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // screenColorPicker
            // 
            this.screenColorPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.screenColorPicker.Color = System.Drawing.Color.Black;
            this.screenColorPicker.Location = new System.Drawing.Point(133, 19);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(65, 128);
            this.screenColorPicker.Zoom = 6;
            this.screenColorPicker.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // colorEditor
            // 
            this.colorEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEditor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorEditor.Location = new System.Drawing.Point(204, 19);
            this.colorEditor.Name = "colorEditor";
            this.colorEditor.ShowAlphaChannel = false;
            this.colorEditor.Size = new System.Drawing.Size(320, 206);
            this.colorEditor.TabIndex = 9;
            this.colorEditor.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.label3);
            this.tabConsole.Controls.Add(this.label2);
            this.tabConsole.Controls.Add(this.btnSendMode);
            this.tabConsole.Controls.Add(this.label1);
            this.tabConsole.Controls.Add(this.txtModeP2);
            this.tabConsole.Controls.Add(this.txtModeP1);
            this.tabConsole.Controls.Add(this.txtMode);
            this.tabConsole.Controls.Add(this.checkLog);
            this.tabConsole.Controls.Add(this.txtLog);
            this.tabConsole.Controls.Add(this.btnSend);
            this.tabConsole.Controls.Add(this.txtMsg);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(542, 413);
            this.tabConsole.TabIndex = 1;
            this.tabConsole.Text = "Serial Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Param 2";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Param 1";
            // 
            // btnSendMode
            // 
            this.btnSendMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMode.Enabled = false;
            this.btnSendMode.Location = new System.Drawing.Point(461, 387);
            this.btnSendMode.Name = "btnSendMode";
            this.btnSendMode.Size = new System.Drawing.Size(75, 23);
            this.btnSendMode.TabIndex = 8;
            this.btnSendMode.Text = "Send";
            this.btnSendMode.UseVisualStyleBackColor = true;
            this.btnSendMode.Click += new System.EventHandler(this.btnSendMode_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mode";
            // 
            // txtModeP2
            // 
            this.txtModeP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtModeP2.Enabled = false;
            this.txtModeP2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModeP2.Location = new System.Drawing.Point(304, 389);
            this.txtModeP2.Name = "txtModeP2";
            this.txtModeP2.Size = new System.Drawing.Size(71, 18);
            this.txtModeP2.TabIndex = 6;
            // 
            // txtModeP1
            // 
            this.txtModeP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtModeP1.Enabled = false;
            this.txtModeP1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModeP1.Location = new System.Drawing.Point(175, 389);
            this.txtModeP1.Name = "txtModeP1";
            this.txtModeP1.Size = new System.Drawing.Size(71, 18);
            this.txtModeP1.TabIndex = 5;
            // 
            // txtMode
            // 
            this.txtMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMode.Enabled = false;
            this.txtMode.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMode.Location = new System.Drawing.Point(46, 389);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(71, 18);
            this.txtMode.TabIndex = 4;
            // 
            // checkLog
            // 
            this.checkLog.AutoSize = true;
            this.checkLog.Location = new System.Drawing.Point(6, 6);
            this.checkLog.Name = "checkLog";
            this.checkLog.Size = new System.Drawing.Size(86, 17);
            this.checkLog.TabIndex = 3;
            this.checkLog.Text = "Log Enabled";
            this.checkLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(6, 29);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(530, 327);
            this.txtLog.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(461, 358);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.Enabled = false;
            this.txtMsg.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(6, 362);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(449, 18);
            this.txtMsg.TabIndex = 0;
            this.txtMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMsg_KeyDown);
            // 
            // timerHeartBeat
            // 
            this.timerHeartBeat.Interval = 5000;
            this.timerHeartBeat.Tick += new System.EventHandler(this.timerHeartBeat_Tick);
            // 
            // colorEditorManager
            // 
            this.colorEditorManager.ColorEditor = this.colorEditor;
            this.colorEditorManager.ColorGrid = this.colorGrid;
            this.colorEditorManager.ColorWheel = this.colorWheel;
            this.colorEditorManager.ScreenColorPicker = this.screenColorPicker;
            // 
            // barNotifyIcon
            // 
            this.barNotifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.barNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("barNotifyIcon.Icon")));
            this.barNotifyIcon.Text = "notifyIcon1";
            this.barNotifyIcon.Visible = true;
            this.barNotifyIcon.DoubleClick += new System.EventHandler(this.showToolStripMenuItem_Click);
            this.barNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.barNotifyIcon_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // previewPanel
            // 
            this.previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewPanel.Location = new System.Drawing.Point(9, 505);
            this.previewPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(556, 17);
            this.previewPanel.TabIndex = 10;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 531);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.panelTab);
            this.Controls.Add(this.groupConnection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(590, 570);
            this.Name = "MainForm";
            this.Text = "Arduino RGB Case";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupConnection.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelTab.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.panelMaster.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBrightness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).EndInit();
            this.groupMode.ResumeLayout(false);
            this.groupColor.ResumeLayout(false);
            this.groupColor.PerformLayout();
            this.tabConsole.ResumeLayout(false);
            this.tabConsole.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupConnection;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.TabControl panelTab;
        private System.Windows.Forms.TabPage tabControl;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Panel panelMaster;
        private System.Windows.Forms.Timer timerHeartBeat;
        private System.Windows.Forms.GroupBox groupColor;
        private Cyotek.Windows.Forms.ColorWheel colorWheel;
        private DoubleBufferPanel previewPanel;
        private Cyotek.Windows.Forms.ColorGrid colorGrid;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker;
        private Cyotek.Windows.Forms.ColorEditor colorEditor;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager;
        private Cyotek.Windows.Forms.LightnessColorSlider slideBrightness;
        private System.Windows.Forms.NumericUpDown numBrightness;
        private System.Windows.Forms.GroupBox groupBrightness;
        private System.Windows.Forms.GroupBox groupMode;
        private System.Windows.Forms.ComboBox comboMode;
        private System.Windows.Forms.CheckBox checkLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelParam;
        private System.Windows.Forms.NotifyIcon barNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSendMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModeP2;
        private System.Windows.Forms.TextBox txtModeP1;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Button btnClose;
    }
}

