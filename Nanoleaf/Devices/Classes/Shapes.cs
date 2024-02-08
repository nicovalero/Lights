﻿using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    public class Shapes : INanoleafShapes
    {
        [JsonProperty]
        public uint ID { get; private set; }
        [JsonProperty]
        public Uri URL { get; private set; }
        [JsonProperty]
        public DeveloperAuthToken DeveloperAuthToken { get; private set; }
        [JsonProperty]
        public HashSet<IShapesPanel> Panels { get; private set; }

        [JsonConstructor]
        public Shapes() { }

        public Shapes(uint id, Uri url, DeveloperAuthToken token, HashSet<IShapesPanel> panelCollection)
        {
            this.ID = ID;
            URL = url;
            DeveloperAuthToken = token;
            Panels = panelCollection;
        }

        public bool HasAuthToken()
        {
            return DeveloperAuthToken != null;
        }

        public override bool Equals(object obj)
        {
            var instance = obj as Shapes;
            if (instance == null)
                return false;
            
            return instance.URL == this.URL && instance.DeveloperAuthToken == this.DeveloperAuthToken && instance.ID == this.ID;
        }

        public override int GetHashCode()
        {
            int hashCode = -1842355318;
            hashCode = hashCode * -1521134295 + EqualityComparer<Uri>.Default.GetHashCode(URL);
            hashCode = hashCode * -1521134295 + EqualityComparer<DeveloperAuthToken>.Default.GetHashCode(DeveloperAuthToken);
            return hashCode;
        }
    }
}
