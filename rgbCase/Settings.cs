using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace rgbCase
{
    internal class Settings
    {
        public string ComPort { get; set; } = "COM1";
        public int BaudRate { get; set; } = 115200;
        public Color Color { get; set; } = Color.Red;
        public byte Brightness { get; set; } = 255;
        public EModes Mode { get; set; } = EModes.Static;

        public Effects.Static.Parameter Static { get; set; } = new Effects.Static.Parameter();
        public Effects.Strobing.Parameter Strobing { get; set; } = new Effects.Strobing.Parameter();
        public Effects.Breathing.Parameter Breathing { get; set; } = new Effects.Breathing.Parameter();
        public Effects.ColorCycle.Parameter ColorCycle { get; set; } = new Effects.ColorCycle.Parameter();
        public Effects.BreathingCycle.Parameter BreathingCycle { get; set; } = new Effects.BreathingCycle.Parameter();
        public Effects.ScreenGrab.Parameter ScreenGrab { get; set; } = new Effects.ScreenGrab.Parameter();

        public Effects.EffectBase GetEffect(EModes nMode)
        {
            switch (nMode)
            {
                case EModes.Static: return new Effects.Static(Static);
                case EModes.Strobing: return new Effects.Strobing(Strobing);
                case EModes.Breathing: return new Effects.Breathing(Breathing);
                case EModes.ColorCycle: return new Effects.ColorCycle(ColorCycle);
                case EModes.BreathingCycle: return new Effects.BreathingCycle(BreathingCycle);
                case EModes.ScreenGrab: return new Effects.ScreenGrab(ScreenGrab);
                default: return null;
            }
        }

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
