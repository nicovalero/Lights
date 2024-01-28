using Nanoleaf.Action.Actions.ShapesActions;
using Nanoleaf.Action.Actions.ShapesPanelsActions;
using Nanoleaf.Action.Interfaces;
using Nanoleaf.Converters;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.EffectConfig.Creators.Classes;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.Effects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Action.Factories
{
    public class ActionFactory
    {
        //public IAction CreateAction(List<IShapesPanel> panels, AvailableEffects effect, IEffectConfigSet config)
        //{
        //    return null;
        //}

        public IAction CreatePanelsAction(Dictionary<IShapesPanel, INanoleafShapes> panelShapesDictionary, AvailableEffects effect, IEffectConfigSet config)
        {
            IAction action = null;
            switch (effect)
            {
                case AvailableEffects.ColorChange:
                    if (config is ColorChangeConfigSet set)
                    {
                        action = new ShapesPanelsUpdateEffectsAction(panelShapesDictionary, set);
                    }
                    break;
                //case AvailableEffects.UniversalColorWave:
                //    break;
                //case AvailableEffects.TurnOn:
                //    break;
                //case AvailableEffects.TurnOff:
                //    break;
                //case AvailableEffects.UniversalFlash:
                //    break;
                //case AvailableEffects.UniversalBrightnessWave:
                //    break;
                //case AvailableEffects.UniversalFadeIn:
                //    break;
                //case AvailableEffects.UniversalFadeOut:
                //    break;
                default:
                    action = null;
                    break;
            }

            return action;
        }

        public IAction CreateShapesAction(List<INanoleafShapes> shapesList, AvailableEffects effect, IEffectConfigSet config)
        {
            IAction action = null;
            switch (effect)
            {
                case AvailableEffects.ColorChange:
                    if (config is ColorChangeConfigSet set)
                    {
                        var hueValue = RGBToHueConverter.GetHue(set.FinalColor.RGBColor);
                        var colorChangeValues = new ShapesUpdateHueActionValues(hueValue);
                        action = new ShapesUpdateHueAction(shapesList, colorChangeValues, config);
                    }
                    break;
                //case AvailableEffects.UniversalColorWave:
                //    break;
                //case AvailableEffects.TurnOn:
                //    break;
                //case AvailableEffects.TurnOff:
                //    break;
                //case AvailableEffects.UniversalFlash:
                //    break;
                //case AvailableEffects.UniversalBrightnessWave:
                //    break;
                //case AvailableEffects.UniversalFadeIn:
                //    break;
                //case AvailableEffects.UniversalFadeOut:
                //    break;
                default:
                    action = null;
                    break;
            }

            return action;
        }
    }
}
