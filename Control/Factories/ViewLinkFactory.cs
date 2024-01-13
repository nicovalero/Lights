using Control.Enums;
using Control.Models.Classes;
using Control.Models.Classes.ViewEffects;
using Control.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Factories
{
    internal class ViewLinkFactory
    {
        public ViewLinkFactory()
        {
        }

        public IViewLink Construct(IViewEffect effect, List<IViewLight> lights, IViewEffectConfigSet config)
        {
            IViewLink link = new ViewLink(lights, effect, effect.GetEffectType(), config);

            return link;
        }
    }
}
