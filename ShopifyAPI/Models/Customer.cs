using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public string? FamilyName { get; set; }

    public string? PhoneNumber { get; set; }

    public bool DepartmentWorker { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<OrderSummary> OrderSummaries { get; set; } = new List<OrderSummary>();

    public virtual ICollection<ReviewsRating> ReviewsRatings { get; set; } = new List<ReviewsRating>();

    public virtual ICollection<ShopifyOrder> ShopifyOrders { get; set; } = new List<ShopifyOrder>();
}
