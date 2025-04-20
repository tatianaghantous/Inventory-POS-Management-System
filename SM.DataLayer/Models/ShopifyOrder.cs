using System;
using System.Collections.Generic;

namespace SM.DataLayer.Models;

public partial class ShopifyOrder
{
    public long OrderId { get; set; }

    public string? OrderNumber { get; set; }

    public long? ProductId { get; set; }

    public long? Quantity { get; set; }

    public long? CustomerId { get; set; }

    public long? BranchId { get; set; }

    public string? OrderDate { get; set; }

    public string? FulfillmentStatus { get; set; }

    public string? FinancialStatus { get; set; }

    public string? ShippingAddress { get; set; }

    public double? TotalPrice { get; set; }

    public string? Currency { get; set; }

    public string? Note { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
