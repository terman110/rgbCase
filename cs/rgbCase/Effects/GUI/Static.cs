using rgbCase.Base;
using System;

namespace rgbCase.Effects
{
    public partial class Static :
#if DEBUG
        EffectBaseAbstractHack
#else
        EffectBase
#endif
    {
        public Static(Parameter.Static objParam) : base()
        {
            Param = objParam;
            InitializeComponent();
        }

        public Parameter.Static Param { get; set; }

        public override IEffectParameter ParamI { get { return Param; } }

        public override bool IsAnimation { get { return false; } }

        public override void Init(IMainForm form)
        {
            form.SetVisibility(true, true);
            form.Brightness = Math.Max((byte)128, form.Brightness);
            System.Threading.Thread.Sleep(10);
            form.Color = form.Color;
        }

        public override void Work(IMainForm form)
        {

        }
    }
}
