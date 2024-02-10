﻿using Nanoleaf.Action.Interfaces;
using Nanoleaf.Network.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using Nanoleaf.EffectConfig.Creators.Classes;
using Nanoleaf.RequestAttributes;
using System.Threading;

namespace Nanoleaf.Action.Actions.ShapesPanelsActions
{
    public struct ShapesFlashActionValues
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
        public Palette Palette { get; set; }
        public ShapesFlashActionValues(string command, string version, string animType, List<AnimDataValues> animDataList,
            bool loop, Palette palette)
        {
            Command = command;
            Version = version;
            AnimType = animType;
            AnimDataList = animDataList;
            Loop = loop;
            Palette = palette;
        }
    }
    internal class ShapesPanelsFlashAction : IAction
    {
        private Dictionary<INanoleafShapes, Queue<UpdateEffectsRequest>> shapesRequestDictionary;
        private int timePerRequest;

        [JsonProperty("ShapesRequestQueueList")]
        private List<KeyValuePair<INanoleafShapes, Queue<UpdateEffectsRequest>>> ShapesRequestDictionary
        {
            get
            {
                var list = new List<KeyValuePair<INanoleafShapes, Queue<UpdateEffectsRequest>>>();
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
                    shapesRequestDictionary = new Dictionary<INanoleafShapes, Queue<UpdateEffectsRequest>>();
                }
                foreach (var item in value)
                {
                    shapesRequestDictionary.Add(item.Key, item.Value);
                }
            }
        }

        [JsonConstructor]
        internal ShapesPanelsFlashAction()
        {
            shapesRequestDictionary = new Dictionary<INanoleafShapes, Queue<UpdateEffectsRequest>>();
        }
        internal ShapesPanelsFlashAction(Dictionary<IShapesPanel, INanoleafShapes> panelShapesDictionary, ShapesUpdateEffectsActionValues firstValues,
            ShapesUpdateEffectsActionValues finalValues, uint transitionTimeInMiliseconds)
        {
            timePerRequest = Convert.ToInt16(transitionTimeInMiliseconds / 2);
            var panelsByShapes = new Dictionary<INanoleafShapes, List<IShapesPanel>>();
            shapesRequestDictionary = new Dictionary<INanoleafShapes, Queue<UpdateEffectsRequest>>();

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
                var shapes = kvp.Key;
                var queue = new Queue<UpdateEffectsRequest>();

                var firstRequest = new UpdateEffectsRequest(firstValues);
                var secondRequest = new UpdateEffectsRequest(finalValues);

                queue.Enqueue(firstRequest);
                queue.Enqueue(secondRequest);

                shapesRequestDictionary.Add(shapes, queue);
            }
        }

        public bool Perform()
        {
            bool start = false;
            foreach (var kvp in shapesRequestDictionary)
            {
                var thread = new Thread(() =>
                {
                    var shapes = kvp.Key;
                    var requestQueue = kvp.Value;

                    while (!start) { };
                    foreach (var request in requestQueue)
                    {
                        EndpointMessenger.UpdateEffectsRequest(shapes.URL, shapes.DeveloperAuthToken, request);
                        Thread.Sleep(timePerRequest);
                    }
                });
                thread.Start();
            }

            start = true;

            return true;
        }
    }
}
