﻿using Control.Controllers.Interfaces;
using Control.Factories;
using Control.Models.Structs;
using DataStorage.Models;
using DataStorage.Models.Interfaces;
using MIDI.Controllers;
using MIDI.Models.Class;
using MIDI.Models.Structs;
using Nanoleaf.Devices.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Nanoleaf.Action.Interfaces;
using Nanoleaf.Action.Factories;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Effects.Enums;
using Control.Parsers.EffectParsers;
using Control.Models.Interfaces;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using System.Threading;
using System.Linq;
using Windows.UI.Xaml.Shapes;

namespace Control.Controllers
{
    internal class NanoleafLightsController : IMidiLightsController, INanoleafMidiLightsController
    {
        private readonly ShapesController shapesController;
        public static Dictionary<MidiMessageKeys, IAction> _messageActionLinks;
        private readonly ShapesPanelFactory shapesPanelFactory;

        private readonly IAction identifyAction;

        [JsonProperty("MessageActionLinks")]
        internal Dictionary<MidiMessageKeys, IAction> MessageActionLinks
        {
            get { return _messageActionLinks; }
            set { _messageActionLinks = value; }
        }

        internal NanoleafLightsController()
        {
            shapesController = new ShapesController();
            _messageActionLinks = new Dictionary<MidiMessageKeys, IAction>();
            shapesPanelFactory = new ShapesPanelFactory();
        }

        public void CreateLinkHandler(object sender, MidiMessageViewLightsEffectConfig linkData)
        {
            CreateLink(linkData);
        }

        public void DeleteLinkHandler(object sender, MidiMessageKeys keys)
        {
            RemoveLink(keys);
        }

        public bool CreateLink(MidiMessageViewLightsEffectConfig linkData)
        {
            MidiMessageKeys keys = linkData.MidiMessageKeys;

            if (_messageActionLinks.ContainsKey(keys))
                return false;
            else
            {
                var deviceIDs = linkData.ViewLights.Select(x => x.ID).ToList();

                var panels = new HashSet<IShapesPanel>(shapesController.GetAllPanels(deviceIDs));
                var shapes = new HashSet<INanoleafShapes>(shapesController.GetAllShapes(deviceIDs));

                var availableEffect = NanoleafEffectViewEffectParser.GetAvailableEffectFromViewEffect(linkData.ViewEffect);
                IEffectConfigSet config = NanoleafConfigSetFactory.CreateConfigSet(linkData.ViewEffectConfigSet);

                if (shapes.Count == 0)
                {
                    var panelsAction = shapesController.CreateAction(panels, availableEffect, config);
                    _messageActionLinks.Add(keys, panelsAction);
                }
                else
                {
                    var shapesAction = shapesController.CreateShapesAction(shapes, availableEffect, config);
                    _messageActionLinks.Add(keys, shapesAction);
                }
            }

            return true;
        }

        public bool RemoveLink(MidiMessageKeys keys)
        {
            if (!_messageActionLinks.ContainsKey(keys))
                return false;
            else
                _messageActionLinks.Remove(keys);

            return true;
        }

        public void PerformLinkedAction(MidiLightsController sender, MidiMessageKeys keys)
        {
            if (_messageActionLinks.ContainsKey(keys))
            {
                IAction action = _messageActionLinks[keys];
                var thread = new Thread(() => shapesController.PerformSimpleAction(action));
                thread.Start();
            }
        }

        public void PerformIdentifyAction(MidiLightsController sender, List<IViewLight> lights)
        {
            var availableEffectOn = NanoleafEffectViewEffectParser.GetIdentifyAvailableEffectOn();
            IEffectConfigSet configTurnOn = NanoleafConfigSetFactory.CreateIdentifyActionTurnOnConfigSet();

            var availableEffectColorChange = NanoleafEffectViewEffectParser.GetIdentifyAvailableEffectColorChange();
            IEffectConfigSet configColorChange = NanoleafConfigSetFactory.CreateIdentifyActionColorChangeConfigSet(lights);

            var deviceIDs = lights.Select(x => x.ID).ToList();
            var panels = new HashSet<IShapesPanel>(shapesController.GetAllPanels(deviceIDs));
            var shapes = new HashSet<INanoleafShapes>(shapesController.GetAllShapes(deviceIDs));
            bool activateThreads = false;

            if (panels.Count > 0)
            {
                var panelsColorChangeAction = shapesController.CreateAction(panels, availableEffectColorChange, configColorChange);
                var panelsTurnOnAction = shapesController.CreateAction(panels, availableEffectOn, configTurnOn);

                var panelsThread = new Thread(() =>
                {
                    while (!activateThreads) { }
                    //Need to implement the action from the Factory, because it's null atm
                    //shapesController.PerformSimpleAction(panelsTurnOnAction);
                    //Thread.Sleep(10);
                    shapesController.PerformSimpleAction(panelsColorChangeAction);
                });
                panelsThread.Start();
            }

            if (shapes.Count > 0)
            {
                var shapesColorChangeAction = shapesController.CreateShapesAction(shapes, availableEffectColorChange, configColorChange);
                var shapesTurnOnAction = shapesController.CreateShapesAction(shapes, availableEffectOn, configTurnOn);

                var shapesThread = new Thread(() =>
                {
                    while (!activateThreads) { }
                    shapesController.PerformSimpleAction(shapesTurnOnAction);
                    Thread.Sleep(10);
                    shapesController.PerformSimpleAction(shapesColorChangeAction);
                });
                shapesThread.Start();
            }

            activateThreads = true;
        }

        public bool ParseLinks(INanoleafLinkSaveObject saveObject)
        {
            _messageActionLinks.Clear();
            var links = saveObject.Links;
            foreach (KeyValuePair<MidiMessageKeys, IAction> link in links)
            {
                _messageActionLinks.Add(link.Key, link.Value);
            }

            return true;
        }

        public void ConnectSystem()
        {
            shapesController.InitializeSystem();
        }

        public int GetControllerDeviceCount()
        {
            return shapesController.GetShapesControllerCount();
        }

        public Dictionary<MidiMessageKeys, IAction> GetMessageActionLinks()
        {
            return _messageActionLinks;
        }

        public List<AvailableEffects> GetEffects()
        {
            return shapesController.GetAllEffectList();
        }

        public List<IShapesPanel> GetAllAvailableDevices()
        {
            return shapesController.GetAllAvailableDevices();
        }
    }
}
