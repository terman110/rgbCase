using System.Windows.Forms;

namespace rgbCase
{
    internal class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}
