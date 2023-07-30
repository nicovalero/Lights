using PhilipsHue.ColorConverters;
using PhilipsHue.EffectConfig.Creators.Classes;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using PhilipsHue.EffectConfig.Products.Classes;
using PhilipsHue.Effects.Classes;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using UI.Models.Interfaces;
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
                case FlashConfigSet s:
                    effectConfigSet = CreateFlashConfigVMSet(s);
                    break;
                case FadeInConfigSet s:
                    effectConfigSet = CreateFadeInConfigVMSet(s);
                    break;
                case FadeOutConfigSet s:
                    effectConfigSet = CreateFadeOutConfigVMSet(s);
                    break;
                case BrightnessWaveConfigSet s:
                    effectConfigSet = CreateBrightnessWaveConfigVMSet(s);
                    break;
                case ColorWaveConfigSet s:
                    effectConfigSet = CreateColorWaveConfigVMSet(s);
                    break;
                case TurnOnConfigSet s:
                    effectConfigSet = CreateTurnOnConfigVMSet(s);
                    break;
                default:
                    break;
            }
            return effectConfigSet;
        }

        internal static IConfigVMSet CreateConfigSetFromEffect(LightEffect effect)
        {
            IConfigVMSet set = null;
            switch (effect)
            {
                case Flash f:
                    set = new FlashConfig_VMSet(new BrightnessConfig_ViewModel(), new BrightnessConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case ColorChange c:
                    set = new ColorChangeConfig_VMSet(new ColorConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case FadeIn f:
                    set = new FadeInConfig_VMSet(new BrightnessConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case FadeOut f:
                    set = new FadeOutConfig_VMSet(new BrightnessConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case BrightnessWave b:
                    set = new BrightnessWaveConfig_VMSet(new BrightnessConfig_ViewModel(), new LightListConfig_ViewModel(),
                        new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case ColorWave s:
                    set = new ColorWaveConfig_VMSet(new ColorConfig_ViewModel(), new LightListConfig_ViewModel(),
                        new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case TurnOn s:
                    set = new TurnOnConfig_VMSet();
                    break;
                default:
                    break;
            }

            return set;
        }

        private static IConfigVMSet CreateColorChangeConfigVMSet(IEffectConfigSet set)
        {
            if (set is ColorChangeConfigSet configSet)
            {
                Color color = Color.FromRgb(configSet.FinalColor.RGBColor.R, configSet.FinalColor.RGBColor.G, configSet.FinalColor.RGBColor.B);
                ColorConfig_ViewModel colorConfig = new ColorConfig_ViewModel(color);

                uint transitiontime = (uint)configSet.TransitionTimeConfig.Value;
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                return new ColorChangeConfig_VMSet(colorConfig, transitionTimeVM);
            }
            return null;
        }
        private static IConfigVMSet CreateFlashConfigVMSet(IEffectConfigSet set)
        {
            if (set is FlashConfigSet configSet)
            {
                uint transitiontime = (uint)configSet.TransitionTimeConfig.Value;
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                BrightnessConfig_ViewModel firstBrightnessVM = new BrightnessConfig_ViewModel((byte)configSet.FinalBrightnessConfig.Value);
                BrightnessConfig_ViewModel secondBrightnessVM = new BrightnessConfig_ViewModel((byte)configSet.InitialBrightnessConfig.Value);

                return new FlashConfig_VMSet(firstBrightnessVM, secondBrightnessVM, transitionTimeVM);
            }
            return null;
        }
        private static IConfigVMSet CreateFadeInConfigVMSet(IEffectConfigSet vmSet)
        {
            if (vmSet is FadeInConfigSet configSet)
            {
                uint transitiontime = (uint)configSet.TransitionTimeConfig.Value;
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                BrightnessConfig_ViewModel brightnessVM = new BrightnessConfig_ViewModel((byte)configSet.BrightnessConfig.Value);

                return new FadeInConfig_VMSet(brightnessVM, transitionTimeVM);
            }
            return null;
        }
        private static IConfigVMSet CreateFadeOutConfigVMSet(IEffectConfigSet vmSet)
        {
            if (vmSet is FadeOutConfigSet configSet)
            {
                uint transitiontime = (uint)configSet.TransitionTimeConfig.Value;
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                BrightnessConfig_ViewModel brightnessVM = new BrightnessConfig_ViewModel((byte)configSet.BrightnessConfig.Value);

                return new FadeOutConfig_VMSet(brightnessVM, transitionTimeVM);
            }
            return null;
        }

        private static IConfigVMSet CreateBrightnessWaveConfigVMSet(IEffectConfigSet vmSet)
        {
            if (vmSet is BrightnessWaveConfigSet configSet)
            {
                List<IConfigListViewModel> lightsVM = new List<IConfigListViewModel>();
                List<CardConfigList_ViewModel> list = HueLight_ToCardConfigConverter.ConvertHueLight_ToCardConfig(configSet.LightListConfig.LightList);

                foreach (CardConfigList_ViewModel vm in list)
                    lightsVM.Add(vm);
                
                ObservableCollection<IConfigListViewModel> collection = new ObservableCollection<IConfigListViewModel>(lightsVM);
                LightListConfig_ViewModel lightListConfigVM = new LightListConfig_ViewModel(collection);

                BrightnessConfig_ViewModel brightnessVM = new BrightnessConfig_ViewModel((byte)configSet.BrightnessConfig.Value);

                uint transitiontime = (uint)configSet.TransitionTimeConfig.Value;
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                uint intervaltime = (uint)configSet.IntervalTimeConfig.GetTimeInTenthOfSeconds();
                TransitionTimeConfig_ViewModel intervalTimeVM = new TransitionTimeConfig_ViewModel(intervaltime);

                return new BrightnessWaveConfig_VMSet(brightnessVM, lightListConfigVM, transitionTimeVM, intervalTimeVM);
            }
            return null;
        }

        private static IConfigVMSet CreateColorWaveConfigVMSet(IEffectConfigSet vmSet)
        {
            if (vmSet is ColorWaveConfigSet configSet)
            {
                Color color = Color.FromRgb(configSet.ColorConfig.RGBColor.R, configSet.ColorConfig.RGBColor.G, configSet.ColorConfig.RGBColor.B);
                ColorConfig_ViewModel colorConfig = new ColorConfig_ViewModel(color);

                List<IConfigListViewModel> lightsVM = new List<IConfigListViewModel>();
                List<CardConfigList_ViewModel> list = HueLight_ToCardConfigConverter.ConvertHueLight_ToCardConfig(configSet.LightListConfig.LightList);

                foreach (CardConfigList_ViewModel vm in list)
                    lightsVM.Add(vm);

                ObservableCollection<IConfigListViewModel> collection = new ObservableCollection<IConfigListViewModel>(lightsVM);
                LightListConfig_ViewModel lightListConfigVM = new LightListConfig_ViewModel(collection);

                uint transitiontime = (uint)configSet.TransitionTimeConfig.Value;
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                uint intervaltime = (uint)configSet.IntervalTimeConfig.GetTimeInTenthOfSeconds();
                TransitionTimeConfig_ViewModel intervalTimeVM = new TransitionTimeConfig_ViewModel(intervaltime);

                return new ColorWaveConfig_VMSet(colorConfig, lightListConfigVM, transitionTimeVM, intervalTimeVM);
            }
            return null;
        }

        private static IConfigVMSet CreateTurnOnConfigVMSet(IEffectConfigSet vmSet)
        {
            if (vmSet is TurnOnConfigSet configSet)
            {

                return new TurnOnConfig_VMSet();
            }
            return null;
        }
    }
}
