using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace rgbCase.Effects
{
    internal partial class BreathingCycle :
#if DEBUG
        EffectBaseAbstractHack
#else
        EffectBase
#endif
    {
        public class Parameter
        {
            public Parameter() { }
            
            public uint Sleep_ms { get; set; } = 9;
            public byte Min { get; set; } = 0;
            public byte Max { get; set; } = 255;
        }

        public BreathingCycle(Parameter objParam) : base()
        {
            InitializeComponent();
            Param = objParam;
            mMinBright.Value = Param.Min;
            mMaxBright.Value = Param.Max;
            mDelay.Value = Param.Sleep_ms;
            
            randomGen = new Random();
            names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        }

        public Parameter Param { get; set; }

        public override bool IsAnimation { get { return true; } }

        public override void Init(MainForm form)
        {
            form.Color = Color.FromKnownColor(names[randomGen.Next(names.Length)]);
            if (form.Brightness < 10)
                form.Brightness = 255;
            nState = 0;
            form.SetVisibility(true, false);
        }
        
        private uint nState { get; set; } = 0;

        private bool bForward = true;
        Random randomGen;
        KnownColor[] names;
        public override void Work(MainForm form)
        {
            if (form.Brightness <= Param.Min || form.Brightness >= Param.Max)
                bForward = !bForward;

            if (form.Brightness <= Param.Min)
                form.Color = Color.FromKnownColor(names[randomGen.Next(names.Length)]);

            form.Brightness = (byte)((int)form.Brightness + (bForward ? 1 : -1));
            Thread.Sleep((int)Param.Sleep_ms);
        }

        private void mDelay_ValueChanged(object sender, EventArgs e)
        {
            Param.Sleep_ms = (uint)mDelay.Value;
        }

        private void mMinBright_ValueChanged(object sender, EventArgs e)
        {
            Param.Min = (byte)mMinBright.Value;
        }

        private void mMaxBright_ValueChanged(object sender, EventArgs e)
        {
            Param.Max = (byte)mMaxBright.Value;
        }
    }
}
