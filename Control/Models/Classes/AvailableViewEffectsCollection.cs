using Control.Factories;
using Control.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Classes
{
    public enum AvailableViewEffects
    {
        UniversalOn,
        UniversalOff,
        UniversalFlash,
        UniversalColorChange,
        UniversalBrightnessChange,
        UniversalFadeIn,
        UniversalFadeOut,
        UniversalBrightnessWave,
        UniversalColorWave,
        NanoleafEffect
    }

    internal static class AvailableViewEffectsCollection
    {
        public static HashSet<IViewEffect> GetAvailableViewEffects()
        {
            ViewEffectFactory factory = new ViewEffectFactory();
            HashSet<IViewEffect> set = new HashSet<IViewEffect>();
            set.Add(factory.Construct(AvailableViewEffects.UniversalOn));
            set.Add(factory.Construct(AvailableViewEffects.UniversalOff));
            //set.Add(factory.Construct(AvailableViewEffects.UniversalFlash));
            //set.Add(factory.Construct(AvailableViewEffects.UniversalColorChange));
            //set.Add(factory.Construct(AvailableViewEffects.UniversalBrightnessChange));
            //set.Add(factory.Construct(AvailableViewEffects.NanoleafEffect));

            return set;
        }
    }
}
