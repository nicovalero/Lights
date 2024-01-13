using Control.Enums;
using Control.Models.Interfaces;
using PhilipsHue.Effects.Classes;
using PhilipsHue.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using UI.Models.Interfaces;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets.Classes;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI.Resources
{
    internal static class EffectConfigWindowAssigner
    {
        internal static Window GetWindowByEffect(IViewEffect effect, IConfigVMSet configuration)
        {
            Window window = null;
            switch (effect.GetKind())
            {
                default: 
                    return null;
                case AvailableViewEffects.UniversalFlash:
                    if(configuration is FlashConfig_VMSet flashConfig)
                        window = new FlashConfigWindow(flashConfig);
                    else
                        window = new FlashConfigWindow();
                    break;
                case AvailableViewEffects.UniversalColorChange:
                    if (configuration is ColorChangeConfig_VMSet colorChangeConfig)
                        window = new ColorChangeConfigWindow(colorChangeConfig);
                    else
                        window = new ColorChangeConfigWindow();
                    break;
                case AvailableViewEffects.UniversalFadeIn:
                    if (configuration is FadeInConfig_VMSet fadeInConfig)
                        window = new FadeInConfigWindow(fadeInConfig);
                    else
                        window = new FadeInConfigWindow();
                    break;
                case AvailableViewEffects.UniversalFadeOut:
                    if (configuration is FadeOutConfig_VMSet fadeOutConfig)
                        window = new FadeOutConfigWindow(fadeOutConfig);
                    else
                        window = new FadeOutConfigWindow();
                    break;
                case AvailableViewEffects.UniversalBrightnessWave:
                    if (configuration is BrightnessWaveConfig_VMSet brightnessWaveConfig)
                        window = new BrightnessWaveConfigWindow(brightnessWaveConfig);
                    else
                        window = new BrightnessWaveConfigWindow();
                    break;
                case AvailableViewEffects.UniversalColorWave:
                    if (configuration is ColorWaveConfig_VMSet colorWaveConfig)
                        window = new ColorWaveConfigWindow(colorWaveConfig);
                    else
                        window = new ColorWaveConfigWindow();
                    break;
                case AvailableViewEffects.UniversalOn:
                    if (configuration is TurnOnConfig_VMSet turnOnConfig)
                        window = new TurnOnConfigWindow(turnOnConfig);
                    else
                        window = new TurnOnConfigWindow();
                    break;
                case AvailableViewEffects.UniversalOff:
                    if (configuration is TurnOffConfig_VMSet turnOffConfig)
                        window = new TurnOffConfigWindow(turnOffConfig);
                    else
                        window = new TurnOffConfigWindow();
                    break;
                case AvailableViewEffects.NanoleafEffect:
                    if (configuration is NanoleafEffectConfig_VMSet nanoleafEffectConfig)
                        window = new NanoleafEffectConfigWindow(nanoleafEffectConfig);
                    else
                        window = new NanoleafEffectConfigWindow();
                    break;
            }

            SetWindowProperties(window);

            return window;
        }

        private static void SetWindowProperties(Window window)
        {
            switch (window)
            {
                default:
                    break;
                case FlashConfigWindow w:
                    window.Width = 600;
                    window.Height = 400;
                    break;
                case ColorChangeConfigWindow w:
                    window.Width = 600;
                    window.Height = 400;
                    break;
                case FadeInConfigWindow w:
                    window.Width = 600;
                    window.Height = 400;
                    break;
                case FadeOutConfigWindow w:
                    window.Width = 600;
                    window.Height = 400;
                    break;
                case BrightnessWaveConfigWindow w:
                    window.Width = 650;
                    window.Height = 700;
                    break;
                case ColorWaveConfigWindow w:
                    window.Width = 650;
                    window.Height = 700;
                    break;
                case TurnOnConfigWindow w:
                    window.Width = 300;
                    window.Height = 200;
                    break;
                case TurnOffConfigWindow w:
                    window.Width = 300;
                    window.Height = 200;
                    break;
            }
        }
    }
}
