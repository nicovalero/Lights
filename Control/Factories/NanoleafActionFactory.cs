using Control.Enums;
using Control.Models.Classes;
using Control.Models.Interfaces;
using Nanoleaf.Action.Factories;
using Nanoleaf.Action.Interfaces;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.Effects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Factories
{
    internal class NanoleafActionFactory
    {
        private ActionFactory actionFactory;

        internal NanoleafActionFactory()
        {
            actionFactory = new ActionFactory();
        }
        public IAction CreateAction(List<IShapesPanel> shapesPanels, AvailableEffects chosenEffect, IEffectConfigSet effectConfigSet)
        {
            var action = actionFactory.CreateAction(shapesPanels, chosenEffect, effectConfigSet);

            return action;
        }
    }
}
