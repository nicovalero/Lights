using Nanoleaf.Devices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Interfaces
{
    public interface IShapesPanel
    {
        bool IsAmbience();
        bool IsColorCompatible();
        string GetPanelID();
        string GetPanelX();
        string GetPanelY();
        string GetPanelO();
        ShapeType GetShapeType();
    }
}
