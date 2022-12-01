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
        internal static Window GetWindowByEffect(LightEffect effect, IConfigVMSet configuration, ObservableCollection<IConfigListViewModel> data)
        {
            Window window = null;
            switch (effect)
            {
                default: 
                    return null;
                case Flash f:
                    if(configuration is FlashConfig_VMSet flashConfig)
                        window = new FlashConfigWindow(flashConfig);
                    else
                        window = new FlashConfigWindow();
                    break;
                case ColorChange c:
                    if (configuration is ColorChangeConfig_VMSet colorChangeConfig)
                        window = new ColorChangeConfigWindow(colorChangeConfig);
                    else
                        window = new ColorChangeConfigWindow();
                    break;
                case FadeIn f:
                    if (configuration is FadeInConfig_VMSet fadeInConfig)
                        window = new FadeInConfigWindow(fadeInConfig);
                    else
                        window = new FadeInConfigWindow();
                    break;
                case FadeOut f:
                    if (configuration is FadeOutConfig_VMSet fadeOutConfig)
                        window = new FadeOutConfigWindow(fadeOutConfig);
                    else
                        window = new FadeOutConfigWindow();
                    break;
                case BrightnessWave b:
                    //This part might be redundant if the config object already contains the light list
                    //Double check it
                    BrightnessWaveConfig_VMSet set = new BrightnessWaveConfig_VMSet(new BrightnessConfig_ViewModel(),
                        new LightListConfig_ViewModel(data), new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());

                    if (configuration is BrightnessWaveConfig_VMSet brightnessWaveConfig)
                        window = new BrightnessWaveConfigWindow(brightnessWaveConfig);
                    else
                        window = new BrightnessWaveConfigWindow(set);
                    break;
                case ColorWave c:
                    ColorWaveConfig_VMSet colorSet = new ColorWaveConfig_VMSet(new ColorConfig_ViewModel(),
                        new LightListConfig_ViewModel(data), new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());

                    if (configuration is ColorWaveConfig_VMSet colorWaveConfig)
                        window = new ColorWaveConfigWindow(colorWaveConfig);
                    else
                        window = new ColorWaveConfigWindow(colorSet);
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
            }
        }
    }
}
