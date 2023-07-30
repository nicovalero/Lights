using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI.Models.ViewModel_Config_Sets.Classes
{
    internal class TurnOffConfig_VMSet : IConfigVMSet
    {

        public TurnOffConfig_VMSet()
        {
        }

        public List<object> GetConfigViewModels()
        {
            List<object> list = new List<object>();
            return list;
        }
    }
}
