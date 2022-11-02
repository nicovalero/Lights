using PhilipsHue.Models;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.EffectConfig.Creators.Interfaces
{
    public interface IEffectConfigSet
    {
        Queue<HueStateJSONProperty> GetHueStateQueue();
    }
}
