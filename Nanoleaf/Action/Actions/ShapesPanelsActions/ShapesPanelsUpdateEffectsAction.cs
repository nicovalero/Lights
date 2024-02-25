﻿using Nanoleaf.Action.Interfaces;
using Nanoleaf.Network.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using Nanoleaf.EffectConfig.Creators.Classes;
using Nanoleaf.RequestAttributes;
using Nanoleaf.EffectConfig.Creators.Interfaces;

namespace Nanoleaf.Action.Actions.ShapesPanelsActions
{
    public struct AnimDataValues
    {
        private int panelID, nFrames, red, green, blue, alpha, transitionTime;

        public AnimDataValues(int panelID, int nFrames, int red, int green, int blue, int alpha, int transitionTime)
        {
            this.panelID = panelID;
            this.nFrames = nFrames;
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
            this.transitionTime = transitionTime;
        }
        public string GetData()
        {
            var data = string.Join(" ", panelID, nFrames, red, green, blue, alpha, transitionTime);

            return data;
        }
    }
    public struct ShapesUpdateEffectsActionValues
    {
        public string Command { get; set; }
        public string Version { get; set; }
        public string AnimType { get; set; }
        public List<AnimDataValues> AnimDataList { get; set; }
        public string AnimDataString
        {
            get
            {
                var data = AnimDataList.Count.ToString();
                foreach (var item in AnimDataList)
                {
                    data = string.Join(" ", data, item.GetData());
                }

                return data;
            }
        }
        public bool Loop { get; set; }
        public PaletteValues[] PaletteValues { get; set; }
        public ShapesUpdateEffectsActionValues(string command, string version, string animType, List<AnimDataValues> animDataList,
            bool loop, Palette palette)
        {
            Command = command;
            Version = version;
            AnimType = animType;
            AnimDataList = animDataList;
            Loop = loop;
            if(palette != null)
                PaletteValues = palette.GetPaletteArray();
            else
                PaletteValues = new PaletteValues[0];
        }
    }
    internal class ShapesPanelsUpdateEffectsAction : IAction
    {
        private Dictionary<INanoleafShapes, UpdateEffectsRequest> shapesRequestDictionary;

        [JsonProperty]
        private List<KeyValuePair<INanoleafShapes, UpdateEffectsRequest>> ShapesRequestDictionary
        {
            get
            {
                var list = new List<KeyValuePair<INanoleafShapes, UpdateEffectsRequest>>();
                foreach (var item in shapesRequestDictionary)
                {
                    list.Add(item);
                }

                return list;
            }
            set
            {
                if (shapesRequestDictionary == null)
                {
                    shapesRequestDictionary = new Dictionary<INanoleafShapes, UpdateEffectsRequest>();
                }
                foreach (var item in value)
                {
                    shapesRequestDictionary.Add(item.Key, item.Value);
                }
            }
        }

        private const string COMMAND = "display";
        private const string VERSION = "2.0";
        private const string ANIMTYPE = "static";
        private const bool LOOP = false;
        private Palette palette;

        [JsonConstructor]
        internal ShapesPanelsUpdateEffectsAction()
        {
            shapesRequestDictionary = new Dictionary<INanoleafShapes, UpdateEffectsRequest>();
        }
        internal ShapesPanelsUpdateEffectsAction(Dictionary<IShapesPanel, INanoleafShapes> panelShapesDictionary, IColorExchangeConfigSet config)
        {
            var panelsByShapes = new Dictionary<INanoleafShapes, List<IShapesPanel>>();
            var colorValue = config.GetRGBColor();
            var transitionTimeInTenthsOfSeconds = Convert.ToInt32(config.GetTransitionTimeInMilliseconds() / 100);
            shapesRequestDictionary = new Dictionary<INanoleafShapes, UpdateEffectsRequest>();

            foreach (var kvp in panelShapesDictionary)
            {
                if (!panelsByShapes.ContainsKey(kvp.Value))
                {
                    panelsByShapes.Add(kvp.Value, new List<IShapesPanel>());
                }
                panelsByShapes[kvp.Value].Add(kvp.Key);

            }

            foreach (var kvp in panelsByShapes)
            {
                var list = kvp.Value;
                var shapes = kvp.Key;

                var animDataList = new List<AnimDataValues>();

                for (int i = 0; i < list.Count; i++)
                {
                    var panel = list[i];
                    var animData = new AnimDataValues(Convert.ToInt32(panel.GetPanelID()), 1, colorValue.R, colorValue.G, colorValue.B, colorValue.A, transitionTimeInTenthsOfSeconds);
                    animDataList.Add(animData);
                }

                var values = new ShapesUpdateEffectsActionValues(COMMAND, VERSION, ANIMTYPE, animDataList, LOOP, palette);

                var request = new UpdateEffectsRequest(values);

                shapesRequestDictionary.Add(shapes, request);
            }
        }

        public bool Perform()
        {
            foreach (var kvp in shapesRequestDictionary)
            {
                var shapes = kvp.Key;
                var request = kvp.Value;
                EndpointMessenger.UpdateEffectsRequest(shapes.URL, shapes.DeveloperAuthToken, request);
            }

            return true;
        }
    }
}
