using PhilipsHue.Effects.Classes;
using PhilipsHue.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;

namespace UI.Resources
{
    internal static class EffectConfigWindowAssigner
    {
        internal static Window GetWindowByEffect(LightEffect effect)
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
                    window.Width = 300;
                    window.Height = 400;
                    break;
                case ColorChangeConfigWindow w:
                    window.Width = 300;
                    window.Height = 400;
                    break;
                case FadeInConfigWindow w:
                    window.Width = 300;
                    window.Height = 400;
                    break;
            }
        }
    }
}
