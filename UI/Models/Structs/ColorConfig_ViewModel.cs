﻿using Microsoft.Xaml.Behaviors.Core;
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
    internal struct ColorConfig_ViewModel
    {
        private Color? _selectedColor;

        public Color? SelectedColor { get { return _selectedColor; } set { _selectedColor = value; } }

        public ColorConfig_ViewModel(Color? selectedColor)
        {
            _selectedColor = selectedColor;
        }
    }
}
