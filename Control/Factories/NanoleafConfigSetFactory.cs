using Control.Enums;
using Control.Models.Interfaces;
using Nanoleaf.Action.Factories;
using Nanoleaf.Action.Interfaces;
using Nanoleaf.Devices.Classes;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.EffectConfig.Creators.Classes;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.EffectConfig.Parts.Classes;
using Nanoleaf.Effects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Factories
{
    internal static class NanoleafConfigSetFactory
    {
        public static readonly ShapesPanelFactory shapesPanelFactory;

        static NanoleafConfigSetFactory()
        {
            shapesPanelFactory = new ShapesPanelFactory();
        }

        public static IEffectConfigSet CreateConfigSet(IViewEffectConfigSet viewEffectConfigSet)
        {
            var lights = new List<IShapesPanel>();

            var viewLights = (List<IViewLight>)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.LightList);
            if (viewLights != null)
            {
                var nanoleafLights = viewLights.Where(x => x.GetLightType() == LightType.Nanoleaf);

                foreach (var light in nanoleafLights)
                {
                    lights.Add(shapesPanelFactory.CreatePanelFromID(light.ID));
                }
            }

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
                    var lightListConfig = new NanoleafLightListConfig(lights);
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
                    var offColorString = viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.Color).ToString();
                    var offColor = System.Drawing.Color.FromArgb(Convert.ToInt32(offColorString));
                    config = new TurnOffConfigSet(offColor);
                    break;
                case AvailableViewEffects.UniversalFlash:
                    config = new FlashConfigSet((byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessFinal), (byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessStart),
                        (uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    break;
                case AvailableViewEffects.UniversalBrightnessWave:
                    var transition = new TransitionTimeConfig((uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    var listConfig = new NanoleafLightListConfig(lights);
                    var intervalConfig = new TransitionTimeConfig((uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.IntervalTime));
                    config = new BrightnessWaveConfigSet((byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel), transition,
                        listConfig, intervalConfig);
                    break;
                case AvailableViewEffects.UniversalFadeIn:
                    var fadeInBrightness = (byte)((byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel) * 100 / 255);
                    config = new FadeInConfigSet(fadeInBrightness, (uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    break;
                case AvailableViewEffects.UniversalFadeOut:
                    var fadeOutBrightness = (byte)((byte)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.BrightnessLevel) * 100 / 255);
                    config = new FadeOutConfigSet(fadeOutBrightness, (uint)viewEffectConfigSet.GetEffectConfigProperty(EffectConfigPropertyIdentifier.TransitionTime));
                    break;
            }

            return config;
        }

        public static IEffectConfigSet CreateIdentifyActionColorChangeConfigSet(List<IViewLight> viewLights)
        {
            var lights = new List<IShapesPanel>();

            if (viewLights != null)
            {
                var nanoleafLights = viewLights.Where(x => x.GetLightType() == LightType.Nanoleaf);

                foreach (var light in nanoleafLights)
                {
                    lights.Add(shapesPanelFactory.CreatePanelFromID(light.ID));
                }
            }

            IEffectConfigSet config = null;
            var drawingColor = System.Drawing.Color.FromArgb(255,255,255);
            config = new ColorChangeConfigSet(drawingColor, Convert.ToUInt16(10));

            return config;
        }

        public static IEffectConfigSet CreateIdentifyActionTurnOnConfigSet()
        {
            return new TurnOnConfigSet();
        }
    }
}
