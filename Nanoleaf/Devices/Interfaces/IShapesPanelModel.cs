using Nanoleaf.Devices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Interfaces
{
    internal interface IShapesPanelModel
    {
        string GetPanelID();
        string GetPanelX();
        string GetPanelY();
        string GetPanelO();
        string GetShapeType();
    }
}
