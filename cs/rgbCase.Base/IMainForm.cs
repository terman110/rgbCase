using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rgbCase.Base
{
    public interface IMainForm
    {
        bool HideOnLaunch { get; set; }
        Color Color { get; set; }
        byte Brightness { get; set; }
        void SetControllerMode(byte value, byte p1, byte p2);
        void SetVisibility(bool bBright, bool bColor);
    }
}
