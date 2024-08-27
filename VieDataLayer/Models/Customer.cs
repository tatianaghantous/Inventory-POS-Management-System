using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string? Name { get; set; }

    public string? FamilyName { get; set; }

    public string? PhoneNumber { get; set; }

    public long DepartmentWorker { get; set; }

    public long? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<OrderSummary> OrderSummaries { get; set; } = new List<OrderSummary>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<ReviewsRating> ReviewsRatings { get; set; } = new List<ReviewsRating>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<ShopifyOrder> ShopifyOrders { get; set; } = new List<ShopifyOrder>();
}
