using Microsoft.Xaml.Behaviors.Core;
using MIDI.Models.Structs;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UI.Models.Interfaces;

namespace UI.Models.Structs
{
    public struct BrightnessConfig_ViewModel
    {
        private byte _brightnessLevel;

        public byte BrightnessLevel{ get { return _brightnessLevel; } set { _brightnessLevel = value; } }

        public BrightnessConfig_ViewModel(byte selectedBrightnessLevel)
        {
            _brightnessLevel = selectedBrightnessLevel;
        }
    }
}
