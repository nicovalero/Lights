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

namespace Control.Controllers
{
    internal class NanoleafLightsController : IMidiLightsController, INanoleafMidiLightsController
    {
        private readonly ShapesController shapesController;
        public static Dictionary<MidiMessageKeys, IAction> _messageActionLinks;
        private readonly ShapesPanelFactory shapesPanelFactory;
        private readonly NanoleafActionFactory nanoleafActionFactory;

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
            nanoleafActionFactory = new NanoleafActionFactory();
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
                var panels = new List<IShapesPanel>();
                foreach (var light in linkData.ViewLights)
                {
                    panels.Add(shapesPanelFactory.CreatePanelFromID(light.GetID()));
                }

                var availableEffect = NanoleafEffectViewEffectParser.GetAvailableEffectFromViewEffect(linkData.ViewEffect);
                IEffectConfigSet config = NanoleafConfigSetFactory.CreateConfigSet(linkData.ViewEffectConfigSet);

                var action = nanoleafActionFactory.CreateAction(panels, availableEffect, config);
                _messageActionLinks.Add(keys, action);
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
                shapesController.PerformSimpleAction(action);
            }
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
