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
            this.groupConnection = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblBaud = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.panelTab = new System.Windows.Forms.TabControl();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.numBrightness = new System.Windows.Forms.NumericUpDown();
            this.slideBrightness = new Cyotek.Windows.Forms.LightnessColorSlider();
            this.groupColor = new System.Windows.Forms.GroupBox();
            this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.colorGrid = new Cyotek.Windows.Forms.ColorGrid();
            this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.timerHeartBeat = new System.Windows.Forms.Timer(this.components);
            this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
            this.groupBrightness = new System.Windows.Forms.GroupBox();
            this.groupMode = new System.Windows.Forms.GroupBox();
            this.groupConnection.SuspendLayout();
            this.panelTab.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.panelMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).BeginInit();
            this.groupColor.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.groupBrightness.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupConnection
            // 
            this.groupConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupConnection.Controls.Add(this.btnDisconnect);
            this.groupConnection.Controls.Add(this.btnConnect);
            this.groupConnection.Controls.Add(this.lblBaud);
            this.groupConnection.Controls.Add(this.lblPort);
            this.groupConnection.Controls.Add(this.cmbBaud);
            this.groupConnection.Controls.Add(this.cmbPort);
            this.groupConnection.Location = new System.Drawing.Point(12, 12);
            this.groupConnection.Name = "groupConnection";
            this.groupConnection.Size = new System.Drawing.Size(550, 77);
            this.groupConnection.TabIndex = 0;
            this.groupConnection.TabStop = false;
            this.groupConnection.Text = "Connection";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(469, 44);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(469, 17);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Location = new System.Drawing.Point(6, 49);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(32, 13);
            this.lblBaud.TabIndex = 3;
            this.lblBaud.Text = "Baud";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 22);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port";
            // 
            // cmbBaud
            // 
            this.cmbBaud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Location = new System.Drawing.Point(71, 46);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(392, 21);
            this.cmbBaud.TabIndex = 1;
            // 
            // cmbPort
            // 
            this.cmbPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(71, 19);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(392, 21);
            this.cmbPort.TabIndex = 0;
            // 
            // panelTab
            // 
            this.panelTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTab.Controls.Add(this.tabControl);
            this.panelTab.Controls.Add(this.tabConsole);
            this.panelTab.Location = new System.Drawing.Point(12, 95);
            this.panelTab.Name = "panelTab";
            this.panelTab.SelectedIndex = 0;
            this.panelTab.Size = new System.Drawing.Size(550, 417);
            this.panelTab.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.panelMaster);
            this.tabControl.Location = new System.Drawing.Point(4, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl.Size = new System.Drawing.Size(542, 391);
            this.tabControl.TabIndex = 0;
            this.tabControl.Text = "Color Control";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // panelMaster
            // 
            this.panelMaster.Controls.Add(this.groupMode);
            this.panelMaster.Controls.Add(this.groupBrightness);
            this.panelMaster.Controls.Add(this.groupColor);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Enabled = false;
            this.panelMaster.Location = new System.Drawing.Point(3, 3);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(536, 385);
            this.panelMaster.TabIndex = 0;
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
            // groupColor
            // 
            this.groupColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupColor.Controls.Add(this.colorWheel);
            this.groupColor.Controls.Add(this.previewPanel);
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
            this.colorWheel.Size = new System.Drawing.Size(192, 128);
            this.colorWheel.TabIndex = 11;
            this.colorWheel.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // previewPanel
            // 
            this.previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewPanel.Location = new System.Drawing.Point(451, 110);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(73, 115);
            this.previewPanel.TabIndex = 10;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPanel_Paint);
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
            this.screenColorPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.screenColorPicker.Color = System.Drawing.Color.Black;
            this.screenColorPicker.Location = new System.Drawing.Point(451, 19);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(73, 85);
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
            this.colorEditor.Size = new System.Drawing.Size(241, 206);
            this.colorEditor.TabIndex = 9;
            this.colorEditor.ColorChanged += new System.EventHandler(this.OnColorChanged);
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.txtLog);
            this.tabConsole.Controls.Add(this.btnSend);
            this.tabConsole.Controls.Add(this.txtMsg);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(542, 391);
            this.tabConsole.TabIndex = 1;
            this.tabConsole.Text = "Serial Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(6, 6);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(530, 351);
            this.txtLog.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(461, 363);
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
            this.txtMsg.Location = new System.Drawing.Point(6, 365);
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
            // groupMode
            // 
            this.groupMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMode.Location = new System.Drawing.Point(3, 292);
            this.groupMode.Name = "groupMode";
            this.groupMode.Size = new System.Drawing.Size(530, 90);
            this.groupMode.TabIndex = 17;
            this.groupMode.TabStop = false;
            this.groupMode.Text = "Mode";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 531);
            this.Controls.Add(this.panelTab);
            this.Controls.Add(this.groupConnection);
            this.MinimumSize = new System.Drawing.Size(590, 570);
            this.Name = "MainForm";
            this.Text = "Arduino RGB Case";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupConnection.ResumeLayout(false);
            this.groupConnection.PerformLayout();
            this.panelTab.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.panelMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).EndInit();
            this.groupColor.ResumeLayout(false);
            this.groupColor.PerformLayout();
            this.tabConsole.ResumeLayout(false);
            this.tabConsole.PerformLayout();
            this.groupBrightness.ResumeLayout(false);
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
        private System.Windows.Forms.Panel previewPanel;
        private Cyotek.Windows.Forms.ColorGrid colorGrid;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker;
        private Cyotek.Windows.Forms.ColorEditor colorEditor;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager;
        private Cyotek.Windows.Forms.LightnessColorSlider slideBrightness;
        private System.Windows.Forms.NumericUpDown numBrightness;
        private System.Windows.Forms.GroupBox groupBrightness;
        private System.Windows.Forms.GroupBox groupMode;
    }
}

