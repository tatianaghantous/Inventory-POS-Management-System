using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Account
{
    public int LoginId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? HashedPassword { get; set; }

    public bool? HasPermission { get; set; }

    public DateTime? LastConnection { get; set; }

    public int? BranchId { get; set; }

    public virtual ICollection<OrderSummary> OrderSummaries { get; set; } = new List<OrderSummary>();
}
