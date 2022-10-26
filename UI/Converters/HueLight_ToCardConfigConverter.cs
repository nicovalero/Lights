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
using PhilipsHue.Models.Interfaces;
using PhilipsHue.Models.Classes;

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

        private static FontAwesome.Sharp.IconChar GetLightIconByType(HueLight light)
        {
            FontAwesome.Sharp.IconChar icon;
            switch (light)
            {
                default:
                    icon = IconChar.Lightbulb;
                    break;
                case HueColorLight l:
                    icon = IconChar.Lightbulb;
                    break;
            }
            return icon;
        }

        public static List<CardConfigList_ViewModel> ConvertHueLight_ToCardConfig(List<HueLight> lights)
        {
            List<CardConfigList_ViewModel> list = new List<CardConfigList_ViewModel>();

            foreach (HueLight light in lights)
            {
                list.Add(new CardConfigList_ViewModel(light, light.name, _backgroundColor1, _backgroundColor2, GetLightIconByType(light), light.productName));
            }

            return list;
        }
    }
}
