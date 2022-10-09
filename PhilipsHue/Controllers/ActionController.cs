using PhilipsHue.Actions.Interfaces;
using PhilipsHue.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilipsHue.Controllers
{
    public class ActionController
    {
        private static readonly ActionController _controller = new ActionController();

        private ActionController(){ }

        public static ActionController Singleton()
        {
            return _controller;
        }

        public void PerformAction(LightEffectAction action)
        {
            action.Perform();
        }
    }
}
