﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.ExternalRequests.ExternalrequestModels
{
    public class OrganizationResponse
    {
        public Body Body { get; set; }
        public int ResultCode { get; set; }
        public string ResultDescription { get; set; }
    }
}