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
        private Color _backgroundColor1;
        private Color _backgroundColor2;
        private FontAwesome.Sharp.IconChar _icon;

        public object Item { get { return _item; } }
        public string ItemName { get { return _itemName; } }
        public Color BackgroundColor1 { get { return _backgroundColor1; } }
        public Color BackgroundColor2 { get { return _backgroundColor2; } }
        public FontAwesome.Sharp.IconChar Icon { get { return _icon; } }


        public CardConfigList_ViewModel(object item, string itemName, Color backgroundColor1, Color backgroundColor2, FontAwesome.Sharp.IconChar icon)
        {
            _item = item;
            _itemName = itemName;
            _backgroundColor1 = backgroundColor1;
            _backgroundColor2 = backgroundColor2;
            _icon = icon;
        }
    }
}
