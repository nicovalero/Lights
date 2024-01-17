using Control.Enums;
using Control.Models.Classes.ViewEffectConfigSet;
using Control.Models.Interfaces;
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
        internal static IConfigVMSet CreateConfigSet(IViewEffectConfigSet set)
        {
            IConfigVMSet effectConfigSet = null;
            switch (set)
            {
                case ColorChangeViewConfigSet s:
                    effectConfigSet = CreateColorChangeConfigVMSet(s);
                    break;
                case FlashViewConfigSet s:
                    effectConfigSet = CreateFlashConfigVMSet(s);
                    break;
                case FadeInViewConfigSet s:
                    effectConfigSet = CreateFadeInConfigVMSet(s);
                    break;
                case FadeOutViewConfigSet s:
                    effectConfigSet = CreateFadeOutConfigVMSet(s);
                    break;
                case BrightnessWaveViewConfigSet s:
                    effectConfigSet = CreateBrightnessWaveConfigVMSet(s);
                    break;
                case ColorWaveViewConfigSet s:
                    effectConfigSet = CreateColorWaveConfigVMSet(s);
                    break;
                case TurnOnViewConfigSet s:
                    effectConfigSet = CreateTurnOnConfigVMSet(s);
                    break;
                case TurnOffViewConfigSet s:
                    effectConfigSet = CreateTurnOffConfigVMSet(s);
                    break;
                default:
                    break;
            }
            return effectConfigSet;
        }

        internal static IConfigVMSet CreateConfigSetFromEffect(IViewEffect effect)
        {
            IConfigVMSet set = null;
            switch (effect.GetKind())
            {
                case AvailableViewEffects.UniversalFlash:
                    set = new FlashConfig_VMSet(new BrightnessConfig_ViewModel(), new BrightnessConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case AvailableViewEffects.UniversalColorChange:
                    set = new ColorChangeConfig_VMSet(new ColorConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case AvailableViewEffects.UniversalFadeIn:
                    set = new FadeInConfig_VMSet(new BrightnessConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case AvailableViewEffects.UniversalFadeOut:
                    set = new FadeOutConfig_VMSet(new BrightnessConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case AvailableViewEffects.UniversalBrightnessWave:
                    set = new BrightnessWaveConfig_VMSet(new BrightnessConfig_ViewModel(), new LightListConfig_ViewModel(),
                        new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case AvailableViewEffects.UniversalColorWave:
                    set = new ColorWaveConfig_VMSet(new ColorConfig_ViewModel(), new LightListConfig_ViewModel(),
                        new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    break;
                case AvailableViewEffects.UniversalOn:
                    set = new TurnOnConfig_VMSet();
                    break;
                case AvailableViewEffects.UniversalOff:
                    set = new TurnOffConfig_VMSet();
                    break;
                case AvailableViewEffects.NanoleafEffect:
                    set = new NanoleafEffectConfig_VMSet();
                    break;
                default:
                    break;
            }

            return set;
        }

        private static IConfigVMSet CreateColorChangeConfigVMSet(IViewEffectConfigSet set)
        {
            if (set is ColorChangeViewConfigSet configSet)
            {
                //Would be good to normalize this instead of doing the parse in this method
                var colorString = configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.Color).ToString();
                var drawingColor = System.Drawing.Color.FromArgb(Convert.ToInt32(colorString));
                Color color = Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
                ColorConfig_ViewModel colorConfig = new ColorConfig_ViewModel(color);

                uint transitiontime = Convert.ToUInt16(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                return new ColorChangeConfig_VMSet(colorConfig, transitionTimeVM);
            }
            return null;
        }
        private static IConfigVMSet CreateFlashConfigVMSet(IViewEffectConfigSet set)
        {
            if (set is FlashViewConfigSet configSet)
            {
                uint transitiontime = Convert.ToUInt16(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                BrightnessConfig_ViewModel firstBrightnessVM = new BrightnessConfig_ViewModel(Convert.ToByte(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessStart)));
                BrightnessConfig_ViewModel secondBrightnessVM = new BrightnessConfig_ViewModel(Convert.ToByte(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessFinal)));

                return new FlashConfig_VMSet(firstBrightnessVM, secondBrightnessVM, transitionTimeVM);
            }
            return null;
        }
        private static IConfigVMSet CreateFadeInConfigVMSet(IViewEffectConfigSet vmSet)
        {
            if (vmSet is FadeInViewConfigSet configSet)
            {
                uint transitiontime = Convert.ToUInt16(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                BrightnessConfig_ViewModel brightnessVM = new BrightnessConfig_ViewModel(Convert.ToByte(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel)));

                return new FadeInConfig_VMSet(brightnessVM, transitionTimeVM);
            }
            return null;
        }
        private static IConfigVMSet CreateFadeOutConfigVMSet(IViewEffectConfigSet vmSet)
        {
            if (vmSet is FadeOutViewConfigSet configSet)
            {
                uint transitiontime = Convert.ToUInt16(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                BrightnessConfig_ViewModel brightnessVM = new BrightnessConfig_ViewModel(Convert.ToByte(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel)));

                return new FadeOutConfig_VMSet(brightnessVM, transitionTimeVM);
            }
            return null;
        }

        private static IConfigVMSet CreateBrightnessWaveConfigVMSet(IViewEffectConfigSet vmSet)
        {
            if (vmSet is BrightnessWaveViewConfigSet configSet)
            {
                List<IConfigListViewModel> lightsVM = new List<IConfigListViewModel>();
                List<CardConfigList_ViewModel> list = HueLight_ToCardConfigConverter.ConvertViewLight_ToCardConfig(configSet.GetViewLights());

                foreach (CardConfigList_ViewModel vm in list)
                    lightsVM.Add(vm);
                
                ObservableCollection<IConfigListViewModel> collection = new ObservableCollection<IConfigListViewModel>(lightsVM);
                LightListConfig_ViewModel lightListConfigVM = new LightListConfig_ViewModel(collection);

                var brightnessValue = Convert.ToByte(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel));
                BrightnessConfig_ViewModel brightnessVM = new BrightnessConfig_ViewModel(brightnessValue);

                uint transitiontime = Convert.ToUInt16(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                uint intervaltime = Convert.ToUInt16(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.IntervalTime));
                TransitionTimeConfig_ViewModel intervalTimeVM = new TransitionTimeConfig_ViewModel(intervaltime);

                return new BrightnessWaveConfig_VMSet(brightnessVM, lightListConfigVM, transitionTimeVM, intervalTimeVM);
            }
            return null;
        }

        private static IConfigVMSet CreateColorWaveConfigVMSet(IViewEffectConfigSet vmSet)
        {
            if (vmSet is ColorWaveViewConfigSet configSet)
            {
                //Would be good to normalize this instead of doing the parse in this method
                var colorString = configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.Color).ToString();
                var drawingColor = System.Drawing.Color.FromArgb(Convert.ToInt32(colorString));
                Color color = Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
                ColorConfig_ViewModel colorConfig = new ColorConfig_ViewModel(color);

                List<IConfigListViewModel> lightsVM = new List<IConfigListViewModel>();
                List<CardConfigList_ViewModel> list = HueLight_ToCardConfigConverter.ConvertViewLight_ToCardConfig(configSet.GetViewLights());

                foreach (CardConfigList_ViewModel vm in list)
                    lightsVM.Add(vm);

                ObservableCollection<IConfigListViewModel> collection = new ObservableCollection<IConfigListViewModel>(lightsVM);
                LightListConfig_ViewModel lightListConfigVM = new LightListConfig_ViewModel(collection);

                uint transitiontime = Convert.ToUInt16(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                TransitionTimeConfig_ViewModel transitionTimeVM = new TransitionTimeConfig_ViewModel(transitiontime);

                uint intervaltime = Convert.ToUInt16(configSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.IntervalTime));
                TransitionTimeConfig_ViewModel intervalTimeVM = new TransitionTimeConfig_ViewModel(intervaltime);

                return new ColorWaveConfig_VMSet(colorConfig, lightListConfigVM, transitionTimeVM, intervalTimeVM);
            }
            return null;
        }

        private static IConfigVMSet CreateTurnOnConfigVMSet(IViewEffectConfigSet vmSet)
        {
            if (vmSet is TurnOnViewConfigSet configSet)
            {
                return new TurnOnConfig_VMSet();
            }
            return null;
        }

        private static IConfigVMSet CreateTurnOffConfigVMSet(IViewEffectConfigSet vmSet)
        {
            if (vmSet is TurnOffViewConfigSet configSet)
            {
                return new TurnOffConfig_VMSet();
            }
            return null;
        }
    }
}
