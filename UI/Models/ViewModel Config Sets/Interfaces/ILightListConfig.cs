using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Structs;

namespace UI.Models.ViewModel_Config_Sets.Interfaces
{
    internal interface ILightListConfig
    {
        LightListConfig_ViewModel GetLightListConfig();
        void SetLightListConfig(LightListConfig_ViewModel config);
    }
}
