using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace rgbCase.Effects
{
    internal partial class Static :
#if DEBUG
        EffectBaseAbstractHack
#else
        EffectBase
#endif
    {
        public class Parameter
        {
            public Parameter() { }
        }

        public Static(Parameter objParam) : base()
        {
            Param = objParam;
            InitializeComponent();
        }

        public Parameter Param { get; set; }

        public override bool IsAnimation { get { return false; } }

        public override void Init(MainForm form)
        {
            form.SetVisibility(true, true);
            form.Brightness = Math.Max((byte)128, form.Brightness);
            System.Threading.Thread.Sleep(10);
            form.Color = form.Color;
        }

        public override void Work(MainForm form)
        {

        }
    }
}
