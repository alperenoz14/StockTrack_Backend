using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.ExternalRequests.ExternalrequestModels
{
    public class Body
    {
        public List<Organizations> Organizations { get; set; }
        public List<InjectionUnitNames> InjectionUnitNames { get; set; }
    }
}
