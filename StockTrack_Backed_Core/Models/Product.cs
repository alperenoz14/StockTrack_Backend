using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockTrack_Backed_Core.Models
{
    public class Product
    {

        public int ID { get; set; }

        public string Name { get; set; }
        
    }
}
