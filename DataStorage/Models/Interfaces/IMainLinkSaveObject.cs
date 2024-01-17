using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStorage.Models.Interfaces
{
    public interface IMainLinkSaveObject
    {
        string LinksJson { get; set; }
    }
}
