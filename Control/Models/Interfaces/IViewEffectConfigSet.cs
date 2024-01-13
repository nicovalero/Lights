using Control.Enums;
using Control.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Interfaces
{
    public interface IViewEffectConfigSet
    {
        AvailableViewEffects GetKind();
        bool ExistsEffectConfig(EffectConfigPropertyIdentifier effectConfigPropertyIdentifier);
        object GetEffectConfigProperty(EffectConfigPropertyIdentifier effectConfigPropertyIdentifier);
    }
}
