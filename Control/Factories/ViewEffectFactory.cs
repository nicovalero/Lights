using Control.Enums;
using Control.Models.Classes.ViewLights;
using Control.Models.Interfaces;
using PhilipsHue.Collections;
using System;

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
            string description = "";
            EffectType type;
            string typeName = "";
            string name = "";
            AvailableViewEffects kind;

            switch (chosenPack)
            {
                case AvailableViewEffects.UniversalOn:
                    description = "Switches the device on";
                    type = EffectType.Universal;
                    typeName = "Universal";
                    name = "Turn On";
                    kind = AvailableViewEffects.UniversalOn;
                    break;
                case AvailableViewEffects.UniversalOff:
                    description = "Switches the device off";
                    type = EffectType.Universal;
                    typeName = "Universal";
                    name = "Turn Off";
                    kind = AvailableViewEffects.UniversalOff;
                    break;
                case AvailableViewEffects.UniversalFlash:
                    description = "Changes the device's brightness between two values in a short period of time";
                    type = EffectType.Universal;
                    typeName = "Universal";
                    name = "Flash";
                    kind = AvailableViewEffects.UniversalFlash;
                    break;
                case AvailableViewEffects.UniversalColorChange:
                    description = "Changes the light color to another one";
                    type = EffectType.Universal;
                    typeName = "Universal";
                    name = "Color Change";
                    kind = AvailableViewEffects.UniversalColorChange;
                    break;
                case AvailableViewEffects.UniversalColorWave:
                    description = "Changes the lights color to another one at different times";
                    type = EffectType.Universal;
                    typeName = "Universal";
                    name = "Color Wave";
                    kind = AvailableViewEffects.UniversalColorWave;
                    break;
                case AvailableViewEffects.UniversalBrightnessWave:
                    description = "Changes the lights brightness to another value at different times";
                    type = EffectType.Universal;
                    typeName = "Universal";
                    name = "Brightness Wave";
                    kind = AvailableViewEffects.UniversalBrightnessWave;
                    break;
                case AvailableViewEffects.UniversalFadeIn:
                    description = "Changes the light brightness to another value";
                    type = EffectType.Universal;
                    typeName = "Universal";
                    name = "Fade In";
                    kind = AvailableViewEffects.UniversalFadeIn;
                    break;
                case AvailableViewEffects.UniversalFadeOut:
                    description = "Changes the light brightness to another value";
                    type = EffectType.Universal;
                    typeName = "Universal";
                    name = "Fade Out";
                    kind = AvailableViewEffects.UniversalFadeOut;
                    break;
                case AvailableViewEffects.NanoleafEffect:
                    description = "Triggers a defined effect in a Nanoleaf device";
                    type = EffectType.Nanoleaf;
                    typeName = "Nanoleaf";
                    name = "Nanoleaf Effect";
                    kind = AvailableViewEffects.NanoleafEffect;
                    break;
                default:
                    throw new ArgumentException("Available View Effect not found in ViewEffectFactory.Construct.");
            }

            effect = new ViewEffectTemplate(description, type, typeName, name, kind);

            return effect;
        }
    }
}
