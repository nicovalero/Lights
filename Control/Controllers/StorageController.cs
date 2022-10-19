using DataStorage.Models;
using MIDI.Models.Structs;
using PhilipsHue.Actions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Controllers
{
    internal class StorageController
    {
        private static readonly StorageController _storageController = new StorageController();

        private StorageController() { }
        public static StorageController Singleton()
        {
            return _storageController;
        }

        public bool SaveLinks(Dictionary<MidiMessageKeys, LightEffectAction> links)
        {
            HueLinkSaveObject saveObject = new HueLinkSaveObject(links);
            return FileManager.Save(saveObject);
        }

        public string ReadLinks()
        {
            return FileManager.Read();
        }
    }
}
