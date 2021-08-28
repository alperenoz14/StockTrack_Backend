using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.ExternalRequests.ExternalrequestModels
{
    public class Organizations
    {
        public int organizationId { get; set; }
        public string organizationName { get; set; }
        public string organizationStatus { get; set; }
        public string organizationETSOCode { get; set; }
        public string organizationShortName { get; set; }
    }
}
