using System;
using System.Collections.Generic;

namespace ShopifyAPI.Models;

public partial class DailySale
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public decimal? StartingBalance { get; set; }

    public decimal? EndBalance { get; set; }

    public decimal? Profit { get; set; }

    public decimal? TotalSales { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }
}
