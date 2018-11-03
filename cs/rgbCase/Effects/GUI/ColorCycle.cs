using rgbCase.Base;
using System;
using System.Drawing;
using System.Threading;

namespace rgbCase.Effects
{
    public partial class ColorCycle :
#if DEBUG
        EffectBaseAbstractHack
#else
        EffectBase
#endif
    {
        public ColorCycle(Parameter.ColorCycle objParam) : base()
        {
            InitializeComponent();
            Param = objParam;
            mDelay.Value = Param.Sleep_ms;
            mController.Checked = Param.ControllerBased;
        }

        public Parameter.ColorCycle Param { get; set; }

        public override IEffectParameter ParamI { get { return Param; } }

        private IMainForm Form { get; set; }
        
        public override bool IsAnimation { get { return !Param.ControllerBased; } }

        public override void Init(IMainForm form)
        {
            Thread.Sleep(10);
            Form = form;
            form.Color = Color.Black;
            if (form.Brightness < 10)
                form.Brightness = 255;
            nState = 0;
            form.SetVisibility(true, false);
            Thread.Sleep(10);
            if (Form != null && Param.ControllerBased)
                Form.SetControllerMode(2, (byte)Math.Min(Param.Sleep_ms, 255), 0);
        }

        private uint nState { get; set; } = 0;
        public override void Work(IMainForm form)
        {
            if (Param.ControllerBased)
            {
                Thread.Sleep(500);
                return;
            }
            Color col = form.Color;
            switch (nState)
            {
                case 0:
                    if (col.R >= 254) nState = 1;
                    form.Color = Color.FromArgb(col.R + 1, col.G, col.B);
                    break;
                case 1:
                    if (col.B >= 254) nState = 2;
                    form.Color = Color.FromArgb(col.R, col.G, col.B + 1);
                    break;
                case 2:
                    if (col.G >= 254) nState = 3;
                    form.Color = Color.FromArgb(col.R, col.G + 1, col.B);
                    break;
                case 3:
                    if (col.R <= 1) nState = 4;
                    form.Color = Color.FromArgb(col.R - 1, col.G, col.B);
                    break;
                case 4:
                    if (col.B <= 1) nState = 5;
                    form.Color = Color.FromArgb(col.R, col.G, col.B - 1);
                    break;
                case 5:
                    if (col.G <= 1) nState = 0;
                    form.Color = Color.FromArgb(col.R, col.G - 1, col.B);
                    break;
            }
            Thread.Sleep((int)Param.Sleep_ms);
        }

        private void mDelay_ValueChanged(object sender, EventArgs e)
        {
            Param.Sleep_ms = (uint)mDelay.Value;
            if (Form != null && Param.ControllerBased)
                Form.SetControllerMode(2, (byte)Math.Min(Param.Sleep_ms, 255), 0);
        }

        private void mController_CheckedChanged(object sender, EventArgs e)
        {
            Param.ControllerBased = mController.Checked;
        }
    }
}
