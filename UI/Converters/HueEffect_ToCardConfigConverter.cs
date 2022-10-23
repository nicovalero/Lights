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
        private static readonly Dictionary<LightEffect, List<Color>> _colorDictionary;
        private static readonly Dictionary<LightEffect, FontAwesome.Sharp.IconChar> _iconDictionary;

        static HueEffect_ToCardConfigConverter()
        {
            _colorDictionary = new Dictionary<LightEffect, List<Color>>();
            _iconDictionary = new Dictionary<LightEffect, IconChar>();

            PopulateColorDictionary();
            PopulateIconDictionary();
        }

        private static void PopulateColorDictionary()
        {
            List<Color> colorList;
            byte red, red2;
            byte green, green2;
            byte blue, blue2;
            foreach (LightEffect effect in HueLightEffectCollection.GetAllEffectList())
            {
                colorList = new List<Color>();
                switch (effect)
                {
                    default:
                        red = 50;
                        green = 0;
                        blue = 255;

                        red2 = 50;
                        green2 = 0;
                        blue2 = 255;
                        break;
                    case Flash f:
                        red = 180;
                        green = 150;
                        blue = 0;

                        red2 = 210;
                        green2 = 210;
                        blue2 = 210;
                        break;
                    case FadeIn f:
                        red = 0;
                        green = 0;
                        blue = 0;

                        red2 = 255;
                        green2 = 165;
                        blue2 = 0;
                        break;
                    case FadeOut f:
                        red = 170;
                        green = 180;
                        blue = 183;

                        red2 = 0;
                        green2 = 0;
                        blue2 = 0;
                        break;
                    case ColorChange f:
                        red = 59;
                        green = 173;
                        blue = 202;

                        red2 = 204;
                        green2 = 0;
                        blue2 = 255;
                        break;
                }
                colorList.Add(Color.FromRgb(red, green, blue));
                colorList.Add(Color.FromRgb(red2, green2, blue2));
                _colorDictionary.Add(effect, colorList);
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
                        icon = IconChar.Moon;
                        break;
                    case ColorChange f:
                        icon = IconChar.YinYang;
                        break;
                }
                _iconDictionary.Add(effect, icon);
            }
        }

        public static List<CardConfigList_ViewModel> ConvertLightEffect_ToCardConfig(List<LightEffect> effects)
        {
            List<CardConfigList_ViewModel> list = new List<CardConfigList_ViewModel>();

            foreach(LightEffect effect in effects)
            {
                if(_colorDictionary.ContainsKey(effect) && _iconDictionary.ContainsKey(effect))
                    list.Add(new CardConfigList_ViewModel(effect, effect.Name, _colorDictionary[effect][0], _colorDictionary[effect][1], _iconDictionary[effect], effect.EffectTypeName));
            }

            return list;
        }
    }
}
