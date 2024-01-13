using Control.Models.Classes;
using Control.Models.Classes.ViewEffects;
using Control.Models.Classes.ViewLights;
using Control.Models.Interfaces;
using PhilipsHue.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Factories
{
    public class ViewEffectFactory
    {
        //private IViewEffect effect;
        //private IViewConfigSet configSet;
        public ViewEffectFactory()
        {
            HueLightEffectCollection.GetAllEffectList();
        }

        public IViewEffect Construct(AvailableViewEffects chosenPack)
        {
            IViewEffect effect = null;
            switch (chosenPack)
            {
                case AvailableViewEffects.UniversalOn:
                    effect = new UniversalOnViewEffect();
                    break;
                case AvailableViewEffects.UniversalOff:
                    effect = new UniversalOffViewEffect();
                    break;
            }

            return effect;
        }
    }
}
