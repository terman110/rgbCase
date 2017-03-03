using System;
using System.Threading;

namespace rgbCase.Effects
{
    internal partial class Strobing :
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
            public uint Sleep_ms { get; set; } = 250;
        }

        public Strobing(Parameter objParam) : base()
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
            form.SetVisibility(false, true);
        }

        public override void Work(MainForm form)
        {
            form.Brightness = (byte)(form.Brightness > Param.Min + (Param.Max - Param.Min) / 2 ? Param.Min : Param.Max);
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
