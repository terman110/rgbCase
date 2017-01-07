using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rgbCase
{
    public partial class MainForm : Form
    {
        private ArduinoController mCtrl = null;
        private byte mBrightness = 255;
        private Brush _textureBrush;
                
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.Load();

            cmbPort.Items.AddRange(ArduinoController.AvailablePorts);
            if (cmbPort.Items.Contains(Settings.Instance.ComPort.ToString())) cmbPort.SelectedItem = Settings.Instance.ComPort.ToString();
            else if (cmbPort.Items.Count > 0) cmbPort.SelectedIndex = cmbBaud.Items.Count - 1;
            cmbBaud.Items.AddRange(ArduinoController.AvailableBaudRates.Select(x => x.ToString()).ToArray());
            if (cmbBaud.Items.Contains(Settings.Instance.BaudRate.ToString())) cmbBaud.SelectedItem = Settings.Instance.BaudRate.ToString();
            else if (cmbBaud.Items.Count > 0) cmbBaud.SelectedIndex = cmbBaud.Items.Count - 1;

            Brightness = Settings.Instance.Brightness;
            numBrightness.Value = Brightness;
            slideBrightness.Value = (float)Brightness / 2.55f;

            Color = Settings.Instance.Color;

            Task.Factory.StartNew(() => btnConnect_Click(null, null));

            comboMode.Items.AddRange(Enum.GetNames(typeof(EModes)));
            if (comboMode.Items.Contains(Settings.Instance.Mode.ToString()))
                comboMode.SelectedIndex = comboMode.Items.IndexOf(Settings.Instance.Mode.ToString());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(InvokeRequired)
            {
                Invoke(new EventHandler(btnConnect_Click), new object[] { sender, e });
                return;
            }

            if (mCtrl != null)
                btnDisconnect_Click(sender, e);

            try
            {
                lblPort.Enabled = false;
                cmbPort.Enabled = false;
                lblBaud.Enabled = false;
                cmbBaud.Enabled = false;
                txtMsg.Enabled = false;
                btnSend.Enabled = false;
                panelMaster.Enabled = false;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = false;

                string sPort = cmbPort.SelectedItem.ToString();
                int nBaud;
                if (!int.TryParse(cmbBaud.SelectedItem.ToString(), out nBaud))
                    return;
                mCtrl = new ArduinoController();
                mCtrl.MessageReceived += MCtrl_MessageReceived;
                mCtrl.StateChangeReceived += MCtrl_StateChangeReceived;
                mCtrl.MessageSend += MCtrl_MessageSend;
                mCtrl.Connect(sPort, nBaud);

                Task.Factory.StartNew(() => {
                    timerHeartBeat.Start();
                    Thread.Sleep(1000);
                    mCtrl.RequestBrightness(Brightness);
                    Thread.Sleep(1000);
                    mCtrl.RequestColor(Color);
                });
        }
            catch
            {

            }
            finally
            {
                btnDisconnect.Enabled = true;
                txtMsg.Enabled = true;
                btnSend.Enabled = true;
                panelMaster.Enabled = true;
            }

            if (mCtrl == null || !mCtrl.Connected)
                btnDisconnect_Click(sender, e);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(btnDisconnect_Click), new object[] { sender, e });
                return;
            }

            if (mCtrl == null)
                return;

            lblPort.Enabled = false;
            cmbPort.Enabled = false;
            lblBaud.Enabled = false;
            cmbBaud.Enabled = false;
            txtMsg.Enabled = false;
            btnSend.Enabled = false;
            panelMaster.Enabled = false;
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = false;

            try
            {
                timerHeartBeat.Stop();
                mCtrl.Disconnect();
                mCtrl.Dispose();
            }
            catch
            {

            }
            finally
            {
                mCtrl = null;
                lblPort.Enabled = true;
                cmbPort.Enabled = true;
                lblBaud.Enabled = true;
                cmbBaud.Enabled = true;
                btnConnect.Enabled = true;
            }
        }
        
        private void MCtrl_StateChangeReceived(ArduinoController.StateType nType, string sMessage)
        {
            //if (!checkLog.Checked)
            //    return;
            if (InvokeRequired)
            {
                Invoke(new ArduinoController.StateChangeReceivedHandler(MCtrl_StateChangeReceived), new object[] { nType, sMessage });
                return;
            }
            txtLog.AppendText(DateTime.Now.ToString("HH:MM:SS.fff") + " [SC] " + nType.ToString() + ": " + sMessage.ToString() + Environment.NewLine);
            LineCheck();
        }

        private void MCtrl_MessageReceived(ArduinoController.MessageType nType, string sMessage)
        {
            if (!checkLog.Checked)
                return;
            if (InvokeRequired)
            {
                Invoke(new ArduinoController.MessageReceivedHandler(MCtrl_MessageReceived), new object[] { nType, sMessage });
                return;
            }
            txtLog.AppendText(DateTime.Now.ToString("HH:MM:SS.fff") + " [<-] " + nType.ToString() + ": " + sMessage.ToString() + Environment.NewLine);
            LineCheck();
        }

        private void MCtrl_MessageSend(ArduinoController.MessageType nType, string sMessage)
        {
            if (!checkLog.Checked)
                return;
            if (InvokeRequired)
            {
                Invoke(new ArduinoController.MessageSendHandler(MCtrl_MessageSend), new object[] { nType, sMessage });
                return;
            }
            txtLog.AppendText(DateTime.Now.ToString("HH:MM:SS.fff") + " [->] " + nType.ToString() + ": " + sMessage.ToString() + Environment.NewLine);
            LineCheck();
        }

        private void LineCheck()
        {
            if (txtLog.Lines.Length < 1200)
                return;
             txtLog.Lines = txtLog.Lines.Skip(200).ToArray();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (mCtrl == null || !mCtrl.Connected)
                return;
            mCtrl.Send(txtMsg.Text);
            txtMsg.Clear();
        }

        private void txtMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
                e.Handled = true;
            }
        }

        private void timerHeartBeat_Tick(object sender, EventArgs e)
        {
            if (mCtrl == null || !mCtrl.Connected)
                return;
            mCtrl.RequestHeartBeat();
        }
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Settings.Save();

            btnDisconnect_Click(null, null);
            if (_textureBrush != null)
                _textureBrush.Dispose();
            _textureBrush = null;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Color
        public Color Color
        {
            get { return colorEditorManager.Color; }
            set { Color_Set(value); }
        }

        delegate void ColorArgHandler(Color value);
        private void Color_Set(Color value)
        {
            if (InvokeRequired)
            {
                Invoke(new ColorArgHandler(Color_Set), new object[] { value });
                return;
            }

            if (colorEditorManager.Color == value)
                return;
            colorEditorManager.Color = value;
            Settings.Instance.Color = value;
        }

        public byte Brightness
        {
            get { return mBrightness; }
            set { Brightness_Set(value); }
        }

        delegate void ByteArgHandler(byte value);
        private void Brightness_Set(byte value)
        {
            if(InvokeRequired)
            {
                Invoke(new ByteArgHandler(Brightness_Set), new object[] { value });
                return;
            }

            if (mBrightness == value)
                return;
            mBrightness = value;
            Settings.Instance.Brightness = value;
            slideBrightness.Value = (float)value / 2.56f;
            numBrightness.Value = value;
            if (mCtrl != null)
                mCtrl.RequestBrightness(value);
        }

        private void OnColorChanged(object sender, EventArgs e)
        {
            if (mCtrl == null || Settings.Instance.Color == Color)
                return;
            Settings.Instance.Color = Color;
            mCtrl.RequestColor(Color);
            previewPanel.Invalidate();
        }

        private void previewPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle region;

            region = previewPanel.ClientRectangle;

            if (this.Color.A != 255)
            {
                if (_textureBrush == null)
                {
                    using (Bitmap background = new Bitmap(Properties.Resources.cellbackground))
                    {
                        _textureBrush = new TextureBrush(background, WrapMode.Tile);
                    }
                }

                e.Graphics.FillRectangle(_textureBrush, region);
            }

            using (Brush brush = new SolidBrush(this.Color))
            {
                e.Graphics.FillRectangle(brush, region);
            }

            e.Graphics.DrawRectangle(SystemPens.ControlText, region.Left, region.Top, region.Width - 1, region.Height - 1);
        }

        private void numBrightness_ValueChanged(object sender, EventArgs e)
        {
            if (mCtrl == null)
                return;
            if (sender == numBrightness)
            {
                if (Brightness == (byte)numBrightness.Value)
                    return;
                mBrightness = (byte)numBrightness.Value;
                Settings.Instance.Brightness = mBrightness;
                slideBrightness.Value = (float)Brightness / 2.56f;
                mCtrl.RequestBrightness(Brightness);
            }
            else if (sender == slideBrightness)
            {
                if (Brightness == (byte)(slideBrightness.Value * 2.56f))
                    return;
                mBrightness = (byte)(slideBrightness.Value * 2.56f);
                Settings.Instance.Brightness = mBrightness;
                numBrightness.Value = Brightness;
                mCtrl.RequestBrightness(Brightness);
            }
        }
        #endregion

        #region Mode
        private BackgroundWorker mWorker;
        private EModes mMode;
        private void comboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            EModes newMode;
            try { newMode = (EModes)Enum.Parse(typeof(EModes), comboMode.SelectedItem.ToString()); }
            catch { return; }
            if (mMode == newMode)
                return;
            mMode = newMode;
            try
            {
                if (mWorker != null)
                {
                    mWorker.CancelAsync();
                    mWorker.Dispose();
                }
            }
            catch { }
            finally { mWorker = null; }

            if(mMode != EModes.Static)
            {
                mWorker = new BackgroundWorker();
                mWorker.WorkerSupportsCancellation = true;
                mWorker.DoWork += MWorker_DoWork;
                mWorker.RunWorkerCompleted += MWorker_RunWorkerCompleted;
                mWorker.RunWorkerAsync(new object[] { this, mMode });
            }
            Settings.Instance.Mode = mMode;
        }

        private void MWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                comboMode.SelectedIndex = 0;
        }

        private void MWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker == null)
                    return;

                if (!(e.Argument is object[]) || ((object[])e.Argument).Length != 2)
                    return;
                MainForm form = ((object[])e.Argument)[0] as MainForm;
                if (form == null)
                    return;
                if (!(((object[])e.Argument)[1] is EModes))
                    return;
                EModes mode = (EModes)((object[])e.Argument)[1];

                bool bForward = true;

                #region Init
                switch (mode)
                {
                    case EModes.Breathing:
                        form.Brightness = (byte)(Settings.Instance.Breathing_Min + 1);
                        break;
                    case EModes.Strobing: break;
                    case EModes.ColorCycle:
                        form.Color = Color.Black;
                        Settings.Instance.ColorCycle_State = 0;
                        break;
                }
                #endregion

                while (true)
                {
                    if (worker.CancellationPending)
                        return;
                    switch (mode)
                    {
                        case EModes.Breathing:
                            if (form.Brightness <= Settings.Instance.Breathing_Min || form.Brightness >= Settings.Instance.Breathing_Max)
                                bForward = !bForward;
                            form.Brightness = (byte)((int)form.Brightness + (bForward ? 1 : -1));
                            Thread.Sleep((int)Settings.Instance.Breathing_Sleep_ms);
                            break;
                        case EModes.Strobing:
                            form.Brightness = (byte)(form.Brightness > Settings.Instance.Strobing_Min + (Settings.Instance.Strobing_Max - Settings.Instance.Strobing_Min) / 2 ? Settings.Instance.Strobing_Min : Settings.Instance.Strobing_Max);
                            Thread.Sleep((int)Settings.Instance.Strobing_Sleep_ms);
                            break;
                        case EModes.ColorCycle:
                            Color col = form.Color;
                            switch(Settings.Instance.ColorCycle_State)
                            {
                                case 0:
                                    if (col.R >= 254) Settings.Instance.ColorCycle_State = 1;
                                    form.Color = Color.FromArgb(col.R + 1, col.G, col.B);
                                    break;
                                case 1:
                                    if (col.B >= 254) Settings.Instance.ColorCycle_State = 2;
                                    form.Color = Color.FromArgb(col.R, col.G, col.B + 1);
                                    break;
                                case 2:
                                    if (col.G >= 254) Settings.Instance.ColorCycle_State = 3;
                                    form.Color = Color.FromArgb(col.R, col.G + 1, col.B);
                                    break;
                                case 3:
                                    if (col.R <= 1) Settings.Instance.ColorCycle_State = 4;
                                    form.Color = Color.FromArgb(col.R - 1, col.G, col.B);
                                    break;
                                case 4:
                                    if (col.B <= 1) Settings.Instance.ColorCycle_State = 5;
                                    form.Color = Color.FromArgb(col.R, col.G, col.B - 1);
                                    break;
                                case 5:
                                    if (col.G <= 1) Settings.Instance.ColorCycle_State = 0;
                                    form.Color = Color.FromArgb(col.R, col.G - 1, col.B);
                                    break;
                            }
                            Thread.Sleep((int)Settings.Instance.ColorCycle_Sleep_ms);
                            break;
                    }
                }
            }
            catch { e.Cancel = true; }
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (mWorker != null)
                {
                    mWorker.CancelAsync();
                    mWorker.Dispose();
                }
            }
            catch { }
            finally { mWorker = null; }
        }
    }
}
