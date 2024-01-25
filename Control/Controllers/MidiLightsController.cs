using PhilipsHue.Controllers;
using PhilipsHue.Models.Classes;
using MIDI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using Windows.Devices.Midi;
using System.Threading;
using PhilipsHue.Actions.Classes;
using PhilipsHue.Effects.Classes;
using MIDI.Models.Class;
using PhilipsHue.Collections;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using Newtonsoft.Json;
using DataStorage.Models;
using System.Collections;
using Windows.UI.Xaml.Shapes;
using Windows.Devices.Enumeration;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using System.Diagnostics;
using Control.Models.Interfaces;
using DataStorage.Models.Interfaces;
using DataStorage.Models.Classes;
using Control.Factories;
using Control.Enums;
using Control.Models.Classes;
using Windows.Foundation;
using Control.Models.Structs;
using Control.Controllers.Interfaces;
using System.Security.AccessControl;
using System.Text.Json;

namespace Control.Controllers
{
    public class MidiLightsController
    {
        private readonly MidiController _midiController;
        private readonly StorageController _storageController;

        public static Dictionary<MidiMessageKeys, IViewLink> _links;
        public IMidiLightsController _hueLightsController;
        public IMidiLightsController _nanoleafLightsController;
        private IPhilipsHueMidiLightsController _concreteHueLightsController;
        private INanoleafMidiLightsController _concreteNanoleafLightsController;

        private ViewEffectFactory viewEffectFactory;
        private ViewLightFactory viewLightFactory;
        private ViewLinkFactory viewLinkFactory;

        internal event TypedEventHandler<MidiLightsController, MidiMessageViewLightsEffectConfig> CreateLinkPhilipsHueEventHandler;
        internal event TypedEventHandler<MidiLightsController, MidiMessageViewLightsEffectConfig> CreateLinkNanoleafEventHandler;
        internal event TypedEventHandler<MidiLightsController, MidiMessageKeys> DeleteLinkEventHandler;
        internal event TypedEventHandler<MidiLightsController, MidiMessageKeys> PerformLinkEventHandler;

        public MidiLightsController()
        {
            viewEffectFactory = new ViewEffectFactory();
            viewLightFactory = new ViewLightFactory();
            _storageController = StorageController.Singleton();
            _midiController = new MidiController();
            _links = new Dictionary<MidiMessageKeys, IViewLink>();
            _hueLightsController = new PhilipsHueLightsController();
            _concreteHueLightsController = _hueLightsController as IPhilipsHueMidiLightsController;
            _nanoleafLightsController = new NanoleafLightsController();
            _concreteNanoleafLightsController = _nanoleafLightsController as INanoleafMidiLightsController;
            viewLinkFactory = new ViewLinkFactory();
            _midiController.MessageEventHandler += MidiMessageReceived;
            CreateLinkPhilipsHueEventHandler += _hueLightsController.CreateLinkHandler;
            DeleteLinkEventHandler += _hueLightsController.DeleteLinkHandler;

            PerformLinkEventHandler += _hueLightsController.PerformLinkedAction;
        }

        public void MidiMessageReceived(MidiController sender, MidiMessageKeys args)
        {
            var stopw = Stopwatch.StartNew();
            ThreadPool.QueueUserWorkItem((state) => PerformLinkedAction(args));
            stopw.Stop();
            Console.WriteLine("Midi Message processed in " + stopw.ElapsedMilliseconds);
        }

        public bool CreateLink(MidiChannel channel, MidiNote note, MidiVelocity velocity,
            List<IViewLight> viewLights, IViewEffect viewEffect, IViewEffectConfigSet viewConfig)
        {
            MidiMessageKeys keys = new MidiMessageKeys(channel, velocity, note);

            if (_links.ContainsKey(keys))
                return false;
            else
            {
                if (viewLights.Count > 0)
                {
                    var hueLights = viewLights.Where(x => x.GetLightType() == LightType.PhilipsHue).ToList();
                    var nanoleafLights = viewLights.Where(x => x.GetLightType() == LightType.Nanoleaf).ToList();

                    if (hueLights.Count > 0)
                    {
                        var hueLightsAndKeys = new MidiMessageViewLightsEffectConfig(hueLights, keys, viewEffect, viewConfig);

                        //The following line tells the Hue controller to create the link
                        CreateLinkPhilipsHueEventHandler(this, hueLightsAndKeys);
                    }

                    if (nanoleafLights.Count > 0)
                    {
                        var nanoleafLightsAndKeys = new MidiMessageViewLightsEffectConfig(nanoleafLights, keys, viewEffect, viewConfig);

                        //The following line tells the Nanoleaf controller to create the link
                        CreateLinkNanoleafEventHandler(this, nanoleafLightsAndKeys);
                    }

                    var viewLink = viewLinkFactory.Construct(viewEffect, viewLights, viewConfig);
                    _links.Add(keys, viewLink);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool RemoveLink(MidiMessageKeys keys)
        {
            if (!_links.ContainsKey(keys))
                return false;
            else
            {
                _links.Remove(keys);
                DeleteLinkEventHandler(this, keys);
            }

            return true;
        }

        public bool SaveLinksToFile()
        {
            var linkList = new List<KeyValuePair<MidiMessageKeys, ViewLink>>();

            foreach (KeyValuePair<MidiMessageKeys, IViewLink> link in _links)
            {
                linkList.Add(new KeyValuePair<MidiMessageKeys, ViewLink>(link.Key, (ViewLink)link.Value));
            }

            var linksJson = JsonConvert.SerializeObject(linkList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });

            var hueSaveObject = new HueLinkSaveObject(_concreteHueLightsController.GetMessageActionLinks());
            var nanoleafSaveObject = new NanoleafLinkSaveObject(_concreteNanoleafLightsController.GetMessageActionLinks());
            var mainSaveObject = new MainLinkSaveObject(linksJson);

            ILinkSaveObject saveObject = new LinkSaveObject(mainSaveObject, hueSaveObject, nanoleafSaveObject);
            return _storageController.SaveLinks(saveObject);
        }

        public bool ReadLinksFromFile()
        {
            ILinkSaveObject links = _storageController.ReadLinks();

            if (links != null)
            {
                ParseLinks(links.MainLinksJson);
                _concreteHueLightsController.ParseLinks(links.PhilipsHueLinkSaveObject);
                _concreteNanoleafLightsController.ParseLinks(links.NanoleafLinkSaveObject);
            }
            else
                return false;

            return true;
        }

        public bool PerformLinkedAction(MidiMessageKeys keys)
        {
            if (!_links.ContainsKey(keys))
                return false;
            else
            {
                PerformLinkEventHandler(this, keys);
            }

            return true;
        }

        public void StartMidiController()
        {
            _midiController.Start();
        }

        public void StopMidiController()
        {
            _midiController.Stop();
        }

        public string MidiListeningString()
        {
            DeviceWatcherStatus status = _midiController.ListeningStatus();
            string statusString = "";
            switch (status)
            {
                case DeviceWatcherStatus.Started:
                    statusString = "Started";
                    break;
                case DeviceWatcherStatus.Stopped:
                    statusString = "Stopped";
                    break;
                case DeviceWatcherStatus.Stopping:
                    statusString = "Stopping";
                    break;
                case DeviceWatcherStatus.EnumerationCompleted:
                    statusString = "Enumeration Completed";
                    break;
                case DeviceWatcherStatus.Aborted:
                    statusString = "Aborted";
                    break;
                default:
                    statusString = "Unknown";
                    break;
            }

            return statusString;
        }

        public void ConnectBridges()
        {
            _hueLightsController.ConnectSystem();
            _nanoleafLightsController.ConnectSystem();
        }

        public int GetHueBridgeCount()
        {
            return _hueLightsController.GetControllerDeviceCount();
        }

        public List<MidiNote> GetAllMidiNotes()
        {
            return MidiNoteCollection.GetAllNotesList();
        }

        public List<MidiChannel> GetAvailableChannels()
        {
            return MidiChannelCollection.GetAllChannelList();
        }

        public List<MidiVelocity> GetAvailableVelocities()
        {
            return MidiVelocityCollection.GetAllVelocityList();
        }

        public List<IViewEffect> GetAllViewEffectsAvailable()
        {
            var list = new List<IViewEffect>
            {
                viewEffectFactory.Construct(AvailableViewEffects.UniversalOn),
                viewEffectFactory.Construct(AvailableViewEffects.UniversalOff),
                viewEffectFactory.Construct(AvailableViewEffects.UniversalFlash),
                viewEffectFactory.Construct(AvailableViewEffects.UniversalColorChange),
                viewEffectFactory.Construct(AvailableViewEffects.UniversalColorWave),
                viewEffectFactory.Construct(AvailableViewEffects.UniversalBrightnessWave),
                viewEffectFactory.Construct(AvailableViewEffects.UniversalFadeIn),
                viewEffectFactory.Construct(AvailableViewEffects.UniversalFadeOut),
                viewEffectFactory.Construct(AvailableViewEffects.NanoleafEffect)
            };

            return list;
        }

        public List<IViewLight> GetAllAvailableHueLights()
        {
            var hueLights = _concreteHueLightsController.GetAllAvailableDevices();
            var viewLights = new List<IViewLight>();

            foreach (var light in hueLights)
            {
                viewLights.Add(viewLightFactory.ConstructFromHueLight(light));
            }

            return viewLights;
        }

        public List<IViewLight> GetAllAvailableNanoleafLights()
        {
            var nanoleafLights = _concreteNanoleafLightsController.GetAllAvailableDevices();
            var viewLights = new List<IViewLight>();

            foreach (var light in nanoleafLights)
            {
                viewLights.Add(viewLightFactory.ConstructFromNanoleafLight(light));
            }

            return viewLights;
        }

        //public ILinkSaveObject GetSavedLinks()
        //{
        //    return new HueLinkSaveObject(_messageActionLinks);
        //}

        public Dictionary<MidiMessageKeys, IViewLink> GetMidiMessageLinkDictionary()
        {
            return _links;
        }

        private void ParseLinks(IMainLinkSaveObject saveObject)
        {
            _links.Clear();
            var jsonLinks = saveObject.LinksJson;

            var parsedObject = JsonConvert.DeserializeObject<List<KeyValuePair<MidiMessageKeys, ViewLink>>>(jsonLinks,                
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                });
            foreach (KeyValuePair<MidiMessageKeys, ViewLink> link in parsedObject)
            {
                _links.Add(link.Key, link.Value);
            }
        }
    }
}
