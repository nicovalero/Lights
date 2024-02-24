using Nanoleaf.Action.Actions.ShapesActions;
using Nanoleaf.Action.Actions.ShapesPanelsActions;
using Nanoleaf.Action.Interfaces;
using Nanoleaf.Converters;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.EffectConfig.Creators.Classes;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.EffectConfig.Parts.Classes;
using Nanoleaf.Effects.Enums;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Nanoleaf.Action.Factories
{
    public class ActionFactory
    {
        public ActionFactory()
        {
        }

        public IAction CreatePanelsAction(Dictionary<IShapesPanel, INanoleafShapes> panelShapesDictionary, AvailableEffects effect, IEffectConfigSet config)
        {
            IAction action = null;
            switch (effect)
            {
                case AvailableEffects.ColorChange:
                    if (config is ColorChangeConfigSet colorSet)
                    {
                        action = new ShapesPanelsUpdateEffectsAction(panelShapesDictionary, colorSet);
                    }
                    break;
                case AvailableEffects.ColorWave:
                    if (config is ColorWaveConfigSet waveSet)
                    {
                        var panelsQueue = new Queue<IShapesPanel>(waveSet.LightListConfig.LightList);

                        var values = ActionValuesFactory.CreateShapesUpdateColorWaveActionValues(panelsQueue, waveSet.ColorConfig.RGBColor,
                            waveSet.IntervalTimeConfig.GetTimeInMiliseconds());
                        action = new ShapesPanelsColorWaveAction(panelShapesDictionary, values);
                    }
                    break;
                //case AvailableEffects.TurnOn:
                //    break;
                case AvailableEffects.TurnOff:
                    if (config is TurnOffConfigSet turnOffSet)
                    {
                        action = new ShapesPanelsUpdateEffectsAction(panelShapesDictionary, turnOffSet);
                    }
                    break;
                case AvailableEffects.Flash:
                    if(config is FlashConfigSet flashSet)
                    {
                        var firstBrightness = Convert.ToInt16(flashSet.InitialBrightnessConfig.Value);
                        var finalBrightness = Convert.ToInt16(flashSet.FinalBrightnessConfig.Value);
                        var firstColorAttribute = firstBrightness;
                        var finalColorAttribute = finalBrightness;

                        var firstColor = Color.FromArgb(firstColorAttribute, firstColorAttribute, firstColorAttribute);
                        var finalColor = Color.FromArgb(finalColorAttribute, finalColorAttribute, finalColorAttribute);

                        var lightList = panelShapesDictionary.Keys.ToList();
                        var timeDouble = flashSet.TransitionTimeConfig.GetTimeInMiliseconds() / 2.0 / 100.0;
                        var timeInt = Convert.ToUInt16(timeDouble);
                        var firstValues = ActionValuesFactory.CreateShapesFlashActionValues(lightList, firstColor, timeInt);
                        var finalValues = ActionValuesFactory.CreateShapesFlashActionValues(lightList, finalColor, timeInt);

                        var transitionTime = flashSet.TransitionTimeConfig.GetTimeInMiliseconds();

                        action = new ShapesPanelsFlashAction(panelShapesDictionary, firstValues, finalValues, transitionTime);
                    }
                    break;
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
                case AvailableEffects.FadeIn:
                    if (config is FadeInConfigSet fadeInSet)
                    {
                        action = new ShapesFadeInAction(shapesList, fadeInSet);
                    }
                    break;
                case AvailableEffects.FadeOut:
                    if (config is FadeOutConfigSet fadeOutSet)
                    {
                        action = new ShapesFadeOutAction(shapesList, fadeOutSet);
                    }
                    break;
                default:
                    action = null;
                    break;
            }

            return action;
        }
    }
}
