using Control.Enums;
using Control.Factories;
using Control.Models.Classes;

namespace Control.Models.Interfaces
{
    public interface IViewEffect
    {
        EffectType GetEffectType();
        string GetName();
        string GetDescription();
        AvailableViewEffects GetKind();
        string GetEffectTypeName();
    }
}
