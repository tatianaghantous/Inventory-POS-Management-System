using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Branch
{
    public int BranchId { get; set; }

    public string? BranchName { get; set; }

    public string? Address { get; set; }

    public string? ContactInfo { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<DailySale> DailySales { get; set; } = new List<DailySale>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<OrderSummary> OrderSummaries { get; set; } = new List<OrderSummary>();

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<ReviewsRating> ReviewsRatings { get; set; } = new List<ReviewsRating>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<ShopifyOrder> ShopifyOrders { get; set; } = new List<ShopifyOrder>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
