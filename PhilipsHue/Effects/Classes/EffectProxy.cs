using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using PhilipsHue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhilipsHue.Models.Interfaces;

namespace PhilipsHue.Effects.Classes
{
    internal class EffectProxy
    {
        public EffectProxy() { }
        public Task ChangeLightState(Dictionary<string, Bridge> lightBridgeDictionary, string uniqueid, HueStateJSONProperty combo)
        {
            HueState state = combo.State;
            List<HueJSONBodyStateProperty> properties = combo.JsonProperties.ToList();
            if (lightBridgeDictionary.ContainsKey(uniqueid))
                return lightBridgeDictionary[uniqueid].ChangeLightState(uniqueid, state, properties);
            return null;
        }
    }
}
