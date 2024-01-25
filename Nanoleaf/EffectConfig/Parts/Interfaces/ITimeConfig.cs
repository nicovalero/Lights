﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.EffectConfig.Parts.Interfaces
{
    public interface ITimeConfig
    {
        uint GetTimeInMiliseconds();
        uint GetTimeInTenthOfSeconds();
    }
}