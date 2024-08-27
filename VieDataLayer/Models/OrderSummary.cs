using System;
using System.Collections.Generic;

namespace SMDataLayer.Models;

public partial class OrderSummary
{
    public long OrderId { get; set; }

    public long? SellerId { get; set; }

    public long? BuyerId { get; set; }

    public long IsPaid { get; set; }

    public string? OrderDate { get; set; }

    public string? OrderDateTime { get; set; }

    public double? TotalInLbp { get; set; }

    public double? GainInLbp { get; set; }

    public double? TotalInUsd { get; set; }

    public double? GainInUsd { get; set; }

    public long? BranchId { get; set; }

    public double? TotalAfterDiscountInUsd { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Customer? Buyer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Account? Seller { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
