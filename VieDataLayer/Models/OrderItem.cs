using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class OrderItem
{
    public long OrderItemId { get; set; }

    public long? ItemId { get; set; }

    public long? OrderId { get; set; }

    public string? Description { get; set; }

    public long? Quantity { get; set; }

    public double? PriceUsd { get; set; }

    public double? InitialCost { get; set; }

    public double? SalePrice { get; set; }

    public long IsPaid { get; set; }

    public double? UnitPriceAfterDiscount { get; set; }

    public long? DiscountedFromShopify { get; set; }

    public double? TotalPriceAfterDiscount { get; set; }

    public virtual Product? Item { get; set; }

    public virtual OrderSummary? Order { get; set; }
}
