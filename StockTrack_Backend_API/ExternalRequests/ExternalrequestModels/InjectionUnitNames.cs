using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.ExternalRequests.ExternalrequestModels
{
    public class InjectionUnitNames
    {
        public int id { get; set; }
        public string name { get; set; }
        public string eic { get; set; }
        public string organizationETSOCode { get; set; }
    }
}
