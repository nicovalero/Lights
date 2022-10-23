using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Collections
{
    public static class HueLightEffectKindCollection
    {
        private static readonly Dictionary<HueLightEffectKindEnum, string> _dictionary;

        static HueLightEffectKindCollection()
        {
            _dictionary = new Dictionary<HueLightEffectKindEnum, string>();
            FillDictionary();
        }

        private static void FillDictionary()
        {
            _dictionary.Add(HueLightEffectKindEnum.SINGLE, "Single");
            _dictionary.Add(HueLightEffectKindEnum.MULTI, "Single/Group");
            _dictionary.Add(HueLightEffectKindEnum.GROUP, "Group");
        }

        public static string GetKindName(HueLightEffectKindEnum kind)
        {
            if (_dictionary.ContainsKey(kind))
                return _dictionary[kind];
            else
                return "";
        }
    }
}
