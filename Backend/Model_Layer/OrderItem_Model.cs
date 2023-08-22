using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
    public class OrderItem_Model
    {
        public int OrderItemId { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public string? UnitPrice { get; set; }

        public string? TotalPrice { get; set; }
    }
}
