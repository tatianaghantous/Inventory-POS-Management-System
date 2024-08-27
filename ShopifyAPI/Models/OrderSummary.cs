using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class OrderSummary
{
    public int OrderId { get; set; }

    public int SellerId { get; set; }

    public int? BuyerId { get; set; }

    public bool IsPaid { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? OrderDateTime { get; set; }

    public decimal? TotalInLbp { get; set; }

    public decimal? GainInLbp { get; set; }

    public decimal? TotalInUsd { get; set; }

    public decimal? GainInUsd { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Buyer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Account Seller { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
