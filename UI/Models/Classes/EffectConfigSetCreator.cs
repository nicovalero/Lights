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

                    TransitionTimeConfig_ViewModel transitionTimeConfig = set.TransitionTime;
                    uint transitiontime = transitionTimeConfig.TransitionTime;

                    return new ColorChangeConfigSet(color, transitiontime);
                }
            }
            return null;
        }
        private static FlashConfigSet CreateFlashConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is FlashConfig_VMSet)
            {
                FlashConfig_VMSet flashConfig = (FlashConfig_VMSet)vmSet;
                TransitionTimeConfig_ViewModel transitionTimeConfig = flashConfig.TransitionTime;

                return new FlashConfigSet(flashConfig.FirstBrightnessLevel.BrightnessLevel, flashConfig.SecondBrightnessLevel.BrightnessLevel,
                    transitionTimeConfig.TransitionTime);
            }
            return null;
        }
        private static IEffectConfigSet CreateFadeInConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is FadeInConfig_VMSet)
            {
                FadeInConfig_VMSet fadeInConfig = (FadeInConfig_VMSet)vmSet;
                TransitionTimeConfig_ViewModel transitionTimeConfig = fadeInConfig.TransitionTime;

                return new FadeInConfigSet(fadeInConfig.BrightnessLevel.BrightnessLevel, transitionTimeConfig.TransitionTime);
            }
            return null;
        }
        private static IEffectConfigSet CreateFadeOutConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is FadeOutConfig_VMSet)
            {
                FadeOutConfig_VMSet fadeOutConfig = (FadeOutConfig_VMSet)vmSet;
                TransitionTimeConfig_ViewModel transitionTimeConfig = fadeOutConfig.TransitionTime;

                return new FadeOutConfigSet(fadeOutConfig.BrightnessLevel.BrightnessLevel, transitionTimeConfig.TransitionTime);
            }
            return null;
        }

        private static IEffectConfigSet CreateBrightnessWaveConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is BrightnessWaveConfig_VMSet)
            {
                BrightnessWaveConfig_VMSet config = (BrightnessWaveConfig_VMSet)vmSet;
                LightListConfig_ViewModel lightListConfig = config.LightList;

                List<HueLight> lights = new List<HueLight>();
                foreach(var item in lightListConfig.Collection)
                {
                    CardConfigList_ViewModel cardConfigList = (CardConfigList_ViewModel)item;
                    if (cardConfigList.Item is HueLight)
                    {
                        HueLight light = (HueLight)cardConfigList.Item;
                        lights.Add(light);
                    }
                }

                HueLightListConfig lightsConfig = new HueLightListConfig(lights);
                TransitionTimeConfig transitionConfig = new TransitionTimeConfig(config.TransitionTime.TransitionTime);
                TransitionTimeConfig intervalConfig = new TransitionTimeConfig(config.IntervalTime.TransitionTime);

                return new BrightnessWaveConfigSet(config.BrightnessLevel.BrightnessLevel, transitionConfig, lightsConfig, intervalConfig);
            }
            return null;
        }

        private static IEffectConfigSet CreateColorWaveConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is ColorWaveConfig_VMSet)
            {
                ColorWaveConfig_VMSet config = (ColorWaveConfig_VMSet)vmSet;
                LightListConfig_ViewModel lightListConfig = config.LightList;

                if (config.FinalColor.SelectedColor.HasValue)
                {
                    Color colorValue = config.FinalColor.SelectedColor.Value;
                    var color = System.Drawing.Color.FromArgb(colorValue.A, colorValue.R, colorValue.G, colorValue.B);

                    List<HueLight> lights = new List<HueLight>();
                    foreach (var item in lightListConfig.Collection)
                    {
                        CardConfigList_ViewModel cardConfigList = (CardConfigList_ViewModel)item;
                        if (cardConfigList.Item is HueLight)
                        {
                            HueLight light = (HueLight)cardConfigList.Item;
                            lights.Add(light);
                        }
                    }

                    HueLightListConfig lightsConfig = new HueLightListConfig(lights);
                    TransitionTimeConfig transitionConfig = new TransitionTimeConfig(config.TransitionTime.TransitionTime);
                    TransitionTimeConfig intervalConfig = new TransitionTimeConfig(config.IntervalTime.TransitionTime);

                    return new ColorWaveConfigSet(color, transitionConfig, lightsConfig, intervalConfig);
                }
            }
            return null;
        }

        private static IEffectConfigSet CreateTurnOnConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is TurnOnConfig_VMSet)
            {
                TurnOnConfig_VMSet turnOnConfig = (TurnOnConfig_VMSet)vmSet;

                return new TurnOnConfigSet();
            }
            return null;
        }

        private static IEffectConfigSet CreateTurnOffConfigSet(IConfigVMSet vmSet)
        {
            if (vmSet is TurnOffConfig_VMSet)
            {
                TurnOffConfig_VMSet turnOnConfig = (TurnOffConfig_VMSet)vmSet;

                return new TurnOffConfigSet();
            }
            return null;
        }
    }
}
