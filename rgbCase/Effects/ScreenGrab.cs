using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace rgbCase.Effects
{
    internal partial class ScreenGrab :
#if DEBUG
        EffectBaseAbstractHack
#else
        EffectBase
#endif
    {
        public class Parameter
        {
            public Parameter() { }
            
            public uint Sleep_ms { get; set; } = 250;
            public int Screen_Idx { get; set; } = 0;
        }

        public ScreenGrab(Parameter objParam) : base()
        {
            InitializeComponent();
            Param = objParam;
            mDelay.Value = Param.Sleep_ms;
            Screen[] aScreens = Screen.AllScreens;
            for(int i = 0; i < aScreens.Length; ++i)
                comboBox1.Items.Add((i + 1).ToString() + ": " + aScreens[i].DeviceName);
            comboBox1.Items.Add("All");
            if (Param.Screen_Idx < 0)
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            else if (Param.Screen_Idx < comboBox1.Items.Count)
                comboBox1.SelectedIndex = Param.Screen_Idx;
            else
                comboBox1.SelectedIndex = 0;
        }

        public Parameter Param { get; set; }

        public override bool IsAnimation { get { return true; } }

        public override void Init(MainForm form)
        {
            form.Color = Color.Black;
            if (form.Brightness < 64)
                form.Brightness = 255;
            form.SetVisibility(true, false);
        }

        public override void Work(MainForm form)
        {
            int r = 0, g = 0, b = 0;
            Color c;
            Screen[] aScreen = null;
            if (Param.Screen_Idx >= 0 && Param.Screen_Idx < Screen.AllScreens.Length)
                aScreen = new Screen[] { Screen.AllScreens[Param.Screen_Idx] };
            else
                aScreen = Screen.AllScreens;
            foreach (Screen s in aScreen)
            {
                using (Bitmap bmpScreenshot = new Bitmap(s.Bounds.Width, s.Bounds.Height, PixelFormat.Format32bppArgb))
                {
                    using (Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot))
                        gfxScreenshot.CopyFromScreen(s.Bounds.X, s.Bounds.Y, 0, 0, s.Bounds.Size, CopyPixelOperation.SourceCopy);
                    c = AverageBitmap(bmpScreenshot);
                    r += c.R;
                    g += c.G;
                    b += c.B;
                }
            }
            form.Color = Color.FromArgb(r / aScreen.Length, g / aScreen.Length, b / aScreen.Length);
            Thread.Sleep((int)Param.Sleep_ms);
        }

        private static Color AverageBitmap(Bitmap bm)
        {
            BitmapData srcData = bm.LockBits( new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;

            IntPtr Scan0 = srcData.Scan0;
            long[] totals = new long[] { 0, 0, 0 };
            int width = bm.Width;
            int height = bm.Height;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    for (int color = 0; color < 3; color++)
                        totals[color] += Marshal.ReadByte(Scan0, (y * stride) + x * 4 + color);

            return Color.FromArgb((byte)(totals[2] / (long)(width * height)), (byte)(totals[1] / (long)(width * height)), (byte)(totals[0] / (long)(width * height)));
        }

        private void mDelay_ValueChanged(object sender, EventArgs e)
        {
            Param.Sleep_ms = (uint)mDelay.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Param.Screen_Idx = comboBox1.SelectedIndex == comboBox1.Items.Count - 1 ? -1 : comboBox1.SelectedIndex;
        }
    }
}
