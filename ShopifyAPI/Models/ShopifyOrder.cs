using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class ShopifyOrder
{
    public int OrderId { get; set; }

    public string? OrderNumber { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? CustomerId { get; set; }

    public int? BranchId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? FulfillmentStatus { get; set; }

    public string? FinancialStatus { get; set; }

    public string? ShippingAddress { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Currency { get; set; }

    public string? Note { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
