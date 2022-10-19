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

        internal bool CreateLink(IList selectedLights, object selectedEffect, object selectedChannel, object selectedNote, object selectedVelocity)
        {
            List<HueLight> lights = ConvertIList_ToHueLightList(selectedLights);
            LightEffect effect = (LightEffect)selectedEffect;
            MidiChannel channel = (MidiChannel)selectedChannel;
            MidiNote note = (MidiNote)selectedNote;
            MidiVelocity velocity = (MidiVelocity)selectedVelocity;

            _midiLightsController.CreateLink(channel, note, velocity, lights, effect);

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

        private List<HueLight> ConvertIList_ToHueLightList(IList selectedLights)
        {
            List<HueLight> lights = new List<HueLight>();

            foreach (var light in selectedLights)
            {
                lights.Add((HueLight)light);
            }

            return lights;
        }

        internal void ConnectBridges()
        {
            _midiLightsController.ConnectBridges();
        }

        internal void StartListening()
        {
            _midiLightsController.StartMidiController();
        }

        internal List<MidiChannel> GetAvailableChannelList()
        {
            return _midiLightsController.GetAvailableChannels();
        }

        internal object GetHueEffectList()
        {
            return _midiLightsController.GetAllHueEffects();
        }

        internal List<MidiNote> GetAvailableMidiNoteList()
        {
            return _midiLightsController.GetAllMidiNotes();
        }

        internal List<MidiVelocity> GetAvailableMidiVelocityList()
        {
            return _midiLightsController.GetAvailableVelocities();
        }

        internal List<HueLight> GetAvailableHueLightsList()
        {
            return _midiLightsController.GetAllAvailableHueLights();
        }
    }
}
