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
    internal partial class Breathing :
#if DEBUG
        EffectBaseAbstractHack
#else
        EffectBase
#endif
    {
        public class Parameter
        {
            public Parameter() { }

            public byte Min { get; set; } = 0;
            public byte Max { get; set; } = 255;
            public uint Sleep_ms { get; set; } = 10;
        }

        public Breathing(Parameter objParam) : base()
        {
            InitializeComponent();
            Param = objParam;
            mMinBright.Value = Param.Min;
            mMaxBright.Value = Param.Max;
            mDelay.Value = Param.Sleep_ms;
        }

        public Parameter Param { get; set; }

        public override bool IsAnimation { get { return true; } }

        public override void Init(MainForm form)
        {
            form.Brightness = (byte)(Param.Min + 1);
            form.SetVisibility(false, true);
        }

        private bool bForward = true;
        public override void Work(MainForm form)
        {
            if (form.Brightness <= Param.Min || form.Brightness >= Param.Max)
                bForward = !bForward;
            form.Brightness = (byte)((int)form.Brightness + (bForward ? 1 : -1));
            Thread.Sleep((int)Param.Sleep_ms);
        }

        private void mMinBright_ValueChanged(object sender, EventArgs e)
        {
            Param.Min = (byte)mMinBright.Value;
        }

        private void mMaxBright_ValueChanged(object sender, EventArgs e)
        {
            Param.Max = (byte)mMaxBright.Value;
        }

        private void mDelay_ValueChanged(object sender, EventArgs e)
        {
            Param.Sleep_ms = (uint)mDelay.Value;
        }
    }
}
