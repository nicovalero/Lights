using PhilipsHue.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;
using System.Windows.Media;
using PhilipsHue.Effects.Classes;
using PhilipsHue.Collections;
using System.Windows.Forms;
using UI.Models.Structs;

namespace UI
{
    internal static class HueEffect_ToCardConfigConverter
    {
        private static readonly Dictionary<LightEffect, Color> _colorDictionary;
        private static readonly Dictionary<LightEffect, FontAwesome.Sharp.IconChar> _iconDictionary;

        static HueEffect_ToCardConfigConverter()
        {
            _colorDictionary = new Dictionary<LightEffect, Color>();
            _iconDictionary = new Dictionary<LightEffect, IconChar>();

            PopulateColorDictionary();
            PopulateIconDictionary();
        }

        private static void PopulateColorDictionary()
        {
            byte red;
            byte green;
            byte blue;
            foreach (LightEffect effect in HueLightEffectCollection.GetAllEffectList())
            {
                switch (effect)
                {
                    default:
                        red = 50;
                        green = 0;
                        blue = 255;
                        break;
                    case Flash f:
                        red = 210;
                        green = 180;
                        blue = 0;
                        break;
                    case FadeIn f:
                        red = 255;
                        green = 165;
                        blue = 0;
                        break;
                    case FadeOut f:
                        red = 170;
                        green = 180;
                        blue = 183;
                        break;
                    case ColorChange f:
                        red = 59;
                        green = 173;
                        blue = 202;
                        break;
                }
                _colorDictionary.Add(effect, Color.FromRgb(red, green, blue));
            }            
        }

        private static void PopulateIconDictionary()
        {
            FontAwesome.Sharp.IconChar icon;
            foreach (LightEffect effect in HueLightEffectCollection.GetAllEffectList())
            {
                switch (effect)
                {
                    default:
                        icon = IconChar.Explosion;
                        break;
                    case Flash f:
                        icon = IconChar.Sun;
                        break;
                    case FadeIn f:
                        icon = IconChar.MountainSun;
                        break;
                    case FadeOut f:
                        icon = IconChar.CloudSun;
                        break;
                    case ColorChange f:
                        icon = IconChar.YinYang;
                        break;
                }
                _iconDictionary.Add(effect, icon);
            }
        }

        public static List<CardConfigList_ViewModel> Convert(List<LightEffect> effects)
        {
            List<CardConfigList_ViewModel> list = new List<CardConfigList_ViewModel>();

            foreach(LightEffect effect in effects)
            {
                if(_colorDictionary.ContainsKey(effect) && _iconDictionary.ContainsKey(effect))
                    list.Add(new CardConfigList_ViewModel(effect, effect.Name, _colorDictionary[effect], _iconDictionary[effect]));
            }

            return list;
        }
    }
}
