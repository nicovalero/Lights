﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.EffectConfig.Creators.Interfaces
{
    internal interface IColorExchangeConfigSet
    {
        Color GetRGBColor();
        uint GetTransitionTimeInMilliseconds();
    }
}
