using Nanoleaf.Devices.Enums;
using Nanoleaf.Devices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    internal class ShapesPanel : IShapesPanel
    {
        private string shapeTypeString;
        private ShapeType shapeTypeEnum;

        [JsonProperty("panelId")]
        public string panelID;

        [JsonProperty("shapeType")]
        public string shapeType
        {
            get
            {
                return shapeTypeString;
            }
            set
            {
                shapeTypeString = value;
                shapeTypeEnum = (ShapeType)Convert.ToInt32(value);
            }
        }

        [JsonProperty("o")]
        public string panelO;

        [JsonProperty("x")]
        public string panelX;

        [JsonProperty("y")]
        public string panelY;

        public ShapesPanel(string panelID)
        {
            this.panelID = panelID;
        }

        public ShapesPanel(string panelID, string panelO, string panelX, string panelY)
        {
            this.panelID = panelID;
            this.panelO = panelO;
            this.panelX = panelX;
            this.panelY = panelY;
        }

        public string GetPanelID()
        {
            return panelID;
        }

        public string GetPanelO()
        {
            return panelO;
        }

        public string GetPanelX()
        {
            return panelX;
        }

        public string GetPanelY()
        {
            return panelY;
        }

        public ShapeType GetShapeType()
        {
            return shapeTypeEnum;
        }
    }
}
