using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgbCase.CLI
{
    public class CtrlInterface : IDisposable
    {
        Arduino.Controller _ctrl = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="ret"></param>
        /// <returns>false on fail or exit</returns>
        public bool Evaluate(string input, out string ret)
        {
            ret = string.Empty;
            if (string.IsNullOrWhiteSpace(input))
                return true;

            if (_ctrl == null)
                _ctrl = new Arduino.Controller(Settings.Instance.ComPort, Settings.Instance.BaudRate);
            if (_ctrl == null)
                return false;

            var inputSplit = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string cmd = inputSplit.First().Trim().ToLower();
            var args = inputSplit.Skip(1);

            try
            {
                switch (cmd)
                {
                    case "h":
                    case "help":
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("A call consists of a command and can also contain arguments:");
                        sb.AppendLine("\thelp                   Command help");
                        sb.AppendLine("\tports                  Available ports");
                        sb.AppendLine("\tbauds                  Available bauds");
                        sb.AppendLine("\tmodes                  Available modes");
                        sb.AppendLine("\tisconnected            Is connected?");
                        sb.AppendLine("\ttimestamp              Timestamp");
                        sb.AppendLine("\tport [port]            Get/set port");
                        sb.AppendLine("\tbaud [rate]            Get/set baud rate");
                        sb.AppendLine("\tconnect [port] [baud]  Connect with optional port and baud rate");
                        sb.AppendLine("\tdisconnect             Disconnect");
                        sb.AppendLine("\treconnect              Reconnect/ Connect");
                        sb.AppendLine("\tcolor r g b            Set color r, g, b [0, 255]");
                        sb.AppendLine("\tbrightness b           Set brightness b [0, 255]");
                        sb.AppendLine("\tmode m p1 p2           Set mode m, p1, p2 [0, 255]");
                        sb.AppendLine();
                        sb.AppendLine("Possible return values:");
                        sb.AppendLine("\tOK                     All is fine");
                        sb.AppendLine("\tNO                     Command call failed or not possible right now");
                        sb.AppendLine("\tFAIL                   Error");
                        sb.AppendLine("\t0, 1                   Boolean states false, true");
                        ret += sb.ToString();
                        break;

                    case "port":
                        if (args.Count() > 0)
                        {
                            if (!Arduino.Controller.AvailablePorts.Contains(args.First()))
                            {
                                ret += "NO";
                                return true;
                            }
                            Settings.Instance.ComPort = args.First();
                            ret = "OK";
                        }
                        else
                            ret = Settings.Instance.ComPort;
                        break;

                    case "baud":
                        if (args.Count() > 0)
                        {
                            int nbaud;
                            if (!int.TryParse(args.ElementAt(1), out nbaud) || !Arduino.Controller.AvailableBaudRates.Contains(nbaud))
                            {
                                ret += "NO";
                                return true;
                            }
                            Settings.Instance.BaudRate = nbaud;
                            ret = "OK";
                        }
                        else
                            ret = Settings.Instance.BaudRate.ToString();
                        break;

                    case "ports":
                    case "comports":
                        ret += string.Join("; ", Arduino.Controller.AvailablePorts);
                        break;

                    case "bauds":
                    case "baudrates":
                        ret += string.Join("; ", Arduino.Controller.AvailableBaudRates);
                        break;

                    case "connect":
                    case "con":
                        if (_ctrl.Connected)
                        {
                            ret += "NO";
                            return true;
                        }
                        string port = Settings.Instance.ComPort;
                        int baud = Settings.Instance.BaudRate;
                        if (args.Count() > 0)
                        {
                            if (!Arduino.Controller.AvailablePorts.Contains(args.First()))
                            {
                                ret += "NO";
                                return true;
                            }
                            port = Settings.Instance.ComPort = args.First();
                        }
                        if (args.Count() > 1)
                        {
                            int nbaud;
                            if (!int.TryParse(args.ElementAt(1), out nbaud) || !Arduino.Controller.AvailableBaudRates.Contains(nbaud))
                            {
                                ret += "NO";
                                return true;
                            }
                            baud = Settings.Instance.BaudRate = nbaud;
                        }
                        ret += _ctrl.Connect(port, baud) ? "OK" : "FAIL";
                        break;

                    case "disconnect":
                    case "dis":
                        if (!_ctrl.Connected)
                            ret += "NO";
                        _ctrl.Disconnect();
                        ret += "OK";
                        break;

                    case "reconnect":
                    case "recon":
                        _ctrl.Reconnect();
                        ret += "OK";
                        break;

                    case "isconnected":
                    case "connected":
                    case "ic":
                        ret += _ctrl.Connected ? "1" : "0";
                        break;

                    case "c":
                    case "color":
                        byte r = 0, g = 0, b = 0;
                        if (!_ctrl.Connected || args.Count() != 3 || 
                            !byte.TryParse(args.ElementAt(0), out r) || 
                            !byte.TryParse(args.ElementAt(1), out g) || 
                            !byte.TryParse(args.ElementAt(2), out b))
                            ret += "NO";
                        _ctrl.RequestColor(Color.FromArgb(r, g, b));
                        ret += "OK";
                        break;

                    case "b":
                    case "brightness":
                        byte bg = 0;
                        if (!_ctrl.Connected || args.Count() != 1 ||
                            !byte.TryParse(args.First(), out bg))
                            ret += "NO";
                        _ctrl.RequestBrightness(bg);
                        ret += "OK";
                        break;

                    case "hb":
                    case "heartbeat":
                        _ctrl.RequestHeartBeat();
                        ret += "OK";
                        break;

                    case "m":
                    case "mode":
                        byte mode = 0, p1 = 0, p2 = 0;
                        if (!_ctrl.Connected || args.Count() != 3 ||
                            !byte.TryParse(args.ElementAt(0), out mode) ||
                            !byte.TryParse(args.ElementAt(1), out p1) ||
                            !byte.TryParse(args.ElementAt(2), out p2))
                            ret += "NO";
                        _ctrl.RequestMode(mode, p1, p2);
                        ret += "OK";
                        break;

                    case "modes":
                        ret += Arduino.Controller.AvailableModes;
                        break;

                    case "ts":
                    case "timestamp":
                        ret += Arduino.Controller.Timestamp;
                        break;

                    default:
                        ret += cmd.Length < 1 ? "OK" : "NO";
                        break;
                }
            }
            catch
            {
                ret += "FAIL";
            }

            if (string.IsNullOrWhiteSpace(ret))
                ret = "OK";

            return true;
        }

        public void Dispose()
        {
            if (_ctrl == null)
                return;

            try
            {
                _ctrl.Dispose();
            }
            catch { }
            finally { _ctrl = null; }
        }
    }
}
