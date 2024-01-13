using Control.Enums;
using System.Collections.Generic;

namespace Control.Models.Interfaces
{
    public interface IViewLink
    {
        List<IViewLight> Lights { get; }
        IViewEffect ViewEffect { get; }
        EffectType LinkType { get; }
        IViewEffectConfigSet Config { get; }
    }
}
