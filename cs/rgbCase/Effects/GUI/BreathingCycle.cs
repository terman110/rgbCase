﻿using rgbCase.Base;
using System;
using System.Drawing;
using System.Threading;

namespace rgbCase.Effects
{
    public partial class BreathingCycle :
#if DEBUG
        EffectBaseAbstractHack
#else
        EffectBase
#endif
    {
        public BreathingCycle(Parameter.BreathingCycle objParam) : base()
        {
            InitializeComponent();
            Param = objParam;
            mMinBright.Value = Param.Min;
            mMaxBright.Value = Param.Max;
            mDelay.Value = Param.Sleep_ms;
            mController.Checked = Param.ControllerBased;

            randomGen = new Random();
            names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        }

        public Parameter.BreathingCycle Param { get; set; }

        public override IEffectParameter ParamI { get { return Param; } }

        private IMainForm Form { get; set; }

        public override bool IsAnimation { get { return !Param.ControllerBased; } }

        public override void Init(IMainForm form)
        {
            Thread.Sleep(10);
            form.Color = Color.FromKnownColor(names[randomGen.Next(names.Length)]);
            if (form.Brightness < Param.Min)
                form.Brightness = Param.Min;
            nState = 0;
            if (Param.ControllerBased)
                form.SetControllerMode(3, (byte)Math.Min(Param.Sleep_ms, 255), (byte)Param.Min);
            form.SetVisibility(false, false);
        }

        private uint nState { get; set; } = 0;

        private bool bForward = true;
        Random randomGen;
        KnownColor[] names;
        public override void Work(IMainForm form)
        {
            if (Param.ControllerBased)
            {
                Thread.Sleep(500);
                return;
            }
            if (form.Brightness < 0 || form.Brightness > 255 || form.Brightness <= Param.Min || form.Brightness >= Param.Max)
                bForward = !bForward;

            if (form.Brightness <= Param.Min)
                form.Color = Color.FromKnownColor(names[randomGen.Next(names.Length)]);

            form.Brightness = (byte)((int)form.Brightness + (bForward ? 1 : -1));
            Thread.Sleep((int)Param.Sleep_ms);
        }

        private void mDelay_ValueChanged(object sender, EventArgs e)
        {
            Param.Sleep_ms = (uint)mDelay.Value;
            if (Form != null && Param.ControllerBased)
                Form.SetControllerMode(3, (byte)Math.Min(Param.Sleep_ms, 255), (byte)Param.Min);
        }

        private void mMinBright_ValueChanged(object sender, EventArgs e)
        {
            Param.Min = (byte)mMinBright.Value;
            if (Form != null && Param.ControllerBased)
                Form.SetControllerMode(3, (byte)Math.Min(Param.Sleep_ms, 255), (byte)Param.Min);
        }

        private void mMaxBright_ValueChanged(object sender, EventArgs e)
        {
            Param.Max = (byte)mMaxBright.Value;
        }

        private void mController_CheckedChanged(object sender, EventArgs e)
        {
            Param.Sleep_ms = (uint)mDelay.Value;
            if (Form != null && Param.ControllerBased)
                Form.SetControllerMode(3, (byte)Math.Min(Param.Sleep_ms, 255), (byte)Param.Min);
        }
    }
}
