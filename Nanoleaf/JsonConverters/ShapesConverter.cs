using Nanoleaf.Devices.Classes;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.JsonConverters
{
    internal class ShapesConverter : JsonConverter<Dictionary<INanoleafShapes, UpdateEffectsRequest>>
    {
        public override Dictionary<INanoleafShapes, UpdateEffectsRequest> ReadJson(JsonReader reader, Type objectType, Dictionary<INanoleafShapes, UpdateEffectsRequest> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dictionary = serializer.Deserialize<Dictionary<Shapes, UpdateEffectsRequest>>(reader);

            Dictionary<INanoleafShapes, UpdateEffectsRequest> result = new Dictionary<INanoleafShapes, UpdateEffectsRequest>();
            
            foreach(var kvp in dictionary)
            {
                result.Add(kvp.Key, kvp.Value);
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, Dictionary<INanoleafShapes, UpdateEffectsRequest> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(Shapes));
        }
    }
}
