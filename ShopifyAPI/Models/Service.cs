using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public decimal ServiceCost { get; set; }

    public decimal ServiceSellingPrice { get; set; }

    public string? ServiceType { get; set; }

    public DateTime? ServiceDate { get; set; }

    public decimal? ServiceProfit { get; set; }

    public bool? IsPaid { get; set; }

    public string? ServiceDuration { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
