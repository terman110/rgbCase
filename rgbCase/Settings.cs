using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace rgbCase
{
    internal class Settings
    {
        public string ComPort { get; set; } = "COM1";
        public int BaudRate { get; set; } = 115200;
        public Color Color { get; set; } = Color.Red;
        public byte Brightness { get; set; } = 255;

        #region Instance
        private Settings() { }

        private static Settings mInstance = null;
        public static Settings Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new Settings();
                return mInstance;
            }
            private set { mInstance = value; }
        }
        
        public static Settings Load()
        {
            try
            {
                if (!File.Exists(Environment.CurrentDirectory + "\\settings.json"))
                    return Instance;
                string sJson = File.ReadAllText(Environment.CurrentDirectory + "\\settings.json");
                Instance = JsonConvert.DeserializeObject<Settings>(sJson);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading configuration:" + Environment.NewLine + e.ToString(), "Error Loading Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Instance;
        }

        public static void Save()
        {
            try
            {
                string sJson = JsonConvert.SerializeObject(Instance, Formatting.Indented);
                File.WriteAllText(Environment.CurrentDirectory + "\\settings.json", sJson);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error saving configuration:" + Environment.NewLine + e.ToString(), "Error Saving Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
