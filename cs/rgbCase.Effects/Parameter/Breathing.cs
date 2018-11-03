using rgbCase.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgbCase.Effects.Parameter
{
    public class Breathing : IEffectParameter
    {
        public Breathing() { }

        public byte Min { get; set; } = 0;
        public byte Max { get; set; } = 255;
        public uint Sleep_ms { get; set; } = 10;
        public bool ControllerBased { get; set; } = true;
    }
}
