using rgbCase.Base;
using System.Windows.Forms;

namespace rgbCase.Effects
{
    public abstract class EffectBase : UserControl
    {
        public EffectBase() : base()
        {
        }

        abstract public IEffectParameter ParamI { get; }

        abstract public bool IsAnimation { get; }

        abstract public void Init(IMainForm form);

        abstract public void Work(IMainForm form);

        virtual protected new void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public static Effects.EffectBase GetEffect(EModes nMode)
        {
            if (Settings.Instance == null)
                return null;

            switch (nMode)
            {
                case EModes.Static: return new Effects.Static(Settings.Instance.Static);
                case EModes.Strobing: return new Effects.Strobing(Settings.Instance.Strobing);
                case EModes.Breathing: return new Effects.Breathing(Settings.Instance.Breathing);
                case EModes.ColorCycle: return new Effects.ColorCycle(Settings.Instance.ColorCycle);
                case EModes.BreathingCycle: return new Effects.BreathingCycle(Settings.Instance.BreathingCycle);
                case EModes.ScreenGrab: return new Effects.ScreenGrab(Settings.Instance.ScreenGrab);
                default: return null;
            }
        }
    }

#if DEBUG
    public class EffectBaseAbstractHack : EffectBase
    {
        public EffectBaseAbstractHack() : base()
        {
        }

        override public IEffectParameter ParamI { get { return null; } }

        override public bool IsAnimation { get { return false; } }

        override public void Init(IMainForm form) { }

        override public void Work(IMainForm form) { }
    }
#endif
}
