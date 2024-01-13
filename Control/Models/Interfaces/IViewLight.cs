﻿using Control.Enums;
using PhilipsHue.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Interfaces
{
    public interface IViewLight
    {
        LightType GetLightType();
        string GetID();
        string GetName();
        string GetDescription();
    }
}