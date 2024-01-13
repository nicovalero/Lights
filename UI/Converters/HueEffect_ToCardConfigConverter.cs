using System.Collections.Generic;
using FontAwesome.Sharp;
using System.Windows.Media;
using UI.Models.Structs;
using Control.Models.Interfaces;
using Control.Enums;
using Control.Controllers;

namespace UI
{
    internal static class HueEffect_ToCardConfigConverter
    {
        private static readonly Dictionary<AvailableViewEffects, List<Color>> _colorDictionary;
        private static readonly Dictionary<AvailableViewEffects, FontAwesome.Sharp.IconChar> _iconDictionary;
        private static MidiLightsController _midiLightsController;

        static HueEffect_ToCardConfigConverter()
        {
            _colorDictionary = new Dictionary<AvailableViewEffects, List<Color>>();
            _iconDictionary = new Dictionary<AvailableViewEffects, IconChar>();
            _midiLightsController = new MidiLightsController();

            PopulateColorDictionary();
            PopulateIconDictionary();
        }

        private static void PopulateColorDictionary()
        {
            List<Color> colorList;
            byte red, red2;
            byte green, green2;
            byte blue, blue2;
            foreach (IViewEffect effect in _midiLightsController.GetAllViewEffectsAvailable())
            {
                colorList = new List<Color>();
                switch (effect.GetKind())
                {
                    default:
                        red = 50;
                        green = 0;
                        blue = 255;

                        red2 = 50;
                        green2 = 0;
                        blue2 = 255;
                        break;
                    case AvailableViewEffects.UniversalFlash:
                        red = 180;
                        green = 150;
                        blue = 0;

                        red2 = 210;
                        green2 = 210;
                        blue2 = 210;
                        break;
                    case AvailableViewEffects.UniversalFadeIn:
                        red = 0;
                        green = 0;
                        blue = 0;

                        red2 = 255;
                        green2 = 165;
                        blue2 = 0;
                        break;
                    case AvailableViewEffects.UniversalFadeOut:
                        red = 170;
                        green = 180;
                        blue = 183;

                        red2 = 0;
                        green2 = 0;
                        blue2 = 0;
                        break;
                    case AvailableViewEffects.UniversalColorChange:
                        red = 59;
                        green = 173;
                        blue = 202;

                        red2 = 204;
                        green2 = 0;
                        blue2 = 255;
                        break;
                    case AvailableViewEffects.UniversalBrightnessWave:
                        red = 0;
                        green = 0;
                        blue = 0;

                        red2 = 200;
                        green2 = 0;
                        blue2 = 0;
                        break;
                    case AvailableViewEffects.UniversalColorWave:
                        red = 0;
                        green = 200;
                        blue = 0;

                        red2 = 0;
                        green2 = 0;
                        blue2 = 200;
                        break;
                    case AvailableViewEffects.UniversalOn:
                        red = 204;
                        green = 204;
                        blue = 0;

                        red2 = 204;
                        green2 = 204;
                        blue2 = 0;
                        break;
                    case AvailableViewEffects.UniversalOff:
                        red = 0;
                        green = 0;
                        blue = 0;

                        red2 = 0;
                        green2 = 0;
                        blue2 = 0;
                        break;
                }
                colorList.Add(Color.FromRgb(red, green, blue));
                colorList.Add(Color.FromRgb(red2, green2, blue2));
                _colorDictionary.Add(effect.GetKind(), colorList);
            }
        }

        private static void PopulateIconDictionary()
        {
            FontAwesome.Sharp.IconChar icon;
            foreach (IViewEffect effect in _midiLightsController.GetAllViewEffectsAvailable())
            {
                var kind = effect.GetKind();
                switch (kind)
                {
                    default:
                        icon = IconChar.Explosion;
                        break;
                    case AvailableViewEffects.UniversalFlash:
                        icon = IconChar.Sun;
                        break;
                    case AvailableViewEffects.UniversalFadeIn:
                        icon = IconChar.MountainSun;
                        break;
                    case AvailableViewEffects.UniversalFadeOut:
                        icon = IconChar.Moon;
                        break;
                    case AvailableViewEffects.UniversalColorChange:
                        icon = IconChar.YinYang;
                        break;
                    case AvailableViewEffects.UniversalBrightnessWave:
                        icon = IconChar.HouseTsunami;
                        break;
                    case AvailableViewEffects.UniversalColorWave:
                        icon = IconChar.Rainbow;
                        break;
                    case AvailableViewEffects.UniversalOn:
                        icon = IconChar.Lightbulb;
                        break;
                    case AvailableViewEffects.UniversalOff:
                        icon = IconChar.Moon;
                        break;
                    case AvailableViewEffects.NanoleafEffect:
                        icon = IconChar.Star;
                        break;
                }
                _iconDictionary.Add(effect.GetKind(), icon);
            }
        }

        public static List<CardConfigList_ViewModel> ConvertLightEffect_ToCardConfig(List<IViewEffect> effects)
        {
            List<CardConfigList_ViewModel> list = new List<CardConfigList_ViewModel>();

            foreach(IViewEffect effect in effects)
            {
                if(_colorDictionary.ContainsKey(effect.GetKind()) && _iconDictionary.ContainsKey(effect.GetKind()))
                    list.Add(new CardConfigList_ViewModel(effect.GetName(), effect, effect.GetName(), _colorDictionary[effect.GetKind()][0], _colorDictionary[effect.GetKind()][1], _iconDictionary[effect.GetKind()], effect.GetEffectTypeName()));
            }

            return list;
        }
    }
}
