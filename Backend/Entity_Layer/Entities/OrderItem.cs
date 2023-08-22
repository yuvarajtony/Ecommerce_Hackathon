using System;
using System.Collections.Generic;

namespace Entity_Layer.Entities;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public string? UnitPrice { get; set; }

    public string? TotalPrice { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
