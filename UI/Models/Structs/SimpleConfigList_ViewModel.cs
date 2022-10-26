using Microsoft.Xaml.Behaviors.Core;
using MIDI.Models.Structs;
using PhilipsHue.Effects.Interfaces;
using PhilipsHue.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Interfaces;

namespace UI.Models.Structs
{
    internal struct SimpleConfigList_ViewModel: IConfigListViewModel
    {
        private object _item;
        private string _itemName;

        public object Item { get { return _item; } }
        public string ItemName { get { return _itemName; } }

        public SimpleConfigList_ViewModel(object item, string itemName)
        {
            _item = item;
            _itemName = itemName;
        }
    }
}
