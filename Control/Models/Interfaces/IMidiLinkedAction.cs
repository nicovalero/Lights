﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Interfaces
{
    public class IMidiLinkedAction
    {
        List<IControlledLightEffectAction> ControlledLightEffectActions { get; set; }
    }
}
