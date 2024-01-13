﻿using Control.Enums;
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
                    effect = ColorChange.Singleton();
                    break;
                case AvailableViewEffects.UniversalColorWave:
                    effect = ColorWave.Singleton();
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
                case AvailableViewEffects.UniversalBrightnessChange:
                    break;
                case AvailableViewEffects.UniversalBrightnessWave:
                    effect = BrightnessWave.Singleton();
                    break;
                case AvailableViewEffects.UniversalFadeIn:
                    effect = FadeIn.Singleton();
                    break;
                case AvailableViewEffects.UniversalFadeOut:
                    effect = FadeOut.Singleton();
                    break;
            }

            //Put this into another factory
            IEffectConfigSet config = null;

            switch (viewEffectConfigSet.GetKind())
            {
                case AvailableViewEffects.UniversalColorChange:
                    config = new ColorChangeConfigSet((System.Drawing.Color)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.Color), (uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    break;
                case AvailableViewEffects.UniversalColorWave:
                    //Continue here
                    var transitionConfig = new TransitionTimeConfig((uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    var intervalTime = new TransitionTimeConfig((uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.IntervalTime));
                    var lightListConfig = new HueLightListConfig(lights);
                    config = new ColorWaveConfigSet((System.Drawing.Color)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.Color), transitionConfig, 
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
                        (uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.IntervalTime));
                    break;
                case AvailableViewEffects.UniversalBrightnessChange:
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
