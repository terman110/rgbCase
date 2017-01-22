using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace rgbCase
{
    /// <summary>
    /// Arduino RGB Controller
    /// </summary>
    /// <remarks>
    /// Serial message protocol
    /// =======================
    /// 
    /// Each message contains of 6 byte.
    /// 
    /// Start Byte | Type Byte | Data Byte 0 | Data Byte 1 | Data Byte 2 | End Byte
    /// 0x0f       | 0x..      | 0x..        | 0x..        | 0x..        | 0xff
    /// 
    /// Message         | Type Byte | Data Byte 0 | Data Byte 1 | Data Byte 2
    /// Heart Beat Req. | 0x00      | 0x00        | 0x00        | 0x00
    /// Heart Beat Ack. | 0x01      | 0x00        | 0x00        | 0x00
    /// Brightness Req. | 0x02      | value       | 0x00        | 0x00
    /// Brightness Ack. | 0x03      | value       | 0x00        | 0x00
    /// Mode Req.       | 0x04      | value       | param 0     | param 1
    /// Mode Ack.       | 0x05      | value       | param 0     | param 1
    /// Color Req.      | 0x06      | red         | green       | blue
    /// Color Ack.      | 0x07      | red         | green       | blue
    /// Error           | 0xff      | err code 0  | err code 1  | err code 2
    /// </remarks>
    public class ArduinoController : IDisposable
    {
        public enum MessageType
        {
            Unknown = -1,
            GenericMessage = 0,
            HeartBeat,
            Brightness,
            Mode,
            Color,
            Error = 255
        }

        public enum StateType
        {
            UnknownError = -3,
            Unknown = -2,
            Disconnected = -1,
            Connected = 0,
            /// <summary>An input buffer overflow has occurred. There is either no room in the input buffer, or a character was received after the end-of-file (EOF) character.</summary>
            RXOver = 1,
            /// <summary>A character-buffer overrun has occurred. The next character is lost.</summary>
            Overrun = 2,
            /// <summary>The hardware detected a parity error.</summary>
            RXParity = 4,
            /// <summary>The hardware detected a framing error.</summary>
            Frame = 8,
            /// <summary>The application tried to transmit a character, but the output buffer was full.</summary>
            TXFull = 256
        }

        SerialPort mPort;
        string mPortName = "COM1";
        int mBaud = 115200;
        Int32 mLastReceived = Timestamp;
        Int32 mLastSend = Timestamp;
        const Int32 cTimeout_ms = 5000;
        const Int32 cMinDurationDuringMsg_ms = 1;
        Task mAliveTask;
        CancellationTokenSource mCancelTasks = new CancellationTokenSource();
        Thread mStartingThread;

        static public string[] AvailablePorts { get { return SerialPort.GetPortNames(); } }
        static public int[] AvailableBaudRates { get { return new int[] { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200 }; } }

        public delegate void MessageReceivedHandler(MessageType nType, string sMessage);
        public event MessageReceivedHandler MessageReceived;

        public delegate void MessageSendHandler(MessageType nType, string sMessage);
        public event MessageSendHandler MessageSend;

        public delegate void StateChangeReceivedHandler(StateType nType, string sMessage);
        public event StateChangeReceivedHandler StateChangeReceived;
        
        public ArduinoController()
        {
            mStartingThread = Thread.CurrentThread;
        }

        public ArduinoController(string portName, int baud)
            : this()
        {
            Connect(portName, baud);
        }

        static public Int32 Timestamp { get { return (Int32)(DateTime.UtcNow.Subtract(new DateTime(2017, 1, 1))).TotalMilliseconds; ; } }

        public bool Connected { get { return mPort != null; } }

        public bool Connect(string PortName, int Baud)
        {
            if (Connected)
                Disconnect();

            try
            {
                mPortName = PortName;
                mBaud = Baud;
                mPort = new SerialPort(mPortName, mBaud);
                if (mPort != null)
                {
                    mPort.DataReceived += MPort_DataReceived;
                    mPort.ErrorReceived += MPort_ErrorReceived;
                    mPort.Open();
                    if (StateChangeReceived != null)
                        StateChangeReceived(StateType.Connected, string.Empty);
                    RequestHeartBeat();
                    Settings.Instance.BaudRate = mBaud;
                    Settings.Instance.ComPort = mPortName;
                    Settings.Save();
                }

                mCancelTasks = new CancellationTokenSource();
                mAliveTask = new Task(
                    () => {
                        try
                        {
                            // specify this thread's Abort() as the cancel delegate
                            using (mCancelTasks.Token.Register(Thread.CurrentThread.Abort))
                            {
                                bool bHeartBeatRequested = false;
                                while (true)
                                {
                                    if (mCancelTasks.IsCancellationRequested)
                                        return;

                                    if (Timestamp - mLastReceived > cTimeout_ms)
                                    {
                                        if (!bHeartBeatRequested)
                                        {
                                            bHeartBeatRequested = true;
                                            Task.Factory.StartNew(() => RequestHeartBeat());
                                        }
                                        else
                                        {
                                            Task.Factory.StartNew(() => Reconnect());
                                            return;
                                        }
                                    }
                                    else if (bHeartBeatRequested)
                                        bHeartBeatRequested = false;

                                    Thread.Sleep(1000);
                                }
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }, mCancelTasks.Token);
                mAliveTask.Start();
            }
            catch { }

            return Connected;
        }
        
        public void Disconnect()
        {
            if (!Connected)
                return;

            if (mCancelTasks != null)
            {
                try { mCancelTasks.Cancel(); }
                catch  { }
                try { mCancelTasks.Dispose(); }
                catch { }
                mCancelTasks = null;
            }

            if (mAliveTask != null)
            {
                try { mAliveTask.Dispose(); }
                catch { }
                mAliveTask = null;
            }

            try
            {
                mPortName = string.Empty;
                mBaud = 115200;

                mPort.DataReceived -= MPort_DataReceived;
                mPort.ErrorReceived -= MPort_ErrorReceived;

                mPort.Close();
                mPort.Dispose();
            }
            catch
            {

            }
            finally
            {
                mPort = null;
                if (StateChangeReceived != null)
                    StateChangeReceived(StateType.Disconnected, string.Empty);
            }
        }

        public void Reconnect()
        {
            Connect(mPortName, mBaud);
        }

        private void MPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            StateType nType;
            switch (e.EventType)
            {
                case SerialError.Frame: nType = StateType.Frame; break;
                case SerialError.RXOver: nType = StateType.RXOver; break;
                case SerialError.Overrun: nType = StateType.Overrun; break;
                case SerialError.RXParity: nType = StateType.RXParity; break;
                case SerialError.TXFull: nType = StateType.TXFull; break;
                default: nType = StateType.UnknownError; break;
            }
            if (StateChangeReceived != null)
                StateChangeReceived(nType, e.ToString());
        }

        private void MPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (mPort == null)
                return;
            try
            {
                while (mPort.BytesToRead > 0)
                {
                    switch (e.EventType)
                    {
                        case SerialData.Chars:
                            MessageType nType;
                            byte bD0, bD1, bD2;
                            string sMsg = GetLatestMessage(out nType, out bD0, out bD1, out bD2);
                            if (string.IsNullOrWhiteSpace(sMsg))
                                return;

                            mLastReceived = Timestamp;

                            switch (nType)
                            {
                                case MessageType.Error:
                                    if (StateChangeReceived != null)
                                        StateChangeReceived(StateType.UnknownError, "Last command failed [" + sMsg + "]");
                                    break;
                            }

                            if (MessageReceived != null)
                                MessageReceived(nType, sMsg);
                            break;
                        case SerialData.Eof:
                            break;
                    }
                }
            }
            catch { }
        }

        private string GetLatestMessage(out MessageType nType, out byte bD0, out byte bD1, out byte bD2)
        {
            string sMsg = "";
            try
            {
                int nCnt = mPort.BytesToRead;
                int nByte;
                List<byte> lBytes = new List<byte>();
                while (nCnt > 0)
                {
                    nByte = mPort.ReadByte();
                    if (lBytes.Count == 0 && nByte == 0x0f)
                        lBytes.Add((byte)nByte);
                    else if (lBytes.Count > 0)
                    {
                        lBytes.Add((byte)nByte);
                        if (lBytes.Count == 6 && nByte == 0xff)
                        {
                            bD0 = lBytes[2];
                            bD1 = lBytes[3];
                            bD2 = lBytes[4];
                            switch (lBytes[1])
                            {
                                case 0x01: nType = MessageType.HeartBeat; break;
                                case 0x03: nType = MessageType.Brightness; break;
                                case 0x05: nType = MessageType.Mode; break;
                                case 0x07: nType = MessageType.Color; break;
                                case 0xff: nType = MessageType.Error; break;
                                default: nType = MessageType.GenericMessage; break;
                            }
                            return BitConverter.ToString(lBytes.ToArray());
                        }
                    }
                    sMsg += Convert.ToChar(nByte);
                    nCnt--;
                }
                nType = MessageType.GenericMessage;
                bD0 = 0x00;
                bD1 = 0x00;
                bD2 = 0x00;
            }
            catch
            {
                nType = MessageType.Unknown;
                bD0 = 0x00;
                bD1 = 0x00;
                bD2 = 0x00;
            }
            return sMsg;
        }
                
        public void RequestHeartBeat()
        {
            if (!Connected || !mPort.IsOpen)
                return;

            try { Send(MessageType.HeartBeat); }
            catch { }
        }

        public void RequestColor(Color c)
        {
            if (!Connected || !mPort.IsOpen)
                return;

            try { Send(MessageType.Color, c.R, c.G, c.B); }
            catch { }
        }

        public void RequestBrightness(byte value)
        {
            if (!Connected || !mPort.IsOpen)
                return;

            try { Send(MessageType.Brightness, value); }
            catch { }
        }

        private void Send(MessageType nType, byte bD0 = 0x00, byte bD1 = 0x00, byte bD2 = 0x00)
        {
            byte bType = 0x00;
            switch (nType)
            {
                case MessageType.HeartBeat: bType = 0x00; break;
                case MessageType.Brightness: bType = 0x02; break;
                case MessageType.Mode: bType = 0x04; break;
                case MessageType.Color: bType = 0x06; break;
            }
            Send(new byte[6] { (byte)0x0f, bType, bD0, bD1, bD2, (byte)0xff }, 0, nType);
        }

        public void Send(byte[] aBytes, int nOffset = 0, MessageType nType = MessageType.GenericMessage)
        {
            if (aBytes == null || !Connected || !mPort.IsOpen)
                return;

            Task.Factory.StartNew(() =>
            {
                try
                {
                    Int32 currentTime = Timestamp;
                    if (currentTime - mLastSend < cMinDurationDuringMsg_ms)
                        return;
                    mLastSend = currentTime;

                    mPort.Write(aBytes, 0, aBytes.Length);
                    if (MessageSend != null)
                        MessageSend(nType, BitConverter.ToString(aBytes));
                }
                catch { }
            });
        }

        public void Send(string sMsg, MessageType nType = MessageType.GenericMessage)
        {
            if (sMsg == null || !Connected || !mPort.IsOpen)
                return;

            try
            {
                mPort.Write(sMsg);
                if (MessageSend != null)
                    MessageSend(nType, sMsg);
            }
            catch { }
        }

        public void Dispose()
        {
            if (mPort == null)
                return;
            try
            {
                Disconnect();
            }
            catch
            {

            }
            finally
            {
                mPort = null;
            }
        }
    }
}