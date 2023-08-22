using System;
using System.Collections.Generic;

namespace Entity_Layer.Entities;

public partial class CustomerDetail
{
    public string CustomerEmail { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? CustomerMobileNo { get; set; }

    public string? CustomerAddressLine1 { get; set; }

    public string? CustomerAddressLine2 { get; set; }

    public string? CustomerCity { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
