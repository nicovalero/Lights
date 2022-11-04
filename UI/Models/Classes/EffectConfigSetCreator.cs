using PhilipsHue.EffectConfig.Creators.Classes;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets;
using UI.Models.ViewModel_Config_Sets.Classes;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI.Models.Classes
{
    public static class EffectConfigSetCreator
    {
        internal static IEffectConfigSet CreateConfigSet(IConfigVMSet set)
        {
            IEffectConfigSet effectConfigSet = null;
            switch (set)
            {
                case ColorChangeConfig_VMSet s:
                    effectConfigSet = CreateColorChangeConfigSet(set);
                    break;
                case FlashConfig_VMSet s:
                    effectConfigSet = CreateFlashConfigSet(set);
                    break;
                case FadeInConfig_VMSet s:
                    effectConfigSet = CreateFadeInConfigSet(set);
                    break;
                case FadeOutConfig_VMSet s:
                    effectConfigSet = CreateFadeInConfigSet(set);
                    break;
                default:
                    break;
            }
            return effectConfigSet;
        }

        private static ColorChangeConfigSet CreateColorChangeConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is ColorChangeConfig_VMSet)
            {
                ColorChangeConfig_VMSet set = (ColorChangeConfig_VMSet)vmSet;
                ColorConfig_ViewModel colorConfig = set.FinalColor;

                if (colorConfig.SelectedColor.HasValue)
                {
                    Color value = colorConfig.SelectedColor.Value;
                    var color = System.Drawing.Color.FromArgb(value.A, value.R, value.G, value.B);
                    return new ColorChangeConfigSet(color);
                }
            }
            return null;
        }
        private static FlashConfigSet CreateFlashConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is FlashConfig_VMSet)
            {
                FlashConfig_VMSet flashConfig = (FlashConfig_VMSet)vmSet;

                return new FlashConfigSet(flashConfig.FirstBrightnessLevel.BrightnessLevel, flashConfig.SecondBrightnessLevel.BrightnessLevel);
            }
            return null;
        }
        private static IEffectConfigSet CreateFadeInConfigSet(IConfigVMSet vmSet)
        {
            //To be implemented
            if (vmSet is FlashConfig_VMSet)
            {
                FlashConfig_VMSet flashConfig = (FlashConfig_VMSet)vmSet;

                return new FadeInConfigSet(flashConfig.FirstBrightnessLevel.BrightnessLevel, flashConfig.SecondBrightnessLevel.BrightnessLevel);
            }
            return null;
        }
        private static IEffectConfigSet CreateFadeOutConfigSet(IConfigVMSet vmSet)
        {
            //To be implemented
            if (vmSet is FlashConfig_VMSet)
            {
                FlashConfig_VMSet flashConfig = (FlashConfig_VMSet)vmSet;

                return new FadeOutConfigSet(flashConfig.FirstBrightnessLevel.BrightnessLevel, flashConfig.SecondBrightnessLevel.BrightnessLevel);
            }
            return null;
        }
    }
}
