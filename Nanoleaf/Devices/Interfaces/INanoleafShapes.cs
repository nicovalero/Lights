using Nanoleaf.Network.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Interfaces
{
    public interface INanoleafShapes
    {
        Uri URL { get; }
        DeveloperAuthToken DeveloperAuthToken { get; }
        HashSet<IShapesPanel> Panels { get; }
        bool HasAuthToken();
    }
}
