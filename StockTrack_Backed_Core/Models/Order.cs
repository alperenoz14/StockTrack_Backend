using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockTrack_Backed_Core.Models
{
    public class Order
    {
        public int ID { get; set; }
        public decimal UnitPrice { get; set; }
        public string DeliveryCompany { get; set; }
        public string DeliveryState { get; set; }
        public string DeliveryDate { get; set; }

        [ForeignKey("Plant")]
        public int PlantId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Plant Plant { get; set; }
        public Product Product { get; set; }

    }
}
