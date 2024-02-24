using Control.Models.Interfaces;
using Nanoleaf.Devices.Classes;
using Nanoleaf.Effects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Control.Enums;

namespace Control.Parsers.EffectParsers
{
    internal static class NanoleafEffectViewEffectParser
    {
        internal static AvailableEffects GetAvailableEffectFromViewEffect(IViewEffect effect)
        {
            AvailableEffects availableEffect;

            switch(effect.GetKind())
            {
                case AvailableViewEffects.UniversalFlash:
                    availableEffect = AvailableEffects.Flash;
                    break;
                case AvailableViewEffects.UniversalOff:
                    availableEffect = AvailableEffects.TurnOff;
                    break;
                case AvailableViewEffects.UniversalOn:
                    availableEffect = AvailableEffects.TurnOn;
                    break;
                case AvailableViewEffects.UniversalFadeIn:
                    availableEffect = AvailableEffects.FadeIn;
                    break;
                case AvailableViewEffects.UniversalFadeOut:
                    availableEffect = AvailableEffects.FadeOut;
                    break;
                case AvailableViewEffects.UniversalColorChange:
                    availableEffect = AvailableEffects.ColorChange;
                    break;
                case AvailableViewEffects.UniversalColorWave:
                    availableEffect = AvailableEffects.ColorWave;
                    break;
                default:
                    availableEffect = AvailableEffects.Invalid;
                    break;
            }

            return availableEffect;
        }

        internal static AvailableEffects GetIdentifyAvailableEffectColorChange()
        {
            return AvailableEffects.ColorChange;
        }

        internal static AvailableEffects GetIdentifyAvailableEffectOn()
        {
            return AvailableEffects.TurnOn;
        }
    }
}
