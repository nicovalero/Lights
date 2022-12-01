using PhilipsHue.ColorConverters;
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
    public static class ConfigVMSetCreator
    {
        internal static IConfigVMSet CreateConfigSet(IEffectConfigSet set)
        {
            IConfigVMSet effectConfigSet = null;
            switch (set)
            {
                case ColorChangeConfigSet s:
                    effectConfigSet = CreateColorChangeConfigVMSet(s);
                    break;
                //case FlashConfigSet s:
                //    effectConfigSet = CreateFlashConfigVMSet(s);
                //    break;
                //case FadeInConfigSet s:
                //    effectConfigSet = CreateFadeInConfigVMSet(s);
                //    break;
                //case FadeOutConfigSet s:
                //    effectConfigSet = CreateFadeOutConfigVMSet(s);
                //    break;
                //case BrightnessWaveConfigSet s:
                //    effectConfigSet = CreateBrightnessWaveConfigVMSet(s);
                //    break;
                //case ColorWaveConfigSet s:
                //    effectConfigSet = CreateColorWaveConfigVMSet(s);
                //    break;
                default:
                    break;
            }
            return effectConfigSet;
        }

        private static IConfigVMSet CreateColorChangeConfigVMSet(IEffectConfigSet set)
        {
            if (set is ColorChangeConfigSet configSet)
            {
                Color color = Color.FromRgb(configSet.FinalColor.RGBColor.R, configSet.FinalColor.RGBColor.G, configSet.FinalColor.RGBColor.B);
                ColorConfig_ViewModel colorConfig = new ColorConfig_ViewModel(color);

                uint transitiontime = (uint)configSet.TransitionTimeConfig.Value;
                TransitionTimeConfig_ViewModel transitionTimeConfig = new TransitionTimeConfig_ViewModel(transitiontime);

                return new ColorChangeConfig_VMSet(colorConfig, transitionTimeConfig);
            }
            return null;
        }
        //private static IConfigVMSet CreateFlashConfigSet(IEffectConfigSet vmSet)
        //{
        //    if (vmSet is FlashConfig_VMSet)
        //    {
        //        FlashConfig_VMSet flashConfig = (FlashConfig_VMSet)vmSet;
        //        TransitionTimeConfig_ViewModel transitionTimeConfig = flashConfig.TransitionTime;

        //        return new FlashConfigSet(flashConfig.FirstBrightnessLevel.BrightnessLevel, flashConfig.SecondBrightnessLevel.BrightnessLevel,
        //            transitionTimeConfig.TransitionTime);
        //    }
        //    return null;
        //}
        //private static IConfigVMSet CreateFadeInConfigSet(IEffectConfigSet vmSet)
        //{
        //    if (vmSet is FadeInConfig_VMSet)
        //    {
        //        FadeInConfig_VMSet fadeInConfig = (FadeInConfig_VMSet)vmSet;
        //        TransitionTimeConfig_ViewModel transitionTimeConfig = fadeInConfig.TransitionTime;

        //        return new FadeInConfigSet(fadeInConfig.BrightnessLevel.BrightnessLevel, transitionTimeConfig.TransitionTime);
        //    }
        //    return null;
        //}
        //private static IConfigVMSet CreateFadeOutConfigSet(IEffectConfigSet vmSet)
        //{
        //    if (vmSet is FadeOutConfig_VMSet)
        //    {
        //        FadeOutConfig_VMSet fadeOutConfig = (FadeOutConfig_VMSet)vmSet;
        //        TransitionTimeConfig_ViewModel transitionTimeConfig = fadeOutConfig.TransitionTime;

        //        return new FadeOutConfigSet(fadeOutConfig.BrightnessLevel.BrightnessLevel, transitionTimeConfig.TransitionTime);
        //    }
        //    return null;
        //}

        //private static IConfigVMSet CreateBrightnessWaveConfigSet(IEffectConfigSet vmSet)
        //{
        //    if (vmSet is BrightnessWaveConfig_VMSet)
        //    {
        //        BrightnessWaveConfig_VMSet config = (BrightnessWaveConfig_VMSet)vmSet;
        //        LightListConfig_ViewModel lightListConfig = config.LightList;

        //        List<HueLight> lights = new List<HueLight>();
        //        foreach (var item in lightListConfig.Collection)
        //        {
        //            CardConfigList_ViewModel cardConfigList = (CardConfigList_ViewModel)item;
        //            if (cardConfigList.Item is HueLight)
        //            {
        //                HueLight light = (HueLight)cardConfigList.Item;
        //                lights.Add(light);
        //            }
        //        }

        //        HueLightListConfig lightsConfig = new HueLightListConfig(lights);
        //        TransitionTimeConfig transitionConfig = new TransitionTimeConfig(config.TransitionTime.TransitionTime);
        //        TransitionTimeConfig intervalConfig = new TransitionTimeConfig(config.IntervalTime.TransitionTime);

        //        return new BrightnessWaveConfigSet(config.BrightnessLevel.BrightnessLevel, transitionConfig, lightsConfig, intervalConfig);
        //    }
        //    return null;
        //}

        //private static IConfigVMSet CreateColorWaveConfigSet(IEffectConfigSet vmSet)
        //{
        //    if (vmSet is ColorWaveConfig_VMSet)
        //    {
        //        ColorWaveConfig_VMSet config = (ColorWaveConfig_VMSet)vmSet;
        //        LightListConfig_ViewModel lightListConfig = config.LightList;

        //        if (config.FinalColor.SelectedColor.HasValue)
        //        {
        //            Color colorValue = config.FinalColor.SelectedColor.Value;
        //            var color = System.Drawing.Color.FromArgb(colorValue.A, colorValue.R, colorValue.G, colorValue.B);

        //            List<HueLight> lights = new List<HueLight>();
        //            foreach (var item in lightListConfig.Collection)
        //            {
        //                CardConfigList_ViewModel cardConfigList = (CardConfigList_ViewModel)item;
        //                if (cardConfigList.Item is HueLight)
        //                {
        //                    HueLight light = (HueLight)cardConfigList.Item;
        //                    lights.Add(light);
        //                }
        //            }

        //            HueLightListConfig lightsConfig = new HueLightListConfig(lights);
        //            TransitionTimeConfig transitionConfig = new TransitionTimeConfig(config.TransitionTime.TransitionTime);
        //            TransitionTimeConfig intervalConfig = new TransitionTimeConfig(config.IntervalTime.TransitionTime);

        //            return new ColorWaveConfigSet(color, transitionConfig, lightsConfig, intervalConfig);
        //        }
        //    }
        //    return null;
        //}
    }
}
