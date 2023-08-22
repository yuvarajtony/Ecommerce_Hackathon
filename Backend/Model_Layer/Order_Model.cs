using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
    public class Order_Model
    {
        public int OrderId { get; set; }

        public string? CustomerEmail { get; set; }

        public string? OrderDate { get; set; }

        public string? DeliveryDate { get; set; }

        public string? ShipmentCity { get; set; }

        public int? ShipmentStatus { get; set; }
    }
}
