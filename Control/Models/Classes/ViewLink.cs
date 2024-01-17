using Control.Enums;
using Control.Models.Classes.ViewLights;
using Control.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Classes
{
    public class ViewLink: IViewLink
    {
        private List<IViewLight> lights;
        private IViewEffect viewEffect;
        private IViewEffectConfigSet config;
        public List<IViewLight> Lights { get { return lights; } set { lights = value; } }
        public ViewEffectTemplate ViewEffect { get { return (ViewEffectTemplate)viewEffect; } set { viewEffect = (ViewEffectTemplate)value; } }
        public EffectType LinkType { get; set; }
        public IViewEffectConfigSet Config { get { return config; } set { config = value; } }

        public ViewLink() { }

        public ViewLink(List<IViewLight> lights, IViewEffect viewEffect, EffectType linkType, IViewEffectConfigSet config)
        {
            Lights = lights;
            ViewEffect = (ViewEffectTemplate)viewEffect;
            LinkType = linkType;
            Config = config;
        }
    }
}
