using Control.Enums;
using Control.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Classes
{
    public class ViewLink: IViewLink
    {
        public List<IViewLight> Lights { get; private set; }
        public IViewEffect ViewEffect { get; private set; }
        public EffectType LinkType { get; private set; }
        public IViewEffectConfigSet Config { get; private set; }

        internal ViewLink(List<IViewLight> lights, IViewEffect viewEffect, EffectType linkType, IViewEffectConfigSet config)
        {
            Lights = lights;
            ViewEffect = viewEffect;
            LinkType = linkType;
            Config = config;
        }
    }
}
