using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.RequestAttributes
{
    public struct PaletteValues
    {
        [JsonProperty("hue")]
        public uint hue;

        [JsonProperty("saturation")]
        public uint saturation;

        [JsonProperty("brightness")]
        public uint brightness;
    }
    public class Palette
    {
        [JsonProperty]
        private PaletteValues[] PaletteValues
        {
            get
            {
                return PaletteValuesList.ToArray();
            }
            set
            {
                PaletteValuesList = value.ToList();
            }
        }

        [JsonIgnore]
        public List<PaletteValues> PaletteValuesList;

        [JsonConstructor]
        internal Palette()
        {
            PaletteValuesList = new List<PaletteValues>();
        }
        public Palette(List<PaletteValues> paletteValues)
        {
            PaletteValuesList = paletteValues;
        }

        public PaletteValues[] GetPaletteArray()
        {
            return PaletteValues;
        }
    }
}
