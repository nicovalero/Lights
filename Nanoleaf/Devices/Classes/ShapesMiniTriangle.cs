using Nanoleaf.Devices.Enums;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Network.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    internal class ShapesMiniTriangle : IShapesPanel
    {
        private string panelID;
        private const ShapeType shapeType = ShapeType.ShapesMiniTriangle;
        private string panelO, panelX, panelY;

        [JsonConstructor]
        public ShapesMiniTriangle() { }
        public ShapesMiniTriangle(string panelID, string panelO, string panelX, string panelY)
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
            return shapeType;
        }

        public override bool Equals(object obj)
        {
            var instance = obj as ShapesMiniTriangle;
            return instance.panelID == this.panelID && instance.GetShapeType() == this.GetShapeType();
        }

        public override int GetHashCode()
        {
            int hashCode = -1842355318;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(panelID);
            hashCode = hashCode * -1521134295 + EqualityComparer<ShapeType>.Default.GetHashCode(shapeType);
            return hashCode;
        }
    }
}
