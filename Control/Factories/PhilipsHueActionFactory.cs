using Control.Enums;
using Control.Models.Classes;
using Control.Models.Interfaces;
using PhilipsHue.Actions.Classes;
using PhilipsHue.EffectConfig.Creators.Classes;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.EffectConfig.Parts.Classes;
using PhilipsHue.Effects.Classes;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Classes;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Factories
{
    internal static class PhilipsHueActionFactory
    {
        public static SingleLightEffectAction CreateSingleLightEffectAction(List<IViewLight> viewLights, IViewEffect viewEffect, IViewEffectConfigSet viewEffectConfigSet)
        {
            var lights = new List<HueLight>();

            foreach (var light in viewLights)
            {
                var hueLight = new HueColorLight();
                hueLight.uniqueId = light.GetID();
                lights.Add(hueLight);
            }

            //Put this into another factory
            LightEffect effect = null;

            switch (viewEffect.GetKind())
            {
                case AvailableViewEffects.UniversalColorChange:
                    effect = new ColorChange();
                    break;
                case AvailableViewEffects.UniversalColorWave:
                    effect = new ColorWave();
                    break;
                case AvailableViewEffects.UniversalOn:
                    effect = new TurnOn();
                    break;
                case AvailableViewEffects.UniversalOff:
                    effect = new TurnOff();
                    break;
                case AvailableViewEffects.UniversalFlash:
                    effect = new Flash();
                    break;
                case AvailableViewEffects.UniversalBrightnessWave:
                    effect = new BrightnessWave();
                    break;
                case AvailableViewEffects.UniversalFadeIn:
                    effect = new FadeIn();
                    break;
                case AvailableViewEffects.UniversalFadeOut:
                    effect = new FadeOut();
                    break;
            }

            //Put this into another factory
            IEffectConfigSet config = null;

            switch (viewEffectConfigSet.GetKind())
            {
                case AvailableViewEffects.UniversalColorChange:
                    var colorString = viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.Color).ToString();
                    var drawingColor = System.Drawing.Color.FromArgb(Convert.ToInt32(colorString));
                    config = new ColorChangeConfigSet(drawingColor, 
                        Convert.ToUInt16(viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime)));
                    break;
                case AvailableViewEffects.UniversalColorWave:
                    var transitionConfig = new TransitionTimeConfig((uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    var intervalTime = new TransitionTimeConfig((uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.IntervalTime));
                    var lightListConfig = new HueLightListConfig(lights);
                    var colorString2 = viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.Color).ToString();
                    //var drawingColor2 = System.Drawing.Color.FromArgb(Convert.ToInt16(components2[0]), Convert.ToInt16(components2[1]), Convert.ToInt16(components2[2]));
                    var drawingColor2 = System.Drawing.Color.FromArgb(Convert.ToInt32(colorString2));
                    config = new ColorWaveConfigSet(drawingColor2, transitionConfig, 
                        lightListConfig, intervalTime);
                    break;
                case AvailableViewEffects.UniversalOn:
                    config = new TurnOnConfigSet();
                    break;
                case AvailableViewEffects.UniversalOff:
                    config = new TurnOffConfigSet();
                    break;
                case AvailableViewEffects.UniversalFlash:
                    config = new FlashConfigSet((byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessFinal), (byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessStart),
                        (uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    break;
                case AvailableViewEffects.UniversalBrightnessWave:
                    var transition = new TransitionTimeConfig((uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    var listConfig = new HueLightListConfig(lights);
                    var intervalConfig = new TransitionTimeConfig((uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.IntervalTime));
                    config = new BrightnessWaveConfigSet((byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel), transition,
                        listConfig, intervalConfig);
                    break;
                case AvailableViewEffects.UniversalFadeIn:
                    config = new FadeInConfigSet((byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel), (uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    break;
                case AvailableViewEffects.UniversalFadeOut:
                    config = new FadeOutConfigSet((byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel), (uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    break;
            }

            SingleLightEffectAction action = new SingleLightEffectAction(lights, effect, config);

            return action;
        }
    }
}
