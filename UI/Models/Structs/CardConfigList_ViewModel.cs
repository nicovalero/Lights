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

namespace UI.Models.Structs
{
    internal struct CardConfigList_ViewModel
    {
        private object _item;
        private string _itemName;
        private Color _backgroundColor;
        private FontAwesome.Sharp.IconChar _icon;

        public object Item { get { return _item; } }
        public string ItemName { get { return _itemName; } }
        public Color BackgroundColor { get { return _backgroundColor; } }
        public FontAwesome.Sharp.IconChar Icon { get { return _icon; } }


        public CardConfigList_ViewModel(object item, string itemName, Color color, FontAwesome.Sharp.IconChar icon)
        {
            _item = item;
            _itemName = itemName;
            _backgroundColor = color;
            _icon = icon;
        }
    }
}
