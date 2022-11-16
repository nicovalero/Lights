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
    public struct TransitionTimeConfig_ViewModel
    {
        private uint _transitionTime;

        public uint TransitionTime{ get { return _transitionTime; } set { _transitionTime = value; } }

        public TransitionTimeConfig_ViewModel(uint transitionTime)
        {
            _transitionTime = transitionTime;
        }
    }
}
