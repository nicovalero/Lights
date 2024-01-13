using DataStorage.Models;
using DataStorage.Models.Classes;
using DataStorage.Models.Interfaces;
using MIDI.Models.Structs;
using Newtonsoft.Json;
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

        public bool SaveLinks(ILinkSaveObject saveObject)
        {
            return FileManager.Save(saveObject);
        }

        public ILinkSaveObject ReadLinks()
        {
            string content = FileManager.Read();

            if (!string.IsNullOrEmpty(content))
            {
                ILinkSaveObject links = JsonConvert.DeserializeObject<LinkSaveObject>(content, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });

                return links;
            }
            else
                return null;            
        }
    }
}
