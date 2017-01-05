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
            if (InvokeRequired)
            {
                Invoke(new ArduinoController.StateChangeReceivedHandler(MCtrl_StateChangeReceived), new object[] { nType, sMessage });
                return;
            }
            txtLog.AppendText("[SC] " + nType.ToString() + ": " + sMessage.ToString() + Environment.NewLine);
            LineCheck();
        }

        private void MCtrl_MessageReceived(ArduinoController.MessageType nType, string sMessage)
        {
            if(InvokeRequired)
            {
                Invoke(new ArduinoController.MessageReceivedHandler(MCtrl_MessageReceived), new object[] { nType, sMessage });
                return;
            }
            txtLog.AppendText("[<-] " + nType.ToString() + ": " + sMessage.ToString() + Environment.NewLine);
            LineCheck();
        }

        private void MCtrl_MessageSend(ArduinoController.MessageType nType, string sMessage)
        {
            if (InvokeRequired)
            {
                Invoke(new ArduinoController.MessageSendHandler(MCtrl_MessageSend), new object[] { nType, sMessage });
                return;
            }
            txtLog.AppendText("[->] " + nType.ToString() + ": " + sMessage.ToString() + Environment.NewLine);
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
            set { colorEditorManager.Color = value; Settings.Instance.Color = value; }
        }

        public byte Brightness { get { return mBrightness; } set { mBrightness = value; Settings.Instance.Brightness = value; } }

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
                Brightness = (byte)numBrightness.Value;
                slideBrightness.Value = (float)Brightness / 2.55f;
                mCtrl.RequestBrightness(Brightness);
            }
            else if (sender == slideBrightness)
            {
                if (Brightness == (byte)(slideBrightness.Value * 2.55f))
                    return;
                Brightness = (byte)(slideBrightness.Value * 2.55f);
                numBrightness.Value = Brightness;
                mCtrl.RequestBrightness(Brightness);
            }
        }
        #endregion
    }
}
