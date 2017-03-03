using System.Windows.Forms;

namespace rgbCase.Effects
{
    internal abstract class EffectBase : UserControl
    {
        public EffectBase() : base()
        {
        }

        abstract public bool IsAnimation { get; }

        abstract public void Init(MainForm form);

        abstract public void Work(MainForm form);
    }

#if DEBUG
    internal class EffectBaseAbstractHack : EffectBase
    {
        public EffectBaseAbstractHack() : base()
        {
        }

        override public bool IsAnimation { get { return false; } }

        override public void Init(MainForm form) { }

        override public void Work(MainForm form) { }
    }
#endif
}
