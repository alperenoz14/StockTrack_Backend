using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.ExternalRequests.ExternalrequestModels
{
    public class BodyOrganizations
    {
        public List<Organizations> Organizations { get; set; }      //property isimleri önemli! class ismi değil. //body diye bir sınıf daha olustur.
    }
}
