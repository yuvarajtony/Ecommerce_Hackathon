using System;
using System.Collections.Generic;

namespace Entity_Layer.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public string? CustomerEmail { get; set; }

    public string? OrderDate { get; set; }

    public string? DeliveryDate { get; set; }

    public string? ShipmentCity { get; set; }

    public int? ShipmentStatus { get; set; }

    public virtual CustomerDetail? CustomerEmailNavigation { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
