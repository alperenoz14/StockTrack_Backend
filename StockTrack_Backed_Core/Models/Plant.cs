using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockTrack_Backed_Core.Models
{
    public class Plant
    {

        public int ID { get; set; }
        public int PlantId { get; set; }

        public string Name { get; set; }

        public string EIC { get; set; }

        public string OrganizationETSOCode { get; set; }
        public List<Order> Orders { get; set; }
    }
}
