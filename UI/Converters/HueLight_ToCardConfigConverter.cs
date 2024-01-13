using System.Collections.Generic;
using FontAwesome.Sharp;
using System.Windows.Media;
using UI.Models.Structs;
using PhilipsHue.Models.Interfaces;
using Control.Models.Interfaces;
using Control.Enums;

namespace UI
{
    internal static class HueLight_ToCardConfigConverter
    {
        private static readonly Color _backgroundColor1;
        private static readonly Color _backgroundColor2;
        private static readonly Dictionary<HueLight, FontAwesome.Sharp.IconChar> _iconDictionary;

        static HueLight_ToCardConfigConverter()
        {
            _iconDictionary = new Dictionary<HueLight, IconChar>();
            _backgroundColor1 = Color.FromRgb(21, 36, 87);
            _backgroundColor2 = Color.FromRgb(21, 36, 87);
        }

        private static FontAwesome.Sharp.IconChar GetLightIconByType(LightType lightType)
        {
            FontAwesome.Sharp.IconChar icon;
            switch (lightType)
            {
                default:
                    icon = IconChar.Lightbulb;
                    break;
                case LightType.PhilipsHue:
                    icon = IconChar.Lightbulb;
                    break;
                case LightType.Nanoleaf:
                    icon = IconChar.TriangleCircleSquare;
                    break;
            }
            return icon;
        }

        public static List<CardConfigList_ViewModel> ConvertViewLight_ToCardConfig(List<IViewLight> lights)
        {
            List<CardConfigList_ViewModel> list = new List<CardConfigList_ViewModel>();

            foreach (IViewLight light in lights)
            {
                list.Add(new CardConfigList_ViewModel(light.GetID(), light, light.GetName(), _backgroundColor1, _backgroundColor2, GetLightIconByType(light.GetLightType()), light.GetDescription()));
            }

            return list;
        }
    }
}
