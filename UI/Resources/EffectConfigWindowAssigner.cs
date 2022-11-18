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

namespace UI.Resources
{
    internal static class EffectConfigWindowAssigner
    {
        internal static Window GetWindowByEffect(LightEffect effect, ObservableCollection<IConfigListViewModel> data)
        {
            Window window = null;
            switch (effect)
            {
                default: 
                    return null;
                case Flash f:
                    window = new FlashConfigWindow();
                    break;
                case ColorChange c:
                    window = new ColorChangeConfigWindow();
                    break;
                case FadeIn f:
                    window = new FadeInConfigWindow();
                    break;
                case FadeOut f:
                    window = new FadeOutConfigWindow();
                    break;
                case BrightnessWave b:
                    BrightnessWaveConfig_VMSet set = new BrightnessWaveConfig_VMSet(new BrightnessConfig_ViewModel(),
                        new LightListConfig_ViewModel(data), new TransitionTimeConfig_ViewModel(), new TransitionTimeConfig_ViewModel());
                    window = new BrightnessWaveConfigWindow(set);
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
            }
        }
    }
}
