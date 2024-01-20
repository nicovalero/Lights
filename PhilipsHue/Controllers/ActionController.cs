using PhilipsHue.Actions.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Controllers
{
    public class ActionController
    {
        public ActionController(){ }

        public void PerformAction(Dictionary<string, Bridge> dictionary, LightEffectAction action)
        {
            action.Perform(dictionary);
        }
    }
}
