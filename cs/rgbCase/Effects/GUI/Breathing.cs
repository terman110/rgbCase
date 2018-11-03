using rgbCase.Base;
using System;
using System.Threading;

namespace rgbCase.Effects
{
    public partial class Breathing :
#if DEBUG
        EffectBaseAbstractHack
#else
        EffectBase
#endif
    {
        public Breathing(Parameter.Breathing objParam) : base()
        {
            Param = objParam;

            InitializeComponent();
            mMinBright.Value = Param.Min;
            mMaxBright.Value = Param.Max;
            mDelay.Value = Param.Sleep_ms;
            mController.Checked = Param.ControllerBased;
        }

        public Parameter.Breathing Param { get; set; }

        public override IEffectParameter ParamI { get { return Param; } }

        private IMainForm Form { get; set; }

        public override bool IsAnimation { get { return !this.Param.ControllerBased; } }

        public override void Init(IMainForm form)
        {
            Thread.Sleep(10);
            Form = form;
            form.Brightness = (byte)(Param.Min + 1);
            form.SetVisibility(false, true);
            Thread.Sleep(10);
            if (Param.ControllerBased)
                form.SetControllerMode(1, (byte)Math.Min(Param.Sleep_ms, 255), (byte)Param.Min);
        }

        private bool bForward = true;
        public override void Work(IMainForm form)
        {
            if (Param.ControllerBased)
            {
                Thread.Sleep(500);
                return;
            }
            if (form.Brightness <= Param.Min || form.Brightness >= Param.Max)
                bForward = !bForward;
            form.Brightness = (byte)((int)form.Brightness + (bForward ? 1 : -1));
            Thread.Sleep((int)Param.Sleep_ms);
        }

        private void mMinBright_ValueChanged(object sender, EventArgs e)
        {
            Param.Min = (byte)mMinBright.Value;
            if (Form != null && Param.ControllerBased)
                Form.SetControllerMode(1, (byte)Math.Min(Param.Sleep_ms, 255), (byte)Param.Min);
        }

        private void mMaxBright_ValueChanged(object sender, EventArgs e)
        {
            Param.Max = (byte)mMaxBright.Value;
        }

        private void mDelay_ValueChanged(object sender, EventArgs e)
        {
            Param.Sleep_ms = (uint)mDelay.Value;
            if (Form != null && Param.ControllerBased)
                Form.SetControllerMode(1, (byte)Math.Min(Param.Sleep_ms, 255), (byte)Param.Min);
        }

        private void mController_CheckedChanged(object sender, EventArgs e)
        {
            Param.ControllerBased = mController.Checked;
        }
    }
}
