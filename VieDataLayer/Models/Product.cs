using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Product
{
    public long ProductId { get; set; }

    public string BarcodeId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public long? CategoryId { get; set; }

    public double? SellingPrice { get; set; }

    public double? InitialPrice { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<ReviewsRating> ReviewsRatings { get; set; } = new List<ReviewsRating>();

    public virtual ICollection<ShopifyOrder> ShopifyOrders { get; set; } = new List<ShopifyOrder>();

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
}
