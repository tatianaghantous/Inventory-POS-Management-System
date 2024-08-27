using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string BarcodeId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public int? CategoryId { get; set; }

    public decimal? SellingPrice { get; set; }

    public decimal? InitialPrice { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<ReviewsRating> ReviewsRatings { get; set; } = new List<ReviewsRating>();

    public virtual ICollection<ShopifyOrder> ShopifyOrders { get; set; } = new List<ShopifyOrder>();
}
