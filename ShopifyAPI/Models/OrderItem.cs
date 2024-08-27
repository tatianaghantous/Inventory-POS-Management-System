using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int ItemId { get; set; }

    public int OrderId { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public decimal? PriceUsd { get; set; }

    public decimal? InitialCost { get; set; }

    public decimal? SalePrice { get; set; }

    public bool IsPaid { get; set; }

    public decimal? PriceAfterDiscount { get; set; }

    public bool? DiscountedFromShopify { get; set; }

    public virtual Product Item { get; set; } = null!;

    public virtual OrderSummary Order { get; set; } = null!;
}
