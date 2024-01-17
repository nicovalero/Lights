using Control.Enums;
using Control.Models.Classes;
using Control.Models.Classes.ViewLights;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Control.Models.Interfaces
{
    public interface IViewLink
    {
        List<IViewLight> Lights { get; }
        ViewEffectTemplate ViewEffect { get; }
        EffectType LinkType { get; }
        IViewEffectConfigSet Config { get; }
    }
}
