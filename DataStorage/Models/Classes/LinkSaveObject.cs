using DataStorage.Enums;
using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Models.Classes
{
    public class LinkSaveObject : ILinkSaveObject
    {
        public string JsonContent { get; private set; }

        public LinkSaveObject(string jsonContent)
        {
            this.JsonContent = jsonContent;
        }
    }
}
