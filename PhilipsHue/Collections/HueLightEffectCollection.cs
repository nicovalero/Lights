﻿using PhilipsHue.Effects.Classes;
using PhilipsHue.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Collections
{
    public static class HueLightEffectCollection
    {
        private static Dictionary<byte, LightEffect> _effects;
        public static Dictionary<byte, LightEffect> Effects { get { return _effects; } }
        static HueLightEffectCollection()
        {
            _effects = new Dictionary<byte, LightEffect>();
            FillDictionary();
        }

        private static void FillDictionary()
        {
            Effects.Add(1, ColorChange.Singleton());
            Effects.Add(2, Flash.Singleton());
            Effects.Add(3, FadeIn.Singleton());
            Effects.Add(4, FadeOut.Singleton());
        }

        public static LightEffect GetEffect(byte id)
        {
            if (Effects.ContainsKey(id))
                return Effects[id];
            else
                return null;
        }

        public static List<LightEffect> GetAllEffectList()
        {
            return Effects.Values.ToList();
        }
    }
}