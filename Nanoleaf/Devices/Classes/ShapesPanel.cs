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

        [JsonProperty("shapeTypeEnum")]
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
            }
        }

        [JsonProperty("o")]
        public string panelO;

        [JsonProperty("x")]
        public string panelX;

        [JsonProperty("y")]
        public string panelY;

        [JsonConstructor]
        public ShapesPanel() { }

        public ShapesPanel(string panelID)
        {
            this.panelID = panelID;
        }

        public ShapesPanel(string panelID, string panelO, string panelX, string panelY, ShapeType shapeType)
        {
            this.panelID = panelID;
            this.panelO = panelO;
            this.panelX = panelX;
            this.panelY = panelY;
            this.shapeTypeEnum = shapeType;
            shapeTypeString = shapeType.ToString();
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

        public override bool Equals(object obj)
        {
            var instance = obj as ShapesPanel;
            return instance.panelID == this.panelID;
        }

        public override int GetHashCode()
        {
            int hashCode = -1842355318;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(panelID);
            return hashCode;
        }
    }
}
