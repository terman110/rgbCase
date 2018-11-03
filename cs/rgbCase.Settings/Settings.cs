using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;

namespace rgbCase
{
    public class Settings
    {
        public string ComPort { get; set; } = "COM1";
        public int BaudRate { get; set; } = 115200;
        public Color Color { get; set; } = Color.Red;
        public byte Brightness { get; set; } = 255;
        public EModes Mode { get; set; } = EModes.Static;

        public Effects.Parameter.Static Static { get; set; } = new Effects.Parameter.Static();
        public Effects.Parameter.Strobing Strobing { get; set; } = new Effects.Parameter.Strobing();
        public Effects.Parameter.Breathing Breathing { get; set; } = new Effects.Parameter.Breathing();
        public Effects.Parameter.ColorCycle ColorCycle { get; set; } = new Effects.Parameter.ColorCycle();
        public Effects.Parameter.BreathingCycle BreathingCycle { get; set; } = new Effects.Parameter.BreathingCycle();
        public Effects.Parameter.ScreenGrab ScreenGrab { get; set; } = new Effects.Parameter.ScreenGrab();

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
            if (!File.Exists(Environment.CurrentDirectory + "\\settings.json"))
                return Instance;
            string sJson = File.ReadAllText(Environment.CurrentDirectory + "\\settings.json");
            Instance = JsonConvert.DeserializeObject<Settings>(sJson);
            return Instance;
        }

        public static void Save()
        {
            string sJson = JsonConvert.SerializeObject(Instance, Formatting.Indented);
            File.WriteAllText(Environment.CurrentDirectory + "\\settings.json", sJson);
        }
        #endregion
    }
}
