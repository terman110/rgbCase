namespace rgbCase.Effects
{
    partial class Strobing
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mMinBright = new System.Windows.Forms.NumericUpDown();
            this.mMaxBright = new System.Windows.Forms.NumericUpDown();
            this.mDelay = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mMinBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMaxBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.mMinBright, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mMaxBright, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mDelay, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 150);
            this.tableLayoutPanel1.TabIndex = 0;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Delay [ms]";
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
            this.mDelay.ValueChanged += new System.EventHandler(this.mDelay_ValueChanged);
            // 
            // Strobing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Strobing";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mMinBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMaxBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown mMinBright;
        private System.Windows.Forms.NumericUpDown mMaxBright;
        private System.Windows.Forms.NumericUpDown mDelay;
    }
}
