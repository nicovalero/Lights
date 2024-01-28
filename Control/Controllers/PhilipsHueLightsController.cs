using Control.Controllers.Interfaces;
using Control.Factories;
using Control.Models.Structs;
using DataStorage.Models;
using DataStorage.Models.Interfaces;
using MIDI.Controllers;
using MIDI.Models.Class;
using MIDI.Models.Structs;
using Newtonsoft.Json;
using PhilipsHue.Actions.Classes;
using PhilipsHue.Actions.Interfaces;
using PhilipsHue.Collections;
using PhilipsHue.Controllers;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Control.Controllers
{
    internal class PhilipsHueLightsController : IMidiLightsController, IPhilipsHueMidiLightsController
    {
        private readonly HueLightController _hueLightController;
        public static Dictionary<MidiMessageKeys, LightEffectAction> _messageActionLinks;

        [JsonProperty("MessageActionLinks")]
        public Dictionary<MidiMessageKeys, LightEffectAction> MessageActionLinks
        {
            get { return _messageActionLinks; }
            set { _messageActionLinks = value; }
        }

        internal PhilipsHueLightsController()
        {
            _hueLightController = new HueLightController();
            _messageActionLinks = new Dictionary<MidiMessageKeys, LightEffectAction>();
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
                var action = PhilipsHueActionFactory.CreateSingleLightEffectAction(linkData.ViewLights, linkData.ViewEffect, linkData.ViewEffectConfigSet);
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
                LightEffectAction action = _messageActionLinks[keys];
                var thread = new Thread(() => _hueLightController.PerformAction(action));
                thread.Start();
            }
        }

        public bool ParseLinks(IHueLinkSaveObject saveObject)
        {
            _messageActionLinks.Clear();
            var links = saveObject.Links;
            foreach (KeyValuePair<MidiMessageKeys, LightEffectAction> link in links)
            {
                _messageActionLinks.Add(link.Key, link.Value);
            }

            return true;
        }

        public void ConnectSystem()
        {
            _hueLightController.InitializeBridges();
        }

        public int GetControllerDeviceCount()
        {
            return _hueLightController.GetBridgeCount();
        }

        public Dictionary<MidiMessageKeys, LightEffectAction> GetMessageActionLinks()
        {
            return _messageActionLinks;
        }

        public List<LightEffect> GetEffects()
        {
            return HueLightEffectCollection.GetAllEffectList();
        }

        public List<HueLight> GetAllAvailableDevices()
        {
            return _hueLightController.GetAllAvailableDevices();
        }
    }
}
