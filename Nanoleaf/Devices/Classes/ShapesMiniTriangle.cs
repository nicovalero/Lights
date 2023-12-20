using Nanoleaf.Devices.Enums;
using Nanoleaf.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    internal class ShapesMiniTriangle : IShapesPanel
    {
        private string panelID;
        private const ShapeType shapeType = ShapeType.ShapesMiniTriangle;
        private string panelO, panelX, panelY;

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
    }
}
