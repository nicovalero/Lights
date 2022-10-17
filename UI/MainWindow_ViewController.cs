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

        public List<MidiEffectLink_ViewModel> GetLinks()
        {
            Dictionary<MidiMessageKeys, LightEffectAction> result = _midiLightsController.GetMessageActionLinks();

            return ConvertMidiActionDictionary_ToMidiEffectLinkVM(result);
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
                    pair.Value.GetEffect()),
                    pair.Value.GetLight());
            }

            return list;
        }

        internal void ConnectBridges()
        {
            _midiLightsController.ConnectBridges();
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
