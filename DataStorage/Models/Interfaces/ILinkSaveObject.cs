﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Models.Interfaces
{
    public interface ILinkSaveObject
    {
        IMainLinkSaveObject MainLinksJson { get; }
        IHueLinkSaveObject PhilipsHueLinkSaveObject { get; }
        INanoleafLinkSaveObject NanoleafLinkSaveObject { get; }
        string SerializeToJSON();
    }
}
