using Nanoleaf.Action.Interfaces;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.Effects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Action.Factories
{
    public class ActionFactory
    {
        public IAction CreateAction(List<IShapesPanel> panels, AvailableEffects effect, IEffectConfigSet config)
        {
            return null;
        }
    }
}
