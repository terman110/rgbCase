using rgbCase.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgbCase.Effects.Parameter
{
    public class ColorCycle : IEffectParameter
    {
        public ColorCycle() { }

        public uint Sleep_ms { get; set; } = 9;
        public bool ControllerBased { get; set; } = true;
    }
}
