using Nanoleaf.Action.Interfaces;
using Nanoleaf.Devices.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using static System.TimeZoneInfo;
using Nanoleaf.Converters;
using Nanoleaf.EffectConfig.Creators.Classes;

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
                foreach(var item in AnimDataList)
                {
                    data = string.Join(" ", data, item.GetData());
                }

                return data;
            }
        }
        public bool Loop { get; set; }
        public string[] Palette { get; set; }
        public ShapesUpdateEffectsActionValues(string command, string version, string animType, List<AnimDataValues> animDataList,
            bool loop, string[] palette)
        {
            Command = command;
            Version = version;
            AnimType = animType;
            AnimDataList = animDataList;
            Loop = loop;
            Palette = palette;
        }
    }
    internal class ShapesPanelsUpdateEffectsAction : IAction
    {
        private Dictionary<INanoleafShapes, UpdateEffectsRequest> shapesRequestDictionary;

        private const string COMMAND = "display";
        private const string VERSION = "2.0";
        private const string ANIMTYPE = "static";
        private const bool LOOP = false;
        private string[] PALETTE = new string[] {};

        internal ShapesPanelsUpdateEffectsAction(Dictionary<IShapesPanel, INanoleafShapes> panelShapesDictionary, ColorChangeConfigSet config)
        {
            var panelsByShapes = new Dictionary<INanoleafShapes, List<IShapesPanel>>();
            var colorValue = config.FinalColor.RGBColor;
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

                for(int i = 0; i < list.Count; i++)
                {
                    var panel = list[i];
                    var animData = new AnimDataValues(Convert.ToInt32(panel.GetPanelID()), 1, colorValue.R, colorValue.G, colorValue.B, colorValue.A, 1);
                    animDataList.Add(animData);
                }

                var values = new ShapesUpdateEffectsActionValues(COMMAND, VERSION, ANIMTYPE, animDataList, LOOP, PALETTE);

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
