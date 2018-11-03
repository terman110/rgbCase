using rgbCase.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgbCase.Effects.Parameter
{
    public class ScreenGrab : IEffectParameter
    {
        public ScreenGrab() { }

        public uint Sleep_ms { get; set; } = 250;
        public int Screen_Idx { get; set; } = 0;
    }
}
