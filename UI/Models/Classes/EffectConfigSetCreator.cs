using Control.Models.Classes.ViewEffectConfigSet;
using Control.Models.Classes.ViewEffects;
using Control.Models.Interfaces;
using PhilipsHue.EffectConfig.Creators.Classes;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using PhilipsHue.EffectConfig.Products.Classes;
using PhilipsHue.Models.Interfaces;
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
        internal static IViewEffectConfigSet CreateConfigSet(IConfigVMSet set)
        {
            IViewEffectConfigSet effectConfigSet = null;
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
                    effectConfigSet = CreateFadeOutConfigSet(set);
                    break;
                case BrightnessWaveConfig_VMSet s:
                    effectConfigSet = CreateBrightnessWaveConfigSet(set);
                    break;
                case ColorWaveConfig_VMSet s:
                    effectConfigSet = CreateColorWaveConfigSet(set);
                    break;
                case TurnOnConfig_VMSet s:
                    effectConfigSet = CreateTurnOnConfigSet(set);
                    break;
                case TurnOffConfig_VMSet s:
                    effectConfigSet = CreateTurnOffConfigSet(set);
                    break;
                default:
                    break;
            }
            return effectConfigSet;
        }

        private static IViewEffectConfigSet CreateColorChangeConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is ColorChangeConfig_VMSet)
            {
                ColorChangeConfig_VMSet set = (ColorChangeConfig_VMSet)vmSet;
                ColorConfig_ViewModel colorConfig = set.FinalColor;                

                if (colorConfig.SelectedColor.HasValue)
                {
                    Color value = colorConfig.SelectedColor.Value;
                    var color = System.Drawing.Color.FromArgb(value.A, value.R, value.G, value.B);

                    TransitionTimeConfig_ViewModel transitionTimeConfig = set.TransitionTime;
                    uint transitiontime = transitionTimeConfig.TransitionTime;

                    return new ColorChangeViewConfigSet(color, transitiontime);
                }
            }
            return null;
        }
        private static IViewEffectConfigSet CreateFlashConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is FlashConfig_VMSet)
            {
                FlashConfig_VMSet flashConfig = (FlashConfig_VMSet)vmSet;
                TransitionTimeConfig_ViewModel transitionTimeConfig = flashConfig.TransitionTime;

                return new FlashViewConfigSet(flashConfig.FirstBrightnessLevel.BrightnessLevel, flashConfig.SecondBrightnessLevel.BrightnessLevel,
                    transitionTimeConfig.TransitionTime);
            }
            return null;
        }
        private static IViewEffectConfigSet CreateFadeInConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is FadeInConfig_VMSet)
            {
                FadeInConfig_VMSet fadeInConfig = (FadeInConfig_VMSet)vmSet;
                TransitionTimeConfig_ViewModel transitionTimeConfig = fadeInConfig.TransitionTime;

                return new FadeInViewConfigSet(fadeInConfig.BrightnessLevel.BrightnessLevel, transitionTimeConfig.TransitionTime);
            }
            return null;
        }
        private static IViewEffectConfigSet CreateFadeOutConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is FadeOutConfig_VMSet)
            {
                FadeOutConfig_VMSet fadeOutConfig = (FadeOutConfig_VMSet)vmSet;
                TransitionTimeConfig_ViewModel transitionTimeConfig = fadeOutConfig.TransitionTime;

                return new FadeOutViewConfigSet(fadeOutConfig.BrightnessLevel.BrightnessLevel, transitionTimeConfig.TransitionTime);
            }
            return null;
        }

        private static IViewEffectConfigSet CreateBrightnessWaveConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is BrightnessWaveConfig_VMSet)
            {
                BrightnessWaveConfig_VMSet config = (BrightnessWaveConfig_VMSet)vmSet;
                LightListConfig_ViewModel lightListConfig = config.LightList;

                List<IViewLight> lights = new List<IViewLight>();
                foreach(var item in lightListConfig.Collection)
                {
                    CardConfigList_ViewModel cardConfigList = (CardConfigList_ViewModel)item;
                    if (cardConfigList.Item is IViewLight)
                    {
                        lights.Add((IViewLight)cardConfigList.Item);
                    }
                }

                return new BrightnessWaveViewConfigSet(config.BrightnessLevel.BrightnessLevel, config.TransitionTime.TransitionTime, lights, config.IntervalTime.TransitionTime);
            }
            return null;
        }

        private static IViewEffectConfigSet CreateColorWaveConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is ColorWaveConfig_VMSet)
            {
                ColorWaveConfig_VMSet config = (ColorWaveConfig_VMSet)vmSet;
                LightListConfig_ViewModel lightListConfig = config.LightList;

                if (config.FinalColor.SelectedColor.HasValue)
                {
                    Color colorValue = config.FinalColor.SelectedColor.Value;
                    var color = System.Drawing.Color.FromArgb(colorValue.A, colorValue.R, colorValue.G, colorValue.B);

                    List<IViewLight> lights = new List<IViewLight>();
                    foreach (var item in lightListConfig.Collection)
                    {
                        CardConfigList_ViewModel cardConfigList = (CardConfigList_ViewModel)item;
                        if (cardConfigList.Item is IViewLight effect)
                        {
                            lights.Add(effect);
                        }
                    }

                    return new ColorWaveViewConfigSet(color, config.TransitionTime.TransitionTime, lights, config.IntervalTime.TransitionTime);
                }
            }
            return null;
        }

        private static IViewEffectConfigSet CreateTurnOnConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is TurnOnConfig_VMSet)
            {
                return new TurnOnViewConfigSet();
            }
            return null;
        }

        private static IViewEffectConfigSet CreateTurnOffConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is TurnOffConfig_VMSet)
            {
                return new TurnOffViewConfigSet();
            }
            return null;
        }
    }
}
