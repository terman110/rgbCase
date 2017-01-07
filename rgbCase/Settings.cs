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
        public EModes Mode { get; set; } = EModes.Static;

        public byte Breathing_Min { get; set; } = 32;
        public byte Breathing_Max { get; set; } = 255;
        public uint Breathing_Sleep_ms { get; set; } = 9;

        public byte Strobing_Min { get; set; } = 0;
        public byte Strobing_Max { get; set; } = 255;
        public uint Strobing_Sleep_ms { get; set; } = 250;

        public uint ColorCycle_Sleep_ms { get; set; } = 9;
        [JsonIgnore]
        public uint ColorCycle_State { get; set; } = 0;

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
