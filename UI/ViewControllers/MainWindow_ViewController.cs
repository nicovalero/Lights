using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control.Controllers;
using UI.Models.Structs;
using PhilipsHue.Models.Interfaces;
using System.Collections;
using PhilipsHue.Effects.Interfaces;
using ControlzEx.Standard;
using UI.Models.Interfaces;
using PhilipsHue.EffectConfig.Creators.Interfaces;
using UI.Models.Classes;
using System.CodeDom;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI
{
    internal class MainWindow_ViewController
    {
        private MidiLightsController _midiLightsController;
        private static readonly MainWindow_ViewController _controller = new MainWindow_ViewController();

        private MainWindow_ViewController()
        {
            _midiLightsController = MidiLightsController.Singleton();
        }

        public static MainWindow_ViewController Singleton()
        {
            return _controller;
        }

        internal bool CreateLink(IList selectedLights, IConfigListViewModel selectedEffect, IConfigListViewModel selectedChannel, 
            IConfigListViewModel selectedNote, IConfigListViewModel selectedVelocity, IConfigVMSet config)
        {
            List<HueLight> lights = ConvertIList_ToHueLightList(selectedLights);
            LightEffect effect = (LightEffect)selectedEffect.Item;
            MidiChannel channel = (MidiChannel)selectedChannel.Item;
            MidiNote note = (MidiNote)selectedNote.Item;
            MidiVelocity velocity = (MidiVelocity)selectedVelocity.Item;
            var configuration = GetConfigFromViewModel(config);

            _midiLightsController.CreateLink(channel, note, velocity, lights, effect, configuration);

            return true;
        }

        public List<MidiEffectLink_ViewModel> GetLinks()
        {
            Dictionary<MidiMessageKeys, LightEffectAction> result = _midiLightsController.GetMessageActionLinks();

            return ConvertMidiActionDictionary_ToMidiEffectLinkVM(result);
        }

        public bool SaveLinksToFile()
        {
            return _midiLightsController.SaveLinksToFile();
        }

        public bool LoadLinksFromFile()
        {
            if (_midiLightsController.ReadLinksFromFile())
            {
                GetLinks();
                return true;
            }
            return false;
        }

        private List<MidiEffectLink_ViewModel> ConvertMidiActionDictionary_ToMidiEffectLinkVM(Dictionary<MidiMessageKeys, LightEffectAction> dictionary)
        {
            List<MidiEffectLink_ViewModel> list = new List<MidiEffectLink_ViewModel>();

            foreach (KeyValuePair<MidiMessageKeys, LightEffectAction> pair in dictionary)
            {
                list.Add(new MidiEffectLink_ViewModel(
                    pair.Key.Channel,
                    pair.Key.Velocity,
                    pair.Key.Note,
                    pair.Value.GetEffect(),
                    pair.Value.GetLights()));
            }

            return list;
        }

        private List<SimpleConfigList_ViewModel> ConvertMidiNoteList_ToSimpleConfigListVM(List<MidiNote> notes)
        {
            List<SimpleConfigList_ViewModel> list = new List<SimpleConfigList_ViewModel>();

            foreach (MidiNote note in notes)
            {
                list.Add(new SimpleConfigList_ViewModel(
                    note,
                    note.Name));
            }

            return list;
        }

        private List<SimpleConfigList_ViewModel> ConvertMidiChannelList_ToSimpleConfigListVM(List<MidiChannel> channels)
        {
            List<SimpleConfigList_ViewModel> list = new List<SimpleConfigList_ViewModel>();

            foreach (MidiChannel channel in channels)
            {
                list.Add(new SimpleConfigList_ViewModel(
                    channel,
                    channel.Name));
            }

            return list;
        }

        private List<SimpleConfigList_ViewModel> ConvertMidiVelocityList_ToSimpleConfigListVM(List<MidiVelocity> velocities)
        {
            List<SimpleConfigList_ViewModel> list = new List<SimpleConfigList_ViewModel>();

            foreach (MidiVelocity velocity in velocities)
            {
                list.Add(new SimpleConfigList_ViewModel(
                    velocity,
                    velocity.Name));
            }

            return list;
        }

        private List<HueLight> ConvertIList_ToHueLightList(IList selectedLightItems)
        {
            List<HueLight> lights = new List<HueLight>();

            foreach (IConfigListViewModel light in selectedLightItems)
            {
                lights.Add((HueLight)light.Item);
            }

            return lights;
        }

        internal void ConnectBridges()
        {
            _midiLightsController.ConnectBridges();
        }

        internal int GetHueBridgeCount()
        {
            return _midiLightsController.GetHueBridgeCount();
        }

        internal void StartListening()
        {
            _midiLightsController.StartMidiController();
        }

        internal string GetMidiListeningStatusString()
        {
            return _midiLightsController.MidiListeningString();
        }

        internal List<CardConfigList_ViewModel> GetHueEffectCardConfigList()
        {
            return HueEffect_ToCardConfigConverter.ConvertLightEffect_ToCardConfig(_midiLightsController.GetAllHueEffects());
        }

        public List<SimpleConfigList_ViewModel> GetAvailableMidiNoteList()
        {
            List<MidiNote> result = _midiLightsController.GetAllMidiNotes();

            return ConvertMidiNoteList_ToSimpleConfigListVM(result);
        }

        internal List<SimpleConfigList_ViewModel> GetAvailableMidiVelocityList()
        {
            List<MidiVelocity> result = _midiLightsController.GetAvailableVelocities();

            return ConvertMidiVelocityList_ToSimpleConfigListVM(result);
        }

        internal List<SimpleConfigList_ViewModel> GetAvailableChannelList()
        {
            List<MidiChannel> result = _midiLightsController.GetAvailableChannels();

            return ConvertMidiChannelList_ToSimpleConfigListVM(result);
        }

        internal List<HueLight> GetAvailableHueLightsList()
        {
            return _midiLightsController.GetAllAvailableHueLights();
        }

        internal List<CardConfigList_ViewModel> GetAvailableHueLights_CardConfigList()
        {
            return HueLight_ToCardConfigConverter.ConvertHueLight_ToCardConfig(_midiLightsController.GetAllAvailableHueLights());
        }

        internal IEffectConfigSet GetConfigFromViewModel(IConfigVMSet set)
        {
            return EffectConfigSetCreator.CreateConfigSet(set);
        }
    }
}
