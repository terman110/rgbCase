namespace rgbCase.Effects
{
    partial class BreathingCycle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mMinBright = new System.Windows.Forms.NumericUpDown();
            this.mMaxBright = new System.Windows.Forms.NumericUpDown();
            this.mDelay = new System.Windows.Forms.NumericUpDown();
            this.mController = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mMinBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMaxBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.mMinBright, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.mMaxBright, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.mDelay, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.mController, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 150);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min Brightness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max Brightness";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Delay [ms]";
            // 
            // mMinBright
            // 
            this.mMinBright.Location = new System.Drawing.Point(78, 3);
            this.mMinBright.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.mMinBright.Name = "mMinBright";
            this.mMinBright.Size = new System.Drawing.Size(69, 20);
            this.mMinBright.TabIndex = 3;
            this.mMinBright.ValueChanged += new System.EventHandler(this.mMinBright_ValueChanged);
            // 
            // mMaxBright
            // 
            this.mMaxBright.Location = new System.Drawing.Point(78, 29);
            this.mMaxBright.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.mMaxBright.Name = "mMaxBright";
            this.mMaxBright.Size = new System.Drawing.Size(69, 20);
            this.mMaxBright.TabIndex = 4;
            this.mMaxBright.ValueChanged += new System.EventHandler(this.mMaxBright_ValueChanged);
            // 
            // mDelay
            // 
            this.mDelay.Location = new System.Drawing.Point(78, 55);
            this.mDelay.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.mDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mDelay.Name = "mDelay";
            this.mDelay.Size = new System.Drawing.Size(69, 20);
            this.mDelay.TabIndex = 5;
            this.mDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mController
            // 
            this.mController.AutoSize = true;
            this.mController.Enabled = false;
            this.mController.Location = new System.Drawing.Point(78, 81);
            this.mController.Name = "mController";
            this.mController.Size = new System.Drawing.Size(69, 17);
            this.mController.TabIndex = 7;
            this.mController.Text = "Controller based";
            this.mController.UseVisualStyleBackColor = true;
            this.mController.CheckedChanged += new System.EventHandler(this.mController_CheckedChanged);
            // 
            // BreathingCycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BreathingCycle";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mMinBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMaxBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown mMinBright;
        private System.Windows.Forms.NumericUpDown mMaxBright;
        private System.Windows.Forms.NumericUpDown mDelay;
        private System.Windows.Forms.CheckBox mController;
    }
}
